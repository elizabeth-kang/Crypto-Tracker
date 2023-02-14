using Models;

namespace DataAccess;

/// <summary>
/// Class to access transactions from the database and buisness logic associated with transactions.
/// </summary>
public interface ITransactionDAO
{
    /// <summary>
    /// Gets all the transactions in the database in the database.
    /// </summary>
    /// <returns>A list of all transactions.</returns>
    Task<List<Transaction>> GetAllTransactions();

    /// <summary>
    /// Gets the transcation with the specified id in the database.
    /// </summary>
    /// <param name="id">The id of the transaction to get.</param>
    /// <returns>A transaction object that has the matching id.</returns>
    Task<Transaction> GetTransactionById(int id);

    /// <summary>
    /// Gets all the transactions with the associated wallet id in the database.
    /// </summary>
    /// <param name="wallet_id">The wallet id to get transactions by.</param>
    /// <returns>A list of all transactions that have the wallet_id</returns>
    Task<List<Transaction>> GetAllTransactionsByWalletId(int wallet_id);

    /// <summary>
    /// Gets all the transactions with the associated currency id in the database.
    /// </summary>
    /// <param name="currency_id">The currency id to get transactions by.</param>
    /// <returns>A list of all transactions that have currency id.</returns>
    Task<List<Transaction>> GetAllTransactionsByCurrencyId(int currency_id);

    /// <summary>
    /// Gets all tranactions with associated currency id and wallet id in the database/
    /// </summary>
    /// <param name="currency_id">The currency id to get transactions by.</param>
    /// <param name="wallet_id">The wallet id to get transactions by.</param>
    /// <returns>A list of all transactions that have the currency_id and wallet_id.</returns>
    Task<List<Transaction>> GetAllTransactionsByCurrencyIdAndWalletId(int currency_id, int wallet_id);

    /// <summary>
    /// Creates a transaction in the database.
    /// </summary>
    /// <param name="transaction">The transaction to add to the database.</param>
    /// <returns>A boolean stating whether the operation was successful or not.</returns>
    Task<bool> CreateTransaction(Transaction transaction);

    /// <summary>
    /// Updates a transaction in the database.
    /// </summary>
    /// <param name="transaction">The transaction to update in the database.</param>
    /// <returns>A boolean stating whether the operation was successful or not.</returns>
    Task<bool> UpdateTransaction(Transaction transaction);
}