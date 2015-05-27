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
}