using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using taxcoin.Helpers;

namespace UnitTests
{
    [TestClass]
    public class UnitTest_Datareader
    {
        [TestMethod]
        public void Test_ExistingFile()
        {
            // Arrange
            int[] outputExisting = Datareader.ReadDataFromLocalFile("sampleInput.txt");

            // Assert
            Assert.IsNotNull(outputExisting);
        }

        [TestMethod]
        public void Test_Template()
        {
            // Arrange

            // Act

            // Assert

        }
    }
}
