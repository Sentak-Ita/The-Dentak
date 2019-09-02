using System;

/// <summary>
/// 数値クラス
/// </summary>
public class Number
{
    /// <summary>
    /// 値
    /// </summary>
    public int Value { get; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="value">数値</param>
    private Number(int value)
    {
        Value = value;
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="valueString">数値を表す文字列</param>
    /// <exception cref="ArgumentException">数値への変換に失敗した場合</exception>
    public Number(string valueString)
    {
        try
        {
            Value = int.Parse(valueString);
        } catch (Exception e)
        {
            throw new ArgumentException($"{valueString} is not a number.", e);
        }
    }

    /// <summary>
    /// 二つNumberオブジェクトの和を求める
    /// </summary>
    /// <param name="augend">足される数</param>
    /// <param name="addend">足す数</param>
    /// <returns>二つの数値の和を表すNumberオブジェクト</returns>
    /// <exception cref="OverflowException">足し算でオーバーフローが発生した場合</exception>
    public static Number operator+(Number augend, Number addend)
    {
        var sumValue = checked(augend.Value + addend.Value);
        var sum = new Number(sumValue);
        return sum;
    }
}