using System;

/// <summary>
/// 計算機クラス
/// </summary>
public class Calculator
{
    /// <summary>
    /// 計算を実行する。
    /// 数値を二つ受け取り、足した結果を出力する。
    /// 数値以外の文字列を受け取った場合、処理を終了する。
    /// </summary>
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

        var sum = Add(num1, num2);

        Console.WriteLine($"{num1} + {num2} = {sum}");
    }

    /// <summary>
    /// 二つの数値を足す。
    /// </summary>
    /// <param name="num1">数値</param>
    /// <param name="num2">数値</param>
    /// <returns>二つの数値の和</returns>
    public int Add(int num1, int num2)
    {
        return num1 + num2;
    }
}