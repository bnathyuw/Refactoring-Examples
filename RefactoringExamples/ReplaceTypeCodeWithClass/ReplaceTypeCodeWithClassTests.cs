using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace RefactoringExamples.ReplaceTypeCodeWithClass
{
    [TestFixture]
    public class ReplaceTypeCodeWithClassTests
    {
        private readonly IEnumerable<int> _testCases = new List<int>
        {
            Person.O,
            Person.A,
            Person.B,
            Person.AB
        };

        [TestCaseSource("_testCases")]
        public void A_person_has_a_blood_group(int bloodGroup)
        {
            var person = new Person(bloodGroup);

            Assert.That(person.BloodGroup, Is.EqualTo(bloodGroup));
        }

        [TestCaseSource("_testCases")]
        public void A_persons_blood_group_can_be_amended(int bloodGroup)
        {
            var person = new Person(Person.O);
            Assert.That(person.BloodGroup, Is.EqualTo(Person.O));

            person.BloodGroup = bloodGroup;

            Assert.That(person.BloodGroup, Is.EqualTo(bloodGroup));
        }
    }
}