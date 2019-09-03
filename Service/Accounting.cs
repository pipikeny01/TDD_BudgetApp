using System.Linq;
using TDD_BudgetApp.Entity;
using TDD_BudgetApp.Repos;

namespace TDD_BudgetApp.Service
{
    public class Accounting
    {
        private readonly IRepos<Budget> _budgetRepos;

        public Accounting(IRepos<Budget> stubBudgetRepos)
        {
            _budgetRepos = stubBudgetRepos;
        }

        public double TotalAmount(Period period)
        {
            var budgets = _budgetRepos.GetAll();
            if (budgets.Any())
            {
                var budget = budgets.FirstOrDefault();

                return period.OverlappingDays(budget);
            }

            return 0;
        }
    }
}