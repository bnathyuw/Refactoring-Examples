using System;

namespace RefactoringExamples.ReplaceTypeCodeWithStateStrategy
{
    public abstract class EmployeeType
    {
        public static EmployeeType FromCode(int value)
        {
            switch (value)
            {
                case Employee.Engineer:
                    return new Engineer();
                case Employee.Salesperson:
                    return new Salesperson();
                case Employee.Manager:
                    return new Manager();
                default:
                    throw new Exception("");
            }
        }

        public abstract int Code { get; }

        public int PayAmount(Employee employee)
        {
            switch (Code)
            {
                case Employee.Engineer:
                    return employee.MonthlySalary;
                case Employee.Salesperson:
                    return employee.MonthlySalary + employee.Commission;
                case Employee.Manager:
                    return employee.MonthlySalary + employee.Bonus;
                default:
                    throw new Exception("Incorrect Employee");
            }
        }
    }

    class Engineer : EmployeeType
    {
        public override int Code => Employee.Engineer;
    }

    class Salesperson : EmployeeType
    {
        public override int Code => Employee.Salesperson;
    }

    class Manager : EmployeeType
    {
        public override int Code => Employee.Manager;
    }
}