using System;
using System.Data;
using System.Windows.Forms;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.BUS;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.Helpers;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.GUI;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN
{
    public partial class frmLogin : Form
    {
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();

        public frmLogin()
        {
            InitializeComponent();

            // Mặc định ẩn mật khẩu
            txtMatKhau.UseSystemPasswordChar = true;

            // Đăng ký sự kiện cho checkbox hiện mật khẩu
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Gán sự kiện cho nút Enter hoặc các cài đặt nếu muốn
            this.AcceptButton = btnDangNhap; // Đặt nút đăng nhập là nút mặc định khi nhấn Enter
            this.CancelButton = btnThoat; // Đặt nút thoát là nút hủy khi nhấn Esc
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string maDangNhap = txtMaDangNhap.Text.Trim();
                string matKhau = txtMatKhau.Text.Trim();

                if (string.IsNullOrEmpty(maDangNhap) || string.IsNullOrEmpty(matKhau))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = tkBUS.AuthenticateUser(maDangNhap, matKhau);
                if (dt.Rows.Count > 0)
                {
                    string loaiTaiKhoan = dt.Rows[0]["LoaiTaiKhoan"].ToString();
                    if (loaiTaiKhoan == "Admin")
                    {
                        frmMain mainForm = new frmMain(maDangNhap, loaiTaiKhoan);
                        mainForm.Show();
                        this.Hide();
                    }
                    else if (loaiTaiKhoan == "SinhVien")
                    {
                        frmDanhGiaSinhVien danhGiaForm = new frmDanhGiaSinhVien(maDangNhap);
                        danhGiaForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Sai mã đăng nhập hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void linkTrangWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Mở trang web https://student.nctu.edu.vn/sinh-vien-dang-nhap.html trong trình duyệt mặc định
            System.Diagnostics.Process.Start("https://student.nctu.edu.vn/sinh-vien-dang-nhap.html");
            // Nếu không hoạt động trên một số hệ thống, có thể sử dụng:
            // System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("https://student.nctu.edu.vn/sinh-vien-dang-nhap.html") { UseShellExecute = true });
        }
    }
}
