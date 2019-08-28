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

            var expected = 3;

            var calculator = new Calculator(firstInput, secondInput);
            var actual = calculator.Add();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 一つ目の入力が数値でない場合のテスト
        /// </summary>
        [TestCategory("異常系")]
        [TestMethod]
        [ExpectedException(typeof(InvalidFirstArgumentException))]
        public void 一つ目の入力が数値でないときInvalidFirstArgumentExceptionが発生する()
        {
            var firstInput = "test";
            var secondInput = "2";

            var calculator = new Calculator(firstInput, secondInput);
            calculator.Add();
        }

        /// <summary>
        /// 二つ目の入力が数値でない場合のテスト
        /// </summary>
        [TestCategory("異常系")]
        [TestMethod]
        [ExpectedException(typeof(InvalidSecondArgumentException))]
        public void 二つ目の入力が数値でないときInvalidSecondArgumentExceptionが発生する()
        {
            var firstInput = "1";
            var secondInput = "test";

            var calculator = new Calculator(firstInput, secondInput);
            calculator.Add();
        }

        /// <summary>
        /// 計算結果がint型の最大値を上回る場合のテスト
        /// </summary>
        [TestCategory("異常系")]
        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void 計算結果がint型の最大値を上回ったときOverflowExceptionが発生する()
        {
            var firstInput = int.MaxValue.ToString();
            var secondInput = "1";

            var calculator = new Calculator(firstInput, secondInput);
            calculator.Add();
        }

        /// <summary>
        /// 計算結果がint型の最小値を下回る場合のテスト
        /// </summary>
        [TestCategory("異常系")]
        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void 計算結果がint型の最小値を下回ったときOverflowExceptionが発生する()
        {
            var firstInput = int.MinValue.ToString();
            var secondInput = "-1";

            var calculator = new Calculator(firstInput, secondInput);
            calculator.Add();
        }
    }
}
