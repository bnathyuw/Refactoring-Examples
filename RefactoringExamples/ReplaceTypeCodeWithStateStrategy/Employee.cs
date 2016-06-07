using System;

namespace RefactoringExamples.ReplaceTypeCodeWithStateStrategy
{
    public class Employee
    {
        private readonly int _monthlySalary;
        private readonly int _commission;
        private readonly int _bonus;
        private int _type;
        private EmployeeType _employeeType;
        public const int Engineer = 0;
        public const int Salesperson = 1;
        public const int Manager = 2;

        public Employee(int type)
        {
            Type = type;
            _monthlySalary = 100;
            _commission = 10;
            _bonus = 20;
        }

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int PayAmount()
        {
            switch (Type)
            {
                case Engineer:
                    return _monthlySalary;
                case Salesperson:
                    return _monthlySalary + _commission;
                case Manager:
                    return _monthlySalary + _bonus;
                default:
                    throw new Exception("Incorrect Employee");
            }
        }
    }
}