using NUnit.Framework;

namespace RefactoringExamples.ReplaceTempWithQuery
{
    [TestFixture]
    public class OrderLineShould
    {
        private const double SmallDiscount = .98;
        private const double LargeDiscount = .95;

        [TestCase(20, 10)]
        [TestCase(20, 50)]
        public void Apply_small_discount_to_low_value_order_line(int quantity, int itemPrice)
        {
            var sut = new OrderLine(quantity, itemPrice);

            Assert.That(sut.GetPrice(), Is.EqualTo(quantity * itemPrice * SmallDiscount));
        }

        [TestCase(20, 100)]
        [TestCase(30, 100)]
        public void Apply_large_discount_to_high_value_order_line(int quantity, int itemPrice)
        {
            var sut = new OrderLine(quantity, itemPrice);

            Assert.That(sut.GetPrice(), Is.EqualTo(quantity * itemPrice * LargeDiscount));
        }
    }
}