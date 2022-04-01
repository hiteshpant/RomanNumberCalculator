

using RomanParser.Core.Contract;

namespace RomanParser.Core
{
    public class RomanExpressionParser : IExpression
    {
        private readonly IEnumerable<IValueValidator> _RomanValueValidator;

        public RomanExpressionParser(IEnumerable<IValueValidator> romanValueValidator)
        {
            _RomanValueValidator = romanValueValidator;
        }

        private static Dictionary<char, int> romanCharacterMap = new Dictionary<char, int>()
        {
            {'I',1},
            {'V',5},
            {'X',10},
            {'L',50},
            {'C',100},
            {'D',500},
            {'M',1000 }
        };

        public string Interpret(string input)
        {
            int sum = 0;
            input = input.ToUpper().Trim();
            try
            {
                if(ValidateIfInputIsValid(input))
                {

                    int n = input.Length;

                    for (int i = 0; i < n; i++)
                    {
                        //checks when the next character is like smaller for VI kind of case
                        if (i != n - 1 && romanCharacterMap[input[i]] < romanCharacterMap[input[i + 1]])
                        {
                            sum += romanCharacterMap[input[i + 1]] - romanCharacterMap[input[i]];
                            i++;
                        }
                        //checks when the next character is like greater for IV kind of case
                        else
                        {
                            sum += romanCharacterMap[input[i]];
                        }
                    }
                }
            }

            catch (InValidRomanValueException ex)
            {
                throw ex;
            }            
            return sum.ToString();
        }

        private bool ValidateIfInputIsValid(string input)
        {
            return _RomanValueValidator.FirstOrDefault(x => x.IsValid(input) == false) == null ? true : false;
        }
    }
}
