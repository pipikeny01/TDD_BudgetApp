using System;
using System.Linq;

namespace TDD_BudgetApp
{
    public class Accounting
    {
        private readonly IBudgetRepository _budgetRepository;

        public Accounting(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public decimal TotalAmount(DateTime start, DateTime end)
        {
            var budgets = _budgetRepository.GetAll();

            decimal total = 0;

            var period = new Period(start, end);

            foreach (var budget in budgets)
            {
                total += (decimal)(period.OverlappingDays(budget) * budget.DailyAmount());
            }

            return total;
        }
    }
}