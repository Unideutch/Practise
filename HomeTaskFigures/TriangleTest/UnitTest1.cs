using NUnit.Framework;
using figures;
using System;

namespace SquareTest
{
    public class Tests
    {
        [SetUp]
        public void MainLine_ValidData_NoExeption()
        {

        }

        [Test]
        public void MainLine_WrongData_Exeption()
        {
            Assert.Pass();
        }
    }
}