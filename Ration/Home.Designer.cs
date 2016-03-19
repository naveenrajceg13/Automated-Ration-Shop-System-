namespace Ration
{
    partial class Home
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
            this.llblAdmin = new System.Windows.Forms.LinkLabel();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // llblAdmin
            // 
            this.llblAdmin.AutoSize = true;
            this.llblAdmin.BackColor = System.Drawing.Color.Transparent;
            this.llblAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblAdmin.Location = new System.Drawing.Point(420, 368);
            this.llblAdmin.Name = "llblAdmin";
            this.llblAdmin.Size = new System.Drawing.Size(59, 20);
            this.llblAdmin.TabIndex = 1;
            this.llblAdmin.TabStop = true;
            this.llblAdmin.Text = "Admin";
            this.llblAdmin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblAdmin_LinkClicked);
            // 
            // btnNewUser
            // 
            this.btnNewUser.BackgroundImage = global::Ration.Properties.Resources.newuser;
            this.btnNewUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewUser.Location = new System.Drawing.Point(155, 336);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(93, 82);
            this.btnNewUser.TabIndex = 2;
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // btnUser
            // 
            this.btnUser.BackgroundImage = global::Ration.Properties.Resources.User;
            this.btnUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUser.Location = new System.Drawing.Point(12, 335);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(93, 84);
            this.btnUser.TabIndex = 3;
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Mistral", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(126, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 33);
            this.label1.TabIndex = 4;
            this.label1.Text = "AUTOMATED RATION SHOP";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Ration.Properties.Resources.gew_series_scale_11_l;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(520, 441);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.llblAdmin);
            this.DoubleBuffered = true;
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel llblAdmin;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Label label1;

    }
}

