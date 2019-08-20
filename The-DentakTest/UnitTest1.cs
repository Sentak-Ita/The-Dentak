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
        /// �e�X�g�Ώۂ̃I�u�W�F�N�g
        /// </summary>
        private Calculator calclator = new Calculator();

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
            var actual = calclator.Add(firstInput, secondInput);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// ��ڂ̓��͂����l�łȂ��ꍇ�̃e�X�g
        /// </summary>
        [TestCategory("�ُ�n")]
        [TestMethod]
        public void ��ڂ̓��͂����l�łȂ�()
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

            Assert.Fail("ArgumentException���������Ȃ�����");
        }

        /// <summary>
        /// ��ڂ̓��͂����l�łȂ��ꍇ�̃e�X�g
        /// </summary>
        [TestCategory("�ُ�n")]
        [TestMethod]
        public void ��ڂ̓��͂����l�łȂ�()
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

            Assert.Fail("ArgumentException���������Ȃ�����");
        }

        /// <summary>
        /// �v�Z���ʂ�int�^�̍ő�l������ꍇ�̃e�X�g
        /// </summary>
        [TestCategory("�ُ�n")]
        [TestMethod]
        public void �v�Z���ʂ�int�^�̍ő�l������()
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

            Assert.Fail("OverflowException���������Ȃ�����");
        }

        /// <summary>
        /// �v�Z���ʂ�int�^�̍ŏ��l�������ꍇ�̃e�X�g
        /// </summary>
        [TestCategory("�ُ�n")]
        [TestMethod]
        public void �v�Z���ʂ�int�^�̍ŏ��l�������()
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

            Assert.Fail("OverflowException���������Ȃ�����");
        }
    }
}
