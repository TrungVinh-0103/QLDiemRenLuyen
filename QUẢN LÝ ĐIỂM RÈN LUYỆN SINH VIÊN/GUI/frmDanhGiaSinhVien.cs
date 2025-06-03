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
    public partial class frmDanhGiaSinhVien : Form
    {
        public frmDanhGiaSinhVien()
        {
            InitializeComponent();
        }

        private string maSinhVien;

        public frmDanhGiaSinhVien(string maSV)
        {
            InitializeComponent();
            this.maSinhVien = maSV;

            // TODO: Load dữ liệu tự đánh giá theo mã sinh viên
            // Ví dụ: LoadPhieuDanhGia(maSinhVien);
        }


    }
}
