using System;
using System.Collections.Generic;
using System.Text;

namespace lmq_Day01
{
    internal class Student
    {
        public string masv { get; set; }        // Mã sinh viên
        public string hoTen { get; set; }        // Họ tên
        public DateTime? ngaysinh { get; set; }   // Ngày sinh
        public bool gioitinh { get; set; }        // Giới tính: true = Nam, false = Nữ
        public string email { get; set; }         // Email
        public string soDienThoai { get; set; }   // Số điện thoại
        public string nganhHoc { get; set; }      // Ngành học
        public float dtb { get; set; }            // Điểm trung bình
        public bool trangThai { get; set; }       // Trạng thái học tập: true = Đang học, false = Không còn học

        public void InThongTin()
        {
            string gioiTinhStr = gioitinh ? "Nam" : "Nữ";
            string trangThaiStr = trangThai ? "Đang học" : "Không còn học";
            string ngaySinhStr = ngaysinh.HasValue ? ngaysinh.Value.ToString("dd/MM/yyyy") : "Chưa có";

            Console.WriteLine(
                $"{masv,-8} | {hoTen,-20} | {ngaySinhStr,-10} | {gioiTinhStr,-3} | " +
                $"{nganhHoc,-15} | DTB: {dtb,4:0.0} | {trangThaiStr}");
        }
    }
}