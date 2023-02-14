using Models;
using Services;
using CustomExceptions;

namespace WebAPI.Controllers;

public class WalletController
{
    private readonly WalletServices _service;

    public WalletController(WalletServices service)
    {
        _service = service;
    }
    public async Task<IResult> GetAllWallets()
    {
        var allwallets =  await _service.GetAllWallets();
        return allwallets.Count > 0 ? Results.Ok(allwallets) : Results.BadRequest("No wallet to get!");   
    }
    public async Task<IResult> GetAllWalletsByUserId(int user_id)
    {
        var wallets = await _service.GetAllWalletsByUserId(user_id);
        return wallets.Count > 0 ? Results.Ok(wallets) : Results.BadRequest("No wallets under this user ID!");
    }
    public async Task<IResult> CreateWallet(Wallet wallet)
    {
        var createdWallet = await _service.CreateWallet(wallet);
        return createdWallet ? Results.Ok(wallet) : Results.BadRequest("Invalid wallet input!");
    }
    public async Task<IResult> UpdateWallet(Wallet wallet)
    {
        var updatedWallet = await _service.UpdateWallet(wallet);
        return updatedWallet ? Results.Ok(wallet) : Results.BadRequest("Invalid wallet update input!");

    }
}