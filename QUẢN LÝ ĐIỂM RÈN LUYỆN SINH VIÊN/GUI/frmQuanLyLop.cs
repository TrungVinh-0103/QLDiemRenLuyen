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
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.Helpers;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.GUI
{
    public partial class frmQuanLyLop : Form
    {
        private LopBUS lopBUS = new LopBUS();
        public frmQuanLyLop()
        {
            InitializeComponent();
            LoadLop();
            this.txtTimKiemLop.KeyDown += new KeyEventHandler(this.txtTimKiemLop_KeyDown);
        }
        private void LoadLop()
        {
            // Tải danh sách lớp từ cơ sở dữ liệu
            DataTable dt = lopBUS.GetAllLop();
            if (dt != null && dt.Rows.Count > 0)
            {
                dgvLop.DataSource = dt;

                //Đặt tiêu đề cột cho DataGridView
                dgvLop.Columns["TenLop"].HeaderText = "Tên Lớp";
                dgvLop.Columns["SiSo"].HeaderText = "Sĩ số";
                dgvLop.Columns["MaKhoa"].HeaderText = "Mã Khoa";
                dgvLop.Columns["MaNienKhoa"].HeaderText = "Mã Niên Khóa";
            }
            else
            {
                MessageBox.Show("Không có lớp nào trong hệ thống.");
                dgvLop.DataSource = null; // Xóa dữ liệu nếu không có lớp
            }

        }
        private void btnLoadDanhSachLop_Click(object sender, EventArgs e)
        {
            // Tải lại danh sách lớp từ cơ sở dữ liệu
            LoadLop();
            txtTimKiemLop.Clear(); // Xóa nội dung tìm kiếm
            MessageBox.Show("Đã tải lại danh sách lớp.");
        }
        private void frmQuanLyLop_Load(object sender, EventArgs e)
        {
            dgvLop.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#dddf42");
            dgvLop.DefaultCellStyle.SelectionForeColor = Color.Red;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemLop themLopForm = new frmThemLop();
            themLopForm.ShowDialog();
            LoadLop();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Sửa giá trực tiếp trong DataGridView sau đó click nút Sửa, không sử dụng form Sửa

            if (dgvLop.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvLop.SelectedRows[0];
                string tenLop = selectedRow.Cells["TenLop"].Value.ToString();
                string maKhoa = selectedRow.Cells["MaKhoa"].Value.ToString();
                string maNienKhoa = selectedRow.Cells["MaNienKhoa"].Value.ToString();
                // Mở form sửa với thông tin đã chọn
                frmSuaLop suaLopForm = new frmSuaLop(tenLop, maKhoa, maNienKhoa);
                suaLopForm.ShowDialog();
                LoadLop();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lớp cần sửa.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLop.SelectedRows.Count > 0)
            {
                string tenLop = dgvLop.SelectedRows[0].Cells["TenLop"].Value.ToString();
                string maKhoa = dgvLop.SelectedRows[0].Cells["MaKhoa"].Value.ToString();
                string maNienKhoa = dgvLop.SelectedRows[0].Cells["MaNienKhoa"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa lớp {tenLop} không? Dữ liệu liên quan sẽ bị xóa!",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (lopBUS.DeleteLop(tenLop, maKhoa, maNienKhoa))
                        {
                            MessageBox.Show("Xóa lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadLop();
                        }
                        else
                        {
                            MessageBox.Show("Xóa lớp thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex.Message);
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lớp để xóa!");
            }
        }
        private void btnTimKiemLop_Click(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiemLop.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Vui lòng nhập từ khóa để tìm kiếm.");
                return;
            }

            DataTable dt = lopBUS.SearchLop(searchTerm);
            if (dt.Rows.Count > 0)
            {
                dgvLop.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Không tìm thấy lớp nào với thông tin đã nhập.");
                LoadLop(); // Trả về danh sách lớp ban đầu
            }
        }

        private void txtTimKiemLop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiemLop_Click(sender, e); // Gọi trực tiếp hàm tìm kiếm
                e.SuppressKeyPress = true; // Ngăn tiếng "beep" khi nhấn Enter
            }
        }


    }
}
