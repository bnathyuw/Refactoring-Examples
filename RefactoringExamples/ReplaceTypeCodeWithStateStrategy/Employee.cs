using System;

namespace RefactoringExamples.ReplaceTypeCodeWithStateStrategy
{
    public class BasicRemuneration
    {
        public static int BasicSalary(Employee employee)
        {
            return employee.MonthlySalary;
        }
    }

    public class RemunerationWithCommission
    {
        public static int SalaryWithCommission(Employee employee)
        {
            return employee.MonthlySalary + employee.Commission;
        }
    }

    public class RemunerationWithBonus
    {
        public static int SalaryWithBonus(Employee employee)
        {
            return employee.MonthlySalary + employee.Bonus;
        }
    }

    public class Employee
    {
        private int _type;
        public int MonthlySalary { get; }
        public int Commission { get; }
        public int Bonus { get; }
        public const int Engineer = 0;
        public const int Salesperson = 1;
        public const int Manager = 2;

        public Employee(int type)
        {
            _type = type;
            MonthlySalary = 100;
            Commission = 10;
            Bonus = 20;
        }

        public int Type
        {
            set { _type = value; }
        }

        public int PayAmount()
        {
            switch (_type)
            {
                case Employee.Engineer:
                    return BasicRemuneration.BasicSalary(this);
                case Employee.Salesperson:
                    return RemunerationWithCommission.SalaryWithCommission(this);
                case Employee.Manager:
                    return RemunerationWithBonus.SalaryWithBonus(this);
                default:
                    throw new Exception("Incorrect Employee");
            }
        }
    }
}