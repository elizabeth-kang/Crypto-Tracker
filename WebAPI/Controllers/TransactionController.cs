using Services;
using CustomExceptions;
using DataAccess;
using Models;

namespace WebAPI.Controllers;

/// <summary>
/// Class for transaction controller.
/// </summary>
public class TransactionController
{
    private readonly TransactionServices _Services;

    public TransactionController(TransactionServices services)
    {
        _Services = services;
    }
    
    public async Task<IResult> GetAllTransactions()
    {
        var transactions =  await _Services.GetAllTransactions();
        return transactions.Count > 0 ? Results.Ok(transactions) : Results.BadRequest("No transactions to get!");   
    }

    public async Task<IResult> GetTransactionById(int id)
    {
        var transaction = await _Services.GetTransactionById(id);
        return transaction != null ? Results.Ok(transaction) : Results.BadRequest("No transaction under this ID!");
    }

    public async Task<IResult> GetAllTransactionsByWalletId(int wallet_id)
    {
        var transactions = await _Services.GetAllTransactionsByWalletId(wallet_id);
        return transactions.Count > 0 ? Results.Ok(transactions) : Results.BadRequest("No transactions under this wallet ID!");
    }

    public async Task<IResult> GetAllTransactionsByCurrencyId(int currency_id)
    {
        var transactions = await _Services.GetAllTransactionsByCurrencyId(currency_id);
        return transactions.Count > 0 ? Results.Ok(transactions) : Results.BadRequest("No transactions under this currency ID!");
    }

    public async Task<IResult> GetAllTransactionsByCurrencyIdAndWalletId(int currency_id, int wallet_id)
    {
        var transactions = await _Services.GetAllTransactionsByCurrencyIdAndWalletId(currency_id, wallet_id);
        return transactions.Count > 0 ? Results.Ok(transactions) : Results.BadRequest("No transactions under this wallet ID and currency ID!");
    }

    public async Task<IResult> CreateTransaction(Transaction transaction)
    {
        var createTransaction = await _Services.CreateTransaction(transaction);
        return createTransaction ? Results.Ok(transaction) : Results.BadRequest("Invalid transaction!");
    }

    public async Task<IResult> UpdateTransaction(Transaction transaction)
    {
        var updateTransaction = await _Services.UpdateTransaction(transaction);
        return updateTransaction ? Results.Ok(transaction) : Results.BadRequest("Invalid transactions!");
    }
}