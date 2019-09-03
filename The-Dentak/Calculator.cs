using System;

/// <summary>
/// 計算機クラス
/// </summary>
public class Calculator
{
    /// <summary>
    /// 一つ目の数
    /// </summary>
    private Number FirstNumber { get; }

    /// <summary>
    /// 二つ目の数
    /// </summary>
    private Number SecondNumber { get; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="firstNumber">計算する一つ目の数</param>
    /// <param name="secondNumber">計算する二つ目の数</param>
    /// <exception cref="InvalidFirstArgumentException">一つ目の引数が無効の場合</exception>
    /// <exception cref="InvalidSecondArgumentException">二つ目の引数が無効の場合</exception>
    public Calculator(string firstNumber, string secondNumber)
    {
        try
        {
            FirstNumber = new Number(firstNumber);
        }
        catch (ArgumentIsNotNumberException e)
        {
            throw new InvalidFirstArgumentException(firstNumber, e);
        }

        try
        {
            SecondNumber = new Number(secondNumber);
        }
        catch (ArgumentIsNotNumberException e)
        {
            throw new InvalidSecondArgumentException(secondNumber, e);
        }
    }

    /// <summary>
    /// 足し算を実行する。
    /// </summary>
    /// <exception cref="SumOverflowsException">計算時にオーバーフローした場合</exception>
    public int Add()
    {
        var sum = FirstNumber + SecondNumber;
        return sum.Value;
    }
}