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

            var actual = sut.GetPrice();

            const double assured = 196.0;
            Assert.That(actual, Is.EqualTo(assured));
        }

        [Test]
        public void Calculates_price_for_high_value_order()
        {
            var sut = new ReplaceTempWithQuerySut(20, 100);

            var actual = sut.GetPrice();

            var assured = 1900.0;
            Assert.That(actual, Is.EqualTo(assured));
        }
    }
}