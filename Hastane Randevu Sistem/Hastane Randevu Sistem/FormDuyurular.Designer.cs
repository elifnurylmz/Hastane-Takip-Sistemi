namespace Hastane_Randevu_Sistem
{
    partial class FormDuyurular
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
            this.dataduyuru = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnduyurusil = new System.Windows.Forms.Button();
            this.txtduyuruid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataduyuru)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataduyuru
            // 
            this.dataduyuru.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataduyuru.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataduyuru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataduyuru.Location = new System.Drawing.Point(3, 24);
            this.dataduyuru.Name = "dataduyuru";
            this.dataduyuru.RowHeadersWidth = 51;
            this.dataduyuru.RowTemplate.Height = 24;
            this.dataduyuru.Size = new System.Drawing.Size(473, 382);
            this.dataduyuru.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataduyuru);
            this.groupBox1.Location = new System.Drawing.Point(25, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 409);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Duyurular";
            // 
            // btnduyurusil
            // 
            this.btnduyurusil.Location = new System.Drawing.Point(310, 452);
            this.btnduyurusil.Name = "btnduyurusil";
            this.btnduyurusil.Size = new System.Drawing.Size(191, 41);
            this.btnduyurusil.TabIndex = 2;
            this.btnduyurusil.Text = "Duyuru Sil";
            this.btnduyurusil.UseVisualStyleBackColor = true;
            this.btnduyurusil.Click += new System.EventHandler(this.btnduyurusil_Click);
            // 
            // txtduyuruid
            // 
            this.txtduyuruid.Location = new System.Drawing.Point(142, 459);
            this.txtduyuruid.Name = "txtduyuruid";
            this.txtduyuruid.Size = new System.Drawing.Size(106, 28);
            this.txtduyuruid.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 462);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "DuyuruID:";
            // 
            // FormDuyurular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(525, 502);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtduyuruid);
            this.Controls.Add(this.btnduyurusil);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormDuyurular";
            this.Text = "Duyurular";
            this.Load += new System.EventHandler(this.FormDuyurular_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataduyuru)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataduyuru;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnduyurusil;
        private System.Windows.Forms.TextBox txtduyuruid;
        private System.Windows.Forms.Label label1;
    }
}