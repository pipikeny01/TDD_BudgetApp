using System;

namespace TDD_BudgetApp.Entity
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

        public int Days()
        {
            return (Start - End).Days + 1;
        }

        public double OverlappingDays(Budget budget)
        {
            if (End < budget.FirstDay)
            {
                return 0;
            }

            return Days();
        }
    }
}