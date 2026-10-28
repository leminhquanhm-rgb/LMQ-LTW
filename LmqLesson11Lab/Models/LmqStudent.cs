using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
namespace LmqLesson11Lab.Models
{
    public class LmqStudent
    {
        public int Id { get; set; } // Mã sinh viên

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ tên.")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải từ 4 đến 100 ký tự.")]
        public string? Name { get; set; }

        [Display(Name = "Thư điện tử (Email)")]
        [Required(ErrorMessage = "Email bắt buộc phải được nhập.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Địa chỉ email phải có đuôi gmail.com.")]
        public string? Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$", ErrorMessage = "Mật khẩu từ 8 ký tự trở lên, gồm chữ hoa, chữ thường, số và ký tự đặc biệt.")]
        public string? Password { get; set; }

        [Display(Name = "Ngành học")]
        [Required(ErrorMessage = "Vui lòng chọn ngành học.")]
        public Branch? Branch { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Vui lòng chọn giới tính.")]
        public Gender? Gender { get; set; }

        [Display(Name = "Hệ chính quy")]
        public bool IsRegular { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ.")]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Vui lòng nhập ngày sinh.")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1963", "12/31/2005", ErrorMessage = "Ngày sinh phải nằm trong khoảng 1963 đến 2005.")]
        public DateTime DateOfBorth { get; set; }

        // Thêm trường Điểm theo yêu cầu số 4
        [Display(Name = "Điểm số")]
        [Required(ErrorMessage = "Vui lòng nhập điểm.")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải là số thực từ 0.0 đến 10.0.")]
        public double Diem { get; set; }
    }

    public enum Branch { IT = 1, BE = 2, CE = 3, EE = 4 }
    public enum Gender { Nam = 1, Nữ = 2 }
}
