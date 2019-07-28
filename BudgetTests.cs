using System;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace TDD_BudgetApp
{
    public class BudgetTests
    {
        private Accounting _accounting;
        private IBudgetRepository _stubBudgetRepository;

        [SetUp]
        public void Setup()
        {
            _stubBudgetRepository = Substitute.For<IBudgetRepository>();
            _accounting = new Accounting(_stubBudgetRepository);
         }

        [Test]
        public void no_budgets()
        {
            GivenBudgets();
            TotalAmountShouldBe(0, new DateTime(2010, 4, 1), new DateTime(2010, 4, 1));
        }

        [Test]
        public void period_inside_budget_month()
        {
            GivenBudgets(new Budget { YearMonth = "201004", Amount = 30 });
            TotalAmountShouldBe(1, new DateTime(2010, 4, 1), new DateTime(2010, 4, 1));
        }


        //[Test]
        //public void Daily_Amount_is_10()
        //{
        //    GivenBudgets(new Budget { YearMonth = "201004", Amount = 300 });
        //    TotalAmountShouldBe(20, new DateTime(2010, 4, 1), new DateTime(2010, 4, 2));
        //}

        private void TotalAmountShouldBe(int expect, DateTime start, DateTime end)
        {
            Assert.AreEqual(expect, _accounting.TotalAmount(start, end));
        }

        private void GivenBudgets(params Budget[] budgets)
        {
            _stubBudgetRepository.GetAll().Returns(budgets.ToList());
        }
    }

    public class Budget
    {
        public string YearMonth { get; set; }
        public int Amount { get; set; }
    }
}