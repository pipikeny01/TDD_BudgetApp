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


            return 0;
        }
    }
}