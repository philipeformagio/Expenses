using Expenses.Core.Dtos;

namespace Expenses.Core.Interfaces;

public interface IExpensesService
{
    Task<ExpenseDto?> GetAsync(string id);
    Task InsertAsync(ExpenseDto expenseDto);
    Task UpdateAsync(string id, ExpenseDto expenseDto);
}