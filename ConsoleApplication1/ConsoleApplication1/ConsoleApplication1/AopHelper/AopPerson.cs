using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1.AopHelper
{
    public class AopPerson : AopProxy1Provider<Person> 
    {
        public AopPerson(Type serverType)
            : base(serverType) { }


        public void BeforeHello(string ni, out string ddd)
        {
            ddd = "rr";
            Console.Write("ddddddddddddddddddBeforeHello");
 
        }

        //输出设置
        public void AfterHello(object[] args, object returnValue, object[] OutRef)
        {
            
        }
    }
}
