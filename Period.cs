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

        public int EffectiveDays(Budget budget)
        {
            var effectStart = Start > budget.FirstDay 
                ? Start 
                : budget.FirstDay;

            var effectEnd = budget.LastDay > End 
                ? End 
                : budget.LastDay;

            return (effectEnd - effectStart).Days + 1;
        }
    }
}