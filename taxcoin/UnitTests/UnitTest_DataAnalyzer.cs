using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using taxcoin.Helpers;

namespace UnitTests
{
    [TestClass]
    public class UnitTest_DataAnalyzer
    {
        [TestMethod]
        public void Test_SampleInput()
        {
            // Arrange
            int[] outputExisting = Datareader.ReadDataFromLocalFile("sampleInput.txt");

            // Act
            int maximumValue = new DataAnalyzer(outputExisting).CalculateOptimalRevenue();

            // Assert
            Assert.IsNotNull(outputExisting);
            Assert.AreEqual(maximumValue, 30);
        }

        [TestMethod]
        public void Test_TestInput1()
        {
            // Arrange
            int[] outputExisting = Datareader.ReadDataFromLocalFile("testInput1.txt");

            // Act
            int maximumValue = new DataAnalyzer(outputExisting).CalculateOptimalRevenue();

            // Assert
            Assert.IsNotNull(outputExisting);
            Assert.AreEqual(maximumValue, 200);
        }

        [TestMethod]
        public void Test_TestInput2()
        {
            // Arrange
            int[] outputExisting = Datareader.ReadDataFromLocalFile("testInput2.txt");

            // Act
            int maximumValue = new DataAnalyzer(outputExisting).CalculateOptimalRevenue();

            // Assert
            Assert.IsNotNull(outputExisting);
            Assert.AreEqual(3750, maximumValue);
        }

        [TestMethod]
        [Ignore]
        public void Test_TestInput3()
        {
            // Arrange
            int[] outputExisting = Datareader.ReadDataFromLocalFile("testInput3.txt");

            // Act
            int maximumValue = new DataAnalyzer(outputExisting).CalculateOptimalRevenue();

            // Assert
            Assert.IsNotNull(outputExisting);
            Assert.AreEqual(maximumValue, 265);
        }

        [TestMethod]
        [Ignore]
        public void Test_TestInput4()
        {
            // Arrange
            int[] outputExisting = Datareader.ReadDataFromLocalFile("testInput4.txt");

            // Act
            int maximumValue = new DataAnalyzer(outputExisting).CalculateOptimalRevenue();

            // Assert
            Assert.IsNotNull(outputExisting);
            Assert.AreEqual(maximumValue, 117);
        }



        [TestMethod]
        public void Test_SubmitInput()
        {
            // Arrange
            int[] outputExisting = Datareader.ReadDataFromLocalFile("submitInput.txt");

            // Act
            int maximumValue = new DataAnalyzer(outputExisting).CalculateOptimalRevenue();

            // Assert
            Assert.IsNotNull(outputExisting);
            Assert.AreEqual(maximumValue, 97005394);
        }
    }
}
