using Newtonsoft.Json;
using System;
using webapiProxy;

namespace client
{
    class Program
    {
        Proxy proxy = new Proxy("http://localhost:55198/");
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program p = new Program();
            p.test();
            Console.ReadLine();
        }

        public void test()
        {
            proxy.PostAsync(new webapiProxy.DataContracts.Entity { Id = 1, Name = "test", Weight = 120 });
            proxy.PostAsync(new webapiProxy.DataContracts.Entity { Id = 2, Name = "test2", Weight = 121 });
            proxy.PostAsync(new webapiProxy.DataContracts.Entity { Id = 3, Name = "test3", Weight = 122 });

            var entlist = proxy.GetAllAsync().Result;
            var ent = proxy.GetAsync(1).Result;
            Console.WriteLine(JsonConvert.SerializeObject(entlist));
            Console.WriteLine("******************");
            Console.WriteLine(JsonConvert.SerializeObject(ent));
        }
    }
}
