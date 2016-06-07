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

        public abstract int PayAmount(Employee employee);
    }

    class Engineer : EmployeeType
    {
        public override int PayAmount(Employee employee)
        {
            switch (Employee.Engineer)
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

    class Salesperson : EmployeeType
    {
        public virtual int Code => Employee.Salesperson;

        public override int PayAmount(Employee employee)
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

    class Manager : EmployeeType
    {
        public virtual int Code => Employee.Manager;

        public override int PayAmount(Employee employee)
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
}