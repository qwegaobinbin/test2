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
        protected override void BeforeProcessLogic(object[] args)
        {
            string str = args[0].ToString();
        }
    }
}
