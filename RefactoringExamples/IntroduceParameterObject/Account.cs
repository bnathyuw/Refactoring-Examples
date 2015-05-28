using System;
using System.Collections.Generic;

namespace RefactoringExamples.IntroduceParameterObject
{
    class Account
    {
        private readonly IEnumerable<Entry> _entries;

        public Account(IEnumerable<Entry> entries)
        {
            _entries = entries;
        }

        public double GetFlowBetween(DateTime start, DateTime end)
        {
            double result = 0;
            foreach (var entry in _entries)
            {
                if (entry.Date == start || entry.Date == end || (entry.Date > start && entry.Date < end))
                {
                    result += entry.Value;
                }
            }
            return result;
        } 
    }
}