using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.AopHelper
{
    public abstract class AopProxy1Provider<T> : AopProxy1 where T:class
    {

        public  AopProxy1Provider(Type serverType)
            : base(serverType) { }
        protected override void BeforeProcess(object[] args)
        {
            BeforeProcessLogic(args);
        }

        protected abstract void BeforeProcessLogic(object[] args);
        protected override void AfterProcess(object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
