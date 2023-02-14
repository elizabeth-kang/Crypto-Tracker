using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int WalletIdFk { get; set; }
        public int CurrencyIdFk { get; set; }
        public string TransactionType { get; set; } = null!;
        public decimal TransactionValue { get; set; }
        public DateTime TransactionTime { get; set; }

        public virtual Currency CurrencyIdFkNavigation { get; set; } = null!;
        public virtual Wallet WalletIdFkNavigation { get; set; } = null!;
    }
}