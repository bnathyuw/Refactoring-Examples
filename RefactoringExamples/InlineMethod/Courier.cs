namespace RefactoringExamples.InlineMethod
{
    public class Courier
    {
        private readonly int _numberOfLateDeliveries;

        public Courier(int numberOfLateDeliveries)
        {
            _numberOfLateDeliveries = numberOfLateDeliveries;
        }

        public int GetRating()
        {
            return (MoreThanFiveLateDeliveries()) ? 2 : 1;
        }

        private bool MoreThanFiveLateDeliveries()
        {
            return _numberOfLateDeliveries > 5;
        }
    }
}