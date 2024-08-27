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
            this.CustomerFrom.Location = new System.Drawing.Point(71, 175);
            this.CustomerFrom.Name = "CustomerFrom";
            this.CustomerFrom.Size = new System.Drawing.Size(148, 29);
            this.CustomerFrom.TabIndex = 0;
            this.CustomerFrom.Text = "Customer Form";
            this.CustomerFrom.UseVisualStyleBackColor = true;
            this.CustomerFrom.Click += new System.EventHandler(this.CustomerFrom_Click);
            // 
            // RoomForm
            // 
            this.RoomForm.Location = new System.Drawing.Point(330, 175);
            this.RoomForm.Name = "RoomForm";
            this.RoomForm.Size = new System.Drawing.Size(148, 29);
            this.RoomForm.TabIndex = 1;
            this.RoomForm.Text = "Room Form";
            this.RoomForm.UseVisualStyleBackColor = true;
            this.RoomForm.Click += new System.EventHandler(this.RoomForm_Click);
            // 
            // ReservationForm
            // 
            this.ReservationForm.Location = new System.Drawing.Point(578, 175);
            this.ReservationForm.Name = "ReservationForm";
            this.ReservationForm.Size = new System.Drawing.Size(160, 29);
            this.ReservationForm.TabIndex = 2;
            this.ReservationForm.Text = "Reservation Form";
            this.ReservationForm.UseVisualStyleBackColor = true;
            this.ReservationForm.Click += new System.EventHandler(this.ReservationForm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(271, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Welcome to Hotel Resevation System";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ExitApplication
            // 
            this.ExitApplication.ForeColor = System.Drawing.Color.Red;
            this.ExitApplication.Location = new System.Drawing.Point(330, 342);
            this.ExitApplication.Name = "ExitApplication";
            this.ExitApplication.Size = new System.Drawing.Size(148, 33);
            this.ExitApplication.TabIndex = 5;
            this.ExitApplication.Text = "Close/Exit";
            this.ExitApplication.UseVisualStyleBackColor = true;
            this.ExitApplication.Click += new System.EventHandler(this.ExitApplication_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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

