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
        /// 二つの入力が両方とも数値である場合のテスト
        /// </summary>
        [TestCategory("正常系")]
        [DataTestMethod]
        [DataRow("1", "2", 3)]
        [DataRow( "2147483646",  "1",  2147483647)] // 足し算した結果がint型の最大値
        [DataRow("-2147483647", "-1", -2147483648)] // 足し算した結果がint型の最小値
        public void 二つの入力が両方とも数値である(string firstInput, string secondInput, int expected)
        {
            var calculator = new Calculator(firstInput, secondInput);
            var actual = calculator.Add();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 一つ目の入力が数値でない場合のテスト
        /// </summary>
        [TestCategory("異常系")]
        [DataTestMethod]
        [DataRow("test", "2")]
        public void 一つ目の入力が数値でないときInvalidFirstArgumentExceptionが発生する(string firstInput, string secondInput)
        {
            Assert.ThrowsException<InvalidFirstArgumentException>(()=> new Calculator(firstInput, secondInput));
        }

        /// <summary>
        /// 二つ目の入力が数値でない場合のテスト
        /// </summary>
        [TestCategory("異常系")]
        [DataTestMethod]
        [DataRow("1", "test")]
        public void 二つ目の入力が数値でないときInvalidSecondArgumentExceptionが発生する(string firstInput, string secondInput)
        {
            Assert.ThrowsException<InvalidSecondArgumentException>(() => new Calculator(firstInput, secondInput));
        }

        /// <summary>
        /// オーバーフローの検知
        /// </summary>
        [TestCategory("異常系")]
        [DataTestMethod]
        [DataRow("2147483647" , "1")]
        [DataRow("-2147483648", "-1")]
        public void 計算時にオーバーフローが発生した場合OverflowExceptionがthrowされる(string firstInput, string secondInput)
        {
            var calculator = new Calculator(firstInput, secondInput);
            Assert.ThrowsException<SumOverflowsException>(() => calculator.Add());
        }
    }
}
