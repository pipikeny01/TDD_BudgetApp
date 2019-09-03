using System.Collections.Generic;

namespace TDD_BudgetApp.Repos
{
    public interface IRepos<T>
    {
        List<T> GetAll();
    }
}