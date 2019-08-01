using System;

namespace TDD_BudgetApp
{
    public class Accounting
    {
        private readonly IBudgetRepository _budgetRepository;

        public Accounting(IBudgetRepository stubBudgetRepository)
        {
            _budgetRepository = stubBudgetRepository;
        }

        public double TotalAmount(DateTime start, DateTime end)
        {
            var period = new Period(start, end);


            var budgets = _budgetRepository.GetAll();

            double sum = 0;
            foreach (var budget in budgets)
            {
                sum += budget.CalcAmount(period);
            }

            return sum;
        }
    }
}