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

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.GUI
{
    public partial class frmThemLop : Form
    {
        private LopBUS lopBUS = new LopBUS();
        private KhoaBUS khoaBUS = new KhoaBUS();
        private NienKhoaBUS nienKhoaBUS = new NienKhoaBUS();

        public frmThemLop()
        {
            InitializeComponent();
            LoadCombobox();
        }
        //Load combobox MaKhoa và MaNienKhoa khi form được tải

        private void frmThemLop_Load(object sender, EventArgs e)
        {
            LoadCombobox();
            LoadComboBoxKhoa();
            // Vô hiệu hóa nút Lưu khi chưa nhập tên lớp
            btnLuu.Enabled = false;
        }
        private void LoadComboBoxKhoa()
        {
            DataTable dt = khoaBUS.GetAllKhoa();
            cboMaKhoa.DataSource = dt;
            //cboMaKhoa.DisplayMember = "TenKhoa"; // Hiển thị tên khoa
            cboMaKhoa.ValueMember = "MaKhoa";    // Giá trị thực sự (ID)
        }
        private void LoadCombobox()
        {
            //cboMaKhoa.DataSource = khoaBUS.GetAllKhoa();
            //cboMaKhoa.DisplayMember = "TenKhoa";
            //cboMaKhoa.ValueMember = "MaKhoa";

            cboMaNienKhoa.DataSource = nienKhoaBUS.GetAllNienKhoa();
            //cboMaNienKhoa.DisplayMember = "TenNienKhoa";
            cboMaNienKhoa.ValueMember = "MaNienKhoa";
        }

        private void txtTenLop_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu tên lớp đã nhập thì kích hoạt nút Lưu
            btnLuu.Enabled = !string.IsNullOrWhiteSpace(txtTenLop.Text);
            // Nếu tên lớp rỗng thì vô hiệu hóa nút Lưu
            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                btnLuu.Enabled = false; // Vô hiệu hóa nút Lưu nếu tên lớp rỗng
            }
            else
            {
                btnLuu.Enabled = true; // Kích hoạt nút Lưu nếu tên lớp không rỗng
            }
            // Kiểm tra xem tên lớp đã tồn tại hay chưa, nhưng phải đợi người dùng nhập ít nhất 9 ký tự
            if (txtTenLop.Text.Length >= 9)
            {
                //DataTable dt = lopBUS.SearchLop(txtTenLop.Text.Trim(), "", "");
                DataTable dt = lopBUS.SearchLop(txtTenLop.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Tên lớp đã tồn tại. Vui lòng nhập tên lớp khác.");
                    btnLuu.Enabled = false; // Vô hiệu hóa nút Lưu nếu tên lớp đã tồn tại
                }
            }
        }

        private void cboMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nếu chưa chọn thì thông báo
            if (cboMaKhoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khoa trước khi chọn niên khóa.");
                btnLuu.Enabled = false; // Vô hiệu hóa nút Lưu nếu chưa chọn khoa
                return;
            }
        }

        private void cboMaNienKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nếu chưa chọn thì thông báo
            if (cboMaNienKhoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn niên khóa trước khi thêm lớp.");
                btnLuu.Enabled = false; // Vô hiệu hóa nút Lưu nếu chưa chọn niên khóa
                return;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Lop lop = new Lop(txtTenLop.Text.Trim(), cboMaKhoa.SelectedValue.ToString(), cboMaNienKhoa.SelectedValue.ToString());
            //    if (lopBUS.AddLop(lop))
            //    {
            //        MessageBox.Show("Thêm lớp thành công!");
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Thêm lớp thất bại!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.LogError(ex.Message);
            //    MessageBox.Show("Lỗi: " + ex.Message);
            //}
            //kiểm tra nếu chưa nhập tên lớp, chưa chọn khoa và niên khóa thì thông báo, nếu đã nhập đầy đủ thì thêm lớp
            if (btnLuu.Enabled)
            {
                try
                {
                    Lop lop = new Lop(txtTenLop.Text.Trim(), cboMaKhoa.SelectedValue.ToString(), cboMaNienKhoa.SelectedValue.ToString());
                    if (lopBUS.AddLop(lop))
                    {
                        MessageBox.Show("Thêm lớp thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thêm lớp thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex.Message);
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin lớp.");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //hiển thị thông báo khi người dùng nhấn nút Hủy, nếu người dùng chọn Yes thì đóng form, nếu chọn No thì không làm gì cả
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy thao tác không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng form nếu người dùng chọn Yes
            }
            else
            {
                return; // Không làm gì cả nếu người dùng chọn No
            }
        }


    }
}
