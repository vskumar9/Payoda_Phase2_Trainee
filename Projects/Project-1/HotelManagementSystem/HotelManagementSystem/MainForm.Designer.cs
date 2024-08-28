namespace HotelManagementSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.CustomerFrom = new System.Windows.Forms.Button();
            this.RoomForm = new System.Windows.Forms.Button();
            this.ReservationForm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ExitApplication = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CustomerFrom
            // 
            this.CustomerFrom.AutoSize = true;
            this.CustomerFrom.BackColor = System.Drawing.SystemColors.HighlightText;
            this.CustomerFrom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CustomerFrom.Location = new System.Drawing.Point(168, 264);
            this.CustomerFrom.Name = "CustomerFrom";
            this.CustomerFrom.Size = new System.Drawing.Size(171, 48);
            this.CustomerFrom.TabIndex = 0;
            this.CustomerFrom.Text = "Customer Form";
            this.CustomerFrom.UseVisualStyleBackColor = false;
            this.CustomerFrom.Click += new System.EventHandler(this.CustomerFrom_Click);
            // 
            // RoomForm
            // 
            this.RoomForm.AutoSize = true;
            this.RoomForm.BackColor = System.Drawing.SystemColors.HighlightText;
            this.RoomForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RoomForm.Location = new System.Drawing.Point(511, 264);
            this.RoomForm.Name = "RoomForm";
            this.RoomForm.Size = new System.Drawing.Size(168, 48);
            this.RoomForm.TabIndex = 1;
            this.RoomForm.Text = "Room Form";
            this.RoomForm.UseVisualStyleBackColor = false;
            this.RoomForm.Click += new System.EventHandler(this.RoomForm_Click);
            // 
            // ReservationForm
            // 
            this.ReservationForm.AutoSize = true;
            this.ReservationForm.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ReservationForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReservationForm.Location = new System.Drawing.Point(839, 265);
            this.ReservationForm.Name = "ReservationForm";
            this.ReservationForm.Size = new System.Drawing.Size(171, 47);
            this.ReservationForm.TabIndex = 2;
            this.ReservationForm.Text = "Reservation Form";
            this.ReservationForm.UseVisualStyleBackColor = false;
            this.ReservationForm.Click += new System.EventHandler(this.ReservationForm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Mistral", 24F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(271, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(614, 57);
            this.label1.TabIndex = 4;
            this.label1.Text = "Welcome to Hotel Resevation System";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ExitApplication
            // 
            this.ExitApplication.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitApplication.ForeColor = System.Drawing.Color.Red;
            this.ExitApplication.Location = new System.Drawing.Point(512, 463);
            this.ExitApplication.Name = "ExitApplication";
            this.ExitApplication.Size = new System.Drawing.Size(167, 41);
            this.ExitApplication.TabIndex = 5;
            this.ExitApplication.Text = "LogOut";
            this.ExitApplication.UseVisualStyleBackColor = true;
            this.ExitApplication.Click += new System.EventHandler(this.ExitApplication_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1167, 668);
            this.Controls.Add(this.ExitApplication);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReservationForm);
            this.Controls.Add(this.RoomForm);
            this.Controls.Add(this.CustomerFrom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Hotel Reservation System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CustomerFrom;
        private System.Windows.Forms.Button RoomForm;
        private System.Windows.Forms.Button ReservationForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitApplication;
    }
}

