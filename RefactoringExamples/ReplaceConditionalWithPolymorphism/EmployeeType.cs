using System;

namespace RefactoringExamples.ReplaceConditionalWithPolymorphism
{
    public abstract class EmployeeType
    {
        public abstract int Code { get; }

        public static EmployeeType TypeFrom(int value)
        {
            switch (value)
            {
                case Engineer:
                    return new Engineer();
                case Salesperson:
                    return new Salesperson();
                case Manager:
                    return new Manager();
                default:
                    throw new Exception("Incorrect Employee Code");
            }
        }

        public const int Engineer = 0;
        public const int Salesperson = 1;
        public const int Manager = 2;
    }

    class Engineer : EmployeeType
    {
        public override int Code => Engineer;
    }

    class Salesperson : EmployeeType
    {
        public override int Code => Salesperson;
    }

    class Manager : EmployeeType
    {
        public override int Code => Manager;
    }
}