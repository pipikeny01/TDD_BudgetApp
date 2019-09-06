using System;
using System.Linq;
using TDD_BudgetApp.Helper;

namespace TDD_BudgetApp.Service
{
    public class BudgetService
    {
        private readonly IRepos<Budget> _budgetRepos;

        public BudgetService(IRepos<Budget> stubBudgetRepos)
        {
            _budgetRepos = stubBudgetRepos;
            
        }

        public decimal TotalAmount(DateTime start, DateTime end)
        {
            var budgets = _budgetRepos.GetAll();
            var period = new Period(start, end);

            if (!budgets.Any()) return 0;

            var budget = budgets.First();

            if (period.End < budget.FirstDay())
            {
                return 0;
            }

            return period.Days();

        }
    }
}