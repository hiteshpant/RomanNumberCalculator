
namespace RomanParser.Core.Contract
{
    public interface ISumCalculator
    {
        Task<string> GetSum(string input1, string input2);
    }
}
