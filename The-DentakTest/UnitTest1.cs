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
        /// ��ڂ̓��͂����l�łȂ��ꍇ�̃e�X�g
        /// </summary>
        [TestCategory("�ُ�n")]
        [TestMethod]
        public void ��ڂ̓��͂����l�łȂ�()
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
        /// ��ڂ̓��͂����l�łȂ��ꍇ�̃e�X�g
        /// </summary>
        [TestCategory("�ُ�n")]
        [TestMethod]
        public void ��ڂ̓��͂����l�łȂ�()
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
        /// �v�Z���ʂ�int�^�̍ő�l������ꍇ�̃e�X�g
        /// </summary>
        [TestCategory("�ُ�n")]
        [TestMethod]
        public void �v�Z���ʂ�int�^�̍ő�l������()
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
        /// �v�Z���ʂ�int�^�̍ŏ��l�������ꍇ�̃e�X�g
        /// </summary>
        [TestCategory("�ُ�n")]
        [TestMethod]
        public void �v�Z���ʂ�int�^�̍ŏ��l�������()
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
        /// �v�Z�����s����B
        /// </summary>
        /// <param name="input1">�W�����͂ɓ��͂����ڂ̕�����</param>
        /// <param name="input2">�W�����͂ɓ��͂����ڂ̕�����</param>
        /// <returns>�W���o�͂ɏo�͂��ꂽ������</returns>
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
