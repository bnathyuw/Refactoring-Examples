using NUnit.Framework;

namespace RefactoringExamples.IntroduceExplainingVariable
{
    [TestFixture]
    public class PriceCalculatorShould
    {
        private const double ShippingPercentage = .1;
        private const double FlatRateShipping = 100.0;
        private const double DiscountPercentage = .05;
        private const int DiscountThreshold = 500;

        [TestCase(1, 1)]
        [TestCase(1, 1000)]
        [TestCase(10, 100)]
        [TestCase(DiscountThreshold, 2)]
        public void Apply_percentage_shipping_to_low_value_order(int quantity, int itemPrice)
        {
            var priceCalculator = new PriceCalculator(quantity, itemPrice);

            var price = priceCalculator.Price();

            var basePrice = quantity * itemPrice;
            var expectedPrice = basePrice + basePrice * ShippingPercentage;
            Assert.That(price, Is.EqualTo(expectedPrice));
        }

        [TestCase(1, 1001)]
        [TestCase(DiscountThreshold, 3)]
        [TestCase(DiscountThreshold, 1000)]
        public void Apply_flat_rate_shipping_to_high_value_order(int quantity, int itemPrice)
        {
            var priceCalculator = new PriceCalculator(quantity, itemPrice);

            var price = priceCalculator.Price();

            var expectedPrice = quantity * itemPrice + FlatRateShipping;
            Assert.That(price, Is.EqualTo(expectedPrice));
        }

        [TestCase(DiscountThreshold + 1, 1)]
        [TestCase(1000, 1)]
        public void Apply_discount_to_large_bulk_orders(int quantity, int itemPrice)
        {
            var priceCalculator = new PriceCalculator(quantity, itemPrice);

            var price = priceCalculator.Price();

            var basePrice = quantity * itemPrice;
            var discount = (quantity - DiscountThreshold) * itemPrice * DiscountPercentage;
            var shipping = basePrice * ShippingPercentage;
            var expectedPrice = basePrice - discount + shipping;
            Assert.That(price, Is.EqualTo(expectedPrice));
        }

        [TestCase(DiscountThreshold + 1, 2)]
        [TestCase(DiscountThreshold + 1, 1000)]
        [TestCase(1000, 1000)]
        public void Apply_discount_and_flat_rate_shipping_to_high_value_large_bulk_orders(int quantity, int itemPrice)
        {
            var priceCalculator = new PriceCalculator(quantity, itemPrice);

            var price = priceCalculator.Price();

            var basePrice = quantity * itemPrice;
            var discount = (quantity - DiscountThreshold) * itemPrice * DiscountPercentage;
            var expectedPrice = basePrice - discount + FlatRateShipping;
            Assert.That(price, Is.EqualTo(expectedPrice));
        }
    }
}