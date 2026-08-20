using System;
using System.Collections.Generic;
using System.Text;

namespace lmq_Bai2
{
    internal abstract class Employee
    {
        public string maNV {  get; set; }
        public string hoTen { get; set; }
        public string phongBan { get; set; }
        public DateTime ngayVaoLam { get; set; }
        public float luongCoBan { get; set; }


        public Employee(string maNV, string hoTen, string phongBan, DateTime ngayVaoLam, float luongCoBan)
        {
            this.maNV = maNV;
            this.hoTen = hoTen;
            this.phongBan = phongBan;
            this.ngayVaoLam = ngayVaoLam;
            this.luongCoBan = luongCoBan;
        }

        public abstract float TinhLuong();

        public virtual void InThongTin()
        {
            Console.WriteLine(
                $"{maNV,-6} | {hoTen,-20} | {phongBan,-12} | {ngayVaoLam:dd/MM/yyyy} | " +
                $"Loại: {this.GetType().Name,-18} | Lương: {TinhLuong():N0}");
        }

    }

    // ================== NHÂN VIÊN CHÍNH THỨC ==================
    // Lương = Lương cơ bản + Phụ cấp
    internal class NhanVienChinhThuc : Employee
    {
        public float phuCap { get; set; }

        public NhanVienChinhThuc(string maNV, string hoTen, string phongBan, DateTime ngayVaoLam,
            float luongCoBan, float phuCap)
            : base(maNV, hoTen, phongBan, ngayVaoLam, luongCoBan)
        {
            this.phuCap = phuCap;
        }

        public override float TinhLuong()
        {
            return luongCoBan + phuCap;
        }
    }

    // ================== NHÂN VIÊN THỬ VIỆC ==================
    // Lương = Lương cơ bản x 85%
    internal class NhanVienThuViec : Employee
    {
        public NhanVienThuViec(string maNV, string hoTen, string phongBan, DateTime ngayVaoLam, float luongCoBan)
            : base(maNV, hoTen, phongBan, ngayVaoLam, luongCoBan)
        {
        }

        public override float TinhLuong()
        {
            return luongCoBan * 0.85f;
        }
    }

    // ================== NHÂN VIÊN THỜI VỤ ==================
    // Lương = Số giờ làm x Đơn giá giờ
    internal class NhanVienThoiVu : Employee
    {
        public float soGioLam { get; set; }
        public float donGiaGio { get; set; }

        public NhanVienThoiVu(string maNV, string hoTen, string phongBan, DateTime ngayVaoLam,
            float soGioLam, float donGiaGio)
            : base(maNV, hoTen, phongBan, ngayVaoLam, luongCoBan: 0) // NV thời vụ không có lương cơ bản
        {
            this.soGioLam = soGioLam;
            this.donGiaGio = donGiaGio;
        }

        public override float TinhLuong()
        {
            return soGioLam * donGiaGio;
        }
    }

    // ================== NHÂN VIÊN KINH DOANH ==================
    // Lương = Lương cơ bản + Doanh số x Tỷ lệ hoa hồng
    internal class NhanVienKinhDoanh : Employee
    {
        public float doanhSo { get; set; }
        public float tyLeHoaHong { get; set; }

        public NhanVienKinhDoanh(string maNV, string hoTen, string phongBan, DateTime ngayVaoLam,
            float luongCoBan, float doanhSo, float tyLeHoaHong)
            : base(maNV, hoTen, phongBan, ngayVaoLam, luongCoBan)
        {
            this.doanhSo = doanhSo;
            this.tyLeHoaHong = tyLeHoaHong;
        }

        public override float TinhLuong()
        {
            return luongCoBan + doanhSo * tyLeHoaHong;
        }
    }

}
