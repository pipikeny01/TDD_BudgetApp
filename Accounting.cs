using System;

namespace TDD_BudgetApp
{
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