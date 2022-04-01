using Microsoft.AspNetCore.Mvc;
using RomanParser.Core;
using RomanParser.Core.Contract;
using System.Diagnostics.CodeAnalysis;

namespace RomanNumberParser.API.Controllers
{
    [ApiController]
    [ExcludeFromCodeCoverage]
    [Route("api/[controller]")]
    public class RomanNumberAdderController : ControllerBase
    {
        private readonly ILogger<RomanNumberAdderController> _Logger;
        private readonly ISumCalculator _SumCalculator;
        private readonly IExpression _Expression;

        public RomanNumberAdderController(ILogger<RomanNumberAdderController> logger, ISumCalculator sumCalculator,
                                           IExpression expression)
        {
            _Logger = logger;
            _SumCalculator = sumCalculator;
            _Expression = expression;
        }


        /// <summary>
        /// Gets Roman Input Data and calculate the sum of bot the number
        /// Max sum can be calcullated till 3999, otherwise it would be a Invalid Roman Value exception
        /// Throws InValidRomanValueException in case its invalid
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost(Name = "AddRomanNumber")]
        public async Task<ActionResult<string>> Post(InputModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await _SumCalculator.GetSum(model.Input1, model.Input2);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (InValidRomanValueException ex)
            {
                _Logger.LogError(ex.Message);
                return new ActionResult<string>(ex.Message);
            }
        }

        private static HttpResponseMessage CreateUserDefinedMessage(string message, System.Net.HttpStatusCode code)
        {
            return new HttpResponseMessage(code)
            {
                Content = new StringContent(message),
                ReasonPhrase = message
            };
        }

        /// <summary>
        /// GetsNumeric Input  Value  and return both the formats
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<string>> AddNumericValue(InputModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string numericSum = String.Empty;
                    string romanSum = String.Empty;
                    await Task.Run(() =>
                    {
                        var sum = AddNumbers(model.Input1, model.Input2);
                        var expression = new DecimalToRomanParser();
                        numericSum = $"{model.Input1} + {model.Input2} = {sum}";
                        var validator = new MaxSumValidaor();
                        if (validator.IsValid(sum))
                        {
                            romanSum = $"{expression.Interpret(model?.Input1)} + {expression.Interpret(model?.Input2)} = {expression.Interpret(sum)}";
                        }
                        else
                        {
                            romanSum = "Right now for Roman Number System We can only interpret value till 3999";
                        }
                    });

                    return numericSum  + ";  "+ romanSum;
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (InValidRomanValueException ex)
            {
                //Its my reposibility to tell the user about the problem
                _Logger.LogError(ex.Message);
                return new ActionResult<string>(ex.Message);
            }
        }

        private string AddNumbers(string input1, string input2)
        {
            int.TryParse(input1, out int num1);
            int.TryParse(input2, out int num2);
            return (num1 + num2).ToString();

        }
    }
}