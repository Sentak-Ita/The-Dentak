using System;

namespace The_Dentak
{
    /// <summary>
    /// エントリーポイントのクラス
    /// </summary>
    class Program
    {
        /// <summary>
        /// エントリーポイント
        /// </summary>
        /// <param name="args">コマンドライン引数</param>
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            calculator.Execute();
        }
    }
}
