using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using Microsoft.Office.Interop.Excel;
using PROJ46_QLRenLuyenSinhVien.Helpers;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.BUS;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.DTO;
using QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.Helpers;

namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.GUI
{
    public partial class frmDanhGiaSinhVien : Form
    {
        private PhieuDanhGiaBUS phieuDanhGiaBUS = new PhieuDanhGiaBUS();
        private MinhChungBUS minhChungBUS = new MinhChungBUS();
        private HocKyBUS hocKyBUS = new HocKyBUS();
        private string maSV;
        private bool isAdminMode = false;
        private Dictionary<string, List<string>> minhChungFiles = new Dictionary<string, List<string>>();
        private int maPhieu = 0;

        private DiemRenLuyenBUS drlBUS = new DiemRenLuyenBUS();
        //private SinhVienBUS svBUS = new SinhVienBUS();
        //private HocKyBUS hkBUS = new HocKyBUS();
        private Dictionary<string, string> hocKyMapping = new Dictionary<string, string>();
        private Dictionary<string, int> namMapping = new Dictionary<string, int>();

        private string maSinhVien;
        private SinhVienBUS svBUS = new SinhVienBUS();
        //private TextBox txtEmail;
        //private TextBox txtHoTen;

        private string loaiTaiKhoan;

        //public frmDanhGiaSinhVien(string maSV)
        //{
        //    InitializeComponent();
        //    this.maSinhVien = maSV;
        //    txtMaSV.Text = maSV; // Lấy từ mã đăng nhập
        //    LoadComboboxes();
        //    InitializeDefaultValues();
        //    UpdateTotals();

        //}
        public frmDanhGiaSinhVien(string maSV, bool isAdminMode = false, int maPhieu = 0, string loaiTaiKhoan = "SinhVien")
        {
            InitializeComponent();
            this.maSV = maSV;
            this.loaiTaiKhoan = isAdminMode ? "Admin" : loaiTaiKhoan;
            this.isAdminMode = isAdminMode;
            this.maPhieu = maPhieu;
            //txtHoTen = new TextBox();
            //txtEmail = new TextBox();
            LoadData();
            //LoadComboboxes();
            InitializeDefaultValues();
            AttachTextChangedEvents();
            UpdateTotals();
            if (isAdminMode) LoadExistingData();
            LoadComboboxes();
        }
        //Cập nhật 07/06/2025: Thêm hàm LoadComboboxes để load dữ liệu cố định cho các combobox
        private void LoadComboboxes()
        {
            // Ánh xạ học kỳ cố định
            cboMaHocKy.Items.Clear();
            hocKyMapping.Clear();
            cboMaHocKy.Items.Add("Học kỳ 1");
            hocKyMapping["Học kỳ 1"] = $"HK1_{DateTime.Now.Year}";
            cboMaHocKy.Items.Add("Học kỳ 2");
            hocKyMapping["Học kỳ 2"] = $"HK2_{DateTime.Now.Year}";
            cboMaHocKy.Items.Add("Học kỳ 3");
            hocKyMapping["Học kỳ 3"] = $"HK3_{DateTime.Now.Year}";
            if (cboMaHocKy.Items.Count > 0) cboMaHocKy.SelectedIndex = 0;

            // Ánh xạ năm cố định
            cboNam.Items.Clear();
            namMapping.Clear();
            cboNam.Items.Add("Năm 2025");
            namMapping["Năm 2025"] = 2025;
            cboNam.Items.Add("Năm 2024");
            namMapping["Năm 2024"] = 2024;
            cboNam.Items.Add("Năm 2023");
            namMapping["Năm 2023"] = 2023;
            if (cboNam.Items.Count > 0) cboNam.SelectedIndex = 0;
        }
        private void LoadExistingData()
        {
            if (maPhieu > 0)
            {
                System.Data.DataTable dt = phieuDanhGiaBUS.GetPhieuDanhGiaByMaPhieu(maPhieu);
                if (dt.Rows.Count > 0)
                {
                    // Chọn học kỳ và năm dựa trên dữ liệu
                    string maHocKy = dt.Rows[0]["MaHocKy"].ToString();
                    int nam = int.Parse(dt.Rows[0]["Nam"].ToString());
                    foreach (var kvp in hocKyMapping)
                    {
                        if (kvp.Value == maHocKy)
                        {
                            cboMaHocKy.SelectedItem = kvp.Key;
                            break;
                        }
                    }
                    foreach (var kvp in namMapping)
                    {
                        if (kvp.Value == nam)
                        {
                            cboNam.SelectedItem = kvp.Key;
                            break;
                        }
                    }

                    // Gán các điểm
                    txtDiem1_1.Text = dt.Rows[0]["Diem1_1"].ToString();
                    txtDiem1_2.Text = dt.Rows[0]["Diem1_2"].ToString();
                    txtDiem1_3.Text = dt.Rows[0]["Diem1_3"].ToString();
                    txtDiem1_4.Text = dt.Rows[0]["Diem1_4"].ToString();
                    txtDiem1_5.Text = dt.Rows[0]["Diem1_5"].ToString();
                    txtDiem1_6.Text = dt.Rows[0]["Diem1_6"].ToString();
                    txtDiem1_7.Text = dt.Rows[0]["Diem1_7"].ToString();
                    txtDiem1_8.Text = dt.Rows[0]["Diem1_8"].ToString();

                    txtDiem2_1.Text = dt.Rows[0]["Diem2_1"].ToString();
                    txtDiem2_2.Text = dt.Rows[0]["Diem2_2"].ToString();
                    txtDiem2_3.Text = dt.Rows[0]["Diem2_3"].ToString();
                    txtDiem2_4.Text = dt.Rows[0]["Diem2_4"].ToString();
                    txtDiem2_5.Text = dt.Rows[0]["Diem2_5"].ToString();
                    txtDiem2_6.Text = dt.Rows[0]["Diem2_6"].ToString();
                    txtDiem2_7.Text = dt.Rows[0]["Diem2_7"].ToString();

                    txtDiem3_1.Text = dt.Rows[0]["Diem3_1"].ToString();
                    txtDiem3_2.Text = dt.Rows[0]["Diem3_2"].ToString();
                    txtDiem3_3.Text = dt.Rows[0]["Diem3_3"].ToString();
                    txtDiem3_4.Text = dt.Rows[0]["Diem3_4"].ToString();
                    txtDiem3_5.Text = dt.Rows[0]["Diem3_5"].ToString();
                    txtDiem3_6.Text = dt.Rows[0]["Diem3_6"].ToString();
                    txtDiem3_7.Text = dt.Rows[0]["Diem3_7"].ToString();

                    txtDiem4_1.Text = dt.Rows[0]["Diem4_1"].ToString();
                    txtDiem4_2.Text = dt.Rows[0]["Diem4_2"].ToString();
                    txtDiem4_3.Text = dt.Rows[0]["Diem4_3"].ToString();
                    txtDiem4_4.Text = dt.Rows[0]["Diem4_4"].ToString();
                    txtDiem4_5.Text = dt.Rows[0]["Diem4_5"].ToString();

                    txtDiem5_1.Text = dt.Rows[0]["Diem5_1"].ToString();
                    txtDiem5_2.Text = dt.Rows[0]["Diem5_2"].ToString();
                    txtDiem5_3.Text = dt.Rows[0]["Diem5_3"].ToString();
                    txtDiem5_4.Text = dt.Rows[0]["Diem5_4"].ToString();
                    txtDiem5_5.Text = dt.Rows[0]["Diem5_5"].ToString();
                    txtDiem5_6.Text = dt.Rows[0]["Diem5_6"].ToString();
                    txtTongDiem.Text = dt.Rows[0]["TongDiem"].ToString();
                    txtXepLoai.Text = GetXepLoai(int.Parse(txtTongDiem.Text));

                    // Load minh chứng
                    System.Data.DataTable dtMinhChung = minhChungBUS.GetMinhChungByPhieu(maPhieu);
                    lstImages.Items.Clear();
                    foreach (DataRow row in dtMinhChung.Rows)
                    {
                        lstImages.Items.Add($"Hình {row["MaMinhChung"]}");
                    }
                }
            }
        }

        private void LoadData()
        {
            txtMaSV.Text = maSV;
            SinhVien sv = svBUS.GetSinhVienByMaSV(maSV); // Corrected to match the return type of GetSinhVienByMaSV  
            //if (sv != null)
            //{
            //    txtHoTen.Text = sv.HoTen;
            //    txtEmail.Text = sv.Email;
            //}

            //cboMaHocKy.DataSource = hocKyBUS.GetAllHocKy();
            //cboMaHocKy.DisplayMember = "TenHocKy";
            //cboMaHocKy.ValueMember = "MaHocKy";

            //System.Data.DataTable dtNam = hocKyBUS.GetAllHocKy();
            //if (dtNam.Rows.Count > 0)
            //{
            //    cboNam.DataSource = dtNam;
            //    cboNam.DisplayMember = "Nam";
            //    cboNam.ValueMember = "Nam";
            //}
            //else
            //{
            //    cboNam.DataSource = null;
            //    cboNam.Items.Clear();
            //    MessageBox.Show("Không có dữ liệu năm học nào trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            if (isAdminMode)
            {
                txtMaSV.ReadOnly = true;
                cboMaHocKy.Enabled = false;
                cboNam.Enabled = false;
                foreach (Control control in pnlDanhGia.Controls)
                {
                    if (control is System.Windows.Forms.Button btn && btn.Name.StartsWith("btnGuiMinhChung"))
                    {
                        btn.Visible = false;
                    }
                }
            }
        }
        //private void LoadComboboxes()
        //{
        //    // Load MaHocKy
        //    cboMaHocKy.DataSource = hocKyBUS.GetAllHocKy();
        //    cboMaHocKy.DisplayMember = "TenHocKy";
        //    cboMaHocKy.ValueMember = "MaHocKy";

        //    // Load Nam từ bảng HocKy
        //    System.Data.DataTable dtNam = hocKyBUS.GetAllHocKy(); // Giả sử bảng HocKy có cột Nam
        //    var distinctYears = dtNam.AsEnumerable().Select(row => row.Field<int>("Nam")).Distinct().ToList();
        //    cboNam.DataSource = dtNam.DefaultView;
        //    cboNam.DisplayMember = "Nam";
        //    cboNam.ValueMember = "Nam";
        //}
        private void InitializeDefaultValues()
        {
            foreach (Control control in pnlDanhGia.Controls)
            {
                if (control is System.Windows.Forms.TextBox txt && txt.Name.StartsWith("txtDiem"))
                {
                    txt.Text = "0";
                    txt.KeyPress += TextBox_OnlyNumbers;
                }
            }
            txtDiem1_1.Text = "0";
            txtDiem1_2.Text = "0";
            txtDiem1_3.Text = "0";
            txtDiem1_4.Text = "0";
            txtDiem1_5.Text = "0";
            txtDiem1_6.Text = "0";
            txtDiem1_7.Text = "0";
            txtDiem1_8.Text = "0";
            txtTongDiem1.Text = "0";

            txtDiem2_1.Text = "0";
            txtDiem2_2.Text = "0";
            txtDiem2_3.Text = "0";
            txtDiem2_4.Text = "0";
            txtDiem2_5.Text = "0";
            txtDiem2_6.Text = "0";
            txtDiem2_7.Text = "0";
            txtTongDiem2.Text = "0";

            txtDiem3_1.Text = "0";
            txtDiem3_2.Text = "0";
            txtDiem3_3.Text = "0";
            txtDiem3_4.Text = "0";
            txtDiem3_5.Text = "0";
            txtDiem3_6.Text = "0";
            txtDiem3_7.Text = "0";
            txtTongDiem3.Text = "0";

            txtDiem4_1.Text = "0";
            txtDiem4_2.Text = "0";
            txtDiem4_3.Text = "0";
            txtDiem4_4.Text = "0";
            txtDiem4_5.Text = "0";
            txtTongDiem4.Text = "0";

            txtDiem5_1.Text = "0";
            txtDiem5_2.Text = "0";
            txtDiem5_3.Text = "0";
            txtDiem5_4.Text = "0";
            txtDiem5_5.Text = "0";
            txtDiem5_6.Text = "0";
            txtTongDiem5.Text = "0";
            txtTongDiem.Text = "0";
            txtXepLoai.Text = "";
        }

        private void AttachTextChangedEvents()
        {
            foreach (Control control in pnlDanhGia.Controls)
            {
                if (control is System.Windows.Forms.TextBox txt && (txt.Name.StartsWith("txtDiem") || txt.Name.StartsWith("txtTongDiem")))
                {
                    txt.TextChanged += TextBox_TextChanged;
                }
            }
        }

        private void TextBox_OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
                string txtName = ((System.Windows.Forms.TextBox)sender).Name;
                var displayNames = new Dictionary<string, string>
        {
            { "txtDiem1_1", "Điểm 1.1" }, { "txtDiem1_2", "Điểm 1.2" }, { "txtDiem1_3", "Điểm 1.3" },
            { "txtDiem1_4", "Điểm 1.4" }, { "txtDiem1_5", "Điểm 1.5" }, { "txtDiem1_6", "Điểm 1.6" },
            { "txtDiem1_7", "Điểm 1.7" }, { "txtDiem1_8", "Điểm 1.8" }, { "txtDiem2_1", "Điểm 2.1" },
            { "txtDiem2_2", "Điểm 2.2" }, { "txtDiem2_3", "Điểm 2.3" }, { "txtDiem2_4", "Điểm 2.4" },
            { "txtDiem2_5", "Điểm 2.5" }, { "txtDiem2_6", "Điểm 2.6" }, { "txtDiem2_7", "Điểm 2.7" },
            { "txtDiem3_1", "Điểm 3.1" }, { "txtDiem3_2", "Điểm 3.2" }, { "txtDiem3_3", "Điểm 3.3" },
            { "txtDiem3_4", "Điểm 3.4" }, { "txtDiem3_5", "Điểm 3.5" }, { "txtDiem3_6", "Điểm 3.6" },
            { "txtDiem3_7", "Điểm 3.7" }, { "txtDiem4_1", "Điểm 4.1" }, { "txtDiem4_2", "Điểm 4.2" },
            { "txtDiem4_3", "Điểm 4.3" }, { "txtDiem4_4", "Điểm 4.4" }, { "txtDiem4_5", "Điểm 4.5" },
            { "txtDiem5_1", "Điểm 5.1" }, { "txtDiem5_2", "Điểm 5.2" }, { "txtDiem5_3", "Điểm 5.3" },
            { "txtDiem5_4", "Điểm 5.4" }, { "txtDiem5_5", "Điểm 5.5" }, { "txtDiem5_6", "Điểm 5.6" },
            { "txtTongDiem", "Tổng điểm" }, { "txtXepLoai", "Xếp loại" }
        };
                string displayName = displayNames.ContainsKey(txtName) ? displayNames[txtName] : txtName;
                MessageBox.Show($"Nhập sai ở mục: {displayName}\r\nChỉ được nhập số,\r\nkhông được nhập chữ cái!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
            CheckMinhChungRequirements();
            ValidatePointLimits();
        }
        private void UpdateTotals()
        {
            int tongDiem1 = SumDiem(new[] { txtDiem1_1, txtDiem1_2, txtDiem1_3, txtDiem1_4, txtDiem1_5, txtDiem1_6, txtDiem1_7, txtDiem1_8 });
            int tongDiem2 = SumDiem(new[] { txtDiem2_1, txtDiem2_2, txtDiem2_3, txtDiem2_4, txtDiem2_5, txtDiem2_6, txtDiem2_7 });
            int tongDiem3 = SumDiem(new[] { txtDiem3_1, txtDiem3_2, txtDiem3_3, txtDiem3_4, txtDiem3_5, txtDiem3_6, txtDiem3_7 });
            int tongDiem4 = SumDiem(new[] { txtDiem4_1, txtDiem4_2, txtDiem4_3, txtDiem4_4, txtDiem4_5 });
            int tongDiem5 = SumDiem(new[] { txtDiem5_1, txtDiem5_2, txtDiem5_3, txtDiem5_4, txtDiem5_5, txtDiem5_6 });

            txtTongDiem1.Text = tongDiem1.ToString();
            txtTongDiem2.Text = tongDiem2.ToString();
            txtTongDiem3.Text = tongDiem3.ToString();
            txtTongDiem4.Text = tongDiem4.ToString();
            txtTongDiem5.Text = tongDiem5.ToString();
            int tongDiem = tongDiem1 + tongDiem2 + tongDiem3 + tongDiem4 + tongDiem5;
            txtTongDiem.Text = tongDiem.ToString();

            // Tự động load xếp loại
            txtXepLoai.Text = GetXepLoai(tongDiem);
        }
        private int SumDiem(System.Windows.Forms.TextBox[] diemTextBoxes)
        {
            int sum = 0;
            foreach (var txt in diemTextBoxes)
            {
                if (int.TryParse(txt.Text.Trim(), out int diem))
                {
                    sum += diem;
                }
            }
            return sum;
        }
        private string GetXepLoai(int tongDiem)
        {
            if (tongDiem >= 90) return "Xuất sắc";
            if (tongDiem >= 80) return "Tốt";
            if (tongDiem >= 65) return "Khá";
            if (tongDiem >= 50) return "Trung bình";
            if (tongDiem >= 35) return "Yếu";
            return "Kém";
        }
        private void ValidatePointLimits()
        {
            int tongDiem1 = SumDiem(new[] { txtDiem1_1, txtDiem1_2, txtDiem1_3, txtDiem1_4, txtDiem1_5, txtDiem1_6, txtDiem1_7, txtDiem1_8 });
            if (tongDiem1 > 20)
            {
                MessageBox.Show("Mục 'Tiêu chí 1' đã nhập vượt mức quy định (20 điểm), vui lòng nhập lại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiem1_1.Text = "0"; // Reset để tránh lỗi lặp
                UpdateTotals();
            }

            int diem2_2 = int.TryParse(txtDiem2_2.Text, out int d2_2) ? d2_2 : 0;
            if (diem2_2 > 5)
            {
                MessageBox.Show("Mục '2.2' đã nhập vượt mức quy định (5 điểm), vui lòng nhập lại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiem2_2.Text = "0";
                UpdateTotals();
            }

            int diem2_6 = int.TryParse(txtDiem2_6.Text, out int d2_6) ? d2_6 : 0;
            if (diem2_6 > 5)
            {
                MessageBox.Show("Mục '2.6' đã nhập vượt mức quy định (5 điểm), vui lòng nhập lại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiem2_6.Text = "0";
                UpdateTotals();
            }

            int tongDiem2 = SumDiem(new[] { txtDiem2_1, txtDiem2_2, txtDiem2_3, txtDiem2_4, txtDiem2_5, txtDiem2_6, txtDiem2_7 });
            if (tongDiem2 > 25)
            {
                MessageBox.Show("Mục 'Tiêu chí 2' đã nhập vượt mức quy định (25 điểm), vui lòng nhập lại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiem2_1.Text = "0"; // Reset để tránh lỗi lặp
                UpdateTotals();
            }

            int tongDiem3 = SumDiem(new[] { txtDiem3_1, txtDiem3_2, txtDiem3_3, txtDiem3_4, txtDiem3_5, txtDiem3_6, txtDiem3_7 });
            if (tongDiem3 > 20)
            {
                MessageBox.Show("Mục 'Tiêu chí 3' đã nhập vượt mức quy định (20 điểm), vui lòng nhập lại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiem3_1.Text = "0"; // Reset để tránh lỗi lặp
                UpdateTotals();
            }

            int tongDiem4 = SumDiem(new[] { txtDiem4_1, txtDiem4_2, txtDiem4_3, txtDiem4_4, txtDiem4_5 });
            if (tongDiem4 > 25)
            {
                MessageBox.Show("Mục 'Tiêu chí 4' đã nhập vượt mức quy định (25 điểm), vui lòng nhập lại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiem4_1.Text = "0"; // Reset để tránh lỗi lặp
                UpdateTotals();
            }

            int tongDiem5 = SumDiem(new[] { txtDiem5_1, txtDiem5_2, txtDiem5_3, txtDiem5_4, txtDiem5_5, txtDiem5_6 });
            if (tongDiem5 > 10)
            {
                MessageBox.Show("Mục 'Tiêu chí 5' đã nhập vượt mức quy định (10 điểm), vui lòng nhập lại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiem5_1.Text = "0"; // Reset để tránh lỗi lặp
                UpdateTotals();
            }
        }

        private void CheckMinhChungRequirements()
        {
            if (isAdminMode) return;

            string[] requiredMinhChung = { "txtDiem1_3", "txtDiem1_4", "txtDiem2_3", "txtDiem3_4", "txtDiem3_5", "txtDiem4_1", "txtDiem4_2" };
            var displayNames = new Dictionary<string, string>
    {
        { "txtDiem1_3", "Điểm 1.3" },
        { "txtDiem1_4", "Điểm 1.4" },
        { "txtDiem2_3", "Điểm 2.3" },
        { "txtDiem3_4", "Điểm 3.4" },
        { "txtDiem3_5", "Điểm 3.5" },
        { "txtDiem4_1", "Điểm 4.1" },
        { "txtDiem4_2", "Điểm 4.2" }
    };
            foreach (string txtName in requiredMinhChung)
            {
                Control[] controls = this.Controls.Find(txtName, true);
                if (controls.Length > 0 && controls[0] is System.Windows.Forms.TextBox txt)
                {
                    if (int.TryParse(txt.Text.Trim(), out int diem) && diem != 0 && !minhChungFiles.ContainsKey(txtName))
                    {
                        string displayName = displayNames.ContainsKey(txtName) ? displayNames[txtName] : txtName;
                        MessageBox.Show($"Mục: {displayName}\r\nYêu cầu minh chứng,\r\nvui lòng gửi ảnh!",
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void pnlDanhGia_Scroll(object sender, ScrollEventArgs e)
        {
            // Xử lý sự kiện cuộn của panel pnlDanhGia, khi các control bên trong panel vượt quá kích thước của panel, sự kiện này sẽ được gọi
        }
        private void UploadMinhChung(string txtName)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                ofd.Filter = "Image Files|*.jpg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    minhChungFiles[txtName] = new List<string>(ofd.FileNames);
                    lstImages.Items.Clear();
                    foreach (string file in ofd.FileNames)
                    {
                        lstImages.Items.Add(Path.GetFileName(file));
                    }
                    var displayNames = new Dictionary<string, string>
            {
                { "txtDiem1_3", "Điểm 1.3" },
                { "txtDiem1_4", "Điểm 1.4" },
                { "txtDiem2_3", "Điểm 2.3" },
                { "txtDiem3_4", "Điểm 3.4" },
                { "txtDiem3_5", "Điểm 3.5" },
                { "txtDiem4_1", "Điểm 4.1" },
                { "txtDiem4_2", "Điểm 4.2" }
            };
                    string displayName = displayNames.ContainsKey(txtName) ? displayNames[txtName] : txtName;
                    MessageBox.Show($"Minh chứng cho mục: {displayName}\nĐã được gửi thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btnGuiMinhChung1_3_Click(object sender, EventArgs e)
        {
            UploadMinhChung("txtDiem1_3");
        }

        private void btnGuiMinhChung1_4_Click(object sender, EventArgs e)
        {
            UploadMinhChung("txtDiem1_4");
        }
        private void btnGuiMinhChung2_3_Click(object sender, EventArgs e)
        {
            UploadMinhChung("txtDiem2_3");
        }
        private void btnGuiMinhChung3_4_Click(object sender, EventArgs e)
        {
            UploadMinhChung("txtDiem3_4");
        }

        private void btnGuiMinhChung3_5_Click(object sender, EventArgs e)
        {
            UploadMinhChung("txtDiem3_5");
        }

        private void btnGuiMinhChung4_1_Click(object sender, EventArgs e)
        {
            UploadMinhChung("txtDiem4_1");
        }

        private void btnGuiMinhChung4_2_Click(object sender, EventArgs e)
        {
            UploadMinhChung("txtDiem4_2");
        }
        //Cập nhật 07/06/2025: Thêm hàm GetMaHocKyFromText và GetNamFromText để ánh xạ học kỳ và năm từ chuỗi
        private string GetMaHocKyFromText(string hocKyText)
        {
            return hocKyMapping.ContainsKey(hocKyText) ? hocKyMapping[hocKyText] : throw new Exception("Học kỳ không hợp lệ!");
        }
        //Cập nhật 07/06/2025: Thêm hàm GetNamFromText để ánh xạ năm từ chuỗi
        private int GetNamFromText(string namText)
        {
            return namMapping.ContainsKey(namText) ? namMapping[namText] : throw new Exception("Năm không hợp lệ!");
        }
        private void btnGui_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMaHocKy.SelectedItem == null || cboNam.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn học kỳ và năm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!isAdminMode)
                {
                    // Kiểm tra minh chứng bắt buộc
                    string[] requiredMinhChung = { "txtDiem1_3", "txtDiem1_4", "txtDiem2_3", "txtDiem3_4", "txtDiem3_5", "txtDiem4_1", "txtDiem4_2" };
                    var displayNames = new Dictionary<string, string>
            {
                { "txtDiem1_3", "Điểm 1.3" },
                { "txtDiem1_4", "Điểm 1.4" },
                { "txtDiem2_3", "Điểm 2.3" },
                { "txtDiem3_4", "Điểm 3.4" },
                { "txtDiem3_5", "Điểm 3.5" },
                { "txtDiem4_1", "Điểm 4.1" },
                { "txtDiem4_2", "Điểm 4.2" }
            };
                    foreach (string txtName in requiredMinhChung)
                    {
                        Control[] controls = pnlDanhGia.Controls.Find(txtName, true);
                        if (controls.Length > 0 && controls[0] is System.Windows.Forms.TextBox txt)
                        {
                            if (int.TryParse(txt.Text.Trim(), out int diem) && diem != 0 && !minhChungFiles.ContainsKey(txtName))
                            {
                                string displayName = displayNames.ContainsKey(txtName) ? displayNames[txtName] : txtName;
                                MessageBox.Show($"Mục: {displayName}\r\nYêu cầu minh chứng,\r\nvui lòng gửi ảnh!",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                }

                int tongDiem = int.Parse(txtTongDiem.Text);

                PhieuDanhGia pg = new PhieuDanhGia
                {
                    MaSV = txtMaSV.Text.Trim(),
                    MaHocKy = GetMaHocKyFromText(cboMaHocKy.SelectedItem.ToString()),
                    Nam = GetNamFromText(cboNam.SelectedItem.ToString()),
                    LoaiPhieu = isAdminMode ? "Admin" : "SinhVien",
                    Diem1_1 = int.Parse(txtDiem1_1.Text.Trim()),
                    Diem1_2 = int.Parse(txtDiem1_2.Text.Trim()),
                    Diem1_3 = int.Parse(txtDiem1_3.Text.Trim()),
                    Diem1_4 = int.Parse(txtDiem1_4.Text.Trim()),
                    Diem1_5 = int.Parse(txtDiem1_5.Text.Trim()),
                    Diem1_6 = int.Parse(txtDiem1_6.Text.Trim()),
                    Diem1_7 = int.Parse(txtDiem1_7.Text.Trim()),
                    Diem1_8 = int.Parse(txtDiem1_8.Text.Trim()),
                    Diem2_1 = int.Parse(txtDiem2_1.Text.Trim()),
                    Diem2_2 = int.Parse(txtDiem2_2.Text.Trim()),
                    Diem2_3 = int.Parse(txtDiem2_3.Text.Trim()),
                    Diem2_4 = int.Parse(txtDiem2_4.Text.Trim()),
                    Diem2_5 = int.Parse(txtDiem2_5.Text.Trim()),
                    Diem2_6 = int.Parse(txtDiem2_6.Text.Trim()),
                    Diem2_7 = int.Parse(txtDiem2_7.Text.Trim()),
                    Diem3_1 = int.Parse(txtDiem3_1.Text.Trim()),
                    Diem3_2 = int.Parse(txtDiem3_2.Text.Trim()),
                    Diem3_3 = int.Parse(txtDiem3_3.Text.Trim()),
                    Diem3_4 = int.Parse(txtDiem3_4.Text.Trim()),
                    Diem3_5 = int.Parse(txtDiem3_5.Text.Trim()),
                    Diem3_6 = int.Parse(txtDiem3_6.Text.Trim()),
                    Diem3_7 = int.Parse(txtDiem3_7.Text.Trim()),
                    Diem4_1 = int.Parse(txtDiem4_1.Text.Trim()),
                    Diem4_2 = int.Parse(txtDiem4_2.Text.Trim()),
                    Diem4_3 = int.Parse(txtDiem4_3.Text.Trim()),
                    Diem4_4 = int.Parse(txtDiem4_4.Text.Trim()),
                    Diem4_5 = int.Parse(txtDiem4_5.Text.Trim()),
                    Diem5_1 = int.Parse(txtDiem5_1.Text.Trim()),
                    Diem5_2 = int.Parse(txtDiem5_2.Text.Trim()),
                    Diem5_3 = int.Parse(txtDiem5_3.Text.Trim()),
                    Diem5_4 = int.Parse(txtDiem5_4.Text.Trim()),
                    Diem5_5 = int.Parse(txtDiem5_5.Text.Trim()),
                    Diem5_6 = int.Parse(txtDiem5_6.Text.Trim()),
                    TongDiem = tongDiem
                };

                if (isAdminMode)
                {
                    bool updated = phieuDanhGiaBUS.UpdatePhieuDanhGia(maPhieu, pg);
                    if (updated)
                    {
                        DiemRenLuyenBUS drlBUS = new DiemRenLuyenBUS();
                        drlBUS.UpdateDiemRenLuyen(maSV, GetMaHocKyFromText(cboMaHocKy.SelectedItem.ToString()), GetNamFromText(cboNam.SelectedItem.ToString()), tongDiem, txtXepLoai.Text);
                        MessageBox.Show("Cập nhật đánh giá thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật đánh giá thất bại!");
                    }
                }
                else
                {
                    int newMaPhieu = phieuDanhGiaBUS.AddPhieuDanhGia(pg);
                    if (newMaPhieu > 0)
                    {
                        foreach (var kvp in minhChungFiles)
                        {
                            foreach (string filePath in kvp.Value)
                            {
                                byte[] imageData = ImageHelper.ConvertImageToBytes(filePath);
                                MinhChung mc = new MinhChung
                                {
                                    MaPhieu = newMaPhieu,
                                    ImageData = imageData
                                };
                                int maMinhChung = minhChungBUS.AddMinhChung(mc);
                                if (maMinhChung <= 0)
                                {
                                    MessageBox.Show("Lỗi khi thêm minh chứng, vui lòng thử lại!");
                                    return;
                                }
                            }
                        }
                        DiemRenLuyenBUS drlBUS = new DiemRenLuyenBUS();
                        drlBUS.UpdateDiemRenLuyen(maSV, GetMaHocKyFromText(cboMaHocKy.SelectedItem.ToString()), GetNamFromText(cboNam.SelectedItem.ToString()), tongDiem, txtXepLoai.Text);
                        MessageBox.Show("Gửi đánh giá thành công!");
                        this.Close();
                        frmLogin loginForm = new frmLogin();
                        loginForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Gửi đánh giá thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (loaiTaiKhoan == "Admin")
                {
                    this.Close(); // Admin chỉ đóng form này
                    //frmChonSinhVien chonSinhVienForm = new frmChonSinhVien();
                    //chonSinhVienForm.Show(); // Mở lại form chọn sinh viên
                }
                else if (loaiTaiKhoan == "SinhVien")
                {
                    this.Close(); // Sinh viên thoát toàn bộ chương trình
                    frmLogin loginForm = new frmLogin();
                    loginForm.Show(); // Mở lại form đăng nhập
                }
            }
        }

        private void txtTongDiem1_TextChanged(object sender, EventArgs e)
        {
            // Cập nhật tổng điểm khi txtTongDiem1 thay đổi
            UpdateTotals();
        }

        private void txtTongDiem2_TextChanged(object sender, EventArgs e)
        {
            // Cập nhật tổng điểm khi txtTongDiem2 thay đổi
            UpdateTotals();
        }

        private void txtTongDiem3_TextChanged(object sender, EventArgs e)
        {
            // Cập nhật tổng điểm khi txtTongDiem3 thay đổi
            UpdateTotals();
        }

        private void txtTongDiem4_TextChanged(object sender, EventArgs e)
        {
            // Cập nhật tổng điểm khi txtTongDiem4 thay đổi
            UpdateTotals();
        }

        private void txtTongDiem5_TextChanged(object sender, EventArgs e)
        {
            // Cập nhật tổng điểm khi txtTongDiem5 thay đổi
            UpdateTotals();
        }

        private void txtTongDiem_TextChanged(object sender, EventArgs e)
        {
            // Cập nhật tổng điểm khi txtTongDiem thay đổi
            UpdateTotals();
        }

        private void txtXepLoai_TextChanged(object sender, EventArgs e)
        {
            // Cập nhật xếp loại khi txtXepLoai thay đổi
            if (string.IsNullOrEmpty(txtXepLoai.Text))
            {
                txtXepLoai.Text = GetXepLoai(int.Parse(txtTongDiem.Text));
            }
        }

        private void lstImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstImages.SelectedItems.Count > 0)
            {
                // Lấy giá trị Text của mục đã chọn
                string selectedText = lstImages.SelectedItems[0].ToString();

                if (isAdminMode)
                {
                    // Admin mode: Load ảnh từ bảng MinhChung
                    int maMinhChung = int.Parse(selectedText.Replace("Hình ", ""));
                    System.Data.DataTable dt = minhChungBUS.GetMinhChungByPhieu(maPhieu);
                    foreach (DataRow row in dt.Rows)
                    {
                        if (Convert.ToInt32(row["MaMinhChung"]) == maMinhChung)
                        {
                            using (MemoryStream ms = new MemoryStream((byte[])row["ImageData"]))
                            {
                                picMinhChung.Image = Image.FromStream(ms);
                            }
                            break;
                        }
                    }
                }
                else
                {
                    // Sinh viên mode: Load ảnh từ file tạm
                    foreach (var kvp in minhChungFiles)
                    {
                        foreach (string filePath in kvp.Value)
                        {
                            if (Path.GetFileName(filePath) == selectedText)
                            {
                                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                                {
                                    picMinhChung.Image = Image.FromStream(fs);
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            // Gửi thông báo cho form cha (frmChonSinhVien) để làm mới dữ liệu
            if (this.MdiParent != null)
            {
                foreach (Form form in this.MdiParent.MdiChildren)
                {
                    if (form is frmChonSinhVien chonSinhVienForm)
                    {
                        chonSinhVienForm.RefreshDataGridView();
                        break;
                    }
                }
            }
        }

        private void txtDiem1_1_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem1_2_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem1_3_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem1_4_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem1_5_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem1_6_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem1_7_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem1_8_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem2_1_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem2_2_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem2_3_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem2_4_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem2_5_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem2_6_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem2_7_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem3_1_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem3_2_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem3_3_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem3_4_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem3_5_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem3_6_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem3_7_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem4_1_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem4_2_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem4_3_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem4_4_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem4_5_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem5_1_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem5_2_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem5_3_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem5_4_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem5_5_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void txtDiem5_6_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }
    }
}
