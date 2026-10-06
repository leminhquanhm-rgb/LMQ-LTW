using System.Data;

namespace BanHang
{
    public partial class frmMatHang : Form
    {

        Classes.DataBaseProcess dtbase =
            new Classes.DataBaseProcess();
        public frmMatHang()
        {
            InitializeComponent();
        }

        private void HienChiTiet(bool hien)
        {
            txtMaSP.Enabled = hien;
            txtTenSP.Enabled = hien;
            dtpNgaySX.Enabled = hien;
            dtpNgayHH.Enabled = hien;
            txtDonVi.Enabled = hien;
            txtDonGia.Enabled = hien;
            txtGhiChu.Enabled = hien;

            btnLuu.Enabled = hien;
            btnHuy.Enabled = hien;
        }

        private void frmMatHang_Load(object sender, EventArgs e)
        {
            // Load dữ liệu lên DataGridView
            dgvMatHang.DataSource =
                dtbase.DataReader("SELECT * FROM tblMatHang");

            // Ban đầu chưa chọn sản phẩm nên không cho Sửa, Xóa
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            // Ẩn phần Chi tiết
            HienChiTiet(false);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tblMatHang WHERE 1=1";

            if (txtTKMaSP.Text != "")
            {
                sql += " AND MaSP LIKE N'%" + txtTKMaSP.Text + "%'";
            }

            if (txtTKTenSP.Text != "")
            {
                sql += " AND TenSP LIKE N'%" + txtTKTenSP.Text + "%'";
            }

            dgvMatHang.DataSource = dtbase.DataReader(sql);

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dgvMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra người dùng có bấm vào dòng dữ liệu hay không
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMatHang.Rows[e.RowIndex];

                txtMaSP.Text = row.Cells["MaSP"].Value.ToString();
                txtTenSP.Text = row.Cells["TenSP"].Value.ToString();
                dtpNgaySX.Value = Convert.ToDateTime(row.Cells["NgaySX"].Value);
                dtpNgayHH.Value = Convert.ToDateTime(row.Cells["NgayHH"].Value);
                txtDonVi.Text = row.Cells["DonVi"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();

                // Cho phép sửa và xóa
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtDonVi.Clear();
            txtDonGia.Clear();
            txtGhiChu.Clear();

            dtpNgaySX.Value = DateTime.Now;
            dtpNgayHH.Value = DateTime.Now;

            HienChiTiet(true);

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            txtMaSP.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra tên sản phẩm
            if (txtTenSP.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm!");
                txtTenSP.Focus();
                return;
            }

            // Kiểm tra ngày sản xuất
            if (dtpNgaySX.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sản xuất không được lớn hơn ngày hiện tại!");
                return;
            }

            // Kiểm tra ngày hết hạn
            if (dtpNgayHH.Value < dtpNgaySX.Value)
            {
                MessageBox.Show("Ngày hết hạn phải lớn hơn ngày sản xuất!");
                return;
            }

            // Kiểm tra đơn vị
            if (txtDonVi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đơn vị!");
                txtDonVi.Focus();
                return;
            }

            // Kiểm tra đơn giá
            if (txtDonGia.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đơn giá!");
                txtDonGia.Focus();
                return;
            }

            // =========================
            // TRƯỜNG HỢP THÊM
            // =========================
            if (btnThem.Enabled == true)
            {
                if (txtMaSP.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã sản phẩm!");
                    txtMaSP.Focus();
                    return;
                }

                // Kiểm tra mã sản phẩm đã tồn tại
                string sqlCheck =
                    "SELECT * FROM tblMatHang WHERE MaSP = N'" +
                    txtMaSP.Text + "'";

                DataTable dt = dtbase.DataReader(sqlCheck);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại!");
                    txtMaSP.Focus();
                    return;
                }

                // Thêm sản phẩm
                string sql =
                    "INSERT INTO tblMatHang " +
                    "(MaSP, TenSP, NgaySX, NgayHH, DonVi, DonGia, GhiChu) " +
                    "VALUES (N'" + txtMaSP.Text +
                    "', N'" + txtTenSP.Text +
                    "', '" + dtpNgaySX.Value.ToString("yyyy-MM-dd") +
                    "', '" + dtpNgayHH.Value.ToString("yyyy-MM-dd") +
                    "', N'" + txtDonVi.Text +
                    "', " + txtDonGia.Text.Replace(",", ".") +
                    ", N'" + txtGhiChu.Text + "')";

                dtbase.DataChange(sql);

                MessageBox.Show("Thêm mặt hàng thành công!");
            }

            // =========================
            // TRƯỜNG HỢP SỬA
            // =========================
            else if (btnSua.Enabled == true)
            {
                string sql =
                    "UPDATE tblMatHang SET " +
                    "TenSP = N'" + txtTenSP.Text +
                    "', NgaySX = '" + dtpNgaySX.Value.ToString("yyyy-MM-dd") +
                    "', NgayHH = '" + dtpNgayHH.Value.ToString("yyyy-MM-dd") +
                    "', DonVi = N'" + txtDonVi.Text +
                    "', DonGia = " + txtDonGia.Text.Replace(",", ".") +
                    ", GhiChu = N'" + txtGhiChu.Text +
                    "' WHERE MaSP = N'" + txtMaSP.Text + "'";

                dtbase.DataChange(sql);

                MessageBox.Show("Cập nhật mặt hàng thành công!");
            }

            // Tải lại dữ liệu
            dgvMatHang.DataSource =
                dtbase.DataReader("SELECT * FROM tblMatHang");

            // Tắt phần Chi tiết
            HienChiTiet(false);

            // Đưa nút về trạng thái ban đầu
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            // Xóa dữ liệu
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtDonVi.Clear();
            txtDonGia.Clear();
            txtGhiChu.Clear();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Tắt phần Chi tiết
            HienChiTiet(false);

            // Đưa các nút về trạng thái ban đầu
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            // Xóa dữ liệu trong các ô nhập
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtDonVi.Clear();
            txtDonGia.Clear();
            txtGhiChu.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Cho phép sửa thông tin
            HienChiTiet(true);

            // Không cho phép thêm và xóa
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = false;

            // Không cho sửa mã sản phẩm
            txtMaSP.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa mặt hàng này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string sql =
                    "DELETE FROM tblMatHang " +
                    "WHERE MaSP = N'" + txtMaSP.Text + "'";

                dtbase.DataChange(sql);

                MessageBox.Show("Xóa mặt hàng thành công!");

                // Cập nhật lại DataGridView
                dgvMatHang.DataSource =
                    dtbase.DataReader("SELECT * FROM tblMatHang");

                // Đưa Form về trạng thái ban đầu
                HienChiTiet(false);

                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;

                // Xóa dữ liệu
                txtMaSP.Clear();
                txtTenSP.Clear();
                txtDonVi.Clear();
                txtDonGia.Clear();
                txtGhiChu.Clear();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Bạn có muốn thoát chương trình không?",
               "Xác nhận",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
