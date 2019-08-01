using System;

namespace TDD_BudgetApp
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public int Amount { get; set; }

        public DateTime FirstDay => DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);

        public DateTime LastDay => FirstDay.AddMonths(1).AddDays(-FirstDay.AddMonths(1).Day);

        public double DayAmount()
        {
            return Amount / ((LastDay - FirstDay).TotalDays + 1);
        }

        public double CalcAmount(Period period)
        {
            return DayAmount() * period.OverlappingDays(CreatePeriod());
        }

        private Period CreatePeriod()
        {
           return  new Period(FirstDay,LastDay );
        }
    }
}