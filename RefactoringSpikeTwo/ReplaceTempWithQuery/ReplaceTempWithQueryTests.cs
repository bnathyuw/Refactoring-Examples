using NUnit.Framework;

namespace RefactoringSpikeTwo.ReplaceTempWithQuery
{
    [TestFixture]
    public class ReplaceTempWithQueryTests
    {
        [Test]
        public void Calculates_price_for_low_value_order()
        {
            var sut = new ReplaceTempWithQuerySut(20, 10);

            var price = sut.GetPrice();

            Assert.That(price, Is.EqualTo(196.0));
        }

        [Test]
        public void Calculates_price_for_high_value_order()
        {
            var sut = new ReplaceTempWithQuerySut(20, 100);

            var price = sut.GetPrice();

            Assert.That(price, Is.EqualTo(1900.0));
        }
    }

    public class ReplaceTempWithQuerySut
    {
        private readonly int _itemPrice;
        private readonly int _quantity;

        public ReplaceTempWithQuerySut(int quantity, int itemPrice)
        {
            _quantity = quantity;
            _itemPrice = itemPrice;
        }

        public double GetPrice()
        {
            int basePrice = _quantity*_itemPrice;
            double discountFactor;
            if (basePrice > 1000) discountFactor = 0.95;
            else discountFactor = 0.98;
            return basePrice*discountFactor;
        }
    }
}