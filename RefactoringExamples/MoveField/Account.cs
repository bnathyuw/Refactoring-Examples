namespace RefactoringExamples.MoveField
{
    public class Account
    {
        private AccountType _type;
        private readonly double _interestRate;

        public Account(AccountType type, double interestRate)
        {
            _type = type;
            _interestRate = interestRate;
        }

        public double InterestForAmount_Days(double amount, int days)
        {
            return _interestRate*amount*days/365;
        } 
    }
}