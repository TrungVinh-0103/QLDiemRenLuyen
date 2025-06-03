using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.BUS;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.Helpers;
using System.Data.SqlClient;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.GUI
{

    public partial class frmSuaSinhVien : Form
    {
        private SinhVienBUS svBUS = new SinhVienBUS();
        private LopBUS lopBUS = new LopBUS();
        private KhoaBUS khoaBUS = new KhoaBUS();
        private NienKhoaBUS nienKhoaBUS = new NienKhoaBUS();
        private string maSV;
        private string tenSV;
        public event Action SinhVienUpdated;
        public frmSuaSinhVien(SinhVien sv)
        {
            InitializeComponent();
            maSV = sv.MaSV;
            LoadCombobox();
            LoadData();

        }

        private void LoadCombobox()
        {
            cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });
            cboTrangThai.Items.AddRange(new string[] { "Đang học", "Nghỉ học" });

            cboTenLop.DataSource = lopBUS.SearchLop("");
            cboTenLop.DisplayMember = "TenLop";
            cboTenLop.ValueMember = "TenLop";

            cboMaKhoa.DataSource = khoaBUS.GetAllKhoa();
            cboMaKhoa.DisplayMember = "TenKhoa";
            cboMaKhoa.ValueMember = "MaKhoa";

            cboMaNienKhoa.DataSource = nienKhoaBUS.GetAllNienKhoa();
            cboMaNienKhoa.DisplayMember = "TenNienKhoa";
            cboMaNienKhoa.ValueMember = "MaNienKhoa";
        }

        private void LoadData()
        {
            DataTable dt = svBUS.SearchSinhVien(maSV);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtMaSV.Text = row["MaSV"].ToString();
                txtHoTen.Text = row["HoTen"].ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row["NgaySinh"]);
                cboGioiTinh.SelectedItem = row["GioiTinh"].ToString();
                txtQueQuan.Text = row["QueQuan"].ToString();
                cboTenLop.SelectedValue = row["TenLop"].ToString();
                cboMaKhoa.SelectedValue = row["MaKhoa"].ToString();
                cboMaNienKhoa.SelectedValue = row["MaNienKhoa"].ToString();
                cboTrangThai.SelectedItem = row["TrangThai"].ToString();
            }
        }

        private void frmSuaSinhVien_Load(object sender, EventArgs e)
        {
            // Thiết lập tiêu đề cho form
            this.Text = "Sửa thông tin sinh viên - " + tenSV;
            // Thiết lập các sự kiện cho các trường nhập liệu
            txtMaSV.TextChanged += txtMaSV_TextChanged;
            txtHoTen.TextChanged += txtHoTen_TextChanged;
            dtpNgaySinh.ValueChanged += dtpNgaySinh_ValueChanged;
            cboGioiTinh.SelectedIndexChanged += cboGioiTinh_SelectedIndexChanged;
            txtQueQuan.TextChanged += txtQueQuan_TextChanged;
            cboTenLop.SelectedIndexChanged += cboTenLop_SelectedIndexChanged;
            cboMaKhoa.SelectedIndexChanged += cboMaKhoa_SelectedIndexChanged;
            cboMaNienKhoa.SelectedIndexChanged += cboMaNienKhoa_SelectedIndexChanged;
            cboTrangThai.SelectedIndexChanged += cboTrangThai_SelectedIndexChanged;
        }


        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu mã sinh viên không hợp lệ (ví dụ: rỗng hoặc chỉ chứa khoảng trắng)
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Mã sinh viên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra nếu mã sinh viên đã tồn tại trong cơ sở dữ liệu
            if (svBUS.CheckMaSVExists(txtMaSV.Text) && txtMaSV.Text != maSV)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu tên sinh viên không hợp lệ (ví dụ: rỗng hoặc chỉ chứa khoảng trắng)
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Tên sinh viên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu ngày sinh không hợp lệ (ví dụ: ngày sinh không được lớn hơn ngày hiện tại)
            if (dtpNgaySinh.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không được lớn hơn ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Value = DateTime.Now; 
            }
        }

        private void cboGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu giới tính không được chọn
            if (cboGioiTinh.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtQueQuan_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu quê quán không hợp lệ (ví dụ: rỗng hoặc chỉ chứa khoảng trắng)
            if (string.IsNullOrWhiteSpace(txtQueQuan.Text))
            {
                MessageBox.Show("Quê quán không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void cboTenLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu tên lớp không được chọn
            if (cboTenLop.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tên lớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void cboMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu mã khoa không được chọn
            if (cboMaKhoa.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mã khoa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void cboMaNienKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu mã niên khóa không được chọn
            if (cboMaNienKhoa.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mã niên khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu trạng thái không được chọn
            if (cboTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //full code hoạt động của nút Lưu
            try
            {
                // Tạo đối tượng SinhVien từ dữ liệu trên form
                SinhVien sv = new SinhVien
                {
                    MaSV = txtMaSV.Text.Trim(),
                    HoTen = txtHoTen.Text.Trim(),
                    NgaySinh = dtpNgaySinh.Value,
                    GioiTinh = cboGioiTinh.SelectedItem.ToString(),
                    QueQuan = txtQueQuan.Text.Trim(),
                    TenLop = cboTenLop.SelectedValue.ToString(),
                    MaKhoa = cboMaKhoa.SelectedValue.ToString(),
                    MaNienKhoa = cboMaNienKhoa.SelectedValue.ToString(),
                    TrangThai = cboTrangThai.SelectedItem.ToString()
                };
                // Gọi phương thức cập nhật sinh viên từ BUS
                if (svBUS.UpdateSinhVien(sv, maSV))
                {
                    MessageBox.Show("Cập nhật thông tin sinh viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Gọi sự kiện để thông báo cập nhật thành công
                    SinhVienUpdated?.Invoke();
                    this.Close(); // Đóng form sau khi lưu thành công
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin sinh viên không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Khi người dùng nhấn nút hủy, sẽ hiển thị hộp thoại xác nhận, nếu người dùng chọn "Yes" thì sẽ đóng form mà ko lưu dữ liệu
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
