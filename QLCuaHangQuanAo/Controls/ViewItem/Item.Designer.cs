namespace QLCuaHangQuanAo.UserCotrols
{
    partial class Item
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameSP = new System.Windows.Forms.Label();
            this.GiaSP = new System.Windows.Forms.Label();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_Giam = new System.Windows.Forms.Button();
            this.txt_SoLuong = new System.Windows.Forms.TextBox();
            this.ImageSP = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SizeSP = new System.Windows.Forms.Label();
            this.ColorSP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSP)).BeginInit();
            this.SuspendLayout();
            // 
            // NameSP
            // 
            this.NameSP.AutoSize = true;
            this.NameSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameSP.Location = new System.Drawing.Point(30, 198);
            this.NameSP.Name = "NameSP";
            this.NameSP.Size = new System.Drawing.Size(48, 16);
            this.NameSP.TabIndex = 1;
            this.NameSP.Text = "Name";
            // 
            // GiaSP
            // 
            this.GiaSP.AutoSize = true;
            this.GiaSP.Location = new System.Drawing.Point(116, 254);
            this.GiaSP.Name = "GiaSP";
            this.GiaSP.Size = new System.Drawing.Size(35, 16);
            this.GiaSP.TabIndex = 2;
            this.GiaSP.Text = "200$";
            this.GiaSP.Click += new System.EventHandler(this.GiaSP_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(66, 271);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(32, 23);
            this.btn_Them.TabIndex = 3;
            this.btn_Them.Text = "+";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_Giam
            // 
            this.btn_Giam.Location = new System.Drawing.Point(166, 271);
            this.btn_Giam.Name = "btn_Giam";
            this.btn_Giam.Size = new System.Drawing.Size(28, 23);
            this.btn_Giam.TabIndex = 4;
            this.btn_Giam.Text = "-";
            this.btn_Giam.UseVisualStyleBackColor = true;
            this.btn_Giam.Click += new System.EventHandler(this.btn_Giam_Click);
            // 
            // txt_SoLuong
            // 
            this.txt_SoLuong.Enabled = false;
            this.txt_SoLuong.Location = new System.Drawing.Point(115, 273);
            this.txt_SoLuong.Name = "txt_SoLuong";
            this.txt_SoLuong.Size = new System.Drawing.Size(36, 22);
            this.txt_SoLuong.TabIndex = 5;
            this.txt_SoLuong.TextChanged += new System.EventHandler(this.txt_SoLuong_TextChanged);
            // 
            // ImageSP
            // 
            this.ImageSP.Location = new System.Drawing.Point(33, 11);
            this.ImageSP.Name = "ImageSP";
            this.ImageSP.Size = new System.Drawing.Size(232, 184);
            this.ImageSP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageSP.TabIndex = 0;
            this.ImageSP.TabStop = false;
            this.ImageSP.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Màu";
            // 
            // SizeSP
            // 
            this.SizeSP.AutoSize = true;
            this.SizeSP.Location = new System.Drawing.Point(76, 214);
            this.SizeSP.Name = "SizeSP";
            this.SizeSP.Size = new System.Drawing.Size(44, 16);
            this.SizeSP.TabIndex = 9;
            this.SizeSP.Text = "label3";
            // 
            // ColorSP
            // 
            this.ColorSP.AutoSize = true;
            this.ColorSP.Location = new System.Drawing.Point(76, 234);
            this.ColorSP.Name = "ColorSP";
            this.ColorSP.Size = new System.Drawing.Size(44, 16);
            this.ColorSP.TabIndex = 10;
            this.ColorSP.Text = "label4";
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ColorSP);
            this.Controls.Add(this.SizeSP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_SoLuong);
            this.Controls.Add(this.btn_Giam);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.GiaSP);
            this.Controls.Add(this.NameSP);
            this.Controls.Add(this.ImageSP);
            this.Name = "Item";
            this.Size = new System.Drawing.Size(296, 339);
            this.Load += new System.EventHandler(this.Item_Load);
            this.Click += new System.EventHandler(this.Item_Click);
            ((System.ComponentModel.ISupportInitialize)(this.ImageSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImageSP;
        private System.Windows.Forms.Label NameSP;
        private System.Windows.Forms.Label GiaSP;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Giam;
        private System.Windows.Forms.TextBox txt_SoLuong;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SizeSP;
        private System.Windows.Forms.Label ColorSP;
    }
}
