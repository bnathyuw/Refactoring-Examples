namespace RefactoringExamples.InlineTemp
{
    public class BigOrderDetector
    {
        public bool IsBig(Order order)
        {
            var basePrice = order.BasePrice;
            return basePrice > 1000;
        }
    }
}