using Microsoft.EntityFrameworkCore;
using Models;
using CustomExceptions;
using DataAccess;

namespace DataAccess;

/// <summary>
/// Class to access transactions from the database and buisness logic associated with transactions.
/// </summary>
public class TransactionRepository : ITransactionDAO
{
    private readonly StonksDbContext _context;
    public TransactionRepository(StonksDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<List<Transaction>> GetAllTransactions()
    {
        return await _context.Transactions.ToListAsync();
    }

    /// <inheritdoc />
    public async Task<Transaction> GetTransactionById(int id)
    {
        Transaction? foundTransaction = await _context.Transactions.FirstOrDefaultAsync(transaction => transaction.TransactionId == id);
        if(foundTransaction != null) return foundTransaction;
        throw new RecordNotFoundException("help");
    }

    /// <inheritdoc />
    public async Task<List<Transaction>> GetAllTransactionsByWalletId(int wallet_id)
    {
        return await _context.Transactions.AsNoTracking().Where(Transaction => Transaction.WalletIdFk == wallet_id).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<List<Transaction>> GetAllTransactionsByCurrencyId(int currency_id)
    {
        return await _context.Transactions.AsNoTracking().Where(Transaction => Transaction.CurrencyIdFk == currency_id).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<List<Transaction>> GetAllTransactionsByCurrencyIdAndWalletId(int currency_id, int wallet_id)
    {
        return await _context.Transactions.AsNoTracking()
            .Where(Transaction => Transaction.CurrencyIdFk == currency_id 
                               && Transaction.WalletIdFk == wallet_id)
                .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<bool> CreateTransaction(Transaction transaction)
    {
        _context.Add(transaction);
        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
        return true;
    }

    /// <inheritdoc />
    public async Task<bool> UpdateTransaction(Transaction transaction)
    {
        _context.Update(transaction);
        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
        return true;
    }
}