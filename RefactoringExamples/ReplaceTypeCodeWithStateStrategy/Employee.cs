using System;

namespace RefactoringExamples.ReplaceTypeCodeWithStateStrategy
{
    public class Employee
    {
        private int _type;
        private const int MonthlySalary = 100;
        private const int Commission = 10;
        private const int Bonus = 20;
        public const int Engineer = 0;
        public const int Salesperson = 1;
        public const int Manager = 2;

        public Employee(int type)
        {
            _type = type;
        }

        public int EmployeeType
        {
            set { _type = value; }
        }

        public int PayAmount()
        {
            switch (_type)
            {
                case Engineer:
                    return MonthlySalary;
                case Salesperson:
                    return MonthlySalary + Commission;
                case Manager:
                    return MonthlySalary + Bonus;
                default:
                    throw new Exception("Incorrect Employee");
            }
        }
    }
}