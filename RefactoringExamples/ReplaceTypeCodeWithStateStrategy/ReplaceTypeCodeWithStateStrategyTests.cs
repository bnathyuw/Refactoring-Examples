using NUnit.Framework;

namespace RefactoringExamples.ReplaceTypeCodeWithStateStrategy
{
    [TestFixture]
    public class ReplaceTypeCodeWithStateStrategyTests
    {
        private const int EngineerSalary = 100;
        private const int SalespersonSalary = 110;
        private const int ManagerSalary = 120;

        [Test]
        public void An_engineer_is_paid_just_their_salary()
        {
            var engineer = new Employee(Employee.Engineer);

            Assert.That(engineer.PayAmount(), Is.EqualTo(EngineerSalary));
        }

        [Test]
        public void A_salesperson_is_paid_salary_plus_commission()
        {
            var salesperson = new Employee(Employee.Salesperson);

            Assert.That(salesperson.PayAmount(), Is.EqualTo(SalespersonSalary));
        }

        [Test]
        public void A_manager_is_paid_salary_plus_bonus()
        {
            var manager = new Employee(Employee.Manager);

            Assert.That(manager.PayAmount(), Is.EqualTo(ManagerSalary));
        }

        [Test]
        public void An_employees_pay_changes_when_they_change_role()
        {
            var employee = new Employee(Employee.Manager);
            Assert.That(employee.PayAmount(), Is.EqualTo(ManagerSalary));

            employee.EmployeeType = Employee.Engineer;

            Assert.That(employee.PayAmount(), Is.EqualTo(EngineerSalary));
        }
    }
}