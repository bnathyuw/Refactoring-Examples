using NUnit.Framework;

namespace RefactoringExamples.RemoveAssignmentsToParameters
{
    [TestFixture]
    public class DiscountCalculatorShould
    {
        private DiscountCalculator _discountCalculator;

        private const int TotalValueDiscount = 2;
        private const int QuantityDiscount = 1;
        private const int FrequentCustomerDiscount = 4;

        private const int TotalValueThreshold = 50;
        private const int QuantityThreshold = 100;
        private const int FrequentCustomerThreshold = 10000;

        [SetUp]
        public void SetUp()
        {
            _discountCalculator = new DiscountCalculator();
        }

        [TestCase(1, 1, 1)]
        [TestCase(TotalValueThreshold, QuantityThreshold, FrequentCustomerThreshold)]
        public void Apply_no_discount_for_small_values(int inputVal, int quantity, int yearToDate)
        {
            var discountedValue = _discountCalculator.Discount(inputVal, quantity, yearToDate);

            Assert.That(discountedValue, Is.EqualTo(inputVal));
        }

        [TestCase(TotalValueThreshold + 1, 1, 1)]
        [TestCase(TotalValueThreshold + 2, 1, 1)]
        [TestCase(TotalValueThreshold * 100, 1, 1)]
        [TestCase(TotalValueThreshold + 1, QuantityThreshold, FrequentCustomerThreshold)]
        public void Apply_total_value_discount_for_high_value_orders(int inputVal, int quantity, int yearToDate)
        {
            var discountedValue = _discountCalculator.Discount(inputVal, quantity, yearToDate);

            Assert.That(discountedValue, Is.EqualTo(inputVal - TotalValueDiscount));
        }

        [TestCase(1, QuantityThreshold + 1, 1)]
        [TestCase(1, QuantityThreshold + 2, 1)]
        [TestCase(1, QuantityThreshold * 100, 1)]
        [TestCase(TotalValueThreshold, QuantityThreshold + 1, FrequentCustomerThreshold)]
        public void Apply_quantity_discount_for_large_orders(int inputVal, int quantity, int yearToDate)
        {
            var discountedValue = _discountCalculator.Discount(inputVal, quantity, yearToDate);

            Assert.That(discountedValue, Is.EqualTo(inputVal - QuantityDiscount));
        }

        [TestCase(1, 1, FrequentCustomerThreshold + 1)]
        [TestCase(1, 1, FrequentCustomerThreshold + 2)]
        [TestCase(1, 1, FrequentCustomerThreshold * 100)]
        [TestCase(TotalValueThreshold, QuantityThreshold, FrequentCustomerThreshold + 1)]
        public void Apply_frequent_customer_discount_for_customer_with_many_orders(int inputVal, int quantity, int yearToDate)
        {
            var discountedValue = _discountCalculator.Discount(inputVal, quantity, yearToDate);

            Assert.That(discountedValue, Is.EqualTo(inputVal - FrequentCustomerDiscount));
        }

        [TestCase(TotalValueThreshold + 1, QuantityThreshold + 1, 1, TotalValueDiscount + QuantityDiscount)]
        [TestCase(TotalValueThreshold + 1, 1, FrequentCustomerThreshold + 1, TotalValueDiscount + FrequentCustomerDiscount)]
        [TestCase(1, QuantityThreshold + 1, FrequentCustomerThreshold + 1, QuantityDiscount + FrequentCustomerDiscount)]
        [TestCase(TotalValueThreshold + 1, QuantityThreshold + 1, FrequentCustomerThreshold + 1, TotalValueDiscount + QuantityDiscount + FrequentCustomerDiscount)]
        public void Apply_discounts_in_combination(int inputVal, int quantity, int yearToDate, int expectedDiscount)
        {
            var discountedValue = _discountCalculator.Discount(inputVal, quantity, yearToDate);

            Assert.That(discountedValue, Is.EqualTo(inputVal - expectedDiscount));
        }

    }
}