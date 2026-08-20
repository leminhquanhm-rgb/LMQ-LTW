using System;
using System.Collections.Generic;
using System.Linq;

namespace lmq_Bai2
{
    internal class Program
    {
        static List<Employee> danhSachNV = new List<Employee>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            NapDuLieuMau();
            ChayMenu();
        }

        // ================== MENU CHÍNH ==================
        static void ChayMenu()
        {
            bool tiepTuc = true;
            while (tiepTuc)
            {
                Console.WriteLine();
                Console.WriteLine("===== QUẢN LÝ NHÂN VIÊN & TÍNH LƯƠNG =====");
                Console.WriteLine("1. Thêm nhân viên theo từng loại");
                Console.WriteLine("2. Hiển thị danh sách nhân viên");
                Console.WriteLine("3. Tính lương từng nhân viên");
                Console.WriteLine("4. Tính tổng quỹ lương");
                Console.WriteLine("5. Tìm nhân viên có lương cao nhất");
                Console.WriteLine("6. Sắp xếp nhân viên theo lương");
                Console.WriteLine("7. Thống kê lương theo phòng ban");
                Console.WriteLine("8. Lọc nhân viên có thời gian làm việc trên 3 năm");
                Console.WriteLine("9. Xuất bảng lương theo tháng");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");

                string luaChon = Console.ReadLine();

                try
                {
                    switch (luaChon)
                    {
                        case "1": ThemNhanVien(); break;
                        case "2": HienThiDanhSach(danhSachNV); break;
                        case "3": TinhLuongTungNhanVien(); break;
                        case "4": TinhTongQuyLuong(); break;
                        case "5": TimNhanVienLuongCaoNhat(); break;
                        case "6": SapXepTheoLuong(); break;
                        case "7": ThongKeLuongTheoPhongBan(); break;
                        case "8": LocNhanVienLamTrenBaNam(); break;
                        case "9": XuatBangLuongTheoThang(); break;
                        case "0": tiepTuc = false; break;
                        default: Console.WriteLine("Lựa chọn không hợp lệ."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }

            Console.WriteLine("Tạm biệt!");
        }

        // ================== 1. THÊM NHÂN VIÊN THEO TỪNG LOẠI ==================
        static void ThemNhanVien()
        {
            Console.WriteLine("Chọn loại nhân viên:");
            Console.WriteLine("1. Chính thức");
            Console.WriteLine("2. Thử việc");
            Console.WriteLine("3. Thời vụ");
            Console.WriteLine("4. Kinh doanh");
            Console.Write("Chọn: ");
            string loai = Console.ReadLine();

            Console.Write("Mã nhân viên: ");
            string maNV = Console.ReadLine();

            if (danhSachNV.Any(nv => nv.maNV.Equals(maNV, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Mã nhân viên đã tồn tại.");
                return;
            }

            Console.Write("Họ tên: ");
            string hoTen = Console.ReadLine();

            Console.Write("Phòng ban: ");
            string phongBan = Console.ReadLine();

            Console.Write("Ngày vào làm (dd/MM/yyyy): ");
            DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null,
                System.Globalization.DateTimeStyles.None, out DateTime ngayVaoLam);

            Employee nv = null;

            // Đây là nơi duy nhất dùng switch để hỏi thông tin nhập liệu riêng cho từng loại.
            // Việc TÍNH LƯƠNG thì KHÔNG dùng if/switch nào cả - nhờ đa hình (override TinhLuong).
            switch (loai)
            {
                case "1":
                    Console.Write("Lương cơ bản: ");
                    float luongCoBan1 = float.Parse(Console.ReadLine());
                    Console.Write("Phụ cấp: ");
                    float phuCap = float.Parse(Console.ReadLine());
                    nv = new NhanVienChinhThuc(maNV, hoTen, phongBan, ngayVaoLam, luongCoBan1, phuCap);
                    break;

                case "2":
                    Console.Write("Lương cơ bản: ");
                    float luongCoBan2 = float.Parse(Console.ReadLine());
                    nv = new NhanVienThuViec(maNV, hoTen, phongBan, ngayVaoLam, luongCoBan2);
                    break;

                case "3":
                    Console.Write("Số giờ làm: ");
                    float soGio = float.Parse(Console.ReadLine());
                    Console.Write("Đơn giá giờ: ");
                    float donGia = float.Parse(Console.ReadLine());
                    nv = new NhanVienThoiVu(maNV, hoTen, phongBan, ngayVaoLam, soGio, donGia);
                    break;

                case "4":
                    Console.Write("Lương cơ bản: ");
                    float luongCoBan4 = float.Parse(Console.ReadLine());
                    Console.Write("Doanh số: ");
                    float doanhSo = float.Parse(Console.ReadLine());
                    Console.Write("Tỷ lệ hoa hồng (VD 0.05 = 5%): ");
                    float tyLe = float.Parse(Console.ReadLine());
                    nv = new NhanVienKinhDoanh(maNV, hoTen, phongBan, ngayVaoLam, luongCoBan4, doanhSo, tyLe);
                    break;

                default:
                    Console.WriteLine("Loại nhân viên không hợp lệ.");
                    return;
            }

            danhSachNV.Add(nv);
            Console.WriteLine("Đã thêm nhân viên thành công.");
        }

        // ================== 2. HIỂN THỊ DANH SÁCH ==================
        static void HienThiDanhSach(List<Employee> ds)
        {
            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            // Mỗi nhân viên tự biết cách in thông tin & tính lương của chính nó (đa hình)
            foreach (Employee nv in ds)
                nv.InThongTin();

            Console.WriteLine($"-> Tổng cộng: {ds.Count} nhân viên.");
        }

        // ================== 3. TÍNH LƯƠNG TỪNG NHÂN VIÊN ==================
        static void TinhLuongTungNhanVien()
        {
            Console.Write("Nhập mã nhân viên: ");
            string maNV = Console.ReadLine();

            Employee nv = danhSachNV.FirstOrDefault(x => x.maNV.Equals(maNV, StringComparison.OrdinalIgnoreCase));
            if (nv == null)
            {
                Console.WriteLine("Không tìm thấy nhân viên.");
                return;
            }

            Console.WriteLine($"Lương của {nv.hoTen}: {nv.TinhLuong():N0} VNĐ");
        }

        // ================== 4. TÍNH TỔNG QUỸ LƯƠNG ==================
        static void TinhTongQuyLuong()
        {
            float tong = danhSachNV.Sum(nv => nv.TinhLuong());
            Console.WriteLine($"Tổng quỹ lương: {tong:N0} VNĐ");
        }

        // ================== 5. TÌM NHÂN VIÊN LƯƠNG CAO NHẤT ==================
        static void TimNhanVienLuongCaoNhat()
        {
            if (danhSachNV.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            float luongCaoNhat = danhSachNV.Max(nv => nv.TinhLuong());
            List<Employee> ds = danhSachNV.Where(nv => nv.TinhLuong() == luongCaoNhat).ToList();
            HienThiDanhSach(ds);
        }

        // ================== 6. SẮP XẾP THEO LƯƠNG ==================
        static void SapXepTheoLuong()
        {
            List<Employee> ds = danhSachNV.OrderByDescending(nv => nv.TinhLuong()).ToList();
            HienThiDanhSach(ds);
        }

        // ================== 7. THỐNG KÊ LƯƠNG THEO PHÒNG BAN ==================
        static void ThongKeLuongTheoPhongBan()
        {
            var thongKe = danhSachNV.GroupBy(nv => nv.phongBan);

            foreach (var nhom in thongKe)
            {
                float tongLuong = nhom.Sum(nv => nv.TinhLuong());
                Console.WriteLine($"- {nhom.Key}: {nhom.Count()} nhân viên, tổng lương: {tongLuong:N0} VNĐ");
            }
        }

        // ================== 8. LỌC NHÂN VIÊN LÀM VIỆC TRÊN 3 NĂM ==================
        static void LocNhanVienLamTrenBaNam()
        {
            List<Employee> ds = danhSachNV
                .Where(nv => nv.ngayVaoLam.AddYears(3) <= DateTime.Now)
                .ToList();

            HienThiDanhSach(ds);
        }

        // ================== 9. XUẤT BẢNG LƯƠNG THEO THÁNG ==================
        static void XuatBangLuongTheoThang()
        {
            Console.Write("Nhập tháng/năm cần xuất bảng lương (MM/yyyy): ");
            string thangNam = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"===== BẢNG LƯƠNG THÁNG {thangNam} =====");

            if (danhSachNV.Count == 0)
            {
                Console.WriteLine("Không có dữ liệu nhân viên.");
                return;
            }

            foreach (Employee nv in danhSachNV)
            {
                Console.WriteLine($"{nv.maNV,-6} | {nv.hoTen,-20} | {nv.phongBan,-12} | Lương: {nv.TinhLuong():N0} VNĐ");
            }

            float tongQuyLuong = danhSachNV.Sum(nv => nv.TinhLuong());
            Console.WriteLine($"Tổng quỹ lương tháng {thangNam}: {tongQuyLuong:N0} VNĐ");
        }

        // ================== DỮ LIỆU MẪU ĐỂ TEST NHANH ==================
        static void NapDuLieuMau()
        {
            danhSachNV.Add(new NhanVienChinhThuc(
                "NV001", "Nguyễn Văn An", "Kỹ thuật", new DateTime(2020, 5, 10), 10_000_000, 1_500_000));

            danhSachNV.Add(new NhanVienThuViec(
                "NV002", "Trần Thị Bình", "Nhân sự", new DateTime(2025, 1, 15), 8_000_000));

            danhSachNV.Add(new NhanVienThoiVu(
                "NV003", "Lê Hoàng Cường", "Kho vận", new DateTime(2024, 6, 1), 160, 50_000));

            danhSachNV.Add(new NhanVienKinhDoanh(
                "NV004", "Phạm Thị Dung", "Kinh doanh", new DateTime(2019, 3, 20), 6_000_000, 200_000_000, 0.05f));
        }
    }
}