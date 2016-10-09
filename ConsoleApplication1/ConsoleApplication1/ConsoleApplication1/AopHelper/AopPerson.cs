using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.AopHelper
{
    public class AopPerson : AopProxy1Provider<AopPerson> 
    {
        public AopPerson(Type serverType)
            : base(serverType) { }


        public void BeforeHello(string ni, out string ddd)
        {
            ddd = string.Empty;
        }

        //输出设置
        public void AfterHello(object[] args, object returnValue, object[] OutRef)
        {
            
        }
    }
}
