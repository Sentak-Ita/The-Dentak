using System;

namespace The_Dentak
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input two number.");

            Console.Write("num1:");
            var firstInputString = Console.ReadLine();
            if(!int.TryParse(firstInputString, out int num1))
            {
                Console.WriteLine($"{firstInputString} is not a number!!");
                return;
            }
            
            Console.Write("num2:");
            var secondInputString = Console.ReadLine();
            if(!int.TryParse(secondInputString, out int num2))
            {
                Console.WriteLine($"{secondInputString} is not a number!!");
                return;
            }

            var sum = num1 + num2;
            Console.WriteLine($"{num1} + {num2} = {sum}");
        }
    }
}
