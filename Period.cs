using System;

namespace TDD_BudgetApp
{
    public class Period
    {
        public Period(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; }
        public DateTime End { get; }

        public bool Invalid()
        {
            return Start > End;
        }

        public int OverlappingDays(Period another)
        {
            if (Invalid() || HasNoOverLapping(another))
            {
                return 0;
            }

            var effectiveStart = another.Start > Start ? another.Start : Start;

            var effectiveEnd = another.End < End ? another.End : End;

            return (effectiveEnd - effectiveStart).Days + 1;
        }

        private bool HasNoOverLapping(Period another)
        {
            return Start > another.End || End < another.Start;
        }
    }
}