namespace QUẢN_LÝ_ĐIỂM_RÈN_LUYỆN_SINH_VIÊN.GUI
{
    partial class frmThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKe));
            this.cboMaHocKy = new System.Windows.Forms.ComboBox();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.btnTaiThongKe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // cboMaHocKy
            // 
            this.cboMaHocKy.BackColor = System.Drawing.Color.White;
            this.cboMaHocKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMaHocKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaHocKy.FormattingEnabled = true;
            this.cboMaHocKy.Location = new System.Drawing.Point(236, 94);
            this.cboMaHocKy.Name = "cboMaHocKy";
            this.cboMaHocKy.Size = new System.Drawing.Size(121, 24);
            this.cboMaHocKy.TabIndex = 0;
            // 
            // cboNam
            // 
            this.cboNam.BackColor = System.Drawing.Color.White;
            this.cboNam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(404, 94);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(142, 24);
            this.cboNam.TabIndex = 0;
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongKe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Location = new System.Drawing.Point(1, 133);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.Size = new System.Drawing.Size(726, 272);
            this.dgvThongKe.TabIndex = 1;
            // 
            // btnTaiThongKe
            // 
            this.btnTaiThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnTaiThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaiThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnTaiThongKe.Image")));
            this.btnTaiThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiThongKe.Location = new System.Drawing.Point(296, 411);
            this.btnTaiThongKe.Name = "btnTaiThongKe";
            this.btnTaiThongKe.Size = new System.Drawing.Size(133, 32);
            this.btnTaiThongKe.TabIndex = 2;
            this.btnTaiThongKe.Text = "Tải thống kê";
            this.btnTaiThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTaiThongKe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaiThongKe.UseVisualStyleBackColor = false;
            this.btnTaiThongKe.Click += new System.EventHandler(this.btnTaiThongKe_Click);
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(728, 480);
            this.Controls.Add(this.btnTaiThongKe);
            this.Controls.Add(this.dgvThongKe);
            this.Controls.Add(this.cboNam);
            this.Controls.Add(this.cboMaHocKy);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê";
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMaHocKy;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.Button btnTaiThongKe;
    }
}