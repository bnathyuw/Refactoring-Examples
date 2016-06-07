using System;

namespace RefactoringExamples.ReplaceTypeCodeWithStateStrategy
{
    public abstract class Remuneration
    {
        public abstract int PayAmount(Employee employee);
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
        private int _type;
        public int MonthlySalary { get; }
        public int Commission { get; }
        public int Bonus { get; }
        public const int Engineer = 0;
        public const int Salesperson = 1;
        public const int Manager = 2;

        public Employee(int type)
        {
            _type = type;
            MonthlySalary = 100;
            Commission = 10;
            Bonus = 20;
        }

        public int Type
        {
            set { _type = value; }
        }

        public int PayAmount()
        {
            switch (_type)
            {
                case Employee.Engineer:
                    Remuneration remuneration;
                    remuneration = new BasicRemuneration();
                    return remuneration.PayAmount(this);
                case Employee.Salesperson:
                    return new RemunerationWithCommission().PayAmount(this);
                case Employee.Manager:
                    return new RemunerationWithBonus().PayAmount(this);
                default:
                    throw new Exception("Incorrect Employee");
            }
        }
    }
}