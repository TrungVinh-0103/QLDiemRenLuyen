using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.BUS;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DAO;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.GUI
{
    public partial class frmQuanLySinhVien : Form
    {
        private SinhVienBUS svBUS = new SinhVienBUS(); //Tạo đối tượng SinhVienBUS để tương tác với dữ liệu sinh viên
        public frmQuanLySinhVien()
        {
            InitializeComponent();
            LoadDanhSachSinhVien(); // Gọi hàm để tải danh sách sinh viên
            this.Load += frmQuanLySinhVien_Load;
        }

        //Hàm Load ở đây 
        public void LoadDanhSachSinhVien()
        {
            try
            {
                DataTable dt = svBUS.GetAllSinhVien(); // Lấy tất cả sinh viên từ BUS

                // Sắp xếp DataTable theo HoTen (tên đầy đủ)
                DataView dv = dt.DefaultView;
                dv.Sort = "HoTen ASC";
                dt = dv.ToTable();

                // Tạo cột STT tạm nếu chưa có
                if (!dt.Columns.Contains("STT"))
                    dt.Columns.Add("STT", typeof(int));

                // Gán STT theo thứ tự dòng
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                }

                dgvSinhVien.DataSource = dt; // Gán dữ liệu vào DataGridView

                //Đặt tiêu đề cột cho DataGridView thành tiếng việt có dấu
                //dgvSinhVien.Columns["STT"].HeaderText = "STT";
                dgvSinhVien.Columns["MaSV"].HeaderText = "MSSV";
                dgvSinhVien.Columns["HoTen"].HeaderText = "Họ và tên";
                dgvSinhVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                dgvSinhVien.Columns["GioiTinh"].HeaderText = "Giới tính";
                dgvSinhVien.Columns["QueQuan"].HeaderText = "Quê quán";
                dgvSinhVien.Columns["TenLop"].HeaderText = "Tên lớp";
                dgvSinhVien.Columns["MaKhoa"].HeaderText = "Mã khoa";
                dgvSinhVien.Columns["MaNienKhoa"].HeaderText = "Niên khóa";
                dgvSinhVien.Columns["TrangThai"].HeaderText = "Trạng thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            DataTable dt = SinhVienDAO.GetAllSinhVien_STT();
            dgvSinhVien.DataSource = dt;

            // Gán STT tạm thời sau khi đổ dữ liệu
            for (int i = 0; i < dgvSinhVien.Rows.Count; i++)
            {
                dgvSinhVien.Rows[i].Cells["STT"].Value = i + 1;
            }

            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            //Hoạt động mở frmThemSinhVien
            frmThemSinhVien frm = new frmThemSinhVien();
            frm.SinhVienAdded += LoadDanhSachSinhVien;
            frm.ShowDialog(); // Hiển thị form thêm sinh viên
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvSinhVien.SelectedRows[0];

                SinhVien sv = new SinhVien
                {
                    MaSV = row.Cells["MaSV"].Value.ToString(),
                    HoTen = row.Cells["HoTen"].Value.ToString(),
                    NgaySinh = Convert.ToDateTime(row.Cells["NgaySinh"].Value),
                    GioiTinh = row.Cells["GioiTinh"].Value.ToString(),
                    QueQuan = row.Cells["QueQuan"].Value.ToString(),
                    TenLop = row.Cells["TenLop"].Value.ToString(),
                    MaKhoa = row.Cells["MaKhoa"].Value.ToString(),
                    MaNienKhoa = row.Cells["MaNienKhoa"].Value.ToString(),
                    TrangThai = row.Cells["TrangThai"].Value.ToString()
                };

                frmSuaSinhVien frm = new frmSuaSinhVien(sv);
                frm.SinhVienUpdated += LoadDanhSachSinhVien; // Đăng ký sự kiện cập nhật sinh viên
                frm.ShowDialog();
                LoadData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để sửa.");
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvSinhVien.SelectedRows[0];
                string maSV = row.Cells["MaSV"].Value.ToString();  

                frmXoaSinhVien frm = new frmXoaSinhVien(maSV);
                frm.SinhVienDeleted += LoadDanhSachSinhVien; // Đăng ký sự kiện xóa sinh viên
                frm.ShowDialog();
                LoadData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa.");
            }
        }

        private void btnLoadDanhSachSinhVien_Click(object sender, EventArgs e)
        {
            // Tải lại danh sách lớp từ cơ sở dữ liệu
            LoadDanhSachSinhVien();
            txtTimKiemSinhVien.Clear(); // Xóa nội dung tìm kiếm
            MessageBox.Show("Đã tải lại danh sách lớp.");
            LoadData();
        }

        private void txtTimKiemSinhVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiemSinhVien_Click(sender, e); // Gọi trực tiếp hàm tìm kiếm bên dưới nha
                e.SuppressKeyPress = true; // Ngăn tiếng "beep" khi nhấn Enter
            }
        }

        private void btnTimKiemSinhVien_Click(object sender, EventArgs e)
        {
            //Tìm kiếm sinh viên bằng ký tự gần đúng theo tên hoặc họ hoặc tuổi hoặc quê quán hoặc mã số sinh viên hoặc giới tính hoặc tên lớp hoặc mã khoa hoặc mã niên khóa hoặc ngày sinh được nhập vào
            string keyword = txtTimKiemSinhVien.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
                return;
            }

            DataTable dt = svBUS.SearchSinhVienProc(keyword);
            if (dt.Rows.Count > 0)
            {
                dgvSinhVien.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên phù hợp.");
            }
        }


        //Cái này là tui dùng để đổi màu dòng khi chọn
        private void frmQuanLySinhVien_Load(object sender, EventArgs e)
        {
            dgvSinhVien.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#dddf42");
            dgvSinhVien.DefaultCellStyle.SelectionForeColor = Color.Red;
            LoadData();
        }
    }
}
