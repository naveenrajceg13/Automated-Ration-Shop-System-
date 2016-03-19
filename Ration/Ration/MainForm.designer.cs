namespace Ration
{
    partial class MainForm
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
            System.Windows.Forms.GroupBox gbEnrollment;
            System.Windows.Forms.GroupBox gbEventHandlerStatus;
            System.Windows.Forms.Label lblMaxFingers;
            System.Windows.Forms.Label lblMask;
            System.Windows.Forms.Button QuitButton;
            this.MaxFingers = new System.Windows.Forms.NumericUpDown();
            this.Mask = new System.Windows.Forms.NumericUpDown();
            this.EnrollButton = new System.Windows.Forms.Button();
            this.IsFailure = new System.Windows.Forms.RadioButton();
            this.IsSuccess = new System.Windows.Forms.RadioButton();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            gbEnrollment = new System.Windows.Forms.GroupBox();
            gbEventHandlerStatus = new System.Windows.Forms.GroupBox();
            lblMaxFingers = new System.Windows.Forms.Label();
            lblMask = new System.Windows.Forms.Label();
            QuitButton = new System.Windows.Forms.Button();
            gbEnrollment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxFingers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mask)).BeginInit();
            gbEventHandlerStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEnrollment
            // 
            gbEnrollment.Controls.Add(this.MaxFingers);
            gbEnrollment.Controls.Add(this.Mask);
            gbEnrollment.Controls.Add(this.EnrollButton);
            gbEnrollment.Controls.Add(gbEventHandlerStatus);
            gbEnrollment.Controls.Add(lblMaxFingers);
            gbEnrollment.Controls.Add(lblMask);
            gbEnrollment.Location = new System.Drawing.Point(12, 12);
            gbEnrollment.Name = "gbEnrollment";
            gbEnrollment.Size = new System.Drawing.Size(266, 201);
            gbEnrollment.TabIndex = 0;
            gbEnrollment.TabStop = false;
            gbEnrollment.Text = "Enrollment";
            // 
            // MaxFingers
            // 
            this.MaxFingers.Location = new System.Drawing.Point(160, 52);
            this.MaxFingers.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MaxFingers.Name = "MaxFingers";
            this.MaxFingers.Size = new System.Drawing.Size(94, 20);
            this.MaxFingers.TabIndex = 3;
            this.ToolTip.SetToolTip(this.MaxFingers, "Enter a number from 1 to 10");
            this.MaxFingers.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Mask
            // 
            this.Mask.Location = new System.Drawing.Point(160, 27);
            this.Mask.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.Mask.Name = "Mask";
            this.Mask.Size = new System.Drawing.Size(94, 20);
            this.Mask.TabIndex = 1;
            this.ToolTip.SetToolTip(this.Mask, "Enter a number from 0 to 1023");
            // 
            // EnrollButton
            // 
            this.EnrollButton.Location = new System.Drawing.Point(73, 162);
            this.EnrollButton.Name = "EnrollButton";
            this.EnrollButton.Size = new System.Drawing.Size(107, 23);
            this.EnrollButton.TabIndex = 5;
            this.EnrollButton.Text = "Enroll Fingerprints";
            this.ToolTip.SetToolTip(this.EnrollButton, "Start fingerprint enrollment");
            this.EnrollButton.UseVisualStyleBackColor = true;
            this.EnrollButton.Click += new System.EventHandler(this.EnrollButton_Click);
            // 
            // gbEventHandlerStatus
            // 
            gbEventHandlerStatus.Controls.Add(this.IsSuccess);
            gbEventHandlerStatus.Controls.Add(this.IsFailure);
            gbEventHandlerStatus.Location = new System.Drawing.Point(9, 79);
            gbEventHandlerStatus.Name = "gbEventHandlerStatus";
            gbEventHandlerStatus.Size = new System.Drawing.Size(251, 60);
            gbEventHandlerStatus.TabIndex = 4;
            gbEventHandlerStatus.TabStop = false;
            gbEventHandlerStatus.Text = "Event handler status";
            // 
            // IsFailure
            // 
            this.IsFailure.AutoSize = true;
            this.IsFailure.Location = new System.Drawing.Point(115, 29);
            this.IsFailure.Name = "IsFailure";
            this.IsFailure.Size = new System.Drawing.Size(56, 17);
            this.IsFailure.TabIndex = 1;
            this.IsFailure.TabStop = true;
            this.IsFailure.Text = "Failure";
            this.ToolTip.SetToolTip(this.IsFailure, "Force an enrollment failure");
            this.IsFailure.UseVisualStyleBackColor = true;
            this.IsFailure.CheckedChanged += new System.EventHandler(this.IsFailure_CheckedChanged);
            // 
            // IsSuccess
            // 
            this.IsSuccess.AutoSize = true;
            this.IsSuccess.Location = new System.Drawing.Point(26, 29);
            this.IsSuccess.Name = "IsSuccess";
            this.IsSuccess.Size = new System.Drawing.Size(66, 17);
            this.IsSuccess.TabIndex = 0;
            this.IsSuccess.TabStop = true;
            this.IsSuccess.Text = "Success";
            this.ToolTip.SetToolTip(this.IsSuccess, "Allow a successful enrollment");
            this.IsSuccess.UseVisualStyleBackColor = true;
            // 
            // lblMaxFingers
            // 
            lblMaxFingers.Location = new System.Drawing.Point(6, 53);
            lblMaxFingers.Name = "lblMaxFingers";
            lblMaxFingers.Size = new System.Drawing.Size(148, 20);
            lblMaxFingers.TabIndex = 2;
            lblMaxFingers.Text = "Max. enrolled fingers count";
            lblMaxFingers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMask
            // 
            lblMask.Location = new System.Drawing.Point(6, 27);
            lblMask.Name = "lblMask";
            lblMask.Size = new System.Drawing.Size(148, 20);
            lblMask.TabIndex = 0;
            lblMask.Text = "Fingerprint Mask";
            lblMask.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // QuitButton
            // 
            QuitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            QuitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            QuitButton.Location = new System.Drawing.Point(203, 222);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new System.Drawing.Size(75, 23);
            QuitButton.TabIndex = 2;
            QuitButton.Text = "Quit";
            this.ToolTip.SetToolTip(QuitButton, "Close the sample application");
            QuitButton.UseVisualStyleBackColor = true;
            QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = QuitButton;
            this.ClientSize = new System.Drawing.Size(287, 273);
            this.Controls.Add(QuitButton);
            this.Controls.Add(gbEnrollment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EnrollMentApp";
            gbEnrollment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MaxFingers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mask)).EndInit();
            gbEventHandlerStatus.ResumeLayout(false);
            gbEventHandlerStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.Button EnrollButton;
        private System.Windows.Forms.RadioButton IsFailure;
        private System.Windows.Forms.RadioButton IsSuccess;
		private System.Windows.Forms.NumericUpDown MaxFingers;
		private System.Windows.Forms.NumericUpDown Mask;
		private System.Windows.Forms.ToolTip ToolTip;
    }
}

