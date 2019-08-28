using System;

/// <summary>
/// 計算機クラス
/// </summary>
public class Calculator
{
    /// <summary>
    /// 一つ目の数
    /// </summary>
    private readonly Number firstNumber;

    /// <summary>
    /// 二つ目の数
    /// </summary>
    private readonly Number secondNumber;

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
            this.firstNumber = new Number(firstNumber);
        }
        catch (ArgumentException e)
        {
            throw new InvalidFirstArgumentException($"first number {firstNumber} is invalid", e);
        }

        try
        {
            this.secondNumber = new Number(secondNumber);
        }
        catch (ArgumentException e)
        {
            throw new InvalidSecondArgumentException($"second number {secondNumber} is invalid", e);
        }
    }

    /// <summary>
    /// 足し算を実行する。
    /// </summary>
    /// <exception cref="OverflowException">計算時にオーバーフローした場合</exception>
    public int Add()
    {
        var sum = firstNumber + secondNumber;
        return sum.Value;
    }
}