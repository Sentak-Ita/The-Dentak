using System;

/// <summary>
/// 計算機クラス
/// </summary>
public class Calculator
{
    /// <summary>
    /// 計算を実行する。
    /// 数値を表す文字列を二つ受け取り、足した結果を返す。
    /// </summary>
    /// <exception cref="ArgumentException">数値以外の文字列を受け取った場合</exception>
    /// <exception cref="OverflowException">計算時にオーバーフローした場合</exception>
    public int Add(string firstInput, string secondInput)
    {
        if(!int.TryParse(firstInput, out var firstNumber))
        {
            throw new ArgumentException($"{firstInput} is not a number!!");
        }
        
        if(!int.TryParse(secondInput, out var secondNumber))
        {
            throw new ArgumentException($"{secondInput} is not a number!!");
        }

        var sum = checked(firstNumber + secondNumber);
        return sum;
    }
}