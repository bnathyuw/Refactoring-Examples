namespace RefactoringExamples.ReplaceTempWithQuery
{
    public class OrderLine
    {
        private readonly int _itemPrice;
        private readonly int _quantity;

        public OrderLine(int quantity, int itemPrice)
        {
            _quantity = quantity;
            _itemPrice = itemPrice;
        }

        public double GetPrice()
        {
            var basePrice = _quantity*_itemPrice;
            if (basePrice > 1000)
                return basePrice * 0.95;
            else
                return basePrice * 0.98;
        }
    }
}