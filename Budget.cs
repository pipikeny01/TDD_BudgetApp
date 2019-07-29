using System;

namespace TDD_BudgetApp
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public int Amount { get; set; }

        public DateTime ParseExact => DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);

        public int Days => DateTime.DaysInMonth(ParseExact.Year, ParseExact.Month);

        public DateTime FirstDay => DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);
        public DateTime LastDay
        {
            get
            {
                var daysInMonth = DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
                return new DateTime(FirstDay.Year, FirstDay.Month, daysInMonth);
            }
        }

        public int DayAmount()
        {
            return Amount / Days;
        }
    }
}