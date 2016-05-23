using NUnit.Framework;

namespace RefactoringExamples.ReplaceTypeCodeWithStateStrategy
{
    [TestFixture]
    public class EmployeeInEngineerRoleShould
    {
        private Employee _engineer;
        private const int BasicSalary = 100;
        private const int Commission = 10;
        private const int Bonus = 20;

        [SetUp]
        public void SetUp()
        {
            _engineer = new Employee(Employee.Engineer);
        }

        [Test]
        public void Be_paid_just_their_salary()
        {
            Assert.That(_engineer.PayAmount(), Is.EqualTo(BasicSalary));
        }

        [TestCase(Employee.Manager, BasicSalary + Bonus)]
        [TestCase(Employee.Salesperson, BasicSalary + Commission)]
        public void Get_a_pay_rise_on_promotion(int employeeType, int expectedSalary)
        {
            _engineer.EmployeeType = employeeType;

            Assert.That(_engineer.PayAmount(), Is.EqualTo(expectedSalary));
        }
    }
}