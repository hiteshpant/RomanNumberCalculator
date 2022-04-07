using RomanParser.Core.Contract;
using System.Text;

namespace RomanParser.Core.Parser
{

    //1- Remove all Subtractive Notions in Roman by NonSubtractive one
    //2- combine and sort both the input
    //3- from right to left replace consecutive repetition by corresponding Roman value and also after each replace sort the input.
    //4- Replace all the Additive by possible subtractive value;
    public class RomanNumberSumCalculator : IRomanNumberSumCalculator
    {
        private List<string> PriorityMap = new List<string>(15)
                                                { "M", "D",  "C", "L", "X","V","III","II","I" };
        private readonly IValueValidator? _ValueValidators;

        public RomanNumberSumCalculator(IEnumerable<IValueValidator?> valueValidator)
        {
            _ValueValidators = valueValidator?.FirstOrDefault(x => x.GetType().Name == "RomanValueValidator");
            if (_ValueValidators == null)
            {
                throw new ArgumentNullException("No Validator implemented for Roman Value addition");
            }
        }

        private readonly Dictionary<string, string> _NonSubtractiveMap = new Dictionary<string, string>()
       {
            { "CM","DCCCC"}, { "CD","CCCC"}, { "XC","LXXXX"}, { "XL","XXXX"}, { "IX","VIIII"},{ "IV","IIII"}
       };


        private readonly Dictionary<string, string> _SubtractiveMap = new Dictionary<string, string>()
        {
             { "DCCCC","CM"}, { "CCCC","CD"}, { "LXXXX","XC"}, { "XXXX","XL"}, { "VIIII","IX"},{ "IIII","IV"}
        };

        private string GetBiggerValueForRepetation(string input)
        {
            string result;
            switch (input)
            {
                case "DD":
                    { result = "M"; }
                    break;
                case "CCCCC":
                    { result = "D"; }
                    break;
                case "LL":
                    { result = "C"; }
                    break;
                case "XXXXX":
                    { result = "L"; }
                    break;
                case "VV":
                    { result = "X"; }
                    break;
                case "IIIII":
                    { result = "V"; }
                    break;
                default:
                    result = string.Empty;
                    break;
            }
            return result;
        }

        private int GetPriority(string input)
        {
            return PriorityMap.IndexOf(input);
        }

        private StringBuilder ConvertTheAdditiveNotation(StringBuilder input)
        {
            for (int i = 0; i < input.Length;)
            {
                if (i < input.Length - 4)
                {
                    var combination = char.ToString(input[i]) + char.ToString(input[i + 1]) +
                                                                char.ToString(input[i + 2]) + char.ToString(input[i + 3])
                                                                + char.ToString(input[i + 3]);
                    if (_SubtractiveMap.ContainsKey(combination.ToString()))
                    {
                        var subtractive = _SubtractiveMap[combination.ToString()];
                        input.Remove(i, 5);
                        input.Insert(i, subtractive);
                        i = i + 2;
                        continue;
                    }
                }
                if (i < input.Length - 3)
                {
                    var combination = char.ToString(input[i]) + char.ToString(input[i + 1]) + char.ToString(input[i + 2]) + char.ToString(input[i + 3]);
                    if (_SubtractiveMap.ContainsKey(combination.ToString()))
                    {
                        var subtractive = _SubtractiveMap[combination.ToString()];
                        input.Remove(i, 4);
                        input.Insert(i, subtractive);
                        i = i + 2;
                        continue;
                    }
                }
                i++;
            }
            return input;
        }


        private string AddRomanNumber(string input1, string input2)
        {
            var nonSubtractive1 = GetNonSubtractiveSequence(new StringBuilder(input1));
            var nonSubtractive2 = GetNonSubtractiveSequence(new StringBuilder(input2));
            var sortedValue = SortStringAsPerPriority(nonSubtractive1.ToString() + nonSubtractive2.ToString());
            var sbOutput = new StringBuilder(sortedValue);
            var repeatingString = new StringBuilder();
            var sortedValueLength = sortedValue.Length - 1;
            int startIndex = 0;
            string repetationresult = string.Empty;
            try
            {
                for (int endIndex = sortedValueLength; endIndex > 0;)
                {
                    repeatingString.Clear();
                    repetationresult = string.Empty;
                    repeatingString.Append(sbOutput[endIndex]);
                    startIndex = endIndex - 1;
                    while (startIndex >= 0 && sbOutput[startIndex] == sbOutput[endIndex])
                    {
                        repeatingString.Append(sbOutput[startIndex]);
                        repetationresult = GetBiggerValueForRepetation(repeatingString.ToString());
                        if (repetationresult != string.Empty)
                        {
                            sbOutput.Replace(repeatingString.ToString(), repetationresult, startIndex, endIndex - startIndex + 1);
                            sbOutput = new StringBuilder(SortStringAsPerPriority(sbOutput.ToString()));
                            endIndex = sbOutput.Length - 1;
                            break;
                        }
                        startIndex--;
                    }
                    if (repetationresult == string.Empty)
                    {
                        endIndex--;
                    }
                }
                var output = ConvertTheAdditiveNotation(sbOutput).ToString();

                var isvalid = _ValueValidators.IsValid(output.ToString());
                return output;
            }
            catch (InValidRomanValueException ex)
            {
                throw new InValidRomanValueException(ex.Message + ", As right it is not possible to add Roman number bigger than MMMCMXCIX");
            }
        }


        private string SortStringAsPerPriority(string input)
        {
            var sortedCollection = input.OrderBy(x => GetPriority(x.ToString())).Select(x => x.ToString());
            StringBuilder sb = new StringBuilder();
            foreach (var item in sortedCollection)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }

        private StringBuilder GetNonSubtractiveSequence(StringBuilder input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (i + 1 < input.Length)
                {
                    var combination = char.ToString(input[i]) + char.ToString(input[i + 1]);
                    if (_NonSubtractiveMap.ContainsKey(combination.ToString()))
                    {
                        var nonSubtractiveVal = _NonSubtractiveMap[combination.ToString()];
                        input.Remove(i, 2);
                        input.Insert(i, nonSubtractiveVal);
                        i = i + nonSubtractiveVal.Length - 1;
                    }
                }
            }
            return input;
        }

        public async Task<string> CalculateSum(string input1, string input2)
        {
            try
            {
                var isValid = _ValueValidators != null && _ValueValidators.IsValid(input1) && _ValueValidators.IsValid(input1);
                return await Task.Factory.StartNew(() => AddRomanNumber(input1, input2));
            }
            catch (InValidRomanValueException ex)
            {
                throw ex;
            }
        }
    }
}
