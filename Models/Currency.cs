using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models;

public class Currency
{
    [Key] public int CurrencyId { get; set; }
    [Required] public string CurrencySymbol { get; set; }  = string.Empty;
    [Required] public decimal CurrencyCurrentPrice { get; set; }
    [Required] public DateTime CurrencyTime { get; set; }

    /// <summary>
    /// Empty Currency contructor.
    /// </summary>
    public Currency() { }

    /// <summary>
    /// Currency object.
    /// </summary>
    /// <param name="CurrencyId">The ID of the currency object used in the database as a primary key.</param>
    /// <param name="CurrencySymbol">The Symbol of the currency object such as BTC, ETH, USD, etc.</param>
    /// <param name="CurrencyCurrentPrice">The price of the currency object based off  CurrencyTime.</param>
    /// <param name="CurrencyTime">The time when CurrencyCurrentPrice was last updated.</param>
    public Currency(int CurrencyId, string CurrencySymbol, decimal CurrencyCurrentPrice, DateTime CurrencyTime)
    {
        this.CurrencyId = CurrencyId;
        this.CurrencySymbol = CurrencySymbol;
        this.CurrencyCurrentPrice = CurrencyCurrentPrice;
        this.CurrencyTime = CurrencyTime;
    }
}