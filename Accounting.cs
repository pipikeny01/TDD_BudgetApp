using System;
using System.Collections.Generic;
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

            var period = new Period(start, end);
            var queryBudgets = SelectBudgets(start, end, budgets);

            int sum = 0;
            foreach (var budget in queryBudgets)
            {
                sum += budget.DayAmount() * period.EffectiveDays(budget);
            }

            return sum;
        }

        private static List<Budget> SelectBudgets(DateTime start, DateTime end, List<Budget> budgets)
        {
            var queryBudgets = budgets
                .Where(p => int.Parse(p.YearMonth) >= int.Parse(start.ToString("yyyyMM")) && 
                            int.Parse(p.YearMonth) <= int.Parse(end.ToString("yyyyMM"))).ToList();

            return queryBudgets;
        }
    }
}