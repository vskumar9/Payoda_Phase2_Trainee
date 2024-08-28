namespace HotelManagementSystem
{
    partial class ReservationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReservationForm));
            this.TotalReservations = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ViewReservations = new System.Windows.Forms.Button();
            this.SearchReservations = new System.Windows.Forms.Button();
            this.UpdateReservations = new System.Windows.Forms.Button();
            this.DeleteReservations = new System.Windows.Forms.Button();
            this.AddReservation = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBackToMainForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TotalReservations
            // 
            this.TotalReservations.Location = new System.Drawing.Point(709, 460);
            this.TotalReservations.Name = "TotalReservations";
            this.TotalReservations.Size = new System.Drawing.Size(161, 46);
            this.TotalReservations.TabIndex = 20;
            this.TotalReservations.Text = "Total Reservation";
            this.TotalReservations.UseVisualStyleBackColor = true;
            this.TotalReservations.Click += new System.EventHandler(this.TotalReservations_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(964, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "OR";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(207, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(574, 26);
            this.textBox1.TabIndex = 17;
            // 
            // ViewReservations
            // 
            this.ViewReservations.BackColor = System.Drawing.Color.Transparent;
            this.ViewReservations.Location = new System.Drawing.Point(891, 460);
            this.ViewReservations.Name = "ViewReservations";
            this.ViewReservations.Size = new System.Drawing.Size(232, 46);
            this.ViewReservations.TabIndex = 18;
            this.ViewReservations.Text = "View All Reservation";
            this.ViewReservations.UseVisualStyleBackColor = false;
            this.ViewReservations.Click += new System.EventHandler(this.ViewReservations_Click);
            // 
            // SearchReservations
            // 
            this.SearchReservations.Location = new System.Drawing.Point(833, 41);
            this.SearchReservations.Name = "SearchReservations";
            this.SearchReservations.Size = new System.Drawing.Size(108, 40);
            this.SearchReservations.TabIndex = 16;
            this.SearchReservations.Text = "Search";
            this.SearchReservations.UseVisualStyleBackColor = true;
            this.SearchReservations.Click += new System.EventHandler(this.SearchReservation_Click);
            // 
            // UpdateReservations
            // 
            this.UpdateReservations.BackColor = System.Drawing.Color.Transparent;
            this.UpdateReservations.Location = new System.Drawing.Point(268, 449);
            this.UpdateReservations.Name = "UpdateReservations";
            this.UpdateReservations.Size = new System.Drawing.Size(108, 68);
            this.UpdateReservations.TabIndex = 15;
            this.UpdateReservations.Text = "Update Reservation";
            this.UpdateReservations.UseVisualStyleBackColor = false;
            this.UpdateReservations.Click += new System.EventHandler(this.UpdateReservation_Click);
            // 
            // DeleteReservations
            // 
            this.DeleteReservations.Location = new System.Drawing.Point(1015, 41);
            this.DeleteReservations.Name = "DeleteReservations";
            this.DeleteReservations.Size = new System.Drawing.Size(108, 40);
            this.DeleteReservations.TabIndex = 14;
            this.DeleteReservations.Text = "Delete";
            this.DeleteReservations.UseVisualStyleBackColor = true;
            this.DeleteReservations.Click += new System.EventHandler(this.DeleteReservation_Click);
            // 
            // AddReservation
            // 
            this.AddReservation.Location = new System.Drawing.Point(124, 449);
            this.AddReservation.Name = "AddReservation";
            this.AddReservation.Size = new System.Drawing.Size(108, 68);
            this.AddReservation.TabIndex = 13;
            this.AddReservation.Text = "Add Reservation";
            this.AddReservation.UseVisualStyleBackColor = true;
            this.AddReservation.Click += new System.EventHandler(this.AddReservation_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(124, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(999, 290);
            this.dataGridView1.TabIndex = 12;
            // 
            // btnBackToMainForm
            // 
            this.btnBackToMainForm.ForeColor = System.Drawing.Color.Red;
            this.btnBackToMainForm.Location = new System.Drawing.Point(45, 3);
            this.btnBackToMainForm.Name = "btnBackToMainForm";
            this.btnBackToMainForm.Size = new System.Drawing.Size(153, 38);
            this.btnBackToMainForm.TabIndex = 11;
            this.btnBackToMainForm.Text = "Back to Main";
            this.btnBackToMainForm.UseVisualStyleBackColor = true;
            this.btnBackToMainForm.Click += new System.EventHandler(this.btnBackToMainForm_Click);
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1168, 549);
            this.Controls.Add(this.TotalReservations);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ViewReservations);
            this.Controls.Add(this.SearchReservations);
            this.Controls.Add(this.UpdateReservations);
            this.Controls.Add(this.DeleteReservations);
            this.Controls.Add(this.AddReservation);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnBackToMainForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReservationForm";
            this.Text = "ReservationForm";
            this.Load += new System.EventHandler(this.ReservationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TotalReservations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ViewReservations;
        private System.Windows.Forms.Button SearchReservations;
        private System.Windows.Forms.Button UpdateReservations;
        private System.Windows.Forms.Button DeleteReservations;
        private System.Windows.Forms.Button AddReservation;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBackToMainForm;
    }
}