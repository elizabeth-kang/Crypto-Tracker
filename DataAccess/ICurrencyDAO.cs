using Models;

namespace DataAccess;

public interface ICurrencyDAO
{
    Task<List<Currency>> GetAllCurrencies();
    Task<Currency> GetCurrencyById(int currency_id);
    Task<Currency> GetCurrencyBySymbol(string symbol);
    Task<bool> CreateCurrency(Currency currency);
    Task<bool> UpdateCurrency(Currency currency);
}