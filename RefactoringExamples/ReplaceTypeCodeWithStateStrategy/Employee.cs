using System;

namespace RefactoringExamples.ReplaceTypeCodeWithStateStrategy
{
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
                case Engineer:
                    return BasicSalary(this);
                case Salesperson:
                    return SalaryWithCommission(this);
                case Manager:
                    return SalaryWithBonus(this);
                default:
                    throw new Exception("Incorrect Employee");
            }
        }

        private static int BasicSalary(Employee employee)
        {
            return employee.MonthlySalary;
        }

        private static int SalaryWithCommission(Employee employee)
        {
            return employee.MonthlySalary + employee.Commission;
        }

        private static int SalaryWithBonus(Employee employee)
        {
            return employee.MonthlySalary + employee.Bonus;
        }
    }
}