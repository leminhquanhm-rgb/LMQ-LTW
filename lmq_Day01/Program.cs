using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace lmq_Day01
{
    internal class Program
    {
        static List<Student> danhSachSV = new List<Student>();

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
                Console.WriteLine("===== QUẢN LÝ SINH VIÊN =====");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Hiển thị danh sách");
                Console.WriteLine("3. Tìm sinh viên theo mã");
                Console.WriteLine("4. Tìm gần đúng theo họ tên");
                Console.WriteLine("5. Cập nhật sinh viên");
                Console.WriteLine("6. Xóa sinh viên");
                Console.WriteLine("7. Sắp xếp theo họ tên");
                Console.WriteLine("8. Sắp xếp theo điểm trung bình");
                Console.WriteLine("9. Hiển thị sinh viên điểm từ 8 trở lên");
                Console.WriteLine("10. Hiển thị sinh viên điểm cao nhất");
                Console.WriteLine("11. Tính điểm trung bình toàn bộ sinh viên");
                Console.WriteLine("12. Thống kê sinh viên theo ngành");
                Console.WriteLine("13. Thống kê sinh viên theo trạng thái");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");

                string luaChon = Console.ReadLine();

                try
                {
                    switch (luaChon)
                    {
                        case "1": ThemSinhVien(); break;
                        case "2": HienThiDanhSach(danhSachSV); break;
                        case "3": TimTheoMa(); break;
                        case "4": TimGanDungTheoHoTen(); break;
                        case "5": CapNhatSinhVien(); break;
                        case "6": XoaSinhVien(); break;
                        case "7": SapXepTheoHoTen(); break;
                        case "8": SapXepTheoDiem(); break;
                        case "9": LocDiemTuTaiLen(); break;
                        case "10": SinhVienDiemCaoNhat(); break;
                        case "11": TinhDiemTrungBinhToanBo(); break;
                        case "12": ThongKeTheoNganh(); break;
                        case "13": ThongKeTheoTrangThai(); break;
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

        // ================== 1. THÊM SINH VIÊN ==================
        static void ThemSinhVien()
        {
            Console.Write("Mã sinh viên: ");
            string masv = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(masv))
            {
                Console.WriteLine("Mã sinh viên không được để trống.");
                return;
            }

            if (danhSachSV.Any(sv => sv.masv.Equals(masv, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Mã sinh viên đã tồn tại.");
                return;
            }

            Console.Write("Họ tên: ");
            string hoTen = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                Console.WriteLine("Họ tên không được để trống.");
                return;
            }

            Console.Write("Ngày sinh (dd/MM/yyyy): ");
            DateTime? ngaySinh = null;
            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null,
                    System.Globalization.DateTimeStyles.None, out DateTime ns))
            {
                ngaySinh = ns;
            }

            Console.Write("Giới tính (1 = Nam, 0 = Nữ): ");
            bool gioiTinh = Console.ReadLine() == "1";

            Console.Write("Ngành học: ");
            string nganhHoc = Console.ReadLine();

            Console.Write("Email (Enter để bỏ trống): ");
            string email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email) && !KiemTraEmail(email))
            {
                Console.WriteLine("Email không đúng định dạng.");
                return;
            }

            Console.Write("Số điện thoại (Enter để bỏ trống): ");
            string sdt = Console.ReadLine();

            Student sv = new Student
            {
                masv = masv,
                hoTen = hoTen,
                ngaysinh = ngaySinh,
                gioitinh = gioiTinh,
                nganhHoc = nganhHoc,
                email = string.IsNullOrWhiteSpace(email) ? null : email,
                soDienThoai = string.IsNullOrWhiteSpace(sdt) ? null : sdt,
                dtb = 0,
                trangThai = true
            };

            danhSachSV.Add(sv);
            Console.WriteLine("Đã thêm sinh viên thành công.");
        }

        static bool KiemTraEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        // ================== 2. HIỂN THỊ DANH SÁCH ==================
        static void HienThiDanhSach(List<Student> ds)
        {
            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            foreach (Student sv in ds)
                sv.InThongTin();

            Console.WriteLine($"-> Tổng cộng: {ds.Count} sinh viên.");
        }

        // ================== 3. TÌM THEO MÃ ==================
        static void TimTheoMa()
        {
            Console.Write("Nhập mã sinh viên cần tìm: ");
            string masv = Console.ReadLine();

            Student sv = danhSachSV.FirstOrDefault(s => s.masv.Equals(masv, StringComparison.OrdinalIgnoreCase));

            if (sv == null)
                Console.WriteLine("Không tìm thấy sinh viên.");
            else
                sv.InThongTin();
        }

        // ================== 4. TÌM GẦN ĐÚNG THEO HỌ TÊN ==================
        static void TimGanDungTheoHoTen()
        {
            Console.Write("Nhập từ khóa họ tên: ");
            string tuKhoa = Console.ReadLine();

            List<Student> ketQua = danhSachSV
                .Where(sv => sv.hoTen.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase))
                .ToList();

            HienThiDanhSach(ketQua);
        }

        // ================== 5. CẬP NHẬT SINH VIÊN ==================
        static void CapNhatSinhVien()
        {
            Console.Write("Nhập mã sinh viên cần cập nhật: ");
            string masv = Console.ReadLine();

            Student sv = danhSachSV.FirstOrDefault(s => s.masv.Equals(masv, StringComparison.OrdinalIgnoreCase));
            if (sv == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên.");
                return;
            }

            Console.WriteLine("Thông tin hiện tại:");
            sv.InThongTin();
            Console.WriteLine("Nhập thông tin mới:");

            Console.Write("Họ tên: ");
            string hoTen = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(hoTen)) sv.hoTen = hoTen;

            Console.Write("Ngành học: ");
            string nganh = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nganh)) sv.nganhHoc = nganh;

            Console.Write("Điểm trung bình mới: ");
            if (float.TryParse(Console.ReadLine(), out float diem))
            {
                if (diem < 0 || diem > 10)
                    Console.WriteLine("Điểm trung bình phải từ 0 đến 10. Không cập nhật điểm.");
                else
                    sv.dtb = diem;
            }

            Console.Write("Trạng thái (1 = Đang học, 0 = Không còn học): ");
            string trangThaiInput = Console.ReadLine();
            if (trangThaiInput == "1" || trangThaiInput == "0")
                sv.trangThai = trangThaiInput == "1";

            Console.WriteLine("Cập nhật thành công.");
        }

        // ================== 6. XÓA SINH VIÊN ==================
        static void XoaSinhVien()
        {
            Console.Write("Nhập mã sinh viên cần xóa: ");
            string masv = Console.ReadLine();

            Student sv = danhSachSV.FirstOrDefault(s => s.masv.Equals(masv, StringComparison.OrdinalIgnoreCase));
            if (sv == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên.");
                return;
            }

            danhSachSV.Remove(sv);
            Console.WriteLine("Đã xóa sinh viên.");
        }

        // ================== 7. SẮP XẾP THEO HỌ TÊN ==================
        static void SapXepTheoHoTen()
        {
            List<Student> ds = danhSachSV.OrderBy(sv => sv.hoTen).ToList();
            HienThiDanhSach(ds);
        }

        // ================== 8. SẮP XẾP THEO ĐIỂM TRUNG BÌNH ==================
        static void SapXepTheoDiem()
        {
            List<Student> ds = danhSachSV.OrderByDescending(sv => sv.dtb).ToList();
            HienThiDanhSach(ds);
        }

        // ================== 9. LỌC SINH VIÊN ĐIỂM TỪ 8 TRỞ LÊN ==================
        static void LocDiemTuTaiLen()
        {
            List<Student> ds = danhSachSV.Where(sv => sv.dtb >= 8).ToList();
            HienThiDanhSach(ds);
        }

        // ================== 10. SINH VIÊN ĐIỂM CAO NHẤT ==================
        static void SinhVienDiemCaoNhat()
        {
            if (danhSachSV.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            float diemCaoNhat = danhSachSV.Max(sv => sv.dtb);
            List<Student> ds = danhSachSV.Where(sv => sv.dtb == diemCaoNhat).ToList();
            HienThiDanhSach(ds);
        }

        // ================== 11. ĐIỂM TRUNG BÌNH TOÀN BỘ ==================
        static void TinhDiemTrungBinhToanBo()
        {
            if (danhSachSV.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            float trungBinh = danhSachSV.Average(sv => sv.dtb);
            Console.WriteLine($"Điểm trung bình toàn bộ sinh viên: {trungBinh:0.00}");
        }

        // ================== 12. THỐNG KÊ THEO NGÀNH ==================
        static void ThongKeTheoNganh()
        {
            var thongKe = danhSachSV.GroupBy(sv => sv.nganhHoc);

            foreach (var nhom in thongKe)
                Console.WriteLine($"- {nhom.Key}: {nhom.Count()} sinh viên");
        }

        // ================== 13. THỐNG KÊ THEO TRẠNG THÁI ==================
        static void ThongKeTheoTrangThai()
        {
            var thongKe = danhSachSV.GroupBy(sv => sv.trangThai ? "Đang học" : "Không còn học");

            foreach (var nhom in thongKe)
                Console.WriteLine($"- {nhom.Key}: {nhom.Count()} sinh viên");
        }

        // ================== DỮ LIỆU MẪU ĐỂ TEST NHANH ==================
        static void NapDuLieuMau()
        {
            danhSachSV.Add(new Student
            {
                masv = "SV001",
                hoTen = "Nguyễn Văn An",
                ngaysinh = new DateTime(2004, 3, 12),
                gioitinh = true,
                nganhHoc = "Công nghệ thông tin",
                email = "an.nv@example.com",
                dtb = 8.5f,
                trangThai = true
            });

            danhSachSV.Add(new Student
            {
                masv = "SV002",
                hoTen = "Trần Thị Bình",
                ngaysinh = new DateTime(2003, 11, 5),
                gioitinh = false,
                nganhHoc = "Công nghệ thông tin",
                dtb = 7.2f,
                trangThai = true
            });

            danhSachSV.Add(new Student
            {
                masv = "SV003",
                hoTen = "Lê Hoàng Cường",
                ngaysinh = new DateTime(2004, 7, 20),
                gioitinh = true,
                nganhHoc = "Kỹ thuật phần mềm",
                dtb = 9.1f,
                trangThai = false
            });
        }
    }
}