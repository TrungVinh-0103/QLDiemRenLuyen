using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.BUS;
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
    public partial class frmMain : Form
    {
        private string maDangNhap;
        private string loaiTaiKhoan;
        public frmMain(string maDangNhap, string loaiTaiKhoan)
        {
            InitializeComponent();
            this.AutoScroll = true;
            this.IsMdiContainer = true;
            this.maDangNhap = maDangNhap; 
            this.loaiTaiKhoan = loaiTaiKhoan;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //frmQuanLyLop lopForm = new frmQuanLyLop();
            //lopForm.MdiParent = this;
            //lopForm.Show();
            lblNguoiDangNhap.Text = $"{maDangNhap} - {loaiTaiKhoan}";
            lblNguoiDangNhap.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblNguoiDangNhap.BackColor = Color.Yellow;
            lblNguoiDangNhap.ForeColor = Color.Red;

            menuStrip1.Parent = this;
            menuStrip1.BringToFront();

        }

        private void QuanLyLopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyLop lopForm = new frmQuanLyLop();
            lopForm.MdiParent = this;
            lopForm.Show();
        }
        private void QuanLySinhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLySinhVien svForm = new frmQuanLySinhVien();
            svForm.MdiParent = this;
            svForm.Show();
        }

        private void QuanLyDiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyDiemRenLuyen diemForm = new frmQuanLyDiemRenLuyen();
            diemForm.MdiParent = this;
            diemForm.Show();
        }

        private void DanhGiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //mở frmChonSinhVien
            frmChonSinhVien chonSinhVienForm = new frmChonSinhVien();
            chonSinhVienForm.MdiParent = this;
            chonSinhVienForm.Show();
        }

        private void ThongKeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKe thongKeForm = new frmThongKe();
            thongKeForm.MdiParent = this;
            thongKeForm.Show();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
            new frmLogin().Show();
        }

        private void DanhGiaToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            //DanhGiaToolStripMenuItem.ShowDropDown();
        }

        private void sinhViênĐánhGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
