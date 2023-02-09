using AutoMapper;

using Expenses.Core.Interfaces;
using Expenses.Core.Dtos;
using Expenses.Core.Entites;

namespace Expenses.Core.Services;

public class ExpensesService : IExpensesService
{
    private readonly IMapper _mapper;
    private readonly IExpensesMongoRepository _expensesRepository;
    public ExpensesService(IMapper mapper,
                           IExpensesMongoRepository expensesRepository)
    {
        _mapper = mapper;
        _expensesRepository = expensesRepository;
    }

    public async Task<ExpenseDto?> GetAsync(string id)
    {
        var expenseEntity = await _expensesRepository.GetAsync(id);

        if(expenseEntity is null)
        {
            return null;
        }

        return _mapper.Map<ExpenseDto>(expenseEntity);
    }

    public async Task InsertAsync(ExpenseDto expenseDto)
    {
        var entity = _mapper.Map<Expense>(expenseDto);
        entity.CreateEntityToSave();

        if (entity.IsValid())
            await _expensesRepository.InsertAsync(entity);
    }

    public async Task UpdateAsync(string id, ExpenseDto expenseDto)
    {
        var entity = await _expensesRepository.GetAsync(id);

        if(entity is null  || entity.Id != id) return;

        entity.Name = expenseDto.Name;
        entity.Price = expenseDto.Price.HasValue ? expenseDto.Price.GetValueOrDefault() : 0;

        await _expensesRepository.UpdateAsync(id, entity);
    }
}