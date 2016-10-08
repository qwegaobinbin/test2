
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
      public class AopAttribute : ProxyAttribute
      {
         private AopProxy.IAopProxyBuilder builder=null;
         public AopAttribute(Type builderType)
         {
            this.builder = (ConsoleApplication1.AopProxy.IAopProxyBuilder)Activator.CreateInstance(builderType);
         }
  
         public override MarshalByRefObject CreateInstance(Type serverType)
         {
             AopProxy realProxy = new AopProxy(serverType);
             return realProxy.GetTransparentProxy() as MarshalByRefObject;
         } 

     }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
      public class MethodAopAdviceAttribute : Attribute
      {
  
          private AdviceType type=AdviceType.None;
          public MethodAopAdviceAttribute(AdviceType advicetype)
          {
             this.type = advicetype;
         }

         public AdviceType AdviceType
         {
             get
            {
                 return this.type;
             }
         }
     }
 
     public enum AdviceType
     {
         None,
         Before,
         After,
         Around
     }



     partial interface IAopAction
       {
           void PreProcess(IMessage requestMsg);
           void PostProcess(IMessage requestMsg, IMessage Respond);
       }
     public class AopProxy : RealProxy, IAopAction
     {
         public AopProxy(Type serverType)
             : base(serverType)
         {
         }
         public virtual void PreProcess(object obj, string method = "", int argCount = 0, object[] args = null)
         {
             var o = obj as AopClass1;
             if (o != null)
             {
                 o.IsLock = false;
                 o.Name = "999999";
             }
         }

         public virtual void PreProcess(IMessage requestMsg)
         {
             var o = GetUnwrappedServer();
             IMethodCallMessage call = requestMsg as IMethodCallMessage;
             if (call != null)
             {
                 this.PreProcess(o, call.MethodName, call.InArgCount, call.Args);
             }
             else
             {
                 this.PreProcess(o);
             }

         }

         public virtual void PostProcess(object obj, object returnValue = null, string method = "", int argCount = 0, object[] args = null)
         {
             var o = obj as AopClass1;
             if (o != null)
             {
                 o.IsLock = true;
                 o.Name = "10101010";
             }


         }
         public virtual void PostProcess(IMessage requestMsg, IMessage Respond)
         {
             var o = GetUnwrappedServer();
             ReturnMessage mm = Respond as ReturnMessage;
             var ret = mm.ReturnValue;
             IMethodCallMessage call = requestMsg as IMethodCallMessage;
             if (call != null)
             {
                 this.PostProcess(o, ret, call.MethodName, call.InArgCount, call.Args);
             }
             else
             {
                 this.PostProcess(o, ret);
             }
         }


         public virtual IMessage Proessed(IMessage msg)
         {
             IMessage message;
             if (msg is IConstructionCallMessage)
             {
                 message = this.ProcessConstruct(msg);
             }
             else
             {
                 message = this.ProcessInvoke(msg);
             }
             return message;
         }
         public virtual void ChangeReturnValue(IMessage msg, ref object o)
         {
             if (msg is IMethodCallMessage)
             {
                 var m = msg as IMethodCallMessage;
                 string name = m.MethodName;
                 if (name == "Hello")
                     o = "Hello,Lucy!";
             }
         }
         public virtual IMessage ProcessInvoke(IMessage msg)
         {
             IMethodCallMessage callMsg = msg as IMethodCallMessage;
             IMessage message;
             try
             {
                 object[] args = callMsg.Args;   //方法参数                 
                 object o = callMsg.MethodBase.Invoke(GetUnwrappedServer(), args);  //调用 原型类的 方法       
                 //ChangeReturnValue(msg, ref o);
                 message = new ReturnMessage(o, args, args.Length, callMsg.LogicalCallContext, callMsg);   // 返回类型 Message
             }
             catch (Exception e)
             {
                 message = new ReturnMessage(e, callMsg);
             }

             //Console.WriteLine("Call Method:"+callMsg.MethodName);
             //Console.WriteLine("Return:"+ message.Properties["__Return"].ToString());
             return message;
         }
         public virtual IMessage ProcessConstruct(IMessage msg)
         {
             IConstructionCallMessage constructCallMsg = msg as IConstructionCallMessage;
             //构造函数 初始化
             IConstructionReturnMessage constructionReturnMessage = this.InitializeServerObject((IConstructionCallMessage)msg);
             RealProxy.SetStubData(this, constructionReturnMessage.ReturnValue);

             //Console.WriteLine("Call constructor:"+constructCallMsg.MethodName);
             //Console.WriteLine("Call constructor arg count:"+constructCallMsg.ArgCount);

             return constructionReturnMessage;
         }

         public override IMessage Invoke(IMessage msg)
         {

             #region  获取AdviceType
             AdviceType type = AdviceType.None;
             IMethodCallMessage call = (IMethodCallMessage)msg;

             var CallType = call.MethodBase.GetCustomAttributes(typeof(MethodAopAdviceAttribute), false);


             foreach (Attribute attr in CallType)
             {
                 MethodAopAdviceAttribute mehodAopAttr = attr as MethodAopAdviceAttribute;
                 if (mehodAopAttr != null)
                 {
                     type = mehodAopAttr.AdviceType;
                     break;
                 }
             }
             #endregion

             IMessage message;

             if (type == AdviceType.Before || type == AdviceType.Around)
             {
                 this.PreProcess(msg);
                 Console.WriteLine("::Before Or Around");
             }

             message = this.Proessed(msg);

             if (type == AdviceType.After || type == AdviceType.Around)
             {
                 this.PostProcess(msg, message);
                 Console.WriteLine("::After Or Around");
             }

             return message;

         }



         public interface IAopProxyBuilder
         {
             AopProxy CreateAopProxyInstance(Type type);
         }

         public class AopProxyBuilder : IAopProxyBuilder
         {
             public AopProxy CreateAopProxyInstance(Type type)
             {
                 return new AopProxy(type);

             }
         }
     }


   
     
}
