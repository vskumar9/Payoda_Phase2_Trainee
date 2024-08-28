namespace HotelManagementSystem
{
    partial class AddOrUpdateRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrUpdateRoom));
            this.btnBackToRoomForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBackToRoomForm
            // 
            this.btnBackToRoomForm.ForeColor = System.Drawing.Color.Red;
            this.btnBackToRoomForm.Location = new System.Drawing.Point(912, 27);
            this.btnBackToRoomForm.Name = "btnBackToRoomForm";
            this.btnBackToRoomForm.Size = new System.Drawing.Size(208, 38);
            this.btnBackToRoomForm.TabIndex = 2;
            this.btnBackToRoomForm.Text = "Back to Room Form";
            this.btnBackToRoomForm.UseVisualStyleBackColor = true;
            this.btnBackToRoomForm.Click += new System.EventHandler(this.btnBackToRoomForm_Click);
            // 
            // AddOrUpdateRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1132, 450);
            this.Controls.Add(this.btnBackToRoomForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddOrUpdateRoom";
            this.Text = "AddOrUpdateRoom";
            this.Load += new System.EventHandler(this.AddOrUpdateRooms_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBackToRoomForm;
    }
}