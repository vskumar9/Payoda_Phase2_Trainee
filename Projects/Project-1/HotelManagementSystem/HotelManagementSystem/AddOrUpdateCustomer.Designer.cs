namespace HotelManagementSystem
{
    partial class AddOrUpdateCustomer
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
            this.btnBackToCustomerForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBackToCustomerForm
            // 
            this.btnBackToCustomerForm.ForeColor = System.Drawing.Color.Red;
            this.btnBackToCustomerForm.Location = new System.Drawing.Point(851, 24);
            this.btnBackToCustomerForm.Name = "btnBackToCustomerForm";
            this.btnBackToCustomerForm.Size = new System.Drawing.Size(208, 38);
            this.btnBackToCustomerForm.TabIndex = 1;
            this.btnBackToCustomerForm.Text = "Back to Customer Form";
            this.btnBackToCustomerForm.UseVisualStyleBackColor = true;
            this.btnBackToCustomerForm.Click += new System.EventHandler(this.btnBackToCustomerForm_Click);
            // 
            // AddOrUpdateCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 450);
            this.Controls.Add(this.btnBackToCustomerForm);
            this.Name = "AddOrUpdateCustomer";
            this.Text = "AddOrUpdateCustomer";
            this.Load += new System.EventHandler(this.AddOrUpdateCustomer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBackToCustomerForm;
    }
}