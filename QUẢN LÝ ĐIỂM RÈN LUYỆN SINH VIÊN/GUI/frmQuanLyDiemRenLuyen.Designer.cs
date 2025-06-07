namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.GUI
{
    partial class frmQuanLyDiemRenLuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyDiemRenLuyen));
            this.cboTenLop = new System.Windows.Forms.ComboBox();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.dgvDiemRenLuyen = new System.Windows.Forms.DataGridView();
            this.btnLocDanhSach = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemRenLuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTenLop
            // 
            this.cboTenLop.BackColor = System.Drawing.Color.White;
            this.cboTenLop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboTenLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTenLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTenLop.ForeColor = System.Drawing.Color.Red;
            this.cboTenLop.FormattingEnabled = true;
            this.cboTenLop.Location = new System.Drawing.Point(210, 98);
            this.cboTenLop.Name = "cboTenLop";
            this.cboTenLop.Size = new System.Drawing.Size(274, 24);
            this.cboTenLop.TabIndex = 10;
            // 
            // cboHocKy
            // 
            this.cboHocKy.BackColor = System.Drawing.Color.White;
            this.cboHocKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboHocKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboHocKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHocKy.ForeColor = System.Drawing.Color.Red;
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Location = new System.Drawing.Point(210, 132);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(274, 24);
            this.cboHocKy.TabIndex = 11;
            // 
            // cboNam
            // 
            this.cboNam.BackColor = System.Drawing.Color.White;
            this.cboNam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboNam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNam.ForeColor = System.Drawing.Color.Red;
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(210, 166);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(274, 24);
            this.cboNam.TabIndex = 9;
            this.cboNam.SelectedIndexChanged += new System.EventHandler(this.cboNam_SelectedIndexChanged);
            // 
            // dgvDiemRenLuyen
            // 
            this.dgvDiemRenLuyen.BackgroundColor = System.Drawing.Color.White;
            this.dgvDiemRenLuyen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDiemRenLuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiemRenLuyen.Location = new System.Drawing.Point(12, 277);
            this.dgvDiemRenLuyen.Name = "dgvDiemRenLuyen";
            this.dgvDiemRenLuyen.Size = new System.Drawing.Size(557, 238);
            this.dgvDiemRenLuyen.TabIndex = 12;
            // 
            // btnLocDanhSach
            // 
            this.btnLocDanhSach.BackColor = System.Drawing.Color.White;
            this.btnLocDanhSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLocDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocDanhSach.ForeColor = System.Drawing.Color.Black;
            this.btnLocDanhSach.Image = ((System.Drawing.Image)(resources.GetObject("btnLocDanhSach.Image")));
            this.btnLocDanhSach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocDanhSach.Location = new System.Drawing.Point(170, 236);
            this.btnLocDanhSach.Name = "btnLocDanhSach";
            this.btnLocDanhSach.Size = new System.Drawing.Size(139, 33);
            this.btnLocDanhSach.TabIndex = 13;
            this.btnLocDanhSach.Text = "Lọc danh sách";
            this.btnLocDanhSach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLocDanhSach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLocDanhSach.UseVisualStyleBackColor = false;
            this.btnLocDanhSach.Click += new System.EventHandler(this.btnLocDanhSach_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.White;
            this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.ForeColor = System.Drawing.Color.Black;
            this.btnXuatExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcel.Image")));
            this.btnXuatExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXuatExcel.Location = new System.Drawing.Point(315, 236);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(113, 33);
            this.btnXuatExcel.TabIndex = 13;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXuatExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // txtMaSV
            // 
            this.txtMaSV.BackColor = System.Drawing.Color.White;
            this.txtMaSV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSV.ForeColor = System.Drawing.Color.Red;
            this.txtMaSV.Location = new System.Drawing.Point(210, 202);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(274, 19);
            this.txtMaSV.TabIndex = 14;
            // 
            // frmQuanLyDiemRenLuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(581, 518);
            this.Controls.Add(this.txtMaSV);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.btnLocDanhSach);
            this.Controls.Add(this.dgvDiemRenLuyen);
            this.Controls.Add(this.cboTenLop);
            this.Controls.Add(this.cboHocKy);
            this.Controls.Add(this.cboNam);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuanLyDiemRenLuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý diểm rèn luyện";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemRenLuyen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.ComboBox cboTenLop;
        private System.Windows.Forms.DataGridView dgvDiemRenLuyen;
        private System.Windows.Forms.Button btnLocDanhSach;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.TextBox txtMaSV;
    }
}