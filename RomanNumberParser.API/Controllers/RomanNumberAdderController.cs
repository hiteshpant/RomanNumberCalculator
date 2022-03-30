using Microsoft.AspNetCore.Mvc;
using RomanParser.Core.Contract;

namespace RomanNumberParser.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RomanNumberAdderController : ControllerBase
    {       
        private readonly ILogger<RomanNumberAdderController> _Logger;
        private readonly ISumCalculator _SumCalculator;

        public RomanNumberAdderController(ILogger<RomanNumberAdderController> logger, ISumCalculator sumCalculator)
        {
            _Logger = logger;
            _SumCalculator = sumCalculator;
        }

        [HttpPost(Name = "AddRomanNumber")]
        public async Task<string> Post(InputModel model)
        {
            return await _SumCalculator.GetSum(model.Input1, model.Input2);          
        }
    }
}