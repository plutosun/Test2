using System;

namespace PrintNumber
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program p = new Program();
            p.print(1,100);
            Console.ReadLine();
        }

        public void print(int start, int end)
        {
            if (start > end)
                throw new ApplicationException("start should be smaller than end");
            for(int i=start;i<=end;i++)
            {
                Console.WriteLine(getline(i));
            }
        }

        public string getline(int i)
        {
            string ansible = i % 3 == 0 ? " Ansible" : "";
            string australia = i % 5 == 0 ? " Australia" : "";
            return $"{i}{ansible}{australia}";
        }
    }
}
