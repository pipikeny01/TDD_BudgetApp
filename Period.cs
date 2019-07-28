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
            if (Start > budget.LastDay)
            {
                return 0;
            }
            if (End < budget.FirstDay)
            {
                return 0;
            }

            return Days();
        }
    }
}