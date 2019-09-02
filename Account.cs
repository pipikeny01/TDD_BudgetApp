using System;
using System.Linq;

namespace TDD_BudgetApp
{
    public class Account
    {
        private readonly IRepos<Budget> _budgetRepos;

        public Account(IRepos<Budget> budgetRepos)
        {
            _budgetRepos = budgetRepos;
        }

        public decimal? TotalAmount(DateTime start, DateTime end)
        {
            var period = new Period(start, end);

            if (period.Invalid()) return null;

            return _budgetRepos.GetAll().Sum(budget=> budget.OverlappingAmount(period));
        }
    }
}