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

    //public class AopAttribute : ProxyAttribute
    //{
    //    public override MarshalByRefObject CreateInstance(Type serverType)
    //    {
    //        AopProxy realProxy = new AopProxy(serverType);
    //        return realProxy.GetTransparentProxy() as MarshalByRefObject;
    //    }


    //}
    //public class AopProxy : RealProxy
    //{
    //    public AopProxy(Type serverType)
    //        : base(serverType) { }

    //    public override IMessage Invoke(IMessage msg)
    //    {
    //        if (msg is IConstructionCallMessage)
    //        {
    //            IConstructionCallMessage constructCallMsg = msg as IConstructionCallMessage;
    //            IConstructionReturnMessage constructionReturnMessage = this.InitializeServerObject((IConstructionCallMessage)msg);
    //            RealProxy.SetStubData(this, constructionReturnMessage.ReturnValue);  
    //            return constructionReturnMessage;
    //        }
    //        else
    //        {
    //            IMethodCallMessage callMsg = msg as IMethodCallMessage;
    //            IMessage message;
    //            try
    //            {
    //                object[] args = callMsg.Args;
    //                object o = callMsg.MethodBase.Invoke(GetUnwrappedServer(), args);
    //                message = new ReturnMessage(o, args, args.Length, callMsg.LogicalCallContext, callMsg);
    //            }
    //            catch (Exception e)
    //            {
    //                message = new ReturnMessage(e, callMsg);
    //            }
    //            return message;
    //        }
    //    }
    //}  
}
