using System;
using NUnit.Framework;

namespace RefactoringExamples.IntroduceParameterObject
{
    [TestFixture]
    public class AccountShould
    {
        [Test]
        public void Give_correct_result()
        {
            var account = new Account(new[]
                {
                    new Entry(1, new DateTime(2001, 2, 3)),
                    new Entry(2, new DateTime(2002, 3, 4)),
                    new Entry(3, new DateTime(2003, 4, 5))
                });

            var actual = account.GetFlowBetween(new DateTime(2001, 5, 6), new DateTime(2003, 1, 2));

            Assert.That(actual, Is.EqualTo(2));
        }
    }
}