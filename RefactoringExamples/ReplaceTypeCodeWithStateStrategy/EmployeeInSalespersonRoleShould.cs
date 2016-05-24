using NUnit.Framework;

namespace RefactoringExamples.ReplaceTypeCodeWithStateStrategy
{
    [TestFixture]
    public class EmployeeInSalespersonRoleShould
    {
        private Employee _salesperson;
        private const int BasicSalary = 100;
        private const int Commission = 10;
        private const int Bonus = 20;

        [SetUp]
        public void SetUp()
        {
            _salesperson = new Employee(Employee.Salesperson);
        }

        [Test]
        public void A_salesperson_is_paid_salary_plus_commission()
        {
            Assert.That(_salesperson.PayAmount(), Is.EqualTo(BasicSalary + Commission));
        }

        [Test]
        public void Get_a_pay_rise_on_promotion()
        {
            _salesperson.Type = Employee.Manager;

            Assert.That(_salesperson.PayAmount(), Is.EqualTo(BasicSalary + Bonus));
        }

        [Test]
        public void Get_a_pay_cut_on_demotion()
        {
            _salesperson.Type = Employee.Engineer;

            Assert.That(_salesperson.PayAmount(), Is.EqualTo(BasicSalary));
        }
    }
}