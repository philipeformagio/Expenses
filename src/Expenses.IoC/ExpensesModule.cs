using Autofac;
using AutoMapper;

using Expenses.Core.Interfaces;
using Expenses.Repository.Mongo;
using Expenses.Core.Services;
using Expenses.Core.Mappers;

using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using Expenses.Core.Entites;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

namespace Expenses.IoC;

public class ExpensesModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        #region .: Appsettings :.
        var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json");
        var configuration = config?.Build();
        builder.RegisterInstance(configuration);
        #endregion

        #region .: Mongo :.
        BsonClassMap.RegisterClassMap<Expense>(cm =>
        {
            cm.MapProperty(p => p.Name).SetElementName("name");
            cm.MapProperty(p => p.Price).SetElementName("price");
            cm.MapProperty(p => p.CreatedAt).SetElementName("createdAt");
            cm.MapProperty(p => p.DayOfWeek).SetElementName("dayOfWeek");
            cm.MapProperty(p => p.DueDate).SetElementName("dueData");
            cm.MapProperty(p => p.UpdatedAt).SetElementName("updatedAt");
            cm.SetIgnoreExtraElements(true);
            cm.MapIdProperty(c => c.Id)
                .SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetSerializer(new StringSerializer(BsonType.ObjectId));
        });
        #endregion

        #region .: Repositories :.
        builder.RegisterType<ExpensesMongoRepository>().As<IExpensesMongoRepository>().SingleInstance();
        #endregion

        #region .: Services :.
        builder.RegisterType<ExpensesService>().As<IExpensesService>().SingleInstance();
        #endregion

        #region .: Mapper :.
        var configMapper = new MapperConfiguration(cfg => {
            cfg.AddProfile<ExpenseProfile>();
        });
        builder.RegisterInstance(configMapper.CreateMapper()).As<IMapper>().SingleInstance();
        #endregion
    }
}