using Moq;
using Models;
using CustomExceptions;
using Services;
using Xunit;
using DataAccess;

namespace Tests;

public class WalletTesting
{
    [Fact]
    public void NoWalletsToGet()
    {
        var mockedRepo = new Mock<IWalletDAO>();


        mockedRepo.Setup( repo =>  repo.GetAllWallets()).Throws(new ResourceNotFoundException());


        WalletServices service = new WalletServices(mockedRepo.Object);

        Assert.ThrowsAsync<ResourceNotFoundException>(async () => await service.GetAllWallets());

    }
    [Fact]
    public async Task WrongWalletId()
    {
        var walletRepo = new Mock<IWalletDAO>();

        Wallet newWallet = new Wallet{
            WalletId = 1,
            UserIdFk = 1, 
            CurrencyIdFk = 1,
            AmountCurrency = 10
        };

        walletRepo.Setup( repo =>  repo.CreateWallet(newWallet)).ReturnsAsync(true);
        walletRepo.Setup( repo => repo.GetAllWalletsByUserId(2)).ThrowsAsync(new RecordNotFoundException());

        WalletServices service = new WalletServices(walletRepo.Object);

        await Assert.ThrowsAsync<RecordNotFoundException>(() => service.GetAllWalletsByUserId(2));  
    }
    [Fact]
    public async Task InvalidCreateWallet()
    {
        // Given
        var walletRepo = new Mock<IWalletDAO>();

        Wallet newWallet = new Wallet{
            WalletId = 1,
            UserIdFk = 1, 
            CurrencyIdFk = 1,
            AmountCurrency = 10
        };

        Wallet falseWallet = new Wallet{
            WalletId = 1,
            UserIdFk = 1, 
            CurrencyIdFk = 1,
            AmountCurrency = 0
        };
    
        // When
        walletRepo.Setup( repo =>  repo.CreateWallet(newWallet)).ReturnsAsync(true);
        walletRepo.Setup( repo =>  repo.CreateWallet(falseWallet)).ThrowsAsync(new InvalidInputException());
        // Then
        WalletServices service = new WalletServices(walletRepo.Object);

        await Assert.ThrowsAsync<InvalidInputException>(() => service.CreateWallet(falseWallet));  
    }
        [Fact]
    public async Task FailToUpdateWallet()
    {
        // Given
        var walletRepo = new Mock<IWalletDAO>();

        Wallet newWallet = new Wallet{
            WalletId = 1,
            UserIdFk = 1, 
            CurrencyIdFk = 1,
            AmountCurrency = 10
        };

        Wallet toUpdate = new Wallet{
            WalletId = 0,
            UserIdFk = 1, 
            CurrencyIdFk = 1,
            AmountCurrency = 0
        };
    
        // When
        walletRepo.Setup( repo =>  repo.CreateWallet(newWallet)).ReturnsAsync(true);
        walletRepo.Setup( repo =>  repo.CreateWallet(toUpdate)).ThrowsAsync(new InvalidInputException());
        // Then
        WalletServices service = new WalletServices(walletRepo.Object);

        await Assert.ThrowsAsync<InvalidInputException>(() => service.CreateWallet(toUpdate));  
        // INF loop somewhere!!!
    }
}