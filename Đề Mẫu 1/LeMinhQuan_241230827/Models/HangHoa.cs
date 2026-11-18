using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace LeMinhQuan_241230827.Models;

[Table("HangHoa")]
public partial class HangHoa
{
    [Key]
    public int MaHang { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn loại hàng")]
    public int MaLoai { get; set; }

    [Required(ErrorMessage = "Tên hàng không được để trống")]
    [StringLength(50, ErrorMessage = "Tên hàng tối đa 50 ký tự")]
    public string TenHang { get; set; } = null!;

    [Required(ErrorMessage = "Giá không được để trống")]
    [Range(100.0, 5000.0, ErrorMessage = "Giá phải là số và nằm trong khoảng từ 100 đến 5000")]
    [Column(TypeName = "numeric(18, 0)")]
    public decimal? Gia { get; set; }

    [Required(ErrorMessage = "Tên file ảnh không được để trống")]
    [StringLength(100, ErrorMessage = "Tên file ảnh tối đa 100 ký tự")]
    [RegularExpression(@"^.+\.([jJ][pP][gG]|[pP][nN][gG]|[gG][iI][fF]|[tT][iI][fF][fF])$",
        ErrorMessage = "Tên file ảnh phải có đuôi: .jpg, .png, .gif hoặc .tiff")]
    public string? Anh { get; set; }

    [ForeignKey("MaLoai")]
    [InverseProperty("HangHoas")]
    [ValidateNever]
    public virtual LoaiHang? MaLoaiNavigation { get; set; }
}
