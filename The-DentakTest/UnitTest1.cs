using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace The_DentakTest
{
    /// <summary>
    /// Calculatorクラスのテスト
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// 改行コード
        /// </summary>
        private readonly string NEW_LINE = Environment.NewLine;

        /// <summary>
        /// 二つの入力が両方とも数値である場合のテスト
        /// </summary>
        [TestCategory("正常系")]
        [TestMethod]
        public void 二つの入力が両方とも数値である()
        {
            var firstInput = "1";
            var secondInput = "2";
            var sum = "3";

            var expected = $"Please input two number.{NEW_LINE}" +
                           $"num1:" +
                           $"num2:" +
                           $"success{NEW_LINE}" +
                           $"{firstInput} + {secondInput} = {sum}{NEW_LINE}";

            var actual = ExecuteCalculator(firstInput, secondInput);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 一つ目の入力が数値でない場合のテスト
        /// </summary>
        [TestCategory("異常系")]
        [TestMethod]
        public void 一つ目の入力が数値でない()
        {
            var firstInput = "test";
            var secondInput = "2";

            var expected = $"Please input two number.{NEW_LINE}" +
                           $"num1:" +
                           $"error{NEW_LINE}" +
                           $"{firstInput} is not a number!!{NEW_LINE}";

            var actual = ExecuteCalculator(firstInput, secondInput);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 二つ目の入力が数値でない場合のテスト
        /// </summary>
        [TestCategory("異常系")]
        [TestMethod]
        public void 二つ目の入力が数値でない()
        {
            var firstInput = "1";
            var secondInput = "test";

            var expected = $"Please input two number.{NEW_LINE}" +
                           $"num1:" +
                           $"num2:" +
                           $"error{NEW_LINE}" +
                           $"{secondInput} is not a number!!{NEW_LINE}";

            var actual = ExecuteCalculator(firstInput, secondInput);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 計算結果がint型の最大値を上回る場合のテスト
        /// </summary>
        [TestCategory("異常系")]
        [TestMethod]
        public void 計算結果がint型の最大値を上回る()
        {
            var firstInput = int.MaxValue.ToString();
            var secondInput = "1";

            var sum = int.MinValue.ToString(); // overflow

            var expected = $"Please input two number.{NEW_LINE}" +
                           $"num1:" +
                           $"num2:" +
                           $"error{NEW_LINE}";

            var actual = ExecuteCalculator(firstInput, secondInput);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 計算結果がint型の最小値を下回る場合のテスト
        /// </summary>
        [TestCategory("異常系")]
        [TestMethod]
        public void 計算結果がint型の最小値を下回る()
        {
            var firstInput = int.MinValue.ToString();
            var secondInput = "-1";

            var sum = int.MaxValue.ToString(); // overflow

            var expected = $"Please input two number.{NEW_LINE}" +
                           $"num1:" +
                           $"num2:" +
                           $"error{NEW_LINE}";

            var actual = ExecuteCalculator(firstInput, secondInput);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 計算を実行する。
        /// </summary>
        /// <param name="input1">標準入力に入力する一つ目の文字列</param>
        /// <param name="input2">標準入力に入力する二つ目の文字列</param>
        /// <returns>標準出力に出力された文字列</returns>
        private string ExecuteCalculator(string input1, string input2)
        {
            var stdInput = new StringReader($"{input1}{NEW_LINE}{input2}{NEW_LINE}");
            Console.SetIn(stdInput);

            var stdOutput = new StreamWriter(new MemoryStream());
            Console.SetOut(stdOutput);

            var calclator = new Calculator();
            calclator.Execute();

            stdOutput.Flush();
            stdOutput.BaseStream.Seek(0, SeekOrigin.Begin);
            var stdOutputReader = new StreamReader(stdOutput.BaseStream);
            var result = stdOutputReader.ReadToEnd();

            return result;
        }
    }
}
