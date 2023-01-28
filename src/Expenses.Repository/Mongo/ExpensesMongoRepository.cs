using Expenses.Core.Entites;
using Expenses.Core.Interfaces;

using Microsoft.Extensions.Configuration;

using MongoDB.Bson;

using System.Collections;

namespace Expenses.Repository.Mongo;

public class ExpensesMongoRepository : IExpensesMongoRepository
{
    private readonly IConfigurationRoot _config;
    public ExpensesMongoRepository(IConfigurationRoot config)
    {
        // BsonClassMap.

        _config = config;
    }

    public async Task<Expense> Get(int id)
    {
        return new Expense("car", 1);
    }

    public async Task<IEnumerable<Expense>> GetAll()
    {
        return new List<Expense>() 
        {
            new Expense("car", 1),
            new Expense("car", 1),
            new Expense("car", 1)
        };
    }

    public async Task<Expense> Insert(Expense expense)
    {
        return new Expense("car", 1);
    }

    public async Task<Expense> Update(Expense expense)
    {
        return new Expense("car", 1);
    }
}