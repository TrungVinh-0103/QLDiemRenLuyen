using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.BUS;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.GUI
{
    public partial class frmQuanLyDiemRenLuyen : Form
    {
        private LopBUS lopBUS = new LopBUS();
        private HocKyBUS hkBUS = new HocKyBUS();
        private SinhVienBUS svBUS = new SinhVienBUS();
        private DiemRenLuyenBUS drlBUS = new DiemRenLuyenBUS();

        public frmQuanLyDiemRenLuyen()
        {
            InitializeComponent();
            LoadInitialData();
            dgvDiemRenLuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadInitialData()
        {
            // Load Năm
            DataTable dtNam = hkBUS.GetAllHocKy();
            if (dtNam.Rows.Count > 0)
            {
                // Tạo DataTable mới chỉ chứa cột Nam duy nhất và loại bỏ dữ liệu không hợp lệ
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

            // Load Tên lớp (tất cả lớp từ CSDL)
            DataTable dtLop = lopBUS.GetAllLop();
            if (dtLop.Rows.Count > 0)
            {
                cboTenLop.DataSource = dtLop;
                cboTenLop.DisplayMember = "TenLop";
                cboTenLop.ValueMember = "TenLop";
            }
            else
            {
                cboTenLop.DataSource = null;
                cboTenLop.Items.Clear();
            }
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNam.SelectedValue != null)
            {
                // Ép kiểu an toàn
                if (int.TryParse(cboNam.SelectedValue.ToString(), out int nam))
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
                //    // Xử lý trường hợp SelectedValue không phải số nguyên
                //    //MessageBox.Show("Dữ liệu năm không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    cboHocKy.DataSource = null;
                //    cboHocKy.Items.Clear();
                //    cboHocKy.Text = "";
                //}
            }
        }

        //private SinhVienBUS GetSvBUS()
        //{
        //    if (svBUS == null)
        //    {
        //        svBUS = new SinhVienBUS();
        //    }
        //    return svBUS;
        //}

        // Fix for the CS0029 error in the btnLocDanhSach_Click method  
        private void btnLocDanhSach_Click(object sender, EventArgs e)
        {
            // Kiểm tra ràng buộc
            if (cboTenLop.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn tên lớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboHocKy.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn học kỳ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboNam.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn năm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tenLop = cboTenLop.SelectedValue.ToString();
            string maHocKy = cboHocKy.SelectedValue.ToString();
            int nam = (int)cboNam.SelectedValue;
            string maSV = txtMaSV.Text.Trim();

            // Lấy danh sách sinh viên dựa trên điều kiện
            DataTable dtSinhVien;
            if (!string.IsNullOrEmpty(maSV))
            {
                SinhVien sinhVien = svBUS.GetSinhVienByMaSV(maSV);
                if (sinhVien == null)
                {
                    MessageBox.Show($"Không tìm thấy sinh viên có mã {maSV}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Tạo DataTable từ đối tượng SinhVien
                dtSinhVien = new DataTable();
                dtSinhVien.Columns.Add("MaSV", typeof(string));
                dtSinhVien.Columns.Add("HoTen", typeof(string));

                DataRow row = dtSinhVien.NewRow();
                row["MaSV"] = sinhVien.MaSV;
                row["HoTen"] = sinhVien.HoTen;
                dtSinhVien.Rows.Add(row);
            }
            else
            {
                dtSinhVien = svBUS.GetSinhVienByLop(tenLop); // Chỉ cần tenLop
            }

            // Chuẩn bị DataTable kết quả
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("Lớp", typeof(string));
            dtResult.Columns.Add("Mã SV", typeof(string));
            dtResult.Columns.Add("Họ Tên", typeof(string));
            dtResult.Columns.Add("Học Kỳ", typeof(string));
            dtResult.Columns.Add("Năm", typeof(int));
            dtResult.Columns.Add("Điểm Tổng", typeof(int));
            dtResult.Columns.Add("Xếp Loai", typeof(string));

            foreach (DataRow row in dtSinhVien.Rows)
            {
                string maSVCurrent = row["MaSV"].ToString();
                DataTable dtDiem = drlBUS.GetDiemRenLuyenByMaSVAndHocKy(maSVCurrent, maHocKy, nam);
                if (dtDiem.Rows.Count > 0)
                {
                    DataRow drDiem = dtDiem.Rows[0];
                    dtResult.Rows.Add(
                        tenLop,
                        maSVCurrent,
                        row["HoTen"],
                        drDiem["MaHocKy"],
                        nam,
                        drDiem["Diem"],
                        drDiem["XepLoai"]
                    );
                }
            }

            if (dtResult.Rows.Count == 0)
            {
                MessageBox.Show($"Không có dữ liệu điểm rèn luyện cho lớp {tenLop} trong học kỳ {maHocKy}, năm {nam}!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgvDiemRenLuyen.DataSource = dtResult;
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvDiemRenLuyen.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Xuất danh sách điểm rèn luyện",
                FileName = $"DiemRenLuyen_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Excel.Application excel = new Excel.Application();
                    Excel.Workbook workbook = excel.Workbooks.Add();
                    Excel.Worksheet worksheet = workbook.ActiveSheet;

                    // Đổ tiêu đề
                    for (int i = 0; i < dgvDiemRenLuyen.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dgvDiemRenLuyen.Columns[i].HeaderText;
                    }

                    // Đổ dữ liệu
                    for (int i = 0; i < dgvDiemRenLuyen.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvDiemRenLuyen.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvDiemRenLuyen.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    // Lưu file và đóng
                    workbook.SaveAs(sfd.FileName);
                    workbook.Close();
                    excel.Quit();

                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
