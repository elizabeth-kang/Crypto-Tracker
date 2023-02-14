using Microsoft.EntityFrameworkCore;
using Models;
using CustomExceptions;

namespace DataAccess;

public class WalletRepository : IWalletDAO
{
    private readonly StonksDbContext _context;
    public WalletRepository(StonksDbContext context)
    {
        _context = context;
    }
    public async Task<List<Wallet>> GetAllWallets()
    {
        return await _context.Wallets.ToListAsync();
    }
    public async Task<List<Wallet>> GetAllWalletsByUserId(int user_id)
    {
        return await _context.Wallets.AsNoTracking().Where(Wallet => Wallet.UserIdFk == user_id).ToListAsync();
    }
    public async Task<bool> CreateWallet(Wallet wallet)
    {
        _context.Add(wallet);
        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
        return true;
    }
    public async Task<bool> UpdateWallet(Wallet wallet)
    {
        _context.Update(wallet);
        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
        return true;
    }
    
}