using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD_BudgetApp
{
    public class BudgetTests
    {
        private Account _account;
        private IRepos<Budget> _stubBudgetRepos;

        [SetUp]
        public void Setup()
        {
            _stubBudgetRepos = Substitute.For<IRepos<Budget>>();
            _account = new Account(_stubBudgetRepos);
        }

        [Test]
        public void InvalidDate()
        {
            var start = new DateTime(2019, 4, 2);
            var end = new DateTime(2019, 4, 1);
            decimal? expect = null;
            ShouldBe(expect, start, end);
        }

        [Test]
        public void no_budgets()
        {
            var start = new DateTime(2019, 4, 1);
            var end = new DateTime(2019, 4, 1);
            var expect = 0;
            _stubBudgetRepos.GetAll().Returns(new List<Budget>());
            ShouldBe(expect, start, end);
        }

        [Test]
        public void period_inside_budget_month()
        {
            var start = new DateTime(2019, 4, 1);
            var end = new DateTime(2019, 4, 1);
            var expect = 1;
            GivenBudgets(new Budget { YearMonth = "201904", Amount = 30 });
            ShouldBe(expect, start, end);
        }


        [Test(Description = "輸入的日期在有budget之前回傳0")]
        public void period_no_overlapping_before_budget_firstDay()
        {
            GivenBudgets(new Budget { YearMonth = "201904", Amount = 30 });
            ShouldBe(expect: 0, start: new DateTime(2019, 3, 31), end: new DateTime(2019,3, 31));
        }

        [Test(Description = "輸入的日期在有budget之後回傳0")]
        public void period_no_overlapping_after_budget_lastDay()
        {
            GivenBudgets(new Budget { YearMonth = "201003", Amount = 31 });
            GivenBudgets(new Budget { YearMonth = "201004", Amount = 30 });
            ShouldBe(0, new DateTime(2010, 5, 1), new DateTime(2010, 5, 1));
        }


        [Test]
        public void period_overlapping_budget_firstDay()
        {
            GivenBudgets(new Budget { YearMonth = "201004", Amount = 30 });
            ShouldBe(1, new DateTime(2010, 3, 31), new DateTime(2010, 4, 1));
        }

        [Test]
        public void period_overlapping_budget_lastDay()
        {
            GivenBudgets(new Budget { YearMonth = "201004", Amount = 30 });
            ShouldBe(1, new DateTime(2010, 4, 30), new DateTime(2010, 5, 1));
        }

        [Test]
        public void Daily_Amount_is_10()
        {
            GivenBudgets(new Budget { YearMonth = "201004", Amount = 300 });
            ShouldBe(20, new DateTime(2010, 4, 1), new DateTime(2010, 4, 2));
        }

        [Test]
        public void multiple_budgets()
        {
            GivenBudgets(
                new Budget { YearMonth = "201004", Amount = 300 },
                new Budget { YearMonth = "201005", Amount = 31 });
            ShouldBe(12, new DateTime(2010, 4, 30), new DateTime(2010, 5, 2));
        }

        private void GivenBudgets(params Budget[] budgets)
        {
            _stubBudgetRepos.GetAll().Returns(budgets.ToList());
        }

        private void ShouldBe(decimal? expect, DateTime start, DateTime end)
        {
            var result = _account.TotalAmount(start, end);
            Assert.AreEqual(expect, result);
        }
    }
}