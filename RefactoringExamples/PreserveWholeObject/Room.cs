namespace RefactoringExamples.PreserveWholeObject
{
    public class Room
    {
        private readonly TempRange _daysTempRange;

        public Room(TempRange daysTempRange)
        {
            _daysTempRange = daysTempRange;
        }

        public bool WithinPlan(HeatingPlan heatingPlan)
        {
            var low = _daysTempRange.Low;
            var high = _daysTempRange.High;
            return heatingPlan.WithinRange(low, high);
        }
    }
}