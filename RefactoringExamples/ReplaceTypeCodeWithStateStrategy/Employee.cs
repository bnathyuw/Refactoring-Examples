using System;

namespace RefactoringExamples.ReplaceTypeCodeWithStateStrategy
{
    public class Employee
    {
        private readonly int _monthlySalary;
        private readonly int _commission;
        private readonly int _bonus;
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
            set { _employeeType = EmployeeType.FromCode(value); }
        }

        public int PayAmount()
        {
            return Pay(this, _employeeType);
        }

        private static int Pay(Employee employee, EmployeeType employeeType)
        {
            switch (employeeType.Code)
            {
                case Engineer:
                    return employee._monthlySalary;
                case Salesperson:
                    return employee._monthlySalary + employee._commission;
                case Manager:
                    return employee._monthlySalary + employee._bonus;
                default:
                    throw new Exception("Incorrect Employee");
            }
        }
    }
}