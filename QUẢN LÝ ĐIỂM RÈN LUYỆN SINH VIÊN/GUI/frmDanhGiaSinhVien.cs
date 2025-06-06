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
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
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
        private Dictionary<string, List<string>> minhChungFiles = new Dictionary<string, List<string>>();

        private string maSinhVien;

        public frmDanhGiaSinhVien(string maSV)
        {
            InitializeComponent();
            this.maSinhVien = maSV;
            txtMaSV.Text = maSV; // Lấy từ mã đăng nhập
            LoadComboboxes();
            InitializeDefaultValues();
            UpdateTotals();

        }
        private void LoadComboboxes()
        {
            // Load MaHocKy
            cboMaHocKy.DataSource = hocKyBUS.GetAllHocKy();
            cboMaHocKy.DisplayMember = "TenHocKy";
            cboMaHocKy.ValueMember = "MaHocKy";

            // Load Nam từ bảng HocKy
            System.Data.DataTable dtNam = hocKyBUS.GetAllHocKy(); // Giả sử bảng HocKy có cột Nam
            var distinctYears = dtNam.AsEnumerable().Select(row => row.Field<int>("Nam")).Distinct().ToList();
            cboNam.DataSource = dtNam.DefaultView;
            cboNam.DisplayMember = "Nam";
            cboNam.ValueMember = "Nam";
        }
        private void InitializeDefaultValues()
        {
            // Đặt mặc định là 0 cho tất cả các TextBox điểm
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox groupBox)
                {
                    foreach (Control subControl in groupBox.Controls)
                    {
                        if (subControl is TextBox txt && txt.Name.StartsWith("txtDiem"))
                        {
                            txt.Text = "0";
                            txt.KeyPress += TextBox_OnlyNumbers;
                        }
                    }
                }
            }
            txtTongDiem1.Text = "0";
            txtTongDiem2.Text = "0";
            txtTongDiem3.Text = "0";
            txtTongDiem4.Text = "0";
            txtTongDiem5.Text = "0";
            txtTongDiem.Text = "0";
            txtXepLoai.Text = "";
        }
        private void TextBox_OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
                MessageBox.Show($"Nhập sai ở mục {((TextBox)sender).Name}, không được nhập chữ cái!",
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
        private int SumDiem(TextBox[] diemTextBoxes)
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
            string[] requiredMinhChung = { "txtDiem1_3", "txtDiem1_4", "txtDiem2_3", "txtDiem3_4", "txtDiem3_5", "txtDiem4_1", "txtDiem4_2" };
            foreach (string txtName in requiredMinhChung)
            {
                Control[] controls = this.Controls.Find(txtName, true);
                if (controls.Length > 0 && controls[0] is TextBox txt)
                {
                    if (int.TryParse(txt.Text.Trim(), out int diem) && diem != 0 && !minhChungFiles.ContainsKey(txtName))
                    {
                        MessageBox.Show($"Mục {txtName} yêu cầu minh chứng, vui lòng gửi ảnh!",
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
                    MessageBox.Show($"Minh chứng cho mục {txtName} đã được gửi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnGui_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cboMaHocKy.SelectedValue?.ToString()) || cboNam.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn học kỳ và năm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra minh chứng bắt buộc
                string[] requiredMinhChung = { "txtDiem1_3", "txtDiem1_4", "txtDiem2_3", "txtDiem3_4", "txtDiem3_5", "txtDiem4_1", "txtDiem4_2" };
                foreach (string txtName in requiredMinhChung)
                {
                    Control[] controls = this.Controls.Find(txtName, true);
                    if (controls.Length > 0 && controls[0] is TextBox txt)
                    {
                        if (int.TryParse(txt.Text.Trim(), out int diem) && diem != 0 && !minhChungFiles.ContainsKey(txtName))
                        {
                            MessageBox.Show($"Mục {txtName} yêu cầu minh chứng, vui lòng gửi ảnh!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                int tongDiem = int.Parse(txtTongDiem.Text);

                PhieuDanhGia pg = new PhieuDanhGia
                {
                    //MaPhieu = 0, // MaPhieu sẽ được tự động tạo trong cơ sở dữ liệu
                    MaSV = txtMaSV.Text.Trim(),
                    MaHocKy = cboMaHocKy.SelectedValue.ToString(),
                    Nam = (int)cboNam.SelectedValue,
                    LoaiPhieu = "SinhVien",
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

                int maPhieu = phieuDanhGiaBUS.AddPhieuDanhGia(pg);
                if (maPhieu > 0)
                {
                    foreach (var kvp in minhChungFiles)
                    {
                        foreach (string filePath in kvp.Value)
                        {
                            byte[] imageData = ImageHelper.ConvertImageToBytes(filePath);
                            MinhChung mc = new MinhChung
                            {
                                MaPhieu = maPhieu,
                                ImageData = imageData
                            };
                            phieuDanhGiaBUS.AddMinhChung(mc);
                        }
                    }
                    MessageBox.Show("Gửi đánh giá thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Gửi đánh giá thất bại!");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //thông báo xác nhận trước khi đóng form, đóng form ko lưu dữ liệu, khi nào người dùng nhấn nút "Gửi" thì mới lưu dữ liệu
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                new frmLogin().Show();
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
    }
}
//Còn vấn đề phải fix
//Nếu được thì việc hiển thị ảnh minh chứng, bạn có thể thêm một PictureBox để hiển thị ảnh đã chọn từ danh sách lstImages. Khi người dùng chọn một mục trong lstImages, bạn có thể tải ảnh tương ứng và hiển thị nó trong PictureBox. Dưới đây là ví dụ đơn giản: