using NUnit.Framework;

namespace RefactoringExamples.InlineTemp
{
    [TestFixture]
    public class BigOrderDetectorShould
    {
        private BigOrderDetector _bigOrderDetector;

        [SetUp]
        public void SetUp()
        {
            _bigOrderDetector = new BigOrderDetector();
        }

        [TestCase(1001)]
        [TestCase(2000)]
        [TestCase(1000000)]
        public void Catch_big_orders(double basePrice)
        {
            Assert.That(_bigOrderDetector.IsBig(Order.Priced(basePrice)), Is.EqualTo(true));
        }

        [TestCase(1000)]
        [TestCase(1)]
        [TestCase(0)]
        public void Clear_small_orders(double basePrice)
        {
            Assert.That(_bigOrderDetector.IsBig(Order.Priced(basePrice)), Is.EqualTo(false));
        }
    }
}