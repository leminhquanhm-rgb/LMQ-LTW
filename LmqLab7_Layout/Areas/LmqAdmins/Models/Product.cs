using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LmqLab7_Layout.Areas.LmqAdmins.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal? SalePrice { get; set; }

    public bool Status { get; set; }

    public int CategoryId { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

    [ValidateNever]
    public virtual Category Category { get; set; } = null!;
}