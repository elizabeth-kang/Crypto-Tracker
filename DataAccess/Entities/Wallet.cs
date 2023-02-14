using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Wallet
    {
        public Wallet()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int WalletId { get; set; }
        public int UserIdFk { get; set; }
        public int CurrencyIdFk { get; set; }
        public decimal AmountCurrency { get; set; }

        public virtual Currency CurrencyIdFkNavigation { get; set; } = null!;
        public virtual User UserIdFkNavigation { get; set; } = null!;
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}