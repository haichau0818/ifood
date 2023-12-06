using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace FoodManage.Models;

public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    [ForeignKey("Genders")]
    public int GenderId { get; set; }
    public Gender Genders { get; set; }

    [StringLength(10)]
    public string PhoneNumber { get; set; } = null!;

    [ForeignKey("Roles")]
    public int RoleId { get; set; }
    public Role Roles { get; set; }
 

    [StringLength(100)]
    public string Address { get; set; } = null!;

    public DateTime DateOfBird { get; set; }

    public byte[] Avatar { get; set; } = null;
}


