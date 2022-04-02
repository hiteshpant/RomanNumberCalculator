
namespace RomanParser.Core.Contract
{
    public interface IRomanNumberSumCalculator
    {       
        /// <summary>
        /// Calculate Sum for Roman Number
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        Task<string> CalculateSum(string input1, string input2);
    }
}
