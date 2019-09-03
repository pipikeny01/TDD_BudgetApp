using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using TDD_BudgetApp.Entity;
using TDD_BudgetApp.Repos;
using TDD_BudgetApp.Service;

namespace TDD_BudgetApp
{
    public class BudgetTests
    {
        private IRepos<Budget> _stubBudgetRepos = Substitute.For<IRepos<Budget>>();
        private Accounting _accounting;

        [SetUp]
        public void SetUp()
        {
            _accounting = new Accounting(_stubBudgetRepos);
        }

        [Test]
        public void no_budgets()
        {
            GivenBudgets();
            TotalAmountShouldBe(0, new DateTime(2010, 4, 1), new DateTime(2010, 4, 2));
        }

        [Test]
        public void period_inside_budget_month()
        {
            GivenBudgets(new Budget { YearMonth = "201004", Amount = 30 });
            TotalAmountShouldBe(1, new DateTime(2010, 4, 1), new DateTime(2010, 4, 1));
        }

        [Test]
        public void period_no_overlapping_before_budget_firstDay()
        {
            GivenBudgets(new Budget { YearMonth = "201004", Amount = 30 });
            TotalAmountShouldBe(0, new DateTime(2010, 3, 31), new DateTime(2010, 3, 31));
        }

        private void GivenBudgets(params Budget[] givenBudges)
        {
            _stubBudgetRepos.GetAll().Returns(givenBudges.ToList());
        }

        private void TotalAmountShouldBe(int expect, DateTime start, DateTime end)
        {
            var totalAmount = _accounting.TotalAmount(new Period(start, end));
            Assert.AreEqual(expect, totalAmount);
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