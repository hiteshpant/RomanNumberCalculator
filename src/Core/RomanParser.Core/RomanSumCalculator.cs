using RomanParser.Core.Contract;

namespace RomanParser.Core
{
    public class RomanSumCalculator : ISumCalculator
    {
        private readonly IExpression _Expression;
        public RomanSumCalculator(IExpression expression)
        {
            _Expression = expression;
        }

        /// <summary>
        /// Adds the roman number and give back the result in case value is withing 3999, otherwise exception
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        /// <exception cref="InValidRomanValueException"></exception>
        public async Task<string> GetSum(string input1, string input2)
        {
            var value = await Task.Run(()=>Int32.Parse(_Expression.Interpret(input1)) + Int32.Parse(_Expression.Interpret(input2)));
            //Poor Mans DI :) :) :)
            var maxValidator = new MaxSumValidaor();
            if (maxValidator.IsValid(value.ToString()))
            {
                var romanValue = new DecimalToRomanParser();
                return await Task.Run(() => romanValue.Interpret(value.ToString()));
            }
            else
            {
                throw new InValidRomanValueException("Max Value reached we can add such a big numbers in Roman Format");
            }
        }
    }
}