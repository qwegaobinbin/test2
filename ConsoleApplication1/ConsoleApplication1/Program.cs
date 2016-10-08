using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    //多态继承
    class Program
    {
  
        static void Main(string[] args)
        {
          



            //AopClass1 aopClass = new AopClass1("d");
            //AopClass1.Say("ddpffffffffffffppp");
            //aopClass.Hello();


            //using (ZipOutputStream s = new ZipOutputStream(File.Create(@"F:\360Downloads\Software\3.zip")))
            //{
            //    s.SetLevel(6);  //设置压缩等级，等级越高压缩效果越明显，但占用CPU也会更多
            //    using (FileStream fs = File.OpenRead(@"F:\360Downloads\Software\3.txt"))
            //    {
            //        byte[] buffer = new byte[4 * 1024];  //缓冲区，每次操作大小
            //        ZipEntry entry = new ZipEntry(Path.GetFileName(@"改名.txt"));     //创建压缩包内的文件
            //        entry.DateTime = DateTime.Now;  //文件创建时间
            //        s.PutNextEntry(entry);          //将文件写入压缩包

            //        int sourceBytes;
            //        do
            //        {
            //            sourceBytes = s.Read(buffer, 0, buffer.Length);    //读取文件内容(1次读4M，写4M)
            //            s.Write(buffer, 0, sourceBytes);                    //将文件内容写入压缩相应的文件
            //        } while (sourceBytes > 0);
            //    }
            //    s.CloseEntry();
            //}

            Person person = new Person();
            person.Hello("ff");
            Console.ReadKey();
          







        }
        [AopAttribute1]
        public class Person : ContextBoundObject
        {
           
            public void Hello(string ni)
            {
                Console.Write("你电话");
            }
        
        }


        /// <summary>
        /// 压缩字节数组
        /// </summary>
        /// <param name="str"></param>
        public static byte[] Compress(byte[] inputBytes)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                using (GZipStream zipStream = new GZipStream(outStream, CompressionMode.Compress, true))
                {
                    zipStream.Write(inputBytes, 0, inputBytes.Length);
                    zipStream.Close(); //很重要，必须关闭，否则无法正确解压
                    return outStream.ToArray();
                }
            }
        }
    }

    [AopAttribute(typeof(ConsoleApplication1.AopProxy.AopProxyBuilder))]
    public class AopClass1 : ContextBoundObject
    {

        public string Name
        {
            get;
            set;
        }
       
        public bool IsLock = true;

    
        public AopClass1(string name)
        {
            Name = name;
            Console.WriteLine("Aop Class Create Name:" + Name);
        }
  
        public AopClass1()
        {
            Console.WriteLine("Aop Class Create");
        }

        [MethodAopAdvice(AdviceType.Around)]
        public string Hello()
        {
            //throw new ArgumentException("dd");
            Console.WriteLine("hello world:");
            return "hello world:";
        }

        [MethodAopAdvice(AdviceType.Before)]
        public static string Say(string content)
        {
            string c = "IsLock:" ;
            Console.WriteLine(c);
            return c;
        }
       
        public override string ToString()
        {
            return string.Format("Name:{0},IsLock:{1}", this.Name, this.IsLock);

        }

    }
}
