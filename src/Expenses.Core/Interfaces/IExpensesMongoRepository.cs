using Expenses.Core.Entites;
using System.Collections;

namespace Expenses.Core.Interfaces;

public interface IExpensesMongoRepository
{
    Task<Expense?> GetAsync(string id);
    Task<IEnumerable<Expense?>> GetAsync();
    Task InsertAsync(Expense expense);
    Task UpdateAsync(string id, Expense updatedExpense);
}