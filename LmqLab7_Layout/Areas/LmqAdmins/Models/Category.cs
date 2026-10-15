using System;
using System.Collections.Generic;

namespace LmqLab7_Layout.Areas.LmqAdmins.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
