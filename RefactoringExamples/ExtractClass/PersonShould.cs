using NUnit.Framework;

namespace RefactoringExamples.ExtractClass
{
    [TestFixture]
    public class PersonShould
    {
        [Test]
        public void Format_telephone_number()
        {
            const string officeAreaCode = "020";
            const string officeNumber = "1234 5678";
            var bloggs = new Person("Bloggs", officeAreaCode, officeNumber);

            Assert.That(bloggs.TelephoneNumber, Is.EqualTo($"({officeAreaCode}) {officeNumber}"));

        }
    }
}