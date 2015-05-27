namespace RefactoringExamples.ReplaceMethodWithMethodObject
{
    public class ReplaceMethodWithMethodObjectSut
    {
        public int Gamma(int inputVal, int quantity, int yearToDate)
        {
            var importantValue1 = (inputVal*quantity) + Delta();
            var importantValue2 = (inputVal*yearToDate) + 100;
            if ((yearToDate - importantValue2) > 100)
                importantValue2 -= 20;
            var importantValue3 = importantValue2*7;
            return importantValue3 - 2*importantValue1;
        }

        private int Delta()
        {
            return 20;
        }
    }
}