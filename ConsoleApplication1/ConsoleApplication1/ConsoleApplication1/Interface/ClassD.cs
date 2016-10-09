using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ClassD
    {
        public string str = "ddd";
        public virtual string Hello(string str,out string st)
        {
            st = "ddd";
            return str;
        }
    }
}
