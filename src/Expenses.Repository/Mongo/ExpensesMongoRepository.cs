using Expenses.Core.Entites;
using Expenses.Core.Interfaces;

using Microsoft.Extensions.Options;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Expenses.Repository.Mongo;

public class ExpensesMongoRepository : IExpensesMongoRepository
{
    private readonly IMongoCollection<Expense> _expenseCollection;
    public ExpensesMongoRepository(IOptions<ExpenseDatabaseSettings> expenseDatabaseSettings)
    {
        //TODO: Tentar colocar no Module pra ver o que acontece
        // BsonClassMap.RegisterClassMap<Expense>(cm =>
        // {
        //     cm.AutoMap();
        //     cm.SetIgnoreExtraElements(true);
        //     cm.MapIdProperty(c => c.Id)
        //         .SetIdGenerator(StringObjectIdGenerator.Instance)
        //         .SetSerializer(new StringSerializer(BsonType.ObjectId));
        // });

        var mongoClient = new MongoClient(
            expenseDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            expenseDatabaseSettings.Value.DatabaseName);

        _expenseCollection = mongoDatabase.GetCollection<Expense>(
            expenseDatabaseSettings.Value.ExpenseCollectionName);
    }

    public async Task<Expense?> GetAsync(string id) => 
        await _expenseCollection.Find(x => x.Id == id)
                                .FirstOrDefaultAsync();

    public async Task<IEnumerable<Expense?>> GetAsync()
    {
        return await Task.FromResult(new List<Expense>()
        {
            new Expense("car", 1),
            new Expense("car", 1),
            new Expense("car", 1)
        });
    }

    public async Task InsertAsync(Expense newExpense) => 
        await _expenseCollection.InsertOneAsync(newExpense);

    public async Task UpdateAsync(string id, Expense updatedExpense) =>
        await _expenseCollection.ReplaceOneAsync(x => x.Id == id, updatedExpense);
}