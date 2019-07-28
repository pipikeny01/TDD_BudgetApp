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

        public double TotalAmount(DateTime start, DateTime end)
        {

            var budgets = _budgetRepository.GetAll();

            if (budgets.Any())
            {
                return (end - start).TotalDays; 
            }

            return 0;
        }
    }
}