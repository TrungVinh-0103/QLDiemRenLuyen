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
    public partial class frmXoaSinhVien : Form
    {
        private SinhVienBUS svBUS = new SinhVienBUS();
        private string maSV; // Biến lưu mã sinh viên cần xóa
        public event Action SinhVienDeleted; // Sự kiện thông báo khi sinh viên đã bị xóa
        public frmXoaSinhVien(string maSV)
        {
            InitializeComponent();
            this.maSV = maSV;
            LoadData();
        }

        private void frmXoaSinhVien_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            try
            {
                DataTable dt = svBUS.SearchSinhVien(maSV);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblMaSVValue.Text = row["MaSV"].ToString();
                    lblHoTenValue.Text = row["HoTen"].ToString();
                    lblNgaySinhValue.Text = Convert.ToDateTime(row["NgaySinh"]).ToString("dd/MM/yyyy");
                    lblGioiTinhValue.Text = row["GioiTinh"].ToString();
                    lblQueQuanValue.Text = row["QueQuan"].ToString();
                    lblTenLopValue.Text = row["TenLop"].ToString();
                    lblMaKhoaValue.Text = row["MaKhoa"].ToString();
                    lblMaNienKhoaValue.Text = row["MaNienKhoa"].ToString();
                    lblTrangThaiValue.Text = row["TrangThai"].ToString();
                    lblEmailValue.Text = row["Email"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên với mã: " + maSV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                MessageBox.Show("Lỗi khi tải thông tin sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            //full code hoạt động của nút Xác nhận xóa
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (svBUS.DeleteSinhVien(maSV))
                    {
                        MessageBox.Show("Xóa sinh viên không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Xóa sinh viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SinhVienDeleted?.Invoke(); // Gọi sự kiện thông báo đã xóa
                        this.Close(); // Đóng form sau khi xóa thành công
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                MessageBox.Show("Lỗi khi xóa sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //hủy mà không làm mất sinh viên
            this.Close();
        }
    }
}
