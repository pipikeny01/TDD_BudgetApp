using System;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace TDD_BudgetApp
{
    public class BudgetTests
    {


        [Test]
        public void no_budgets()
        {
        }

        //[Test]
        //public void period_inside_budget_month()
        //{
        //    GivenBudgets(new Budget { YearMonth = "201004", Amount = 30 });
        //    TotalAmountShouldBe(1, new DateTime(2010, 4, 1), new DateTime(2010, 4, 1));
        //}

        //[Test(Description = "輸入的日期在有budget之前回傳0")]
        //public void period_no_overlapping_before_budget_firstDay()
        //{
        //    GivenBudgets(new Budget { YearMonth = "201004", Amount = 30 });
        //    TotalAmountShouldBe(0, new DateTime(2010, 3, 31), new DateTime(2010, 3, 31));
        //}

        //[Test(Description = "輸入的日期在有budget之後回傳0")]
        //public void period_no_overlapping_after_budget_lastDay()
        //{
        //    GivenBudgets(new Budget { YearMonth = "201003", Amount = 31 });
        //    GivenBudgets(new Budget { YearMonth = "201004", Amount = 30 });
        //    TotalAmountShouldBe(0, new DateTime(2010, 5, 1), new DateTime(2010, 5, 1));
        //}

        //[Test]
        //public void Daily_Amount_is_10()
        //{
        //    GivenBudgets(new Budget { YearMonth = "201004", Amount = 300 });
        //    TotalAmountShouldBe(20, new DateTime(2010, 4, 1), new DateTime(2010, 4, 2));
        //}

    }
}