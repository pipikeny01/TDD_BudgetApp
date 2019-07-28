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

        public DateTime End { get; private set; }
        public DateTime Start { get; private set; }

        public double Days()
        {
            return (End - Start).TotalDays + 1;
        }

        public double OverlappingDays(Budget budget)
        {
            if (End < Start)
                return 0;


            if (Start > budget.LastDay || End < budget.FirstDay)
            {
                return 0;
            }

            var effectiveStart = budget.FirstDay > Start
                ? budget.FirstDay
                : Start;

            var effectiveEnd = budget.LastDay < End
                ? budget.LastDay
                : End;

            return (effectiveEnd - effectiveStart).TotalDays + 1;
        }
    }
}