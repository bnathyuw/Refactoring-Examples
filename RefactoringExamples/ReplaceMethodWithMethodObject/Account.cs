namespace RefactoringExamples.ReplaceMethodWithMethodObject
{
    public class Gamma
    {
        private readonly Account _account;
        private readonly int _inputVal;
        private readonly int _quantity;
        private readonly int _yearToDate;
        private int _importantValue1;
        private int _importantValue2;
        private int _importantValue3;

        public Gamma(Account account, int inputVal, int quantity, int yearToDate)
        {
            _account = account;
            _inputVal = inputVal;
            _quantity = quantity;
            _yearToDate = yearToDate;
        }

        public int Compute()
        {
            _importantValue1 = (_inputVal*_quantity) + _account.Delta();
            _importantValue2 = (_inputVal*_yearToDate) + 100;
            if ((_yearToDate - _importantValue2) > 100)
                _importantValue2 -= 20;
            _importantValue3 = _importantValue2*7;
            return _importantValue3 - 2*_importantValue1;
        }
    }

    public class Account
    {
        public int Gamma(int inputVal, int quantity, int yearToDate)
        {
            return new Gamma(this, inputVal, quantity, yearToDate).Compute();
        }

        public int Delta()
        {
            return 20;
        }
    }
}