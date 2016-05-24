using NUnit.Framework;

namespace RefactoringExamples.ReplaceTypeCodeWithStateStrategy
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
            _manager = new Employee(Employee.Manager);
        }

        [Test]
        public void A_manager_is_paid_salary_plus_bonus()
        {
            Assert.That(_manager.PayAmount(), Is.EqualTo(BasicSalary + Bonus));
        }

        [TestCase(Employee.Engineer, BasicSalary)]
        [TestCase(Employee.Salesperson, BasicSalary + Commission)]
        public void Get_a_pay_cut_on_demotion(int employeeType, int expectedSalary)
        {
            _manager.Type = employeeType;

            Assert.That(_manager.PayAmount(), Is.EqualTo(expectedSalary));
        }
    }
}