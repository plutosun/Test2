using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program p = new Program();
            p.q3_1();
            Console.ReadLine();
        }

        public void q3_1()
        {
            Singleton.Instance.PrintAnswer();
        }
        public void q3_2()
        {
            List<ICommand> cmdlist = new List<ICommand>();
            ValueObj obj = new ValueObj();
            cmdlist.Add(new AddOne(obj));
            cmdlist.Add(new AddFive(obj));
            cmdlist.Add(new AddTen(obj));
            obj.PrintAnswer();
        }
        public void q3_3()
        {
            List<ICommand> cmdlist = new List<ICommand>();
            ValueObj obj = new ValueObj();
            cmdlist.Add(new AddOne(obj));
            cmdlist.Add(new AddFive(obj));
            cmdlist.Add(new AddTen(obj));
            obj.PrintAnswer();
        }
        public void q3_4()
        {
            Fascade f = new Fascade();
            f.PrintAnswer();
        }
    }

    public interface IAnswer
    {
        void PrintAnswer();
    }
    #region Singleton
    public class Singleton : IAnswer
    {
        private Singleton() { }
        private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());
        public static Singleton Instance { get { return _instance.Value; } }
        public void PrintAnswer()
        {
            Console.WriteLine("Protected by System.Lazy<>, which is thread safe");
            Console.WriteLine("when you want your singleton class to be inherited and changed by external classes, or you want code can be testable");

        }
    }
    #endregion

    #region Command
    public class ValueObj : IAnswer
    {
        public int value { get; set; }

        public void PrintAnswer()
        {
            Console.WriteLine($"value is {value} ...  use Command pattern to add a work to a queue to run later rather than immediately run when calling");
        }
    }
    public interface ICommand
    {
        bool isCompleted { get; set; }
        void Execute();
    }
    public class AddOne : ICommand
    {
        private ValueObj _val;
        public bool isCompleted { get; set; }
        public AddOne(ValueObj value)
        {
            _val = value;
        }
        public void Execute()
        {
            _val.value += 1;
        }
    }

    public class AddFive : ICommand
    {
        private ValueObj _val;
        public bool isCompleted { get; set; }
        public AddFive(ValueObj value)
        {
            _val = value;
        }
        public void Execute()
        {
            _val.value += 5;
        }
    }

    public class AddTen : ICommand
    {
        private ValueObj _val;
        public bool isCompleted { get; set; }
        public AddTen(ValueObj value)
        {
            _val = value;
        }
        public void Execute()
        {
            _val.value += 10;
        }
    }
    #endregion

    #region Facade
    public class DoSth1
    {
        public void Do (){}
}
    public class DoSth2
    {
        public void Do() { }
    }
    public class DoSth3
    {
        public void Do() { }
    }

    public class Fascade : IAnswer
    {
        DoSth1 s1; DoSth2 s2; DoSth3 s3;
        public Fascade()
        {
            s1 = new DoSth1();
            s2 = new DoSth2();
            s3 = new DoSth3();
        }
       public void DoSthOneByOne()
        {
            s1.Do();
            s2.Do();
            s3.Do();
        }

        public void PrintAnswer()
        {
            Console.WriteLine("Samilar as gateway pattern, expose a customer-oriented business domain funciton interface, and evelop detailed and complex series of internal api calls. which makes the interface and client-sdie code is much clean and easy to understand.");
        }
    }
    #endregion

}