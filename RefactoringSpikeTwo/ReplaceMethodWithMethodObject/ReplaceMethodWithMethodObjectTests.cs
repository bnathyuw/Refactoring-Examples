using NUnit.Framework;

namespace RefactoringSpikeTwo.ReplaceMethodWithMethodObject
{
    [TestFixture]
    public class ReplaceMethodWithMethodObjectTests
    {
        [Test]
        public void Foo()
        {
            var sut = new ReplaceMethodWithMethodObjectSut();

            var actual = sut.Gamma(2, 4, 6);

            const int assured = 768;
            Assert.That(actual, Is.EqualTo(assured));
        }
    }
}