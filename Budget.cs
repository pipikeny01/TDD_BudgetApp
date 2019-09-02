using System;

namespace TDD_BudgetApp
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public decimal Amount { get; set; }

        private DateTime FirstDay => DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);

        private DateTime LastDay {
            get
            {
                var daysInMonth = DateTime.DaysInMonth(FirstDay.Year,FirstDay.Month);
                return  new DateTime(FirstDay.Year,FirstDay.Month,daysInMonth);
            }
        }

        private int Days()
        {
            return (LastDay - FirstDay).Days + 1;
        }

        private decimal DaliAmount()
        {
            return Amount / Days();
        }

        private Period CreatePeriod()
        {
            return new Period(FirstDay, LastDay);
        }

        public decimal OverlappingAmount(Period period)
        {
            return DaliAmount() * period.OverlappingDays(CreatePeriod());
        }
    }
}