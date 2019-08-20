using System;

namespace The_Dentak
{
    /// <summary>
    /// エントリーポイントのクラス
    /// </summary>
    class Program
    {
        /// <summary>
        /// エントリーポイント
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Please input two number.");

            Console.Write("num1:");
            var firstInput = Console.ReadLine();
            Console.Write("num2:");
            var secondInput = Console.ReadLine();

            var calculator = new Calculator();
            int result;
            try
            {
                result = calculator.Add(firstInput, secondInput);
            } catch(Exception e)
            {
                Console.WriteLine("error");
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("success");
            Console.WriteLine($"{firstInput} + {secondInput} = {result}");
        }
    }
}
