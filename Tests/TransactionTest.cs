using Moq;
using Models;
using CustomExceptions;
using Services;
using Xunit;
using DataAccess;

namespace Tests;

public class TransactionTest
{
    [Fact]
    public void NoTransactionsToGet()
    {
        var mockedRepo = new Mock<ITransactionDAO>();


        mockedRepo.Setup( repo =>  repo.GetAllTransactions()).Throws(new ResourceNotFoundException());


        TransactionServices service = new TransactionServices(mockedRepo.Object);

        Assert.ThrowsAsync<ResourceNotFoundException>(async () => await service.GetAllTransactions());

    }

    [Fact]
    public async Task WrongTransactionId()
    {
        var mockedRepo = new Mock<ITransactionDAO>();

        Transaction newTransaction = new Transaction {
            TransactionId = 1,
            WalletIdFk = 1,
            CurrencyIdFk = 1,
            TransactionType = "Buy",
            TransactionValue = 1000,
            TransactionTime = DateTime.Now
        };

        mockedRepo.Setup( repo => repo.CreateTransaction(newTransaction)).ReturnsAsync(true);
        mockedRepo.Setup( repo => repo.GetTransactionById(2)).ThrowsAsync(new RecordNotFoundException());

        TransactionServices service = new TransactionServices(mockedRepo.Object);

        await Assert.ThrowsAsync<RecordNotFoundException>(async () => await service.GetTransactionById(2));  
    }

    [Fact]
    public async Task WrongTransactionsByWalletId()
    {
        var mockedRepo = new Mock<ITransactionDAO>();

        Transaction newTransaction = new Transaction {
            TransactionId = 1,
            WalletIdFk = 1,
            CurrencyIdFk = 1,
            TransactionType = "Buy",
            TransactionValue = 1000,
            TransactionTime = DateTime.Now
        };

        mockedRepo.Setup( repo => repo.CreateTransaction(newTransaction)).ReturnsAsync(true);
        mockedRepo.Setup( repo => repo.GetAllTransactionsByWalletId(2)).ThrowsAsync(new RecordNotFoundException());

        TransactionServices service = new TransactionServices(mockedRepo.Object);

        await Assert.ThrowsAsync<RecordNotFoundException>(async () => await service.GetAllTransactionsByWalletId(2));  
    }
    [Fact]
    public async Task WrongTransactionsByCurrencyId()
    {
        var mockedRepo = new Mock<ITransactionDAO>();

        Transaction newTransaction = new Transaction {
            TransactionId = 1,
            WalletIdFk = 1,
            CurrencyIdFk = 1,
            TransactionType = "Buy",
            TransactionValue = 1000,
            TransactionTime = DateTime.Now
        };

        mockedRepo.Setup( repo => repo.CreateTransaction(newTransaction)).ReturnsAsync(true);
        mockedRepo.Setup( repo => repo.GetAllTransactionsByCurrencyId(2)).ThrowsAsync(new RecordNotFoundException());

        TransactionServices service = new TransactionServices(mockedRepo.Object);

        await Assert.ThrowsAsync<RecordNotFoundException>(async () => await service.GetAllTransactionsByCurrencyId(2));  
    }
    // [Fact]
    // public async Task InvalidCreateTransaction()
    // {
    //     // Given
    //     var mockedRepo = new Mock<ITransactionDAO>();

    //     Transaction newTransaction = new Transaction {
    //         TransactionId = 1,
    //         WalletIdFk = 1,
    //         CurrencyIdFk = 1,
    //         TransactionType = "Buy",
    //         TransactionValue = 1000,
    //         TransactionTime = DateTime.Now
    //     };

    //     Transaction badTransaction = new Transaction {
    //         TransactionId = 1,
    //         WalletIdFk = 1,
    //         CurrencyIdFk = 1,
    //         TransactionType = "Buy",
    //         TransactionValue = 100, //different line
    //         TransactionTime = DateTime.Now
    //     };
    
    //     // When
    //     mockedRepo.Setup( repo => repo.CreateTransaction(newTransaction)).ReturnsAsync(true);
    //     mockedRepo.Setup( repo => repo.CreateTransaction(badTransaction)).ThrowsAsync(new ResourceNotFoundException());
    //     // Then
    //     TransactionServices service = new TransactionServices(mockedRepo.Object);

    //     await Assert.ThrowsAsync<ResourceNotFoundException>(async () => await service.CreateTransaction(badTransaction));  
    // }
    // [Fact]
    // public async Task InvalidUpdateWallet()
    // {
    //     // Given
    //     var mockedRepo = new Mock<ITransactionDAO>();

    //     Transaction newTransaction = new Transaction {
    //         TransactionId = 1,
    //         WalletIdFk = 1,
    //         CurrencyIdFk = 1,
    //         TransactionType = "Buy",
    //         TransactionValue = 1000,
    //         TransactionTime = DateTime.Now
    //     };

    //     Transaction badTransaction = new Transaction {
    //         TransactionId = 1,
    //         WalletIdFk = 1,
    //         CurrencyIdFk = 1,
    //         TransactionType = "Buy",
    //         TransactionValue = 100, //different line
    //         TransactionTime = DateTime.Now
    //     };
    
    //     // When
    //     mockedRepo.Setup( repo => repo.CreateTransaction(newTransaction)).ReturnsAsync(true);
    //     mockedRepo.Setup( repo => repo.CreateTransaction(badTransaction)).ThrowsAsync(new ResourceNotFoundException());
    //     // Then
    //     TransactionServices service = new TransactionServices(mockedRepo.Object);

    //     await Assert.ThrowsAsync<ResourceNotFoundException>(async () => await service.UpdateTransaction(badTransaction));  
    // }
}