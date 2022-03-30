namespace RomanParser.Core
{
    public class InValidRomanValueException : Exception
    {
        public InValidRomanValueException()
        {
        }

        public InValidRomanValueException(string? message) : base(message)
        {

        }     
    }
}
