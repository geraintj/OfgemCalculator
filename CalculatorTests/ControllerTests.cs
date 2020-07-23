using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using OfgemCalculator.Controllers;
using OfgemCalculator.Entities;
using Xunit;

namespace CalculatorTests
{
    public class ControllerTests
    {
        private Mock<IRepository> _repo;
        private HttpContext _httpContext;

        public ControllerTests()
        {
            _repo = new Mock<IRepository>();
            _httpContext = new DefaultHttpContext() { Connection = { Id = "NewConnection", RemoteIpAddress = new IPAddress(0)}};
        }

        public static IEnumerable<object[]> GetIntegers()
        {
            yield return new object[] { "5", "1" };
            yield return new object[] { "75", "12" };
            yield return new object[] { "3", "1987" };
            yield return new object[] { "46", "176" };
            yield return new object[] { "104", "7" };
            yield return new object[] { "10423", "67" };
            yield return new object[] { "67", "10423" };
            yield return new object[] { "1", "199999999" };
            yield return new object[] { "4567890", "8" };
            yield return  new object[] { "300", "700" };
        }

        public static IEnumerable<object[]> GetDecimals()
        {
            yield return new object[] { "5.4", "1" };
            yield return new object[] { "75", "3.8" };
            yield return new object[] { "3.5", "1987.89" };
            yield return new object[] { "46.678", "176" };
            yield return new object[] { "104.5", "7.8901" };
        }

        [Theory]
        [MemberData(nameof(GetIntegers))]
        public async Task IntegerAdditionCorrect(string firstNumber, string secondNumber)
        {
            // Arrange
            var controller = new CalculatorController(_repo.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = _httpContext
                }
            };

            // Act
            var response = await controller.Add(firstNumber, secondNumber) as OkObjectResult;

            // Assert
            var expected = int.Parse(firstNumber) + int.Parse(secondNumber);
            Assert.Equal($"{expected:0.#######}", response.Value);
            _repo.Verify(x => x.SaveAsync(It.IsAny<Calculation>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetDecimals))]
        public async Task DecimalAdditionCorrect(string firstNumber, string secondNumber)
        {
            // Arrange
            var controller = new CalculatorController(_repo.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = _httpContext
                }
            };
            // Act
            var response = await controller.Add(firstNumber, secondNumber) as OkObjectResult;

            // Assert
            var expected = decimal.Parse(firstNumber) + decimal.Parse(secondNumber);
            Assert.Equal($"{expected:0.#######}", response.Value);
            _repo.Verify(x => x.SaveAsync(It.IsAny<Calculation>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetIntegers))]
        public async Task IntegerSubtractionCorrect(string firstNumber, string secondNumber)
        {
            // Arrange
            var controller = new CalculatorController(_repo.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = _httpContext
                }
            };

            // Act
            var response = await controller.Subtract(firstNumber, secondNumber) as OkObjectResult;

            // Assert
            var expected = int.Parse(firstNumber) - int.Parse(secondNumber);
            Assert.Equal($"{expected:0.#######}", response.Value);
            _repo.Verify(x => x.SaveAsync(It.IsAny<Calculation>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetDecimals))]
        public async Task DecimalSubtractionCorrect(string firstNumber, string secondNumber)
        {
            // Arrange
            var controller = new CalculatorController(_repo.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = _httpContext
                }
            };

            // Act
            var response = await controller.Subtract(firstNumber, secondNumber) as OkObjectResult;

            // Assert
            var expected = decimal.Parse(firstNumber) - decimal.Parse(secondNumber);
            Assert.Equal($"{expected:0.#######}", response.Value);
            _repo.Verify(x => x.SaveAsync(It.IsAny<Calculation>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetIntegers))]
        public async Task IntegerMultiplyCorrect(string firstNumber, string secondNumber)
        {
            // Arrange
            var controller = new CalculatorController(_repo.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = _httpContext
                }
            };

            // Act
            var response = await controller.Multiply(firstNumber, secondNumber) as OkObjectResult;

            // Assert
            var expected = int.Parse(firstNumber) * int.Parse(secondNumber);
            Assert.Equal($"{expected:0.#######}", response.Value);
            _repo.Verify(x => x.SaveAsync(It.IsAny<Calculation>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetDecimals))]
        public async Task DecimalMultiplyCorrect(string firstNumber, string secondNumber)
        {
            // Arrange
            var controller = new CalculatorController(_repo.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = _httpContext
                }
            };

            // Act
            var response = await controller.Multiply(firstNumber, secondNumber) as OkObjectResult;

            // Assert
            var expected = decimal.Parse(firstNumber) * decimal.Parse(secondNumber);
            Assert.Equal($"{expected:0.#######}", response.Value);
            _repo.Verify(x => x.SaveAsync(It.IsAny<Calculation>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetIntegers))]
        public async Task IntegerDivideCorrect(string firstNumber, string secondNumber)
        {
            // Arrange
            var controller = new CalculatorController(_repo.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = _httpContext
                }
            };

            // Act
            var response = await controller.Divide(firstNumber, secondNumber) as OkObjectResult;

            // Assert
            var expected = int.Parse(firstNumber) / decimal.Parse(secondNumber);
            Assert.Equal($"{expected:0.#######}", response.Value);
            _repo.Verify(x => x.SaveAsync(It.IsAny<Calculation>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(GetDecimals))]
        public async Task DecimalDivideCorrect(string firstNumber, string secondNumber)
        {
            // Arrange
            var controller = new CalculatorController(_repo.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = _httpContext
                }
            };

            // Act
            var response = await controller.Divide(firstNumber, secondNumber) as OkObjectResult;

            // Assert
            var expected = decimal.Parse(firstNumber) / decimal.Parse(secondNumber);
            Assert.Equal($"{expected:0.#######}", response.Value);
            _repo.Verify(x => x.SaveAsync(It.IsAny<Calculation>()), Times.Once);
        }
    }
}
