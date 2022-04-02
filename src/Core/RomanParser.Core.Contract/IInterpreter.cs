
namespace RomanParser.Core.Contract
{
    public interface IInterpreter
    {
        Task<string> Interpret(string input1);
    }
}
