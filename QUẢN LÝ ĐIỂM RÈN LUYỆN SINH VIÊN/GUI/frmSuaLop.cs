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

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.GUI
{
    public partial class frmSuaLop : Form
    {
        private string tenLop;
        private string maKhoa;
        private string maNienKhoa;
        private KhoaBUS khoaBUS = new KhoaBUS();
        private NienKhoaBUS nienKhoaBUS = new NienKhoaBUS();

        private void LoadComboBoxKhoa()
        {
            DataTable dt = khoaBUS.GetAllKhoa();
            cboMaKhoa.DataSource = dt;
            //cboMaKhoa.DisplayMember = "TenKhoa"; // Hiển thị tên khoa
            cboMaKhoa.ValueMember = "MaKhoa";    // Giá trị thực sự (ID)
        }
        private void LoadComboBoxNienKhoa()
        {
            DataTable dt = nienKhoaBUS.GetAllNienKhoa();
            cboMaNienKhoa.DataSource = dt;
            //cboMaNienKhoa.DisplayMember = "TenNienKhoa"; // Hiển thị tên niên khóa
            cboMaNienKhoa.ValueMember = "MaNienKhoa";    // Giá trị thực sự (ID)
        }
        // Constructor với 3 parameters  
        public frmSuaLop(string tenLop, string maKhoa, string maNienKhoa)
        {
            InitializeComponent();
            this.tenLop = tenLop;
            this.maKhoa = maKhoa;
            this.maNienKhoa = maNienKhoa;

            // Optionally, populate form fields with these values  
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Giả sử bạn đã có các trường nhập liệu trong form để sửa thông tin lớp
            string newTenLop = txtTenLop.Text.Trim();
            string newMaKhoa = cboMaKhoa.Text.Trim();
            string newMaNienKhoa = cboMaNienKhoa.Text.Trim();
            if (string.IsNullOrEmpty(newTenLop) || string.IsNullOrEmpty(newMaKhoa) || string.IsNullOrEmpty(newMaNienKhoa))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp.");
                return;
            }
            // Thực hiện cập nhật thông tin lớp vào cơ sở dữ liệu
            try
            {
                // Giả sử bạn có một phương thức cập nhật lớp trong lớp BUS
                LopBUS lopBUS = new LopBUS();
                lopBUS.UpdateLop(tenLop, newTenLop, newMaKhoa, newMaNienKhoa);
                MessageBox.Show("Cập nhật lớp thành công.");
                this.Close(); // Đóng form sau khi lưu thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật lớp: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

            // Hủy thao tác và đóng form
            this.Close(); // Đóng form mà không lưu thay đổi
        }
        //LOAD============================================================
        private void frmSuaLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLRenLuyenSinhVienDataSet1.NienKhoa' table. You can move, or remove it, as needed.
            //this.nienKhoaTableAdapter.Fill(this.qLRenLuyenSinhVienDataSet1.NienKhoa);
            // TODO: This line of code loads data into the 'qLRenLuyenSinhVienDataSet.Khoa' table. You can move, or remove it, as needed.
            //this.khoaTableAdapter.Fill(this.qLRenLuyenSinhVienDataSet.Khoa);

            LoadComboBoxKhoa();
            LoadComboBoxNienKhoa();


        }

        private void cboMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
