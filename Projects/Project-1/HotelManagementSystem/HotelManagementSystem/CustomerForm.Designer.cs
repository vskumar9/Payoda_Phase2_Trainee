namespace HotelManagementSystem
{
    partial class CustomerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerForm));
            this.btnBackToMainForm = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AddCustomer = new System.Windows.Forms.Button();
            this.DeleteCustomer = new System.Windows.Forms.Button();
            this.UpdateCustomer = new System.Windows.Forms.Button();
            this.SearchCustomer = new System.Windows.Forms.Button();
            this.ViewCustomers = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TotalCustomers = new System.Windows.Forms.Button();
            this.comboBoxSortOptions = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ASC_Order = new System.Windows.Forms.Button();
            this.DESC_Order = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBackToMainForm
            // 
            this.btnBackToMainForm.ForeColor = System.Drawing.Color.Red;
            this.btnBackToMainForm.Location = new System.Drawing.Point(24, 24);
            this.btnBackToMainForm.Name = "btnBackToMainForm";
            this.btnBackToMainForm.Size = new System.Drawing.Size(153, 38);
            this.btnBackToMainForm.TabIndex = 0;
            this.btnBackToMainForm.Text = "Back to Main";
            this.btnBackToMainForm.UseVisualStyleBackColor = true;
            this.btnBackToMainForm.Click += new System.EventHandler(this.btnBackToMainForm_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.Location = new System.Drawing.Point(103, 108);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(999, 290);
            this.dataGridView1.TabIndex = 1;
            // 
            // AddCustomer
            // 
            this.AddCustomer.Location = new System.Drawing.Point(103, 470);
            this.AddCustomer.Name = "AddCustomer";
            this.AddCustomer.Size = new System.Drawing.Size(108, 68);
            this.AddCustomer.TabIndex = 2;
            this.AddCustomer.Text = "Add Customer";
            this.AddCustomer.UseVisualStyleBackColor = true;
            this.AddCustomer.Click += new System.EventHandler(this.AddCustomer_Click);
            // 
            // DeleteCustomer
            // 
            this.DeleteCustomer.Location = new System.Drawing.Point(994, 62);
            this.DeleteCustomer.Name = "DeleteCustomer";
            this.DeleteCustomer.Size = new System.Drawing.Size(108, 40);
            this.DeleteCustomer.TabIndex = 3;
            this.DeleteCustomer.Text = "Delete";
            this.DeleteCustomer.UseVisualStyleBackColor = true;
            this.DeleteCustomer.Click += new System.EventHandler(this.DeleteCustomer_Click);
            // 
            // UpdateCustomer
            // 
            this.UpdateCustomer.BackColor = System.Drawing.Color.Transparent;
            this.UpdateCustomer.Location = new System.Drawing.Point(247, 470);
            this.UpdateCustomer.Name = "UpdateCustomer";
            this.UpdateCustomer.Size = new System.Drawing.Size(108, 68);
            this.UpdateCustomer.TabIndex = 4;
            this.UpdateCustomer.Text = "Update Customer";
            this.UpdateCustomer.UseVisualStyleBackColor = false;
            this.UpdateCustomer.Click += new System.EventHandler(this.UpdateCustomer_Click);
            // 
            // SearchCustomer
            // 
            this.SearchCustomer.Location = new System.Drawing.Point(812, 62);
            this.SearchCustomer.Name = "SearchCustomer";
            this.SearchCustomer.Size = new System.Drawing.Size(108, 40);
            this.SearchCustomer.TabIndex = 5;
            this.SearchCustomer.Text = "Search";
            this.SearchCustomer.UseVisualStyleBackColor = true;
            this.SearchCustomer.Click += new System.EventHandler(this.SearchCustomer_Click);
            // 
            // ViewCustomers
            // 
            this.ViewCustomers.BackColor = System.Drawing.Color.Transparent;
            this.ViewCustomers.Location = new System.Drawing.Point(870, 481);
            this.ViewCustomers.Name = "ViewCustomers";
            this.ViewCustomers.Size = new System.Drawing.Size(232, 46);
            this.ViewCustomers.TabIndex = 8;
            this.ViewCustomers.Text = "View All Customers";
            this.ViewCustomers.UseVisualStyleBackColor = false;
            this.ViewCustomers.Click += new System.EventHandler(this.ViewCustomers_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(186, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(574, 26);
            this.textBox1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(943, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "OR";
            // 
            // TotalCustomers
            // 
            this.TotalCustomers.Location = new System.Drawing.Point(688, 481);
            this.TotalCustomers.Name = "TotalCustomers";
            this.TotalCustomers.Size = new System.Drawing.Size(161, 46);
            this.TotalCustomers.TabIndex = 10;
            this.TotalCustomers.Text = "Total Customers";
            this.TotalCustomers.UseVisualStyleBackColor = true;
            this.TotalCustomers.Click += new System.EventHandler(this.TotalCustomers_Click);
            // 
            // comboBoxSortOptions
            // 
            this.comboBoxSortOptions.FormattingEnabled = true;
            this.comboBoxSortOptions.Location = new System.Drawing.Point(247, 589);
            this.comboBoxSortOptions.Name = "comboBoxSortOptions";
            this.comboBoxSortOptions.Size = new System.Drawing.Size(121, 28);
            this.comboBoxSortOptions.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(129, 592);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Sort By:";
            // 
            // ASC_Order
            // 
            this.ASC_Order.Location = new System.Drawing.Point(412, 589);
            this.ASC_Order.Name = "ASC_Order";
            this.ASC_Order.Size = new System.Drawing.Size(85, 28);
            this.ASC_Order.TabIndex = 13;
            this.ASC_Order.Text = "ASC";
            this.ASC_Order.UseVisualStyleBackColor = true;
            this.ASC_Order.Click += new System.EventHandler(this.ASC_Order_Click);
            // 
            // DESC_Order
            // 
            this.DESC_Order.Location = new System.Drawing.Point(549, 588);
            this.DESC_Order.Name = "DESC_Order";
            this.DESC_Order.Size = new System.Drawing.Size(85, 28);
            this.DESC_Order.TabIndex = 14;
            this.DESC_Order.Text = "DESC";
            this.DESC_Order.UseVisualStyleBackColor = true;
            this.DESC_Order.Click += new System.EventHandler(this.DESC_Order_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(503, 589);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "OR";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1169, 700);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DESC_Order);
            this.Controls.Add(this.ASC_Order);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxSortOptions);
            this.Controls.Add(this.TotalCustomers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ViewCustomers);
            this.Controls.Add(this.SearchCustomer);
            this.Controls.Add(this.UpdateCustomer);
            this.Controls.Add(this.DeleteCustomer);
            this.Controls.Add(this.AddCustomer);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnBackToMainForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBackToMainForm;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddCustomer;
        private System.Windows.Forms.Button DeleteCustomer;
        private System.Windows.Forms.Button UpdateCustomer;
        private System.Windows.Forms.Button SearchCustomer;
        private System.Windows.Forms.Button ViewCustomers;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TotalCustomers;
        private System.Windows.Forms.ComboBox comboBoxSortOptions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ASC_Order;
        private System.Windows.Forms.Button DESC_Order;
        private System.Windows.Forms.Label label3;
    }
}