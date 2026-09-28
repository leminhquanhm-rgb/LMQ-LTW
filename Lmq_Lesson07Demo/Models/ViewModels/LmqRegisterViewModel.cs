using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lmq_Lesson07Demo.Models.ViewModels
{
    public class LmqRegisterViewModel
    {
        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được trống")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Độ dài tên từ 3-20 ký tự")]
        public string lmqUserName { get; set; }

        [DisplayName("Họ và tên")]
        [Required(ErrorMessage = "Họ và tên không được trống")]
        public string lmqFullName { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Hãy nhập Password")]
        [DataType(DataType.Password)]
        public string lmqPassword { get; set; }

        [DisplayName("Gõ lại mật khẩu")]
        [Required(ErrorMessage = "Hãy nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("lmqPassword", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        public string lmqConfirmPassword { get; set; }

        [DisplayName("Hòm thư")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email không bỏ trống")]
        public string lmqEmail { get; set; }

        [DisplayName("Điện thoại")]
        [RegularExpression(@"^0\d{9,12}$",
            ErrorMessage = "Phải bắt đầu bằng 0 và dài 10-13 số")]
        public string lmqPhone { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime lmqBirthday { get; set; }
    }
}