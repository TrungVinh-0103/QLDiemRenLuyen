namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.GUI
{
    partial class frmSuaLop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuaLop));
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.cboMaNienKhoa = new System.Windows.Forms.ComboBox();
            this.nienKhoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLRenLuyenSinhVienDataSet1 = new QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.QLRenLuyenSinhVienDataSet1();
            this.cboMaKhoa = new System.Windows.Forms.ComboBox();
            this.khoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLRenLuyenSinhVienDataSet = new QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.QLRenLuyenSinhVienDataSet();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.khoaTableAdapter = new QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.QLRenLuyenSinhVienDataSetTableAdapters.KhoaTableAdapter();
            this.nienKhoaTableAdapter = new QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.QLRenLuyenSinhVienDataSet1TableAdapters.NienKhoaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.nienKhoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLRenLuyenSinhVienDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLRenLuyenSinhVienDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.LightCoral;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(225, 355);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(115, 41);
            this.btnHuy.TabIndex = 10;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.LightGreen;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(104, 355);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(115, 41);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu lớp";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // cboMaNienKhoa
            // 
            this.cboMaNienKhoa.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.nienKhoaBindingSource, "MaNienKhoa", true));
            this.cboMaNienKhoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMaNienKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaNienKhoa.FormattingEnabled = true;
            this.cboMaNienKhoa.Location = new System.Drawing.Point(90, 312);
            this.cboMaNienKhoa.Name = "cboMaNienKhoa";
            this.cboMaNienKhoa.Size = new System.Drawing.Size(267, 28);
            this.cboMaNienKhoa.TabIndex = 8;
            // 
            // nienKhoaBindingSource
            // 
            this.nienKhoaBindingSource.DataMember = "NienKhoa";
            this.nienKhoaBindingSource.DataSource = this.qLRenLuyenSinhVienDataSet1;
            // 
            // qLRenLuyenSinhVienDataSet1
            // 
            this.qLRenLuyenSinhVienDataSet1.DataSetName = "QLRenLuyenSinhVienDataSet1";
            this.qLRenLuyenSinhVienDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cboMaKhoa
            // 
            this.cboMaKhoa.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.khoaBindingSource, "MaKhoa", true));
            this.cboMaKhoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMaKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaKhoa.FormattingEnabled = true;
            this.cboMaKhoa.Location = new System.Drawing.Point(90, 232);
            this.cboMaKhoa.Name = "cboMaKhoa";
            this.cboMaKhoa.Size = new System.Drawing.Size(267, 28);
            this.cboMaKhoa.TabIndex = 7;
            this.cboMaKhoa.SelectedIndexChanged += new System.EventHandler(this.cboMaKhoa_SelectedIndexChanged);
            // 
            // khoaBindingSource
            // 
            this.khoaBindingSource.DataMember = "Khoa";
            this.khoaBindingSource.DataSource = this.qLRenLuyenSinhVienDataSet;
            // 
            // qLRenLuyenSinhVienDataSet
            // 
            this.qLRenLuyenSinhVienDataSet.DataSetName = "QLRenLuyenSinhVienDataSet";
            this.qLRenLuyenSinhVienDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtTenLop
            // 
            this.txtTenLop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLop.Location = new System.Drawing.Point(90, 157);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(267, 22);
            this.txtTenLop.TabIndex = 6;
            // 
            // khoaTableAdapter
            // 
            this.khoaTableAdapter.ClearBeforeFill = true;
            // 
            // nienKhoaTableAdapter
            // 
            this.nienKhoaTableAdapter.ClearBeforeFill = true;
            // 
            // frmSuaLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(449, 448);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.cboMaNienKhoa);
            this.Controls.Add(this.cboMaKhoa);
            this.Controls.Add(this.txtTenLop);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSuaLop";
            this.Text = "frmSuaLop";
            this.Load += new System.EventHandler(this.frmSuaLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nienKhoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLRenLuyenSinhVienDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLRenLuyenSinhVienDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.ComboBox cboMaNienKhoa;
        private System.Windows.Forms.ComboBox cboMaKhoa;
        private System.Windows.Forms.TextBox txtTenLop;
        private QLRenLuyenSinhVienDataSet qLRenLuyenSinhVienDataSet;
        private System.Windows.Forms.BindingSource khoaBindingSource;
        private QLRenLuyenSinhVienDataSetTableAdapters.KhoaTableAdapter khoaTableAdapter;
        private QLRenLuyenSinhVienDataSet1 qLRenLuyenSinhVienDataSet1;
        private System.Windows.Forms.BindingSource nienKhoaBindingSource;
        private QLRenLuyenSinhVienDataSet1TableAdapters.NienKhoaTableAdapter nienKhoaTableAdapter;
    }
}