using System;
using RomanParser.Core.Contract;
using System.Text;

namespace RomanParser.Core
{
    public class DecimalToRomanParser : IExpression
    {
        private static Tuple<int, string>[] romanCharacterMap =
        {
           new Tuple<int, string>( 1000,"M") ,
           new Tuple<int, string>( 900,"CM") ,
           new Tuple<int, string>( 500,"D") ,
           new Tuple<int, string>( 400,"CD") ,
           new Tuple<int, string>( 100,"C") ,
           new Tuple<int, string>( 90,"XC") ,
           new Tuple<int, string>( 50,"L") ,
           new Tuple<int, string>( 40,"XL") ,
           new Tuple<int, string>( 10,"X") ,
           new Tuple<int, string>( 9,"IX") ,
           new Tuple<int, string>( 5,"V") ,
           new Tuple<int, string>( 4,"IV") ,
           new Tuple<int, string>( 1,"I") ,
        };

        public string Interpret(string input)
        {
            StringBuilder result = new StringBuilder();
            if (Int32.TryParse(input.ToUpper().Trim(), out int inputVal))
            {

                // Loop through each symbol, stopping if num becomes 0.
                for (int i = 0; i < romanCharacterMap.Length && inputVal > 0; i++)
                {
                    // Repeat while the current symbol still fits into num.
                    while (romanCharacterMap[i].Item1 <= inputVal)
                    {
                        inputVal -= romanCharacterMap[i].Item1;
                        result.Append(romanCharacterMap[i].Item2);
                    }
                }
            }
            return result.ToString();
        }
    }
}
