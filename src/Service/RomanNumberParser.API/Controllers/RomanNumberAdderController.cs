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
        private readonly IRomanNumberSumCalculator _SumCalculator;
        private readonly IInterpreter _Interpreter;
        private readonly IEnumerable<IValueValidator> _ValueValidator;

        public RomanNumberAdderController(ILogger<RomanNumberAdderController> logger, IRomanNumberSumCalculator sumCalculator
                                         , IInterpreter interpreter, IEnumerable<IValueValidator> valueValidator)
        {
            _Logger = logger;
            _SumCalculator = sumCalculator;
            _Interpreter = interpreter;
            _ValueValidator = valueValidator;
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
                    return await _SumCalculator.CalculateSum(model.Input1, model.Input2);
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
                    var numericvaidaor = _ValueValidator.FirstOrDefault(x => x.GetType()
                                                        .Name == "DecimalValueValidator");
                    numericvaidaor?.IsValid(model.Input1);
                    numericvaidaor?.IsValid(model.Input2);

                    var romanNumber1 = await _Interpreter.Interpret(model.Input1);
                    var romanNumber2 = await _Interpreter.Interpret(model.Input2);
                    return await _SumCalculator.CalculateSum(romanNumber1, romanNumber2);

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

            catch (InvalidDataException ex)
            {
                //Its my reposibility to tell the user about the problem
                _Logger.LogError(ex.Message);
                return new ActionResult<string>(ex.Message);
            }
        }
    }
}