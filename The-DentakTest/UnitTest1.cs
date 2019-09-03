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
        /// ��̓��͂������Ƃ����l�ł���ꍇ�̃e�X�g
        /// </summary>
        [TestCategory("����n")]
        [DataTestMethod]
        [DataRow("1", "2", 3)]
        [DataRow( "2147483646",  "1",  2147483647)] // �����Z�������ʂ�int�^�̍ő�l
        [DataRow("-2147483647", "-1", -2147483648)] // �����Z�������ʂ�int�^�̍ŏ��l
        public void ��̓��͂������Ƃ����l�ł���(string firstInput, string secondInput, int expected)
        {
            var calculator = new Calculator(firstInput, secondInput);
            var actual = calculator.Add();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// ��ڂ̓��͂����l�łȂ��ꍇ�̃e�X�g
        /// </summary>
        [TestCategory("�ُ�n")]
        [DataTestMethod]
        [DataRow("test", "2")]
        public void ��ڂ̓��͂����l�łȂ��Ƃ�InvalidFirstArgumentException����������(string firstInput, string secondInput)
        {
            Assert.ThrowsException<InvalidFirstArgumentException>(()=> new Calculator(firstInput, secondInput));
        }

        /// <summary>
        /// ��ڂ̓��͂����l�łȂ��ꍇ�̃e�X�g
        /// </summary>
        [TestCategory("�ُ�n")]
        [DataTestMethod]
        [DataRow("1", "test")]
        public void ��ڂ̓��͂����l�łȂ��Ƃ�InvalidSecondArgumentException����������(string firstInput, string secondInput)
        {
            Assert.ThrowsException<InvalidSecondArgumentException>(() => new Calculator(firstInput, secondInput));
        }

        /// <summary>
        /// �I�[�o�[�t���[�̌��m
        /// </summary>
        [TestCategory("�ُ�n")]
        [DataTestMethod]
        [DataRow("2147483647" , "1")]
        [DataRow("-2147483648", "-1")]
        public void �v�Z���ɃI�[�o�[�t���[�����������ꍇOverflowException��throw�����(string firstInput, string secondInput)
        {
            var calculator = new Calculator(firstInput, secondInput);
            Assert.ThrowsException<SumOverflowsException>(() => calculator.Add());
        }
    }
}
