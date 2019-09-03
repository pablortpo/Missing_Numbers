using MissingNumbers.BusinessLogic.Implement;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase]
        public void MissingNumbersTest()
        {
            int n = 10, m = 13;
            List<int> arr = new List<int> { 203, 204, 205, 206, 207, 208, 203, 204, 205, 206 };
            List<int> brr = new List<int> { 203, 204, 204, 205, 206, 207, 205, 208, 203, 206, 205, 206, 204 };
            List<int> expectedResult = new List<int> { 204, 205, 206 };
            MissingNumber missingNumber = new MissingNumber();
            List<int> result = missingNumber.GetMissingNumbers(n, arr, m, brr);

            Assert.AreEqual(expectedResult, result);

        }

        [TestCase]
        public void MissingNumbersTest_Successful()
        {
            int n = 6, m = 8;
            List<int> arr = new List<int> { 7, 2, 5, 3, 5, 3 };
            List<int> brr = new List<int> { 7, 2, 5, 4, 6, 3, 5, 3 };
            List<int> expectedResult = new List<int> { 4, 6 };
            MissingNumber missingNumber = new MissingNumber();
            List<int> result = missingNumber.GetMissingNumbers(n, arr, m, brr);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase]
        public void MissingNumbersTest_SuccessfulSorted()
        {
            int n = 6, m = 8;
            List<int> arr = new List<int> { 7, 2, 5, 3, 5, 3 };
            List<int> brr = new List<int> { 7, 2, 5, 6, 4, 3, 5, 3 };
            List<int> expectedResult = new List<int> { 4, 6 };
            MissingNumber missingNumber = new MissingNumber();
            List<int> result = missingNumber.GetMissingNumbers(n, arr, m, brr);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase]
        public void MissingNumbersTest_FailException()
        {
            int n = -4, m = 13;
            List<int> arr = new List<int> { 203, 204, 205, 206, 207, 208, 203, 204, 205, 206 };
            List<int> brr = new List<int> { 203, 204, 204, 205, 206, 207, 205, 208, 203, 206, 205, 206, 204 };
            ArgumentException expectedResult = new ArgumentException("Error in [n] the length expect is out of range.");
            MissingNumber missingNumber = new MissingNumber();
            List<int> test = new List<int>();
            ArgumentException result = new ArgumentException();
            try
            {
                test = missingNumber.GetMissingNumbers(n, arr, m, brr);
            }
            catch (ArgumentException ex)
            {
                result = ex;
            }

            Assert.AreEqual(expectedResult.Message, result.Message);

        }
    }
}