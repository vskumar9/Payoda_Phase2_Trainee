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
            this.label3 = new System.Windows.Forms.Label();
            this.DESC_Order = new System.Windows.Forms.Button();
            this.ASC_Order = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSortOptions = new System.Windows.Forms.ComboBox();
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(707, 572);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 25);
            this.label3.TabIndex = 29;
            this.label3.Text = "OR";
            // 
            // DESC_Order
            // 
            this.DESC_Order.Location = new System.Drawing.Point(753, 571);
            this.DESC_Order.Name = "DESC_Order";
            this.DESC_Order.Size = new System.Drawing.Size(85, 28);
            this.DESC_Order.TabIndex = 28;
            this.DESC_Order.Text = "DESC";
            this.DESC_Order.UseVisualStyleBackColor = true;
            this.DESC_Order.Click += new System.EventHandler(this.DESC_Order_Click);
            // 
            // ASC_Order
            // 
            this.ASC_Order.Location = new System.Drawing.Point(616, 572);
            this.ASC_Order.Name = "ASC_Order";
            this.ASC_Order.Size = new System.Drawing.Size(85, 28);
            this.ASC_Order.TabIndex = 27;
            this.ASC_Order.Text = "ASC";
            this.ASC_Order.UseVisualStyleBackColor = true;
            this.ASC_Order.Click += new System.EventHandler(this.ASC_Order_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(333, 575);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "Sort By:";
            // 
            // comboBoxSortOptions
            // 
            this.comboBoxSortOptions.FormattingEnabled = true;
            this.comboBoxSortOptions.Location = new System.Drawing.Point(451, 572);
            this.comboBoxSortOptions.Name = "comboBoxSortOptions";
            this.comboBoxSortOptions.Size = new System.Drawing.Size(121, 28);
            this.comboBoxSortOptions.TabIndex = 25;
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1168, 661);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DESC_Order);
            this.Controls.Add(this.ASC_Order);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxSortOptions);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button DESC_Order;
        private System.Windows.Forms.Button ASC_Order;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSortOptions;
    }
}