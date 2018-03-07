using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //4.1 
            Console.WriteLine(@"it is a design pattern to distinguish different functional or information sections, and address them in seperate concerns");
            //4.2 IoC
            Console.WriteLine(@"it is a design pattern to decouple components from each other by separating order of execution with the actual business rules being executed. like asp.net MVC");
            //4.3 DI
            Console.WriteLine(@"it is a design pattern to decouple components from each other by separating different functions into different classes, and use either constructor injection or setter injection to linke them and collaborate to work. which is good for code maintainance and reading");
            //4.4 SRP
            Console.WriteLine(@"it is a design principle that every class should have responsibility over a single part of the functionality provided by the software, and that responsibility should be entirely encapsulated by the class.");
        }
    }
}
