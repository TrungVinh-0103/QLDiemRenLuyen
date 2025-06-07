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
    public partial class frmThongKe : Form
    {
        private DiemRenLuyenBUS drlBUS = new DiemRenLuyenBUS();
        private SinhVienBUS svBUS = new SinhVienBUS();
        private HocKyBUS hkBUS = new HocKyBUS(); 
        public frmThongKe()
        {
            InitializeComponent();
            LoadComboboxes();
            //SetupDataGridView();
            dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadComboboxes()
        {
            //// Tải danh sách năm từ CSDL  
            //DataTable dtNam = hkBUS.GetAllHocKy(); 
            //if (dtNam.Rows.Count > 0)
            //{
            //    DataTable dtUniqueYears = dtNam.DefaultView.ToTable(true, "Nam");
            //    cboNam.DataSource = dtUniqueYears;
            //    cboNam.DisplayMember = "Nam";
            //    cboNam.ValueMember = "Nam";
            //}
            //else
            //{
            //    cboNam.DataSource = null;
            //    cboNam.Items.Clear();
            //}
            // Danh sách năm cố định với text ánh xạ
            cboNam.Items.Clear();
            cboNam.Items.Add("Năm 2025");
            cboNam.Items.Add("Năm 2024");
            cboNam.Items.Add("Năm 2023");
            cboNam.Items.Add("Năm 2022");
            cboNam.SelectedIndex = 0; // Mặc định chọn Năm 2025

            // Danh sách học kỳ cố định  
            cboMaHocKy.Items.Clear();
            cboMaHocKy.Items.Add("Học kỳ 1");
            cboMaHocKy.Items.Add("Học kỳ 2");
            cboMaHocKy.Items.Add("Học kỳ 3");
            cboMaHocKy.SelectedIndex = 0; // Mặc định chọn Học kỳ 1  
        }

        private void SetupDataGridView()
        {
            dgvThongKe.Columns.Clear();
            dgvThongKe.Columns.Add("TenLop", "Lớp");
            dgvThongKe.Columns.Add("MaSV", "Mã SV");
            dgvThongKe.Columns.Add("HoTen", "Họ Tên");
            dgvThongKe.Columns.Add("MaHocKy", "Học Kỳ");
            dgvThongKe.Columns.Add("Nam", "Năm");
            dgvThongKe.Columns.Add("Diem", "Điểm Tổng");
            dgvThongKe.Columns.Add("XepLoai", "Xếp Loại");
        }

        private string GetMaHocKyFromText(string hocKyText, int nam)
        {
            //// Lấy danh sách học kỳ từ CSDL dựa trên năm  
            //DataTable dtHocKy = hkBUS.GetHocKyByNam(nam);
            //if (dtHocKy != null && dtHocKy.Rows.Count > 0)
            //{
            //    string hocKyMatch = null;
            //    if (hocKyText == "Học kỳ 1")
            //    {
            //        hocKyMatch = dtHocKy.Rows.Cast<DataRow>().FirstOrDefault(r => r["TenHocKy"].ToString().Contains("1"))?["MaHocKy"]?.ToString();
            //    }
            //    else if (hocKyText == "Học kỳ 2")
            //    {
            //        hocKyMatch = dtHocKy.Rows.Cast<DataRow>().FirstOrDefault(r => r["TenHocKy"].ToString().Contains("2"))?["MaHocKy"]?.ToString();
            //    }
            //    else if (hocKyText == "Học kỳ 3")
            //    {
            //        hocKyMatch = dtHocKy.Rows.Cast<DataRow>().FirstOrDefault(r => r["TenHocKy"].ToString().Contains("3"))?["MaHocKy"]?.ToString();
            //    }

            //    return hocKyMatch ?? throw new Exception("Không tìm thấy mã học kỳ tương ứng!");
            //}
            //return null;
            // Ánh xạ học kỳ cố định với MaHocKy trong CSDL (giả định)
            string hocKyMatch;
            if (hocKyText == "Học kỳ 1")
            {
                hocKyMatch = $"HK1_{nam}";
            }
            else if (hocKyText == "Học kỳ 2")
            {
                hocKyMatch = $"HK2_{nam}";
            }
            else if (hocKyText == "Học kỳ 3")
            {
                hocKyMatch = $"HK3_{nam}";
            }
            else
            {
                throw new Exception("Học kỳ không hợp lệ!");
            }
            return hocKyMatch;
        }

        private int GetNamFromText(string namText)
        {
            if (namText == "Năm 2025")
                return 2025;
            else if (namText == "Năm 2024")
                return 2024;
            else if (namText == "Năm 2023")
                return 2023;
            else
                throw new Exception("Năm không hợp lệ!");
        }
        private void btnTaiThongKe_Click(object sender, EventArgs e)
        {
            //    try
            //    {
            //        if (cboMaHocKy.SelectedItem == null)
            //        {
            //            MessageBox.Show("Vui lòng chọn học kỳ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }
            //        if (cboNam.SelectedValue == null)
            //        {
            //            MessageBox.Show("Vui lòng chọn năm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //        string hocKyText = cboMaHocKy.SelectedItem.ToString();
            //        int nam = (int)cboNam.SelectedValue;
            //        string maHocKy = GetMaHocKyFromText(hocKyText, nam);

            //        if (string.IsNullOrEmpty(maHocKy))
            //        {
            //            MessageBox.Show($"Không tìm thấy mã học kỳ cho {hocKyText} trong năm {nam}!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //        // Lấy tất cả sinh viên
            //        DataTable dtAllSinhVien = svBUS.GetAllSinhVien();
            //        DataTable dtDiem = drlBUS.GetAllDiemRenLuyen();

            //        // Chuẩn bị DataTable kết quả
            //        DataTable dtResult = new DataTable();
            //        dtResult.Columns.Add("TenLop", typeof(string));
            //        dtResult.Columns.Add("MaSV", typeof(string));
            //        dtResult.Columns.Add("HoTen", typeof(string));
            //        dtResult.Columns.Add("MaHocKy", typeof(string));
            //        dtResult.Columns.Add("Nam", typeof(int));
            //        dtResult.Columns.Add("Diem", typeof(int));
            //        dtResult.Columns.Add("XepLoai", typeof(string));

            //        foreach (DataRow svRow in dtAllSinhVien.Rows)
            //        {
            //            string maSV = svRow["MaSV"].ToString();
            //            DataRow[] diemRows = dtDiem.Select($"MaSV = '{maSV}' AND MaHocKy = '{maHocKy}' AND Nam = {nam}");

            //            if (diemRows.Length == 0)
            //            {
            //                // Sinh viên chưa có điểm
            //                dtResult.Rows.Add(
            //                    svRow["TenLop"],
            //                    maSV,
            //                    svRow["HoTen"],
            //                    maHocKy,
            //                    nam,
            //                    DBNull.Value,
            //                    "Chưa có điểm"
            //                );
            //            }
            //            else
            //            {
            //                DataRow diemRow = diemRows[0];
            //                int tongDiem = diemRow["Diem"] != DBNull.Value ? (int)diemRow["Diem"] : 0;
            //                if (tongDiem < 50) // Ngưỡng chưa đạt
            //                {
            //                    dtResult.Rows.Add(
            //                        svRow["TenLop"],
            //                        maSV,
            //                        svRow["HoTen"],
            //                        maHocKy,
            //                        nam,
            //                        tongDiem,
            //                        diemRow["XepLoai"]
            //                    );
            //                }
            //            }
            //        }

            //        if (dtResult.Rows.Count == 0)
            //        {
            //            MessageBox.Show($"Không có sinh viên chưa đạt hoặc chưa có điểm trong học kỳ {hocKyText}, năm {nam}!",
            //                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            dgvThongKe.DataSource = dtResult;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Logger.LogError(ex.Message);
            //        MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            try
            {
                if (cboMaHocKy.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn học kỳ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cboNam.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn năm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string hocKyText = cboMaHocKy.SelectedItem.ToString();
                string namText = cboNam.SelectedItem.ToString();
                int nam = GetNamFromText(namText);
                string maHocKy = GetMaHocKyFromText(hocKyText, nam);

                // Lấy tất cả sinh viên
                DataTable dtAllSinhVien = svBUS.GetAllSinhVien();
                DataTable dtDiem = drlBUS.GetAllDiemRenLuyen();

                // Chuẩn bị DataTable kết quả
                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("TenLop", typeof(string));
                dtResult.Columns.Add("MaSV", typeof(string));
                dtResult.Columns.Add("HoTen", typeof(string));
                dtResult.Columns.Add("MaHocKy", typeof(string));
                dtResult.Columns.Add("Nam", typeof(int));
                dtResult.Columns.Add("Diem", typeof(int));
                dtResult.Columns.Add("XepLoai", typeof(string));

                foreach (DataRow svRow in dtAllSinhVien.Rows)
                {
                    string maSV = svRow["MaSV"].ToString();
                    DataRow[] diemRows = dtDiem.Select($"MaSV = '{maSV}' AND MaHocKy = '{maHocKy}' AND Nam = {nam}");

                    if (diemRows.Length == 0)
                    {
                        // Sinh viên chưa có điểm
                        dtResult.Rows.Add(
                            svRow["TenLop"],
                            maSV,
                            svRow["HoTen"],
                            maHocKy,
                            nam,
                            DBNull.Value,
                            "Chưa có điểm"
                        );
                    }
                    else
                    {
                        DataRow diemRow = diemRows[0];
                        int diem = diemRow["Diem"] != DBNull.Value ? (int)diemRow["Diem"] : 0;
                        dtResult.Rows.Add(
                            svRow["TenLop"],
                            maSV,
                            svRow["HoTen"],
                            maHocKy,
                            nam,
                            diem,
                            diemRow["XepLoai"]
                        );
                    }
                }

                if (dtResult.Rows.Count == 0)
                {
                    MessageBox.Show($"Không có sinh viên nào trong học kỳ {hocKyText}, năm {namText}!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvThongKe.DataSource = dtResult;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
