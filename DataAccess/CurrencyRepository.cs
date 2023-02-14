using Microsoft.EntityFrameworkCore;
using Models;
using CustomExceptions;

namespace DataAccess;

public class CurrencyRepository : ICurrencyDAO
{
    private readonly StonksDbContext _context;
    public CurrencyRepository(StonksDbContext context)
    {
        _context = context;
    }

    public async Task<List<Currency>> GetAllCurrencies()
    {
        return await _context.Currencies.ToListAsync();
    }
    public async Task<Currency> GetCurrencyById(int currency_id)
    {
        Currency? foundCurrency = await _context.Currencies.FirstOrDefaultAsync(currency => currency.CurrencyId == currency_id);
        if(foundCurrency != null) return foundCurrency;
        throw new RecordNotFoundException("Could not find the currency with such id");

    }
    public async Task<Currency> GetCurrencyBySymbol(string symbol)
    {
        Currency? foundCurrency = await _context.Currencies.FirstOrDefaultAsync(currency => currency.CurrencySymbol == symbol);
        if(foundCurrency != null) return foundCurrency;
        throw new RecordNotFoundException("Could not find the currency with such symbol");
    }
    public async Task<bool> CreateCurrency(Currency currency)
    {
        _context.Add(currency);
        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
        return true;
    }
    public async Task<bool> UpdateCurrency(Currency currency)
    {
        _context.Update(currency);
        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
        return true;
    }
}