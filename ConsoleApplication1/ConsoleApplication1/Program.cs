using System;
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
            AInterface aInterface = new ClassC();
            aInterface.fang1();
            string str1= "text3fff";
            string str = "text3";

            str = "123hh";
            str = "123hhh";
            str = "123ggg";
            str = "123hhh";
            str = "123hh";

            str = "123";
            str = "123";
            str = "12355gggg5";
            str = "123";
            str = "123";

            str = "123";

        }
    }
}
