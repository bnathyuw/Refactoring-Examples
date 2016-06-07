using System;

namespace RefactoringExamples.ReplaceTypeCodeWithStateStrategy
{
    public abstract class Remuneration
    {
        public abstract int PayAmount(Employee employee);

        public static Remuneration FromType(int type)
        {
            switch (type)
            {
                case Employee.Engineer:
                    return new BasicRemuneration();
                case Employee.Salesperson:
                    return new RemunerationWithCommission();
                case Employee.Manager:
                    return new RemunerationWithBonus();
                default:
                    throw new Exception("Incorrect Employee");
            }
        }
    }

    public class BasicRemuneration : Remuneration
    {
        public override int PayAmount(Employee employee)
        {
            return employee.MonthlySalary;
        }
    }

    public class RemunerationWithCommission : Remuneration
    {
        public override int PayAmount(Employee employee)
        {
            return employee.MonthlySalary + employee.Commission;
        }
    }

    public class RemunerationWithBonus : Remuneration
    {
        public override int PayAmount(Employee employee)
        {
            return employee.MonthlySalary + employee.Bonus;
        }
    }

    public class Employee
    {
        private Remuneration _remuneration;
        public int MonthlySalary { get; }
        public int Commission { get; }
        public int Bonus { get; }
        public const int Engineer = 0;
        public const int Salesperson = 1;
        public const int Manager = 2;

        public Employee(int type)
        {
            _remuneration = Remuneration.FromType(type);
            MonthlySalary = 100;
            Commission = 10;
            Bonus = 20;
        }

        public int Type
        {
            set
            {
                _remuneration = Remuneration.FromType(value);
            }
        }

        public int PayAmount()
        {
            return _remuneration.PayAmount(this);
        }
    }
}