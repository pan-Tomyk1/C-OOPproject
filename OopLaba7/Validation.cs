namespace OopLaba7
{
    public class Validation
    {
        public static bool ValidateNumber(int number, int max, int min)
        {
            return number <= max && number >= min;
        }
    }
}