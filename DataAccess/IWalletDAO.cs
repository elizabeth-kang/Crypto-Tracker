using Models;

namespace DataAccess;

public interface IWalletDAO
{
    Task<List<Wallet>> GetAllWallets();
    Task<List<Wallet>> GetAllWalletsByUserId(int user_id);
    Task<bool> CreateWallet(Wallet wallet);
    Task<bool> UpdateWallet(Wallet wallet);

}