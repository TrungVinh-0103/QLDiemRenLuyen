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
    public partial class frmChonSinhVien : Form
    {
        private KhoaBUS khoaBUS = new KhoaBUS();
        private LopBUS lopBUS = new LopBUS();
        private SinhVienBUS svBUS = new SinhVienBUS();
        private HocKyBUS hkBUS = new HocKyBUS();
        private PhieuDanhGiaBUS pgBUS = new PhieuDanhGiaBUS();

        //private TextBox txtSTT = new TextBox();
        //private TextBox txtMaSV = new TextBox();
        //private TextBox txtHoTen = new TextBox();
        //private TextBox txtNgaySinh = new TextBox();

        public frmChonSinhVien()
        {
            InitializeComponent();
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            // Load Năm
            DataTable dtNam = hkBUS.GetAllHocKy();
            if (dtNam.Rows.Count > 0)
            {
                // Tạo DataTable mới chỉ chứa cột Nam duy nhất
                DataTable dtUniqueYears = dtNam.DefaultView.ToTable(true, "Nam");
                dtUniqueYears.Rows.Cast<DataRow>().Where(r => r["Nam"] == DBNull.Value || !int.TryParse(r["Nam"].ToString(), out _)).ToList().ForEach(r => r.Delete());
                dtUniqueYears.AcceptChanges();
                cboNam.DataSource = dtUniqueYears;
                cboNam.DisplayMember = "Nam";
                cboNam.ValueMember = "Nam";
            }
            else
            {
                cboNam.DataSource = null;
                cboNam.Items.Clear();
            }
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNam.SelectedValue != null)
            {
                // Kiểm tra và ép kiểu an toàn
                if (cboNam.SelectedValue is int nam)
                {
                    DataTable dtHocKy = hkBUS.GetHocKyByNam(nam);
                    if (dtHocKy.Rows.Count > 0)
                    {
                        cboHocKy.DataSource = dtHocKy;
                        cboHocKy.DisplayMember = "TenHocKy";
                        cboHocKy.ValueMember = "MaHocKy";
                    }
                    else
                    {
                        cboHocKy.DataSource = null;
                        cboHocKy.Items.Clear();
                        cboHocKy.Text = "";
                        //MessageBox.Show($"Không có học kỳ nào trong năm {nam}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //else
                //{
                //    // Xử lý trường hợp SelectedValue không phải int
                //    //MessageBox.Show("Dữ liệu năm không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    cboHocKy.DataSource = null;
                //    cboHocKy.Items.Clear();
                //    cboHocKy.Text = "";
                //}
            }
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHocKy.SelectedValue != null)
            {
                DataTable dtKhoa = khoaBUS.GetAllKhoa();
                if (dtKhoa.Rows.Count > 0)
                {
                    cboKhoa.DataSource = dtKhoa;
                    cboKhoa.DisplayMember = "TenKhoa";
                    cboKhoa.ValueMember = "MaKhoa";
                }
                else
                {
                    cboKhoa.DataSource = null;
                    cboKhoa.Items.Clear();
                    cboKhoa.Text = "";
                    //MessageBox.Show("Không có khoa nào trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhoa.SelectedValue != null && cboHocKy.SelectedValue != null && cboNam.SelectedValue != null)
            {
                string maKhoa = cboKhoa.SelectedValue.ToString();
                string maHocKy = cboHocKy.SelectedValue.ToString();
                int nam = (int)cboNam.SelectedValue;

                // Lấy TenKhoa từ DataTable của cboKhoa
                DataTable dtKhoa = (DataTable)cboKhoa.DataSource;
                string tenKhoa = dtKhoa.AsEnumerable()
                    .Where(row => row.Field<string>("MaKhoa") == maKhoa)
                    .Select(row => row.Field<string>("TenKhoa"))
                    .FirstOrDefault() ?? "Không xác định";

                // Lấy TenHocKy từ DataTable của cboHocKy
                DataTable dtHocKy = (DataTable)cboHocKy.DataSource;
                string tenHocKy = dtHocKy.AsEnumerable()
                    .Where(row => row.Field<string>("MaHocKy") == maHocKy)
                    .Select(row => row.Field<string>("TenHocKy"))
                    .FirstOrDefault() ?? "Không xác định";

                DataTable dtLop = lopBUS.GetLopByKhoaAndHocKy(maKhoa, maHocKy, nam);
                if (dtLop.Rows.Count > 0)
                {
                    cboLop.DataSource = dtLop;
                    cboLop.DisplayMember = "TenLop";
                    cboLop.ValueMember = "TenLop";
                }
                else
                {
                    cboLop.DataSource = null;
                    cboLop.Items.Clear();
                    //MessageBox.Show($"Không có lớp nào thuộc khoa {cboKhoa.Text} có sinh viên đã đánh giá trong học kỳ {cboHocKy.Text}, năm {nam}!",
                    //    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //private void cboNganh_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        private void btnXemDanhSach_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedValue == null || cboHocKy.SelectedValue == null || cboNam.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin (Năm, Học kỳ, Khoa, Lớp)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tenLop = cboLop.SelectedValue.ToString();
            string maKhoa = cboKhoa.SelectedValue.ToString();
            string maNienKhoa = lopBUS.GetMaNienKhoaByTenLopAndMaKhoa(tenLop, maKhoa);
            string maHocKy = cboHocKy.SelectedValue.ToString();
            int nam = (int)cboNam.SelectedValue;

            DataTable dtSinhVien = svBUS.GetSinhVienByLop(tenLop, maKhoa, maNienKhoa);
            if (dtSinhVien.Rows.Count == 0)
            {
                MessageBox.Show($"Không có sinh viên nào trong lớp {tenLop} thuộc khoa {cboKhoa.Text}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("STT", typeof(int));
            dtResult.Columns.Add("MaSV", typeof(string));
            dtResult.Columns.Add("HoTen", typeof(string));
            dtResult.Columns.Add("NgaySinh", typeof(DateTime));
            dtResult.Columns.Add("TrangThai", typeof(string));
            dtResult.Columns.Add("DiemTongKet", typeof(int));
            dtResult.Columns.Add("MaPhieu", typeof(int)); // Ẩn cột này trong DataGridView

            int stt = 1;
            foreach (DataRow row in dtSinhVien.Rows)
            {
                string maSV = row["MaSV"].ToString();
                DataTable dtPhieu = pgBUS.GetPhieuDanhGia(maSV, maHocKy, nam, "SinhVien");
                string trangThai = dtPhieu.Rows.Count > 0 ? "Đã đánh giá" : "Chưa đánh giá";
                int diemTongKet = dtPhieu.Rows.Count > 0 ? Convert.ToInt32(dtPhieu.Rows[0]["TongDiem"]) : 0;
                int maPhieu = dtPhieu.Rows.Count > 0 ? Convert.ToInt32(dtPhieu.Rows[0]["MaPhieu"]) : 0;

                dtResult.Rows.Add(stt++, maSV, row["HoTen"], row["NgaySinh"], trangThai, diemTongKet, maPhieu);
            }

            dgvDanhSach.DataSource = dtResult;
            dgvDanhSach.Columns["MaPhieu"].Visible = false; // Ẩn cột MaPhieu
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvDanhSach.SelectedRows[0];
                txtSTT.Text = row.Cells["STT"].Value.ToString();
                txtMaSV.Text = row.Cells["MaSV"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtNgaySinh.Text = Convert.ToDateTime(row.Cells["NgaySinh"].Value).ToString("dd/MM/yyyy");
            }
        }

        private void btnXemDanhGia_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvDanhSach.SelectedRows[0];
                string maSV = row.Cells["MaSV"].Value.ToString();
                int maPhieu = Convert.ToInt32(row.Cells["MaPhieu"].Value);
                if (maPhieu == 0)
                {
                    MessageBox.Show("Sinh viên này chưa tự đánh giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmDanhGiaSinhVien form = new frmDanhGiaSinhVien(maSV, true, maPhieu);
                form.MdiParent = this.MdiParent;
                form.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xem đánh giá!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshDataGridView()
        {
            if (cboLop.SelectedValue != null && cboHocKy.SelectedValue != null && cboNam.SelectedValue != null)
            {
                string tenLop = cboLop.SelectedValue.ToString();
                string maKhoa = cboKhoa.SelectedValue.ToString();
                string maNienKhoa = lopBUS.GetMaNienKhoaByTenLopAndMaKhoa(tenLop, maKhoa);
                string maHocKy = cboHocKy.SelectedValue.ToString();
                int nam = (int)cboNam.SelectedValue;

                DataTable dtSinhVien = svBUS.GetSinhVienByLop(tenLop, maKhoa, maNienKhoa);
                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("STT", typeof(int));
                dtResult.Columns.Add("MaSV", typeof(string));
                dtResult.Columns.Add("HoTen", typeof(string));
                dtResult.Columns.Add("NgaySinh", typeof(DateTime));
                dtResult.Columns.Add("TrangThai", typeof(string));
                dtResult.Columns.Add("DiemTongKet", typeof(int));
                dtResult.Columns.Add("MaPhieu", typeof(int)); // Ẩn cột này trong DataGridView

                int stt = 1;
                foreach (DataRow row in dtSinhVien.Rows)
                {
                    string maSV = row["MaSV"].ToString();
                    DataTable dtPhieu = pgBUS.GetPhieuDanhGia(maSV, maHocKy, nam, "SinhVien");
                    string trangThai = dtPhieu.Rows.Count > 0 ? "Đã đánh giá" : "Chưa đánh giá";
                    int diemTongKet = dtPhieu.Rows.Count > 0 ? Convert.ToInt32(dtPhieu.Rows[0]["TongDiem"]) : 0;
                    int maPhieu = dtPhieu.Rows.Count > 0 ? Convert.ToInt32(dtPhieu.Rows[0]["MaPhieu"]) : 0;

                    dtResult.Rows.Add(stt++, maSV, row["HoTen"], row["NgaySinh"], trangThai, diemTongKet, maPhieu);
                }

                dgvDanhSach.DataSource = dtResult;
                dgvDanhSach.Columns["MaPhieu"].Visible = false; // Ẩn cột MaPhieu
            }
        }
    }
}
