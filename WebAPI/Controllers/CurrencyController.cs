using Models;
using Services;
using CustomExceptions;

namespace WebAPI.Controllers;

public class CurrencyController
{
    private readonly CurrencyServices _service;

    public CurrencyController(CurrencyServices service)
    {
        _service = service;
    }
    public async Task<IResult> GetAllCurrencies()
    {
        var allcurrencies =  await _service.GetAllCurrencies();
        return allcurrencies.Count > 0 ? Results.Ok(allcurrencies) : Results.BadRequest("No currencies to get!");   
    }
    public async Task<IResult> GetCurrencyById(int currency_id)
    {
        var currencies = await _service.GetCurrencyById(currency_id);
        return currencies != null ? Results.Ok(currencies) : Results.BadRequest("No currencies under this currency ID!");
    }
    public async Task<IResult> GetCurrencyBySymbol(string symbol)
    {
        var currency = await _service.GetCurrencyBySymbol(symbol);
        return currency != null ? Results.Ok(currency) : Results.BadRequest("No currency with this SYMBOL!");
    }
    public async Task<IResult> CreateCurrency(Currency currency)
    {
        var createdCurrency = await _service.CreateCurrency(currency);
        return createdCurrency ? Results.Ok(createdCurrency) : Results.BadRequest("Invalid currency input!");
    }
    public async Task<IResult> UpdateCurrency(Currency currency)
    {
        var updatedCurrency = await _service.UpdateCurrency(currency);
        return updatedCurrency ? Results.Ok(updatedCurrency) : Results.BadRequest("Invalid currency update input!");

    }
}