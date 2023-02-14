using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models;

public class Wallet
{
    
    [Key] public int WalletId { get; set; }
    [ForeignKey("User")] public int UserIdFk { get; set; }
    [ForeignKey("Currnecy")] public int CurrencyIdFk { get; set; }
    [Required] public decimal AmountCurrency { get; set; }


    /// <summary>
    /// Empty Wallet constructor.
    /// </summary>
    public Wallet() { }

    /// <summary>
    /// Wallet constructor.
    /// </summary>
    /// <param name="UserIdFk">The ID of the User associated with this Wallet. Also used for database forgien key.</param>
    /// <param name="CurrencyIdFk">The ID of the Currency associated with this Wallet. Also used for database forgien key.</param>
    /// <param name="AmountCurrency">The amount of currency held in the Wallet.</param>
    public Wallet(int UserIdFk, int CurrencyIdFk, decimal AmountCurrency)
    {
        this.UserIdFk = UserIdFk;
        this.CurrencyIdFk = CurrencyIdFk;
        this.AmountCurrency = AmountCurrency;
    }

    /// <summary>
    /// Wallet constructor.
    /// </summary>
    /// <param name="WalletId">The ID of the User object used in the database as a primary key.</param>
    /// <param name="UserIdFk">The ID of the User associated with this Wallet. Also used for database forgien key.</param>
    /// <param name="CurrencyIdFk">The ID of the Currency associated with this Wallet. Also used for database forgien key.</param>
    /// <param name="AmountCurrency">The amount of currency held in the Wallet.</param>
    public Wallet(int WalletId, int UserIdFk, int CurrencyIdFk, decimal AmountCurrency)
    {
        this.WalletId = WalletId;
        this.UserIdFk = UserIdFk;
        this.CurrencyIdFk = CurrencyIdFk;
        this.AmountCurrency = AmountCurrency;
    }
}

