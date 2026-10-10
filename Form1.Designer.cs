namespace Griffindo_toys_system
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBoxMainImage = new System.Windows.Forms.PictureBox();
            this.lblQuiteAtticFilms = new System.Windows.Forms.Label();
            this.lblMotto = new System.Windows.Forms.Label();
            this.pictureBoxLogoNoName = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLoginNow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogoNoName)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxMainImage
            // 
            this.pictureBoxMainImage.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMainImage.Image")));
            this.pictureBoxMainImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMainImage.Name = "pictureBoxMainImage";
            this.pictureBoxMainImage.Size = new System.Drawing.Size(423, 496);
            this.pictureBoxMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMainImage.TabIndex = 40;
            this.pictureBoxMainImage.TabStop = false;
            // 
            // lblQuiteAtticFilms
            // 
            this.lblQuiteAtticFilms.AutoSize = true;
            this.lblQuiteAtticFilms.Font = new System.Drawing.Font("Britannic Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuiteAtticFilms.Location = new System.Drawing.Point(497, 111);
            this.lblQuiteAtticFilms.Name = "lblQuiteAtticFilms";
            this.lblQuiteAtticFilms.Size = new System.Drawing.Size(255, 44);
            this.lblQuiteAtticFilms.TabIndex = 39;
            this.lblQuiteAtticFilms.Text = "Grifindo Toys";
            // 
            // lblMotto
            // 
            this.lblMotto.AutoSize = true;
            this.lblMotto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotto.Location = new System.Drawing.Point(454, 172);
            this.lblMotto.Name = "lblMotto";
            this.lblMotto.Size = new System.Drawing.Size(324, 23);
            this.lblMotto.TabIndex = 38;
            this.lblMotto.Text = "Creating Joy, One Toy At A Time";
            // 
            // pictureBoxLogoNoName
            // 
            this.pictureBoxLogoNoName.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogoNoName.Image")));
            this.pictureBoxLogoNoName.Location = new System.Drawing.Point(664, 339);
            this.pictureBoxLogoNoName.Name = "pictureBoxLogoNoName";
            this.pictureBoxLogoNoName.Size = new System.Drawing.Size(217, 198);
            this.pictureBoxLogoNoName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogoNoName.TabIndex = 37;
            this.pictureBoxLogoNoName.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.Location = new System.Drawing.Point(773, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(77, 26);
            this.btnExit.TabIndex = 36;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLoginNow
            // 
            this.btnLoginNow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginNow.Location = new System.Drawing.Point(486, 242);
            this.btnLoginNow.Name = "btnLoginNow";
            this.btnLoginNow.Size = new System.Drawing.Size(278, 45);
            this.btnLoginNow.TabIndex = 35;
            this.btnLoginNow.Text = "Login Now!";
            this.btnLoginNow.UseVisualStyleBackColor = true;
            this.btnLoginNow.Click += new System.EventHandler(this.btnLoginNow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(862, 495);
            this.Controls.Add(this.pictureBoxMainImage);
            this.Controls.Add(this.lblQuiteAtticFilms);
            this.Controls.Add(this.lblMotto);
            this.Controls.Add(this.pictureBoxLogoNoName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLoginNow);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMainImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogoNoName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMainImage;
        private System.Windows.Forms.Label lblQuiteAtticFilms;
        private System.Windows.Forms.Label lblMotto;
        private System.Windows.Forms.PictureBox pictureBoxLogoNoName;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLoginNow;
    }
}

