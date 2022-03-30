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

        public async Task<string> GetSum(string input1, string input2)
        {
            var value = Int32.Parse(_Expression.Interpret(input1)) + Int32.Parse(_Expression.Interpret(input2));
            var romanValue = new DecimalToRomanParser();
            return await Task.Run(()=> romanValue.Interpret(value.ToString()));
        }
    }
}