namespace RefactoringExamples.RemoveAssignmentsToParameters
{
    public class DiscountCalculator
    {
        public int Discount(int inputVal, int quantity, int yearToDate)
        {
            if (inputVal > 50) inputVal -= 2;
            if (quantity > 100) inputVal -= 1;
            if (yearToDate > 10000) inputVal -= 4;
            return inputVal;
        }
    }
}