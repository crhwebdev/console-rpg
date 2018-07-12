using System;

namespace ConsoleRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type 'q' to quit");
            Console.WriteLine("Type 'h' for help");
            Console.WriteLine("");
            while (true)
            {
                Console.Write("What shall we do? : ");
                string input = Console.ReadLine();

                if(input == "q")
                {
                    break;
                }

                if(input == "h")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Type 'q' to quit");
                    Console.WriteLine("Type 'h' for help");
                    Console.WriteLine("");
                }
            }
            
        }
    }
}
