using Expenses.Core.Entites;
using Expenses.Core.Interfaces;

using Microsoft.Extensions.Configuration;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

using System.Collections;

namespace Expenses.Repository.Mongo;

public class ExpensesMongoRepository : IExpensesMongoRepository
{
    private readonly IConfigurationRoot _config;
    public ExpensesMongoRepository(IConfigurationRoot config)
    {
        BsonClassMap.RegisterClassMap<Expense>(cm => 
        {
            cm.AutoMap();
            cm.SetIgnoreExtraElements(true);
            cm.MapIdProperty(c => c.Id)
                .SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetSerializer(new StringSerializer(BsonType.ObjectId));
        });

        _config = config;
    }

    public async Task<Expense> Get(int id)
    {
        return await Task.FromResult(new Expense("car", 1));
    }

    public async Task<IEnumerable<Expense>> GetAll()
    {
        return await Task.FromResult(new List<Expense>() 
        {
            new Expense("car", 1),
            new Expense("car", 1),
            new Expense("car", 1)
        });
    }

    public async Task<Expense> Insert(Expense expense)
    {
        return await Task.FromResult(new Expense("car", 1));
    }

    public async Task<Expense> Update(Expense expense)
    {
        return await Task.FromResult(new Expense("car", 1));
    }
}