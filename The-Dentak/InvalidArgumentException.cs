using System;

/// <summary>
/// 引数の文字列が数値形式でない場合にthrowされる例外
/// </summary>
[Serializable]
internal class ArgumentIsNotNumberException : Exception
{
    public ArgumentIsNotNumberException(string argument, Exception innerException) 
        : base($"{argument} is not a number.", innerException)
    {
    }
}