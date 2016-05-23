using System;

namespace RefactoringExamples.IntroduceExplainingVariable
{
    public class PriceCalculator
    {
        private readonly int _quantity;
        private readonly double _itemPrice;

        public PriceCalculator(int quantity, double itemPrice)
        {
            _quantity = quantity;
            _itemPrice = itemPrice;
        }

        public double Price()
        {
            return _quantity*_itemPrice -
                   Math.Max(0, _quantity - 500)*_itemPrice*.05 +
                   Math.Min(_quantity*_itemPrice*.1, 100.0);
        }
    }
}