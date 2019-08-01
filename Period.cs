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

        public double OverlappingDays(Budget budget)
        {
            if (InvalidDay() || NoOverlapping(budget)) return 0;

            var effectiveStart = Start;
            var effectiveEnd = End;

            if (Start <= budget.FirstDay && End <= budget.LastDay)
            {
                effectiveStart = budget.FirstDay;
                effectiveEnd = End;
            }

            if (Start <= budget.LastDay && End >= budget.LastDay)
            {
                effectiveStart = Start;
                effectiveEnd = budget.LastDay;
            }

            return (effectiveEnd - effectiveStart).TotalDays + 1;
        }

        private bool InvalidDay()
        {
            return Start >End;
        }

        private bool NoOverlapping(Budget budget)
        {
            return End < budget.FirstDay || Start > budget.LastDay;
        }
    }
}