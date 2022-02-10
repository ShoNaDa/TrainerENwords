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
            List<short> Numbers = new List<short>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //#1
            Assert.AreNotEqual(true, TrainerPage.IsNumber("1231", Numbers));

            //#2
            Assert.AreEqual(true, TrainerPage.IsNumber("2", Numbers));

            //#3
            Assert.AreNotEqual(true, TrainerPage.IsNumber("b", Numbers));

            //#4
            Assert.AreEqual(true, TrainerPage.IsNumber("10", Numbers));
        }

        [TestMethod]
        public void TestIsRight()
        {
            //#1
            Assert.AreEqual(true, TrainerPage.IsRight("Кот", "Кот"));

            //#2
            Assert.AreNotEqual(true, TrainerPage.IsRight("Отец", "Кот"));

            //#3
            Assert.AreNotEqual(true, TrainerPage.IsRight("Между", "Первый"));

            //#4
            Assert.AreEqual(true, TrainerPage.IsRight("Отец", "Отец"));
        }

        [TestMethod]
        public void TestProcent()
        {
            //#1
            Assert.AreEqual(100, EndPage.Procent(10));

            //#2
            Assert.AreEqual(30, EndPage.Procent(3));

            //#3
            Assert.AreNotEqual(30, EndPage.Procent(4));

            //#4
            Assert.AreNotEqual(10, EndPage.Procent(7));
        }
    }
}