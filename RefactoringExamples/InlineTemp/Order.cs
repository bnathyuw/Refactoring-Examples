namespace RefactoringExamples.InlineTemp
{
    public class Order
    {
        public static Order Priced(double basePrice)
        {
            return new Order(basePrice);
        }

        private Order(double basePrice)
        {
            BasePrice = basePrice;
        }

        public double BasePrice { get; }
    }
}