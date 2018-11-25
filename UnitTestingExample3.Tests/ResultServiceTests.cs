using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingExample3.business;
using Moq;
using UnitTestingExample3.data;

namespace UnitTestingExample3.Tests
{
    [TestClass]
    public class ResultServiceTests
    {

        ResultService _serviceUnderTest;
        private Mock<IResultRepository> mockRepository;

        [TestInitialize]
        public void Initialize()
        {
            mockRepository = new Mock<IResultRepository>();
            _serviceUnderTest = new ResultService(mockRepository.Object);
        }

        [TestMethod]
        public void CreateResult_HappyPath_NoErrors()
        {
            // arrange

            // act
            _serviceUnderTest.CreateResult("hello", "8");

            // assert

        }

        [TestMethod]
        public void CreateResult_AmountLessThanZero_Exception()
        {
            // arrange
            Exception thrownException = null;

            // act
            try
            {
                _serviceUnderTest.CreateResult("hello", "-3");
            } catch(Exception ex)
            {
                thrownException = ex;
            }

            // assert
            Assert.IsNotNull(thrownException);
        }

        [TestMethod]
        public void CreateResult_NormalPath_ActiveDefaultsToTrue()
        {
            // arrange

            // act
            var result = _serviceUnderTest.CreateResult("hello", "8");

            // assert
            Assert.IsTrue(result.active);

        }

        [TestMethod]
        public void CreateResult_TestPatient_IsRealSetToFalse()
        {
            // arrange
            Result savedResult = null;
            mockRepository.Setup(r => r.Add(It.IsAny<Result>())).Callback<Result>((a) => savedResult = a);

            // act
            _serviceUnderTest.CreateResult("prp1660", "8");

            // assert
            Assert.IsFalse(savedResult.isReal);
        }
    }
}
