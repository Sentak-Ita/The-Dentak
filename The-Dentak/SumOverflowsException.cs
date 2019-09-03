using System;

/// <summary>
/// 足し算の合計がオーバーフローした場合にthrowされる例外
/// </summary>
[Serializable]
public class SumOverflowsException : Exception
{
    public SumOverflowsException(int value1, int value2, OverflowException e)
        : base($"{value1} + {value2} occured overflow.", e)
    {
    }
}