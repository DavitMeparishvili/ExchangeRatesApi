using ExchangeRatesApi.Context;
using ExchangeRatesApi.Data;
using ExchangeRatesApi.Dto;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IExchangeratesRepo, ExchangeratesRepo>();

var app = builder.Build();
app.UseHttpsRedirection();

app.MapGet("/exchange-rates", async (string date, string code, IExchangeratesRepo repo) =>
{
    var result = await repo.GetExchangerates(new Filter()
    {
        Date = date,
        Code = code,
    });
    return Results.Ok(result);
});

app.Run();
