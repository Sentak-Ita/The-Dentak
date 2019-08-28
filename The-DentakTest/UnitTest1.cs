using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace The_DentakTest
{
    /// <summary>
    /// Calculator�N���X�̃e�X�g
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// ���s�R�[�h
        /// </summary>
        private readonly string NEW_LINE = Environment.NewLine;

        /// <summary>
        /// ��̓��͂������Ƃ����l�ł���ꍇ�̃e�X�g
        /// </summary>
        [TestCategory("����n")]
        [TestMethod]
        public void ��̓��͂������Ƃ����l�ł���()
        {
            var firstInput = "1";
            var secondInput = "2";

            var expected = 3;

            var calculator = new Calculator(firstInput, secondInput);
            var actual = calculator.Add();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// ��ڂ̓��͂����l�łȂ��ꍇ�̃e�X�g
        /// </summary>
        [TestCategory("�ُ�n")]
        [TestMethod]
        [ExpectedException(typeof(InvalidFirstArgumentException))]
        public void ��ڂ̓��͂����l�łȂ��Ƃ�InvalidFirstArgumentException����������()
        {
            var firstInput = "test";
            var secondInput = "2";

            var calculator = new Calculator(firstInput, secondInput);
            calculator.Add();
        }

        /// <summary>
        /// ��ڂ̓��͂����l�łȂ��ꍇ�̃e�X�g
        /// </summary>
        [TestCategory("�ُ�n")]
        [TestMethod]
        [ExpectedException(typeof(InvalidSecondArgumentException))]
        public void ��ڂ̓��͂����l�łȂ��Ƃ�InvalidSecondArgumentException����������()
        {
            var firstInput = "1";
            var secondInput = "test";

            var calculator = new Calculator(firstInput, secondInput);
            calculator.Add();
        }

        /// <summary>
        /// �v�Z���ʂ�int�^�̍ő�l������ꍇ�̃e�X�g
        /// </summary>
        [TestCategory("�ُ�n")]
        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void �v�Z���ʂ�int�^�̍ő�l���������Ƃ�OverflowException����������()
        {
            var firstInput = int.MaxValue.ToString();
            var secondInput = "1";

            var calculator = new Calculator(firstInput, secondInput);
            calculator.Add();
        }

        /// <summary>
        /// �v�Z���ʂ�int�^�̍ŏ��l�������ꍇ�̃e�X�g
        /// </summary>
        [TestCategory("�ُ�n")]
        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void �v�Z���ʂ�int�^�̍ŏ��l����������Ƃ�OverflowException����������()
        {
            var firstInput = int.MinValue.ToString();
            var secondInput = "-1";

            var calculator = new Calculator(firstInput, secondInput);
            calculator.Add();
        }
    }
}
