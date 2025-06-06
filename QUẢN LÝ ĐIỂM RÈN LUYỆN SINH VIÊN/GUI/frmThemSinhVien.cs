using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.BUS;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.Helpers;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.GUI
{
    public partial class frmThemSinhVien : Form
    {
        private SinhVienBUS sinhVienBUS = new SinhVienBUS();
        private LopBUS lopBUS = new LopBUS();
        private ErrorProvider errorProvider = new ErrorProvider();
        public event Action SinhVienAdded; // Khai báo event ở đầu class



        public frmThemSinhVien()
        {
            InitializeComponent();
            LoadComboBoxSinhVien();
        }

        private void frmThemSinhVien_Load(object sender, EventArgs e){}

        private void LoadComboBoxSinhVien()
        {
            try
            {
                // Full code Load danh sách giới tính vào ComboBox
                DataTable dtGioiTinh = new DataTable();
                dtGioiTinh.Columns.Add("GioiTinh");
                dtGioiTinh.Rows.Add("Nam");
                dtGioiTinh.Rows.Add("Nữ");
                cboGioiTinh.DataSource = dtGioiTinh;
                cboGioiTinh.DisplayMember = "GioiTinh";
                cboGioiTinh.ValueMember = "GioiTinh";
                // Đặt giá trị mặc định cho ComboBox giới tính
                cboGioiTinh.SelectedIndex = -1; // Không chọn mặc định
                cboGioiTinh.SelectedIndexChanged += cboGioiTinh_SelectedIndexChanged;
                // Load danh sách lớp vào ComboBox
                DataTable dtLop = lopBUS.GetAllLop();
                cboTenLop.DataSource = dtLop;
                cboTenLop.DisplayMember = "TenLop";
                cboTenLop.ValueMember = "TenLop";
                // Load danh sách khoa vào ComboBox
                DataTable dtKhoa = lopBUS.GetAllKhoa();
                cboMaKhoa.DataSource = dtKhoa;
                cboMaKhoa.DisplayMember = "TenKhoa";
                cboMaKhoa.ValueMember = "MaKhoa";
                // Load danh sách niên khóa vào ComboBox
                DataTable dtNienKhoa = lopBUS.GetAllNienKhoa();
                cboMaNienKhoa.DataSource = dtNienKhoa;
                cboMaNienKhoa.DisplayMember = "TenNienKhoa";
                cboMaNienKhoa.ValueMember = "MaNienKhoa";
                // Load trạng thái vào ComboBox
                DataTable dtTrangThai = new DataTable();
                dtTrangThai.Columns.Add("TrangThai");
                dtTrangThai.Rows.Add("Đang học");
                dtTrangThai.Rows.Add("Nghỉ học");
                cboTrangThai.DataSource = dtTrangThai;
                cboTrangThai.DisplayMember = "TrangThai";
                cboTrangThai.ValueMember = "TrangThai";
                // Đặt giá trị mặc định cho ComboBox trạng thái
                cboTrangThai.SelectedIndex = -1; // Không chọn mặc định
                cboTrangThai.SelectedIndexChanged += cboTrangThai_SelectedIndexChanged;
                //cboTrangThai.Items.Add("Đang học");
                //cboTrangThai.Items.Add("Nghỉ học");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra mã sinh viên có hợp lệ hay không
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                errorProvider.SetError(txtMaSV, "Mã sinh viên không được để trống.");
            }
            else
            {
                errorProvider.SetError(txtMaSV, string.Empty);
            }
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra họ tên có hợp lệ hay không
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                errorProvider.SetError(txtHoTen, "Họ và tên không được để trống.");
            }
            else
            {
                errorProvider.SetError(txtHoTen, string.Empty);
            }
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            // Kiểm tra ngày sinh có hợp lệ hay không
            if (dtpNgaySinh.Value > DateTime.Now)
            {
                errorProvider.SetError(dtpNgaySinh, "Ngày sinh không được lớn hơn ngày hiện tại.");
            }
            else
            {
                errorProvider.SetError(dtpNgaySinh, string.Empty);
            }
        }

        private void cboGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra giới tính có được chọn hay không
            if (cboGioiTinh.SelectedIndex == -1)
            {
                errorProvider.SetError(cboGioiTinh, "Vui lòng chọn giới tính.");
            }
            else
            {
                errorProvider.SetError(cboGioiTinh, string.Empty);
            }
        }

        private void txtQueQuan_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra quê quán có hợp lệ hay không
            if (string.IsNullOrWhiteSpace(txtQueQuan.Text))
            {
                errorProvider.SetError(txtQueQuan, "Quê quán không được để trống.");
            }
            else
            {
                errorProvider.SetError(txtQueQuan, string.Empty);
            }
        }

        private void cboTenLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra lớp có được chọn hay không
            if (cboTenLop.SelectedIndex == -1)
            {
                errorProvider.SetError(cboTenLop, "Vui lòng chọn lớp.");
            }
            else
            {
                errorProvider.SetError(cboTenLop, string.Empty);
            }
        }

        private void cboMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra khoa có được chọn hay không
            if (cboMaKhoa.SelectedIndex == -1)
            {
                errorProvider.SetError(cboMaKhoa, "Vui lòng chọn khoa.");
            }
            else
            {
                errorProvider.SetError(cboMaKhoa, string.Empty);
            }
        }

        private void cboMaNienKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra niên khóa có được chọn hay không
            if (cboMaNienKhoa.SelectedIndex == -1)
            {
                errorProvider.SetError(cboMaNienKhoa, "Vui lòng chọn niên khóa.");
            }
            else
            {
                errorProvider.SetError(cboMaNienKhoa, string.Empty);
            }
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra trạng thái có được chọn hay không
            if (cboTrangThai.SelectedIndex == -1)
            {
                errorProvider.SetError(cboTrangThai, "Vui lòng chọn trạng thái.");
            }
            else
            {
                errorProvider.SetError(cboTrangThai, string.Empty);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường dữ liệu
                if (string.IsNullOrWhiteSpace(txtMaSV.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                    dtpNgaySinh.Value > DateTime.Now || cboGioiTinh.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtQueQuan.Text) || cboTenLop.SelectedIndex == -1 ||
                    cboMaKhoa.SelectedIndex == -1 || cboMaNienKhoa.SelectedIndex == -1 ||
                    cboTrangThai.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Tạo đối tượng SinhVien
                SinhVien sv = new SinhVien
                {
                    MaSV = txtMaSV.Text.Trim(),
                    HoTen = txtHoTen.Text.Trim(),
                    NgaySinh = dtpNgaySinh.Value,
                    GioiTinh = cboGioiTinh.Text,
                    QueQuan = txtQueQuan.Text.Trim(),
                    TenLop = cboTenLop.SelectedValue.ToString(),
                    MaKhoa = cboMaKhoa.SelectedValue.ToString(),
                    MaNienKhoa = cboMaNienKhoa.SelectedValue.ToString(),
                    TrangThai = cboTrangThai.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                };
                // Thêm sinh viên vào cơ sở dữ liệu
                if (sinhVienBUS.InsertSinhVien(sv))
                {
                    MessageBox.Show("Thêm sinh viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SinhVienAdded?.Invoke(); // Gọi sự kiện để frmQuanLySinhVien tự load lại
                    this.Close(); // Đóng form sau khi thêm thành công
                }
                else
                {
                    MessageBox.Show("Thêm sinh viên thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //Hiển thị hộp thoại xác nhận hủy
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy không?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }


    }
}
