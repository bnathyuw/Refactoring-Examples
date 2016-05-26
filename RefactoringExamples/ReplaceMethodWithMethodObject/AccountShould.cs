using NUnit.Framework;

namespace RefactoringExamples.ReplaceMethodWithMethodObject
{
    [TestFixture]
    public class AccountShould
    {
        private Account _account;

        private const int Multiplier1 = 7;
        private const int Delta = 20;
        private const int ImportantValueWeighting = 100;
        private const int Multiplier2 = 2;
        private const int SecondaryWeighting = 20;

        [SetUp]
        public void SetUp()
        {
            _account = new Account();
        }

        [TestCase(1, 1)]
        [TestCase(100, 100)]
        public void Give_canned_value(int quantity, int yearToDate)
        {
            var gamma = _account.Gamma(0, quantity, yearToDate);

            Assert.That(gamma, Is.EqualTo(ImportantValueWeighting * Multiplier1 - Multiplier2 * Delta));
        }

        [TestCase(1, 1, 1)]
        [TestCase(1, 100, 100)]
        [TestCase(-199, 1, 1)]
        [TestCase(-1, 1, 100)]
        [TestCase(3, 1, -100)]
        public void Calculate_value_with_primary_weighting(int inputVal, int quantity, int yearToDate)
        {
            var gamma = _account.Gamma(inputVal, quantity, yearToDate);

            Assert.That(gamma, Is.EqualTo((inputVal * yearToDate + ImportantValueWeighting) * Multiplier1 - Multiplier2 * (inputVal * quantity + Delta)));
        }

        [TestCase(-200, 1, 1)]
        [TestCase(-1, 1, 101)]
        [TestCase(3, 1, -101)]
        public void Calculate_value_with_secondary_weighting(int inputVal, int quantity, int yearToDate)
        {
            var gamma = _account.Gamma(inputVal, quantity, yearToDate);

            Assert.That(gamma, Is.EqualTo((inputVal * yearToDate + ImportantValueWeighting - SecondaryWeighting) * Multiplier1 - Multiplier2 * (inputVal * quantity + Delta)));
        }
    }
}