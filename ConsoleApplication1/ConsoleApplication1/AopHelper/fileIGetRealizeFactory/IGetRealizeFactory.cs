using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.AopHelper.fileIGetRealizeFactory
{
    public interface IGetRealizeFactory
    {
        AopProxy1 GetRealizeFactory(Type type);
    }
}
