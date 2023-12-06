using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodManage.Models;

public partial class Gender
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string GenderName { get; set; } = null!;

    public DateTime ExpDate { get; set; }

}
