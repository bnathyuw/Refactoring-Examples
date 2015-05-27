using System;

namespace RefactoringExamples.ReplaceTypeCodeWithStateStrategy
{
    public class Employee
    {
        private int _type;
        private const int MonthlySalary = 100;
        private const int Commission = 10;
        private const int Bonus = 20;
        public const int ENGINEER = 0;
        public const int SALESPERSON = 1;
        public const int MANAGER = 2;

        public Employee(int type)
        {
            _type = type;
        }

        public int EmployeeType
        {
            get { return _type; }
            set { _type = value; }
        }

        public int PayAmount()
        {
            switch (_type)
            {
                case ENGINEER:
                    return MonthlySalary;
                case SALESPERSON:
                    return MonthlySalary + Commission;
                case MANAGER:
                    return MonthlySalary + Bonus;
                default:
                    throw new Exception("Incorrect Employee");
            }
        }
    }
}