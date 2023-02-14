using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class User
    {
        public User()
        {
            Profiles = new HashSet<Profile>();
            Wallets = new HashSet<Wallet>();
        }

        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Profile> Profiles { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}