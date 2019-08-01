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
            if (End < budget.FirstDay || Start > budget.LastDay)
            {
                return 0;
            }

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
    }

    public class Accounting
    {
        private readonly IBudgetRepository _budgetRepository;

        public Accounting(IBudgetRepository stubBudgetRepository)
        {
            _budgetRepository = stubBudgetRepository;
        }

        public double TotalAmount(DateTime start, DateTime end)
        {
            if (start > end) return 0;

            var budgets = _budgetRepository.GetAll();

            double sum = 0;
            var period = new Period(start, end);
            foreach (var budget in budgets)
            {
                sum += budget.DayAmount() * period.OverlappingDays(budget);
            }

            return sum;
        }
    }
}