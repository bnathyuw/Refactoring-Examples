using NUnit.Framework;

namespace RefactoringSpikeTwo.SplitTemporaryVariable
{
    [TestFixture]
    public class SplitTemporaryVariableTests
    {
        [Test]
        public void Gives_correct_result()
        {
            var sut = new SplitTemporaryVariableSut(12, 23, 34, 45);

            var actual = sut.GetDistanceTravelled(56);

            const double assured = 1291.5652173913045d;
            Assert.That(actual, Is.EqualTo(assured));
        }
    }
}