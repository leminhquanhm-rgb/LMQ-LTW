using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace LeMinhQuan_241230827.Models
{
 
    [ModelMetadataType(typeof(TaiSanMetadata))]
    public partial class TaiSan { }

    public class TaiSanMetadata
    {
        [Display(Name = "Loại tài sản")]
        public int MaLoai { get; set; }

        [Display(Name = "Tên tài sản")]
        [Required(ErrorMessage = "Tên tài sản không được để trống")]
        public string? TenTs { get; set; }

        [Display(Name = "Nguyên giá (triệu đồng)")]
        [Required(ErrorMessage = "Nguyên giá không được để trống")]
        [Range(1, 2000, ErrorMessage = "Nguyên giá phải từ 1 đến 2000 (triệu đồng)")]
        public decimal? NguyenGia { get; set; }

        [Display(Name = "Ảnh")]
        [RegularExpression(@"^.+\.(jpg|jpeg|png|webp|JPG|JPEG|PNG|WEBP)$",
            ErrorMessage = "Tên ảnh phải có đuôi .jpg, .jpeg, .png hoặc .webp")]
        public string? Anh { get; set; }
    }
}