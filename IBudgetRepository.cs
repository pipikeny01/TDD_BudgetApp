using System.Collections.Generic;

namespace TDD_BudgetApp
{
    public interface IBudgetRepository
    {
        List<Budget> GetAll();
    }
}