namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.GUI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.QuanLyLopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuanLySinhVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DanhGiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuanLyDiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThongKeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DangXuatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblNguoiDangNhap = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QuanLyLopToolStripMenuItem,
            this.QuanLySinhVienToolStripMenuItem,
            this.DanhGiaToolStripMenuItem,
            this.QuanLyDiemToolStripMenuItem,
            this.ThongKeToolStripMenuItem,
            this.DangXuatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(933, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // QuanLyLopToolStripMenuItem
            // 
            this.QuanLyLopToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.QuanLyLopToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuanLyLopToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.QuanLyLopToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("QuanLyLopToolStripMenuItem.Image")));
            this.QuanLyLopToolStripMenuItem.Name = "QuanLyLopToolStripMenuItem";
            this.QuanLyLopToolStripMenuItem.Size = new System.Drawing.Size(147, 29);
            this.QuanLyLopToolStripMenuItem.Text = "Quản lý Lớp";
            this.QuanLyLopToolStripMenuItem.Click += new System.EventHandler(this.QuanLyLopToolStripMenuItem_Click);
            // 
            // QuanLySinhVienToolStripMenuItem
            // 
            this.QuanLySinhVienToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.QuanLySinhVienToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuanLySinhVienToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.QuanLySinhVienToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("QuanLySinhVienToolStripMenuItem.Image")));
            this.QuanLySinhVienToolStripMenuItem.Name = "QuanLySinhVienToolStripMenuItem";
            this.QuanLySinhVienToolStripMenuItem.Size = new System.Drawing.Size(194, 29);
            this.QuanLySinhVienToolStripMenuItem.Text = "Quản lý Sinh viên";
            this.QuanLySinhVienToolStripMenuItem.Click += new System.EventHandler(this.QuanLySinhVienToolStripMenuItem_Click);
            // 
            // DanhGiaToolStripMenuItem
            // 
            this.DanhGiaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DanhGiaToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DanhGiaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DanhGiaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.DanhGiaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DanhGiaToolStripMenuItem.Image")));
            this.DanhGiaToolStripMenuItem.Name = "DanhGiaToolStripMenuItem";
            this.DanhGiaToolStripMenuItem.Size = new System.Drawing.Size(119, 29);
            this.DanhGiaToolStripMenuItem.Text = "Đánh giá";
            this.DanhGiaToolStripMenuItem.MouseHover += new System.EventHandler(this.DanhGiaToolStripMenuItem_MouseHover);
            // 
            // QuanLyDiemToolStripMenuItem
            // 
            this.QuanLyDiemToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.QuanLyDiemToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuanLyDiemToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.QuanLyDiemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("QuanLyDiemToolStripMenuItem.Image")));
            this.QuanLyDiemToolStripMenuItem.Name = "QuanLyDiemToolStripMenuItem";
            this.QuanLyDiemToolStripMenuItem.Size = new System.Drawing.Size(159, 29);
            this.QuanLyDiemToolStripMenuItem.Text = "Quản lý Điểm";
            this.QuanLyDiemToolStripMenuItem.Click += new System.EventHandler(this.QuanLyDiemToolStripMenuItem_Click);
            // 
            // ThongKeToolStripMenuItem
            // 
            this.ThongKeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ThongKeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThongKeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ThongKeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ThongKeToolStripMenuItem.Image")));
            this.ThongKeToolStripMenuItem.Name = "ThongKeToolStripMenuItem";
            this.ThongKeToolStripMenuItem.Size = new System.Drawing.Size(124, 29);
            this.ThongKeToolStripMenuItem.Text = "Thống kê";
            this.ThongKeToolStripMenuItem.Click += new System.EventHandler(this.ThongKeToolStripMenuItem_Click);
            // 
            // DangXuatToolStripMenuItem
            // 
            this.DangXuatToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DangXuatToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DangXuatToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.DangXuatToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DangXuatToolStripMenuItem.Image")));
            this.DangXuatToolStripMenuItem.Name = "DangXuatToolStripMenuItem";
            this.DangXuatToolStripMenuItem.Size = new System.Drawing.Size(133, 29);
            this.DangXuatToolStripMenuItem.Text = "Đăng xuất";
            this.DangXuatToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lblNguoiDangNhap
            // 
            this.lblNguoiDangNhap.AutoSize = true;
            this.lblNguoiDangNhap.BackColor = System.Drawing.Color.Yellow;
            this.lblNguoiDangNhap.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiDangNhap.ForeColor = System.Drawing.Color.Red;
            this.lblNguoiDangNhap.Location = new System.Drawing.Point(9, 40);
            this.lblNguoiDangNhap.Name = "lblNguoiDangNhap";
            this.lblNguoiDangNhap.Size = new System.Drawing.Size(0, 25);
            this.lblNguoiDangNhap.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(933, 433);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblNguoiDangNhap);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý điểm rèn luyện";
            this.TransparencyKey = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem QuanLyLopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuanLySinhVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuanLyDiemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DanhGiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThongKeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DangXuatToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblNguoiDangNhap;
    }
}