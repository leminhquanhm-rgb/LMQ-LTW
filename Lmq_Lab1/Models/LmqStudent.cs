using System.Reflection;

namespace Lmq_Lab1.Models
{
    public class LmqStudent
    {
        public int Id { get; set; }//Mã sinh viên
        public string? Name { get; set; } //Họ tên
        public string? Email { get; set; } //Email
        public string? Password { get; set; }//Mật khẩu
        public LmqBranch? Branch { get; set; }//Ngành học
        public LmqGender? Gender { get; set; }//Giới tính
        public bool IsRegular { get; set; }//Hệ: true-chính qui, false-phi cq
        public string? Address { get; set; }//Địa chi
        public DateTime DateOfBorth { get; set; }//Ngày sinh
    }
}
