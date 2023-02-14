using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models;

public class Profile
{
    [Key] public int ProfileId { get; set; }
    [ForeignKey("User")] public int UserIdFk { get; set; }
    [Required] public string FirstName { get; set; } = string.Empty;
    [Required] public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Empty Profile constructor.
    /// </summary>
    public Profile() { }

    /// <summary>
    /// Profile object.
    /// </summary>
    /// <param name="UserIdFk">The ID of the User who creates the profile. This is used for database forgien key.</param>
    /// <param name="FirstName">The first name for profile.</param>
    /// <param name="LastName">The last name for profile.</param>
    public Profile(int UserIdFk, string FirstName, string LastName)
    {
        this.UserIdFk = UserIdFk;
        this.FirstName = FirstName;
        this.LastName = LastName;
    }

    /// <summary>
    /// Profile object.
    /// </summary>
    /// <param name="ProfileId">The ID of the Profile object used in the database as a primary key.</param>
    /// <param name="UserIdFk">The ID of the User who creates the profile. This is used for database forgien key.</param>
    /// <param name="FirstName">The first name for profile.</param>
    /// <param name="LastName">The last name for profile.</param>
    public Profile(int ProfileId, int UserIdFk, string FirstName, string LastName)
    {
        this.ProfileId = ProfileId;
        this.UserIdFk = UserIdFk;
        this.FirstName = FirstName;
        this.LastName = LastName;
    }
}

