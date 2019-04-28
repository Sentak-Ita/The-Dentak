using System;

class Calculator
{
    public void Execute()
    {
        Console.WriteLine("Please input two number.");

        Console.Write("num1:");
        var firstInputString = Console.ReadLine();
        if(!int.TryParse(firstInputString, out var num1))
        {
            Console.WriteLine($"{firstInputString} is not a number!!");
            return;
        }
        
        Console.Write("num2:");
        var secondInputString = Console.ReadLine();
        if(!int.TryParse(secondInputString, out var num2))
        {
            Console.WriteLine($"{secondInputString} is not a number!!");
            return;
        }

        var sum = add(num1, num2);

        Console.WriteLine($"{num1} + {num2} = {sum}");
    }

    public int add(int num1, int num2)
    {
        return num1 + num2;
    }
}