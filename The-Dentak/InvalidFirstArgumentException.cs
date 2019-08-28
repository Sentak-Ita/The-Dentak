using System;

/// <summary>
/// メソッドの第1引数に与えられた値が無効のときにthrowされる例外
/// </summary>
public class InvalidFirstArgumentException : Exception
{
    public InvalidFirstArgumentException(string message, Exception innerException) : base(message, innerException)
    {
    }
}