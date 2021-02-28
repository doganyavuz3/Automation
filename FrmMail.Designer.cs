
namespace ticari_otomasyon
{
    partial class FrmMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMail));
            this.label1 = new System.Windows.Forms.Label();
            this.TxtMailAdres = new DevExpress.XtraEditors.TextEdit();
            this.TxtKonu = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtMesaj = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnGonder = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMailAdres.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtKonu.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(10, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mail Adresi : ";
            // 
            // TxtMailAdres
            // 
            this.TxtMailAdres.EditValue = "";
            this.TxtMailAdres.Location = new System.Drawing.Point(119, 163);
            this.TxtMailAdres.Name = "TxtMailAdres";
            this.TxtMailAdres.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtMailAdres.Properties.Appearance.Options.UseFont = true;
            this.TxtMailAdres.Size = new System.Drawing.Size(204, 26);
            this.TxtMailAdres.TabIndex = 1;
            // 
            // TxtKonu
            // 
            this.TxtKonu.EditValue = "";
            this.TxtKonu.Location = new System.Drawing.Point(119, 202);
            this.TxtKonu.Name = "TxtKonu";
            this.TxtKonu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtKonu.Properties.Appearance.Options.UseFont = true;
            this.TxtKonu.Size = new System.Drawing.Size(204, 26);
            this.TxtKonu.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(52, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Konu : ";
            // 
            // TxtMesaj
            // 
            this.TxtMesaj.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtMesaj.Location = new System.Drawing.Point(119, 236);
            this.TxtMesaj.Name = "TxtMesaj";
            this.TxtMesaj.Size = new System.Drawing.Size(204, 117);
            this.TxtMesaj.TabIndex = 4;
            this.TxtMesaj.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(48, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mesaj : ";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 111);
            this.panel1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(95, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "MAİL GÖNDERME PANELİ";
            // 
            // BtnGonder
            // 
            this.BtnGonder.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGonder.Appearance.Options.UseFont = true;
            this.BtnGonder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnGonder.ImageOptions.Image")));
            this.BtnGonder.Location = new System.Drawing.Point(144, 359);
            this.BtnGonder.Name = "BtnGonder";
            this.BtnGonder.Size = new System.Drawing.Size(106, 29);
            this.BtnGonder.TabIndex = 0;
            this.BtnGonder.Text = "Gönder";
            this.BtnGonder.Click += new System.EventHandler(this.BtnGonder_Click);
            // 
            // FrmMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(335, 419);
            this.Controls.Add(this.BtnGonder);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtMesaj);
            this.Controls.Add(this.TxtKonu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtMailAdres);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MAIL";
            this.Load += new System.EventHandler(this.FrmMail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtMailAdres.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtKonu.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit TxtMailAdres;
        private DevExpress.XtraEditors.TextEdit TxtKonu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox TxtMesaj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton BtnGonder;
    }
}