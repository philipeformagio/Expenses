using Expenses.Core.Entites;
using System.Collections;

namespace Expenses.Core.Interfaces;

public interface IExpensesMongoRepository
{
    Task<Expense> Get(int id);
    Task<IEnumerable<Expense>> GetAll();
    Task<Expense> Insert(Expense expense);
    Task<Expense> Update(Expense expense);
}