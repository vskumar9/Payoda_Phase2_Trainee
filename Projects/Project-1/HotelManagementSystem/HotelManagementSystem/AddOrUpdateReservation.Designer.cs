namespace HotelManagementSystem
{
    partial class AddOrUpdateReservation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrUpdateReservation));
            this.btnBackToReservationForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBackToReservationForm
            // 
            this.btnBackToReservationForm.ForeColor = System.Drawing.Color.Red;
            this.btnBackToReservationForm.Location = new System.Drawing.Point(911, 29);
            this.btnBackToReservationForm.Name = "btnBackToReservationForm";
            this.btnBackToReservationForm.Size = new System.Drawing.Size(222, 46);
            this.btnBackToReservationForm.TabIndex = 3;
            this.btnBackToReservationForm.Text = "Back to Reservation Form";
            this.btnBackToReservationForm.UseVisualStyleBackColor = true;
            this.btnBackToReservationForm.Click += new System.EventHandler(this.btnBackToReservationForm_Click);
            // 
            // AddOrUpdateReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1145, 505);
            this.Controls.Add(this.btnBackToReservationForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddOrUpdateReservation";
            this.Text = "AddOrUpdateReservation";
            this.Load += new System.EventHandler(this.AddOrUpdateReservation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBackToReservationForm;
    }
}