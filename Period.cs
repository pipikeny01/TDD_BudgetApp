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

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public double OverlappingDays(Period anotherPeriod)
        {
            if (InvalidDay() || NoOverlapping(anotherPeriod)) return 0;

            var effectiveStart = Start;
            var effectiveEnd = End;

            if (Start <= anotherPeriod.Start && End <= anotherPeriod.End)
            {
                effectiveStart = anotherPeriod.Start;
                effectiveEnd = End;
            }

            if (Start <= anotherPeriod.End && End >= anotherPeriod.End)
            {
                effectiveStart = Start;
                effectiveEnd = anotherPeriod.End;
            }

            return (effectiveEnd - effectiveStart).TotalDays + 1;
        }

        private bool InvalidDay()
        {
            return Start >End;
        }

        private bool NoOverlapping(Period anotherPeriod)
        {
            return End < anotherPeriod.Start || Start > anotherPeriod.End;
        }
    }
}