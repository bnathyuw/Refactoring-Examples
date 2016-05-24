using NUnit.Framework;

namespace RefactoringExamples.ReplaceConditionalWithPolymorphism
{
    [TestFixture]
    public class EmployeeInManagerRoleShould
    {
        private Employee _manager;
        private const int BasicSalary = 100;
        private const int Commission = 10;
        private const int Bonus = 20;

        [SetUp]
        public void SetUp()
        {
            _manager = new Employee(EmployeeType.Manager);
        }

        [Test]
        public void A_manager_is_paid_salary_plus_bonus()
        {
            Assert.That(_manager.PayAmount(), Is.EqualTo(BasicSalary + Bonus));
        }

        [TestCase(EmployeeType.Engineer, BasicSalary)]
        [TestCase(EmployeeType.Salesperson, BasicSalary + Commission)]
        public void Get_a_pay_cut_on_demotion(int employeeType, int expectedSalary)
        {
            _manager.Type = employeeType;

            Assert.That(_manager.PayAmount(), Is.EqualTo(expectedSalary));
        }
    }
}