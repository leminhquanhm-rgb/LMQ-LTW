using System.ComponentModel.DataAnnotations;

namespace Lmq_Lab5.Models
{
    public class LmqProduct : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [MinLength(6, ErrorMessage = "Tên sản phẩm phải có ít nhất 6 ký tự")]
        [MaxLength(150, ErrorMessage = "Tên sản phẩm không được vượt quá 150 ký tự")]
        public string Name { get; set; }

        [Display(Name = "Hình ảnh")]
        public string? Image { get; set; }

        [Display(Name = "Giá chuẩn")]
        [Required(ErrorMessage = "Giá chuẩn không được để trống")]
        [DataType(DataType.Text)]
        [Range(100000, float.MaxValue,
            ErrorMessage = "Giá chuẩn phải lớn hơn hoặc bằng 100.000")]
        public float Price { get; set; }

        [Display(Name = "Giá bán")]
        [Required(ErrorMessage = "Giá bán không được để trống")]
        [DataType(DataType.Text)]
        [Range(0, float.MaxValue,
            ErrorMessage = "Giá bán không được âm")]
        public float SalePrice { get; set; }

        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Mô tả không được để trống")]
        [MaxLength(1500,
            ErrorMessage = "Mô tả không được vượt quá 1500 ký tự")]
        public string Description { get; set; }

        [Display(Name = "Danh mục")]
        [Required(ErrorMessage = "Vui lòng chọn danh mục")]
        public int CategoryId { get; set; }

        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            if (SalePrice > Price * 0.9f)
            {
                yield return new ValidationResult(
                    "Giá bán phải nhỏ hơn hoặc bằng 90% giá chuẩn.",
                    new[] { nameof(SalePrice) }
                );
            }

            string[] sensitiveWords =
            {
                "die",
                "admin",
                "fack"
            };

            foreach (string word in sensitiveWords)
            {
                if (!string.IsNullOrEmpty(Description) &&
                    Description.Contains(
                        word,
                        StringComparison.OrdinalIgnoreCase))
                {
                    yield return new ValidationResult(
                        $"Mô tả không được chứa từ nhạy cảm: {word}",
                        new[] { nameof(Description) }
                    );
                }
            }
        }
    }
}