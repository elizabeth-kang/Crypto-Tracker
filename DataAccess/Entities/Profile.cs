using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Profile
    {
        public int ProfileId { get; set; }
        public int UserIdFk { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual User UserIdFkNavigation { get; set; } = null!;
    }
}