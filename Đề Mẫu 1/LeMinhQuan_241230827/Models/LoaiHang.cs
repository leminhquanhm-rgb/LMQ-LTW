using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LeMinhQuan_241230827.Models;

[Table("LoaiHang")]
public partial class LoaiHang
{
    [Key]
    public int MaLoai { get; set; }

    [StringLength(50)]
    public string TenLoai { get; set; } = null!;

    [InverseProperty("MaLoaiNavigation")]
    public virtual ICollection<HangHoa> HangHoas { get; set; } = new List<HangHoa>();
}
