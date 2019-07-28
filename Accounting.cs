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

            if (budgets.Any())
            {
                var budget = budgets.First();
                var period = new Period(start, end);

                return (decimal)(period.OverlappingDays(budget) * budget.DailyAmount());
            }

            return 0;
        }
    }
}