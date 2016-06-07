using System;

namespace RefactoringExamples.ReplaceTypeCodeWithStateStrategy
{
    public class Employee
    {
        public int MonthlySalary { get; }
        public int Commission { get; }
        public int Bonus { get; }
        private EmployeeType _employeeType;
        public const int Engineer = 0;
        public const int Salesperson = 1;
        public const int Manager = 2;

        public Employee(int type)
        {
            Type = type;
            MonthlySalary = 100;
            Commission = 10;
            Bonus = 20;
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
                    return employee.MonthlySalary;
                case Salesperson:
                    return employee.MonthlySalary + employee.Commission;
                case Manager:
                    return employee.MonthlySalary + employee.Bonus;
                default:
                    throw new Exception("Incorrect Employee");
            }
        }
    }
}