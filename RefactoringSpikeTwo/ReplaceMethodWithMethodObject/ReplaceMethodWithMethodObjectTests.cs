using NUnit.Framework;

namespace RefactoringSpikeTwo.ReplaceMethodWithMethodObject
{
    [TestFixture]
    public class ReplaceMethodWithMethodObjectTests
    {
        [Test]
        public void Gives_assured_result()
        {
            var sut = new ReplaceMethodWithMethodObjectSut();

            var actual = sut.Gamma(2, 4, 6);

            const int assured = 728;
            Assert.That(actual, Is.EqualTo(assured));
        }
    }
}