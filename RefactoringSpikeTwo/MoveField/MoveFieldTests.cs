using NUnit.Framework;

namespace RefactoringSpikeTwo.MoveField
{
    [TestFixture]
    public class MoveFieldTests
    {
        [Test]
        public void Returns_correct_amount()
        {
            var account = new Account(new AccountType(), 1.3);

            var actual = account.InterestForAmount_Days(24.68, 10);

            const double assured = 0.87901369863013712d;
            Assert.That(actual, Is.EqualTo(assured));
        }
    }
}