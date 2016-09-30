using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    //多态继承
    class Program
    {
  
        static void Main(string[] args)
        {
            //AInterface aInterface = new ClassC();
            //aInterface.fang1();

            //string str = "12kkkk3";
            //str = "123";
            //str = "123";
           
            //object obj = default(DateTime);

            //var dic = new Dictionary<string, string>();
            //dic.Add("1","A");
            //dic.Add("2","B");
            //dic.Add("3","C");

            ////foreach(var item in dic)
            ////{
            ////    string key =  item.Key;
            ////    string value = item.Value;
            ////}


            //ClassF classF = new ClassF();
            //classF.Hello("dd");

            //string str;
            //AopClass aopClass = new AopClass();

            //aopClass.Hello("ddgggg", out str);


            AopClass aopClass = new AopClass();
            aopClass.Say("ddpffffffffffffppp");
            aopClass.Hello();

        }
    }

    [AopAttribute(typeof(ConsoleApplication1.AopProxy.AopProxyBuilder))]
    public class AopClass : ContextBoundObject
    {

        public string Name
        {
            get;
            set;
        }

        public bool IsLock = true;
        public AopClass(string name)
        {
            Name = name;
            Console.WriteLine("Aop Class Create Name:" + Name);
        }

        public AopClass()
        {
            Console.WriteLine("Aop Class Create");
        }

        [MethodAopAdvice(AdviceType.Around)]
        public string Hello()
        {
            Console.WriteLine("hello world:");
            return "hello world:";
        }

        [MethodAopAdvice(AdviceType.Before)]
        public string Say(string content)
        {
            string c = "IsLock:" + IsLock + "\t " + Name + " :" + content;
            Console.WriteLine(c);
            return c;
        }
        public override string ToString()
        {
            return string.Format("Name:{0},IsLock:{1}", this.Name, this.IsLock);

        }

    }
}
