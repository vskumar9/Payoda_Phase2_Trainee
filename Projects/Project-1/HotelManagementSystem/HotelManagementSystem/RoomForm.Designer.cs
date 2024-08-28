namespace HotelManagementSystem
{
    partial class RoomForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomForm));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AddRoom = new System.Windows.Forms.Button();
            this.DeleteRoom = new System.Windows.Forms.Button();
            this.UpdateRoom = new System.Windows.Forms.Button();
            this.SearchRoom = new System.Windows.Forms.Button();
            this.ViewRooms = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnBackToMainForm = new System.Windows.Forms.Button();
            this.TotalRooms = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(955, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "OR";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(115, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(999, 290);
            this.dataGridView1.TabIndex = 11;
            // 
            // AddRoom
            // 
            this.AddRoom.Location = new System.Drawing.Point(115, 435);
            this.AddRoom.Name = "AddRoom";
            this.AddRoom.Size = new System.Drawing.Size(108, 68);
            this.AddRoom.TabIndex = 12;
            this.AddRoom.Text = "Add Room";
            this.AddRoom.UseVisualStyleBackColor = true;
            this.AddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // DeleteRoom
            // 
            this.DeleteRoom.Location = new System.Drawing.Point(1006, 27);
            this.DeleteRoom.Name = "DeleteRoom";
            this.DeleteRoom.Size = new System.Drawing.Size(108, 40);
            this.DeleteRoom.TabIndex = 13;
            this.DeleteRoom.Text = "Delete";
            this.DeleteRoom.UseVisualStyleBackColor = true;
            this.DeleteRoom.Click += new System.EventHandler(this.btnDeleteRoom_Click);
            // 
            // UpdateRoom
            // 
            this.UpdateRoom.Location = new System.Drawing.Point(259, 435);
            this.UpdateRoom.Name = "UpdateRoom";
            this.UpdateRoom.Size = new System.Drawing.Size(108, 68);
            this.UpdateRoom.TabIndex = 14;
            this.UpdateRoom.Text = "Update Room";
            this.UpdateRoom.UseVisualStyleBackColor = true;
            this.UpdateRoom.Click += new System.EventHandler(this.btnUpdateRoom_Click);
            // 
            // SearchRoom
            // 
            this.SearchRoom.Location = new System.Drawing.Point(824, 27);
            this.SearchRoom.Name = "SearchRoom";
            this.SearchRoom.Size = new System.Drawing.Size(108, 40);
            this.SearchRoom.TabIndex = 15;
            this.SearchRoom.Text = "Search";
            this.SearchRoom.UseVisualStyleBackColor = true;
            this.SearchRoom.Click += new System.EventHandler(this.SearchRooms_Click);
            // 
            // ViewRooms
            // 
            this.ViewRooms.BackColor = System.Drawing.Color.Transparent;
            this.ViewRooms.Location = new System.Drawing.Point(882, 446);
            this.ViewRooms.Name = "ViewRooms";
            this.ViewRooms.Size = new System.Drawing.Size(232, 46);
            this.ViewRooms.TabIndex = 17;
            this.ViewRooms.Text = "View All Rooms";
            this.ViewRooms.UseVisualStyleBackColor = false;
            this.ViewRooms.Click += new System.EventHandler(this.RoomForm_Load);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(198, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(574, 26);
            this.textBox1.TabIndex = 16;
            // 
            // btnBackToMainForm
            // 
            this.btnBackToMainForm.ForeColor = System.Drawing.Color.Red;
            this.btnBackToMainForm.Location = new System.Drawing.Point(12, 29);
            this.btnBackToMainForm.Name = "btnBackToMainForm";
            this.btnBackToMainForm.Size = new System.Drawing.Size(153, 38);
            this.btnBackToMainForm.TabIndex = 10;
            this.btnBackToMainForm.Text = "Back to Main";
            this.btnBackToMainForm.UseVisualStyleBackColor = true;
            this.btnBackToMainForm.Click += new System.EventHandler(this.btnBackToMainForm_Click);
            // 
            // TotalRooms
            // 
            this.TotalRooms.BackColor = System.Drawing.Color.Transparent;
            this.TotalRooms.Location = new System.Drawing.Point(690, 446);
            this.TotalRooms.Name = "TotalRooms";
            this.TotalRooms.Size = new System.Drawing.Size(160, 46);
            this.TotalRooms.TabIndex = 19;
            this.TotalRooms.Text = "Total Rooms";
            this.TotalRooms.UseVisualStyleBackColor = false;
            this.TotalRooms.Click += new System.EventHandler(this.TotalRooms_Click);
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1151, 542);
            this.Controls.Add(this.TotalRooms);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ViewRooms);
            this.Controls.Add(this.SearchRoom);
            this.Controls.Add(this.UpdateRoom);
            this.Controls.Add(this.DeleteRoom);
            this.Controls.Add(this.AddRoom);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnBackToMainForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RoomForm";
            this.Text = "RoomForm";
            this.Load += new System.EventHandler(this.RoomForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddRoom;
        private System.Windows.Forms.Button DeleteRoom;
        private System.Windows.Forms.Button UpdateRoom;
        private System.Windows.Forms.Button SearchRoom;
        private System.Windows.Forms.Button ViewRooms;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnBackToMainForm;
        private System.Windows.Forms.Button TotalRooms;
    }
}