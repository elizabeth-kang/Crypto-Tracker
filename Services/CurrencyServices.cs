using DataAccess;
using Models;
using CustomExceptions;

namespace Services;

public class CurrencyServices
{
    private readonly ICurrencyDAO _repo;

    public CurrencyServices(ICurrencyDAO repo)
    {
        _repo = repo;
    }
    public async Task<List<Currency>> GetAllCurrencies()
    {
        try
        {
            return await _repo.GetAllCurrencies();
        }
        catch (RecordNotFoundException)
        {   
            throw new RecordNotFoundException();
        }
    }
    public async Task<Currency> GetCurrencyById(int currency_id)
    {
        try
        {
            return await _repo.GetCurrencyById(currency_id);   
        }
        catch (RecordNotFoundException)
        {
            throw new RecordNotFoundException();
        }
    }
    public async Task<Currency> GetCurrencyBySymbol(string symbol)
    {
        try
        {
            return await _repo.GetCurrencyBySymbol(symbol);
        }
        catch (InvalidInputException)
        {
            throw new InvalidInputException();
        }
    }
    public async Task<bool> CreateCurrency(Currency currency)
    {
        try
        {
            return await _repo.CreateCurrency(currency);
        }
        catch (InvalidInputException)
        {
            throw new InvalidInputException();
        }
    }
    public async Task<bool> UpdateCurrency(Currency currency)
    {
        try
        {
            return await _repo.UpdateCurrency(currency);
        }
        catch (InvalidInputException)
        { 
            throw new InvalidInputException();
        }
    }
}