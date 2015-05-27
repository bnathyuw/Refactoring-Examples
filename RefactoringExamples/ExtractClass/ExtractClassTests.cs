using NUnit.Framework;

namespace RefactoringExamples.ExtractClass
{
    [TestFixture]
    public class ExtractClassTests
    {
        [Test]
        public void Has_correct_telephone_number()
        {
            var bloggs = new Person("Bloggs", "020", "1234 5678");

            Assert.That(bloggs.TelephoneNumber, Is.EqualTo("(020) 1234 5678"));

        }
    }
}