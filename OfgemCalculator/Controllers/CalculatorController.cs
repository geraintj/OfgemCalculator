using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Features;
using OfgemCalculator.Entities;

namespace OfgemCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly IRepository _repository;

        public CalculatorController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("Add")]
        public async Task<ActionResult> Add(string firstNumber, string secondNumber)
        {

            var firstNumberNumeric = firstNumber.Contains(".") ? decimal.Parse(firstNumber) : int.Parse(firstNumber);
            var secondNumberNumeric = secondNumber.Contains(".") ? decimal.Parse(secondNumber) : int.Parse(secondNumber);
            var result = firstNumberNumeric + secondNumberNumeric;
            await SaveCalculation(new Calculation()
            {
                First = firstNumber,
                Second = secondNumber,
                Operation = Operation.Add,
                ClientIp = HttpContext.Connection.RemoteIpAddress.ToString(),
                Result = $"{result:0.#######}"
            });
            return Ok($"{result:0.#######}");
        }

        [HttpGet]
        [Route("Subtract")]
        public async Task<ActionResult> Subtract(string firstNumber, string secondNumber)
        {
            var firstNumberNumeric = firstNumber.Contains(".") ? decimal.Parse(firstNumber) : int.Parse(firstNumber);
            var secondNumberNumeric = secondNumber.Contains(".") ? decimal.Parse(secondNumber) : int.Parse(secondNumber);
            var result = firstNumberNumeric - secondNumberNumeric;
            await SaveCalculation(new Calculation()
            {
                First = firstNumber,
                Second = secondNumber,
                Operation = Operation.Subtract,
                ClientIp = HttpContext.Connection.RemoteIpAddress.ToString(),
                Result = $"{result:0.#######}"
            });
            return Ok($"{result:0.#######}");
        }

        [HttpGet]
        [Route("Multiply")]
        public async Task<ActionResult> Multiply(string firstNumber, string secondNumber)
        {
            var firstNumberNumeric = firstNumber.Contains(".") ? decimal.Parse(firstNumber) : int.Parse(firstNumber);
            var secondNumberNumeric = secondNumber.Contains(".") ? decimal.Parse(secondNumber) : int.Parse(secondNumber);
            var result = firstNumberNumeric * secondNumberNumeric;
            await SaveCalculation(new Calculation()
            {
                First = firstNumber,
                Second = secondNumber,
                Operation = Operation.Multiply,
                ClientIp = HttpContext.Connection.RemoteIpAddress.ToString(),
                Result = $"{result:0.#######}"
            });
            return Ok($"{result:0.#######}");
        }

        [HttpGet]
        [Route("Divide")]
        public async Task<ActionResult> Divide(string firstNumber, string secondNumber)
        {
            var firstNumberNumeric = firstNumber.Contains(".") ? decimal.Parse(firstNumber) : int.Parse(firstNumber);
            var secondNumberNumeric = secondNumber.Contains(".") ? decimal.Parse(secondNumber) : int.Parse(secondNumber);
            var result = firstNumberNumeric / secondNumberNumeric;
            await SaveCalculation(new Calculation()
            {
                First = firstNumber,
                Second = secondNumber,
                Operation = Operation.Divide,
                ClientIp = HttpContext.Connection.RemoteIpAddress.ToString(),
                Result = $"{result:0.#######}"
            });
            return Ok($"{result:0.#######}");
        }

        private async Task SaveCalculation(Calculation calculation)
        {
            await _repository.SaveAsync(calculation);
        }
    }
}