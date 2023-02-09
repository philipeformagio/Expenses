using Autofac;
using Autofac.Extensions.DependencyInjection;

using Expenses.IoC;
using Expenses.Repository.Mongo;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new ExpensesModule()));
builder.Services.Configure<ExpenseDatabaseSettings>(builder.Configuration.GetSection("ExpenseDatabase"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(handler =>
{
    handler.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>();

        if (exception != null)
            app.Logger.LogError(500, "Mensagem {mesagem} trace: {result}", exception.Error.Message, exception.Error.StackTrace);

        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json; charset=utf-8";

        await context.Response.WriteAsync($"{{\"valid\":false,\"messages\":[\"Ops... Uma falha ocorreu!\"],\"protocolo\":\"{Guid.NewGuid()}\"}}");
    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
