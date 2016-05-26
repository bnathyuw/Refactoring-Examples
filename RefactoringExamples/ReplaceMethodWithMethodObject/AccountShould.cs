using NUnit.Framework;

namespace RefactoringExamples.ReplaceMethodWithMethodObject
{
    [TestFixture]
    public class AccountShould
    {
        [Test]
        public void Gives_assured_result()
        {
            var sut = new Account();

            var actual = sut.Gamma(2, 4, 6);

            const int assured = 728;
            Assert.That(actual, Is.EqualTo(assured));
        }
    }
}