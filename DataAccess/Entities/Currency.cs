using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Currency
    {
        public Currency()
        {
            Transactions = new HashSet<Transaction>();
            Wallets = new HashSet<Wallet>();
        }

        public int CurrencyId { get; set; }
        public string CurrencySymbol { get; set; } = null!;
        public decimal CurrencyCurrentPrice { get; set; }
        public DateTime CurrencyTime { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}