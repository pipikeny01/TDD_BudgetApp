using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TDD_BudgetApp.Service;

namespace TDD_BudgetApp
{
    public class BudgetTests
    {
        private BudgetService _budgetService;
        private IRepos<Budget> _stubBudgetRepos;

        [SetUp]
        public void Setup()
        {
            _stubBudgetRepos = Substitute.For<IRepos<Budget>>();
            _budgetService = new BudgetService(_stubBudgetRepos);
        }

        [Test]
        public void no_budgets()
        {
            GivenBudgets();
            TotalAmountShouldBe(0, new DateTime(2019, 08, 01), new DateTime(2019, 08, 01));
        }

        [Test]
        public void period_inside_budget_month()
        {
            GivenBudgets(new Budget { YearMonth = "201909", Amount = 30 });
            TotalAmountShouldBe(1, new DateTime(2019, 09, 01), new DateTime(2019, 09, 01));
        }


        [Test]
        public void period_no_overlapping_before_budget_firstDay()
        {
            GivenBudgets(new Budget { YearMonth = "201004", Amount = 30 });
            TotalAmountShouldBe(0, new DateTime(2010, 3, 31), new DateTime(2010, 3, 31));
        }


        private void GivenBudgets(params Budget[] budgets)
        {
            _stubBudgetRepos.GetAll()
                .Returns(budgets.ToList());
        }

        private void TotalAmountShouldBe(int expected, DateTime start, DateTime end)
        {
            var totalAmount = _budgetService.TotalAmount(start, end);
            Assert.AreEqual(expected, totalAmount);
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

    public class Budget
    {
        public string YearMonth { get; set; }
        public decimal Amount { get; set; }

        public DateTime FirstDay()
        {
            return DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);
        }
    }

    public interface IRepos<T>
    {
        List<Budget> GetAll();
    }
}