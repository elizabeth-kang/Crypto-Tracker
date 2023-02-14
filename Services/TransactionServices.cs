using Models;
using DataAccess;
using CustomExceptions;

namespace Services;

/// <summary>
/// The class service layer for transactions.
/// </summary>
public class TransactionServices
{
    private readonly ITransactionDAO _transactionDAO;

    public TransactionServices(ITransactionDAO transactionDAO)
    {
        _transactionDAO = transactionDAO;
    }

    /// <summary>
    /// Gets all the transactions from the database.
    /// </summary>
    /// <exception cref="RecordNotFoundException">There are no transactions in the database.</exception>
    /// <returns>A list of all transactions.</returns>
    public async Task<List<Transaction>> GetAllTransactions()
    {
        try
        {
            return await _transactionDAO.GetAllTransactions();
        }
        catch (Exception)
        {
            throw new RecordNotFoundException();
        }
    }

    /// <summary>
    /// Gets transaction by the id from database.
    /// </summary>
    /// <param name="id">Id of transaction to get.</param>
    /// <exception cref="RecordNotFoundException">There is no transaction with this id in the database.</exception>
    /// <returns>Transactions object with matching id.</returns>
    public async Task<Transaction> GetTransactionById(int id)
    {
        try
        {
            return await _transactionDAO.GetTransactionById(id);
        }
        catch (Exception)
        {
            throw new RecordNotFoundException();
        }
    }

    /// <summary>
    /// Gets all the transactions with the matching wallet id from database..
    /// </summary>
    /// <param name="wallet_id">Wallet id to get transactions by.</param>
    /// <exception cref="RecordNotFoundException">There are no transactions with matching wallet id in the database.</exception>
    /// <returns>List of all transactions with said wallet id.</returns>
    public async Task<List<Transaction>> GetAllTransactionsByWalletId(int wallet_id)
    {
        try
        {
            return await _transactionDAO.GetAllTransactionsByWalletId(wallet_id);
        }
        catch (Exception)
        {
            throw new RecordNotFoundException();
        }
    }

    /// <summary>
    /// Gets all the transactions with the matching wallet id from database.
    /// </summary>
    /// <param name="currency_id">Currency id to get transactions by.</param>
    /// <exception cref="RecordNotFoundException">There are no transactions with matching currency id in the database.</exception>
    /// <returns>List of all transactions with said wallet id.</returns>
    public async Task<List<Transaction>> GetAllTransactionsByCurrencyId(int currency_id)
    {
        try
        {
            return await _transactionDAO.GetAllTransactionsByCurrencyId(currency_id);
        }
        catch (Exception)
        {
            throw new RecordNotFoundException();
        }
    }

    /// <summary>
    /// Gets all the transactions with the matching wallet id and currency id from database.
    /// </summary>
    /// <param name="currency_id">Currency id to get transactions by.</param>
    /// <param name="wallet_id">Wallet id to get transactions by.</param>
    /// <exception cref="RecordNotFoundException">There are no transactions with matching currency id and wallet id in the database.</exception>
    /// <returns>List of all transactions with said wallet id and currency id.</returns>
    
    public async Task<List<Transaction>> GetAllTransactionsByCurrencyIdAndWalletId(int currency_id, int wallet_id)
    {
        try
        {
            return await _transactionDAO.GetAllTransactionsByCurrencyIdAndWalletId(currency_id, wallet_id);
        }
        catch (Exception)
        {
            
            throw new RecordNotFoundException();
        }
    }

    /// <summary>
    /// Adds a transaction in the database.
    /// </summary>
    /// <param name="create">The transaction to add to the database</param>
    /// <exception cref="RecordNotFoundException">Cannot create transaction in the database.</exception>
    /// <returns>A boolean stating whether the operation was successful or not.</returns>
    public async Task<bool> CreateTransaction(Transaction create)
    {
        try
        {
            return await _transactionDAO.CreateTransaction(create);
        }
        catch (Exception)
        {
            throw new RecordNotFoundException();
        }
    }

    /// <summary>
    /// Updates a transaction in the database.
    /// </summary>
    /// <param name="create">The transaction to update in the database.</param>
    /// <exception cref="RecordNotFoundException">Cannot update transaction in the database.</exception>
    /// <returns>A boolean stating whether the operation was successful or not.</returns>
    public async Task<bool> UpdateTransaction (Transaction create)
    {
        try
        {
            return await _transactionDAO.UpdateTransaction(create);
        }
        catch (Exception)
        {
            throw new RecordNotFoundException();
        }
    }

}