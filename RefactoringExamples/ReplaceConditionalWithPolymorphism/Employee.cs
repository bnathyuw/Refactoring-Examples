using System;

namespace RefactoringExamples.ReplaceConditionalWithPolymorphism
{
    public class Employee
    {
        private EmployeeType _employeeType;
        private readonly int _monthlySalary;
        private readonly int _commission;
        private readonly int _bonus;

        public Employee(int type)
        {
            Type = type;
            _monthlySalary = 100;
            _commission = 10;
            _bonus = 20;
        }

        public int Type
        {
            get { return _employeeType.Code; }
            set { _employeeType = EmployeeType.TypeFrom(value); }
        }

        public int PayAmount()
        {
            switch (Type)
            {
                case EmployeeType.Engineer:
                    return _monthlySalary;
                case EmployeeType.Salesperson:
                    return _monthlySalary + _commission;
                case EmployeeType.Manager:
                    return _monthlySalary + _bonus;
                default:
                    throw new Exception("Incorrect Employee");
            }
        }
    }
}