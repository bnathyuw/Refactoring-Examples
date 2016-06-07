using System;

namespace RefactoringExamples.ReplaceTypeCodeWithStateStrategy
{
    public class Employee
    {
        private int _type;
        private readonly int _monthlySalary;
        private readonly int _commission;
        private readonly int _bonus;
        public const int Engineer = 0;
        public const int Salesperson = 1;
        public const int Manager = 2;

        public Employee(int type)
        {
            _type = type;
            _monthlySalary = 100;
            _commission = 10;
            _bonus = 20;
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
                    return BasicSalary();
                case Salesperson:
                    return SalaryWithCommission();
                case Manager:
                    return SalaryWithBonus();
                default:
                    throw new Exception("Incorrect Employee");
            }
        }

        private int BasicSalary()
        {
            return _monthlySalary;
        }

        private int SalaryWithCommission()
        {
            return _monthlySalary + _commission;
        }

        private int SalaryWithBonus()
        {
            return _monthlySalary + _bonus;
        }
    }
}