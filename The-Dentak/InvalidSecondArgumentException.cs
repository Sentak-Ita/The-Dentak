﻿using System;

/// <summary>
/// メソッドの第2引数に与えられた値が無効のときにthrowされる例外
/// </summary>
public class InvalidSecondArgumentException : Exception
{
    public InvalidSecondArgumentException(string message, Exception innerException) : base(message, innerException)
    {
    }
}