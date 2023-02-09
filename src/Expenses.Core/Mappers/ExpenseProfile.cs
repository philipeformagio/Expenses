using AutoMapper;
using Expenses.Core.Dtos;
using Expenses.Core.Entites;

namespace Expenses.Core.Mappers;

public class ExpenseProfile : Profile
{
    public ExpenseProfile()
    {
        CreateProfileExpenseDto();
    }

    private void CreateProfileExpenseDto()
    {
        CreateMap<ExpenseDto, Expense>()
            .ReverseMap();
    }
}