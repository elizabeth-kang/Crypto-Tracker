using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models;

public class User
{
    [Key] public int UserId { get; set; }
    [Required] public string Email { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Empty User constructor.
    /// </summary>
    public User()
    {

    }

    /// <summary>
    /// User constructor.
    /// </summary>
    /// <param name="UserId">The ID of the User object used in the database as a primary key.</param>
    /// <param name="Email">The email for the user acting as username.</param>
    /// <param name="Password">The password for the user.</param>
    public User(int UserId, string Email, string Password)
    {
        this.UserId = UserId;
        this.Email = Email;
        this.Password = Password;
    }

    /// <summary>
    /// User constructor.
    /// </summary>
    /// <param name="Email">The email for the user acting as username.</param>
    /// <param name="Password">The password for the user.</param>
    public User(string Email, string Password)
    {
        this.Email = Email;
        this.Password = Password;
    }
}

