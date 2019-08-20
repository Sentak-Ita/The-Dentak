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
        /// テスト対象のオブジェクト
        /// </summary>
        private Calculator calclator = new Calculator();

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
            var actual = calclator.Add(firstInput, secondInput);

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

            try
            {
                calclator.Add(firstInput, secondInput);
            } catch(ArgumentException e)
            {
                StringAssert.Contains(e.Message, "test is not a number!!");
                return;
            }

            Assert.Fail("ArgumentExceptionが発生しなかった");
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

            try
            {
                calclator.Add(firstInput, secondInput);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, "test is not a number!!");
                return;
            }

            Assert.Fail("ArgumentExceptionが発生しなかった");
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

            try
            {
                calclator.Add(firstInput, secondInput);
            }
            catch (OverflowException)
            {
                return;
            }

            Assert.Fail("OverflowExceptionが発生しなかった");
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

            try
            {
                calclator.Add(firstInput, secondInput);
            }
            catch (OverflowException)
            {
                return;
            }

            Assert.Fail("OverflowExceptionが発生しなかった");
        }
    }
}
