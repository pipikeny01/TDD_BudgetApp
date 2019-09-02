using System.Collections.Generic;

namespace TDD_BudgetApp
{
    public interface IRepos<T>
    {
        List<Budget> GetAll();
    }
}