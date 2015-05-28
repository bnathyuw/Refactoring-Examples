using System;

namespace RefactoringExamples.IntroduceParameterObject
{
    public class Entry
    {
        private readonly double _value;
        private readonly DateTime _chargeDate;

        public Entry(double value, DateTime chargeDate)
        {
            _value = value;
            _chargeDate = chargeDate;
        }

        public DateTime Date
        {
            get { return _chargeDate; }
        }

        public double Value
        {
            get { return _value; }
        }
    }
}