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
    }

    class Engineer : EmployeeType
    {
    }

    class Salesperson : EmployeeType
    {
    }

    class Manager : EmployeeType
    {
    }
}