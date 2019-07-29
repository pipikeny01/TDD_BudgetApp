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

            var queryBudgets = budgets.Where(p=>
            {
                var dateTime = ParseExact(p);
                return dateTime >= start && dateTime <= end;
            }).ToList();

            if (queryBudgets.Count > 0)
            {
                var firstOrDefault = queryBudgets.FirstOrDefault();
                return firstOrDefault.Amount / ParseExact(firstOrDefault).;
            }

            return 0;
        }

        private static DateTime ParseExact(Budget p)
        {
            return DateTime.ParseExact(p.YearMonth + "01","yyyyMMdd",null);
        }
    }
}