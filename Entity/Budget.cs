using System;

namespace TDD_BudgetApp.Entity
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public decimal Amount { get; set; }

        public DateTime FirstDay => DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);
    }
}