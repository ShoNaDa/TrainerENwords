using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TrainerENwords;

namespace TrainerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIsNumber()
        {
            string text = "1231";
            List<short> Numbers = new List<short>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //#1
            bool expected = true;
            bool actual = TrainerPage.IsNumber(text, Numbers);
            Assert.AreNotEqual(expected, actual);

            //#2
            text = "2";
            actual = TrainerPage.IsNumber(text, Numbers);
            Assert.AreEqual(expected, actual);

            //#3
            text = "b";
            actual = TrainerPage.IsNumber(text, Numbers);
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsRight()
        {
            string answer = "Кот";
            string word = "Кот";

            //#1
            bool expected = true;
            bool actual = TrainerPage.IsRight(answer, word);
            Assert.AreEqual(expected, actual);

            //#2
            answer = "Отец";
            actual = TrainerPage.IsRight(answer, word);
            Assert.AreNotEqual(expected, actual);

            //#3
            answer = "Между";
            word = "Первый";
            actual = TrainerPage.IsRight(answer, word);
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TestProcent()
        {
            int res = 10;

            //#1
            double expected = 100;
            EndPage endPage = new EndPage();
            double actual = endPage.Procent(res);
            Assert.AreEqual(expected, actual);

            //#2
            res = 3;
            expected = 30;
            actual = endPage.Procent(res);
            Assert.AreEqual(expected, actual);

            //#3
            res = 4;
            actual = endPage.Procent(res);
            Assert.AreNotEqual(expected, actual);
        }
    }
}
