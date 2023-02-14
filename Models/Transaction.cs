using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models;

public class Transaction
{
    [Key] public int TransactionId { get; set; }
    [ForeignKey("Wallet")] public int WalletIdFk { get; set; }
    [ForeignKey("Currency")] public int CurrencyIdFk { get; set; }
    [Required] public string TransactionType { get; set; } = string.Empty;
    [Required] public decimal TransactionValue { get; set; }
    [Required] public DateTime TransactionTime { get; set; }

    /// <summary>
    /// Empty transaction constructor.
    /// </summary>
    public Transaction() { }

    /// <summary>
    /// Transaction constructor.
    /// </summary>
    /// <param name="TransactionId">The ID of the Transaction object used in the database as a primary key.</param>
    /// <param name="WalletIdFk">The ID of the Wallet associated with this Transaction. Also used for database forgien key.</param>
    /// <param name="CurrencyIdFk">The ID of the Currency associated with this Transaction. Also used for database forgien key.</param>
    /// <param name="TransactionType">The type of transaction ie "Buy" or "Sell".</param>
    /// <param name="TransactionValue">The value of the transaction.</param>
    /// <param name="TransactionTime">The time when the Transaction was made..</param>
    public Transaction(int WalletIdFk, int CurrencyIdFk, string TransactionType, decimal TransactionValue, DateTime TransactionTime)
    {
        this.WalletIdFk = WalletIdFk;
        this.CurrencyIdFk = CurrencyIdFk;
        this.TransactionType = TransactionType;
        this.TransactionValue = TransactionValue;
        this.TransactionTime = TransactionTime;
    }

    /// <summary>
    /// Transaction constructor.
    /// </summary>
    /// <param name="TransactionId">The ID of the Transaction object used in the database as a primary key.</param>
    /// <param name="WalletIdFk">The ID of the Wallet associated with this Transaction. Also used for database forgien key.</param>
    /// <param name="CurrencyIdFk">The ID of the Currency associated with this Transaction. Also used for database forgien key.</param>
    /// <param name="TransactionType">The type of transaction ie "Buy" or "Sell".</param>
    /// <param name="TransactionValue">The value of the transaction.</param>
    /// <param name="TransactionTime">The time when the Transaction was made.</param>
    public Transaction(int TransactionId, int WalletIdFk, int CurrencyIdFk, string TransactionType, decimal TransactionValue, DateTime TransactionTime)
    {
        this.TransactionId = TransactionId;
        this.WalletIdFk = WalletIdFk;
        this.CurrencyIdFk = CurrencyIdFk;
        this.TransactionType = TransactionType;
        this.TransactionValue = TransactionValue;
        this.TransactionTime = TransactionTime;
    }
}

