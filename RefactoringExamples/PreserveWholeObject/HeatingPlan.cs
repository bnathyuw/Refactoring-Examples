namespace RefactoringExamples.PreserveWholeObject
{
    public class HeatingPlan
    {
        private readonly TempRange _range;

        public HeatingPlan(TempRange range)
        {
            _range = range;
        }

        public bool WithinRange(int low, int high)
        {
            return low >= _range.Low && high <= _range.High;
        }
    }
}