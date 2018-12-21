namespace MotionTest
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInitEng = new System.Windows.Forms.Button();
            this.btnListDevices = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lvBTdev = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtF1 = new System.Windows.Forms.TextBox();
            this.btnF1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnI1 = new System.Windows.Forms.Button();
            this.btnI2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInitEng
            // 
            this.btnInitEng.Location = new System.Drawing.Point(41, 26);
            this.btnInitEng.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnInitEng.Name = "btnInitEng";
            this.btnInitEng.Size = new System.Drawing.Size(234, 46);
            this.btnInitEng.TabIndex = 0;
            this.btnInitEng.Text = "Initialize engine";
            this.btnInitEng.UseVisualStyleBackColor = true;
            this.btnInitEng.Click += new System.EventHandler(this.btnInitEng_Click);
            // 
            // btnListDevices
            // 
            this.btnListDevices.Location = new System.Drawing.Point(13, 42);
            this.btnListDevices.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnListDevices.Name = "btnListDevices";
            this.btnListDevices.Size = new System.Drawing.Size(234, 46);
            this.btnListDevices.TabIndex = 1;
            this.btnListDevices.Text = "List Devices";
            this.btnListDevices.UseVisualStyleBackColor = true;
            this.btnListDevices.Click += new System.EventHandler(this.btnListDevices_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.lvBTdev);
            this.groupBox1.Controls.Add(this.btnListDevices);
            this.groupBox1.Location = new System.Drawing.Point(28, 84);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox1.Size = new System.Drawing.Size(576, 792);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BT";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(13, 404);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(234, 46);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect to device";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lvBTdev
            // 
            this.lvBTdev.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvBTdev.Location = new System.Drawing.Point(13, 100);
            this.lvBTdev.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lvBTdev.Name = "lvBTdev";
            this.lvBTdev.Size = new System.Drawing.Size(546, 288);
            this.lvBTdev.TabIndex = 2;
            this.lvBTdev.UseCompatibleStateImageBehavior = false;
            this.lvBTdev.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "MAC";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtF1);
            this.groupBox2.Controls.Add(this.btnF1);
            this.groupBox2.Location = new System.Drawing.Point(618, 84);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox2.Size = new System.Drawing.Size(312, 792);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Feedback";
            // 
            // txtF1
            // 
            this.txtF1.Location = new System.Drawing.Point(15, 42);
            this.txtF1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtF1.Name = "txtF1";
            this.txtF1.Size = new System.Drawing.Size(80, 36);
            this.txtF1.TabIndex = 1;
            // 
            // btnF1
            // 
            this.btnF1.Location = new System.Drawing.Point(113, 42);
            this.btnF1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnF1.Name = "btnF1";
            this.btnF1.Size = new System.Drawing.Size(182, 46);
            this.btnF1.TabIndex = 0;
            this.btnF1.Text = "Vibrate";
            this.btnF1.UseVisualStyleBackColor = true;
            this.btnF1.Click += new System.EventHandler(this.btnF1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.btnI2);
            this.groupBox3.Controls.Add(this.btnI1);
            this.groupBox3.Location = new System.Drawing.Point(944, 84);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox3.Size = new System.Drawing.Size(312, 792);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 42);
            this.textBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(80, 36);
            this.textBox1.TabIndex = 1;
            // 
            // btnI1
            // 
            this.btnI1.Location = new System.Drawing.Point(113, 42);
            this.btnI1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnI1.Name = "btnI1";
            this.btnI1.Size = new System.Drawing.Size(182, 46);
            this.btnI1.TabIndex = 0;
            this.btnI1.Text = "Register";
            this.btnI1.UseVisualStyleBackColor = true;
            this.btnI1.Click += new System.EventHandler(this.btnI1_Click);
            // 
            // btnI2
            // 
            this.btnI2.Location = new System.Drawing.Point(113, 121);
            this.btnI2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnI2.Name = "btnI2";
            this.btnI2.Size = new System.Drawing.Size(182, 46);
            this.btnI2.TabIndex = 0;
            this.btnI2.Text = "Dereg";
            this.btnI2.UseVisualStyleBackColor = true;
            this.btnI2.Click += new System.EventHandler(this.btnI2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1733, 900);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnInitEng);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInitEng;
        private System.Windows.Forms.Button btnListDevices;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvBTdev;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnF1;
        private System.Windows.Forms.TextBox txtF1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnI1;
        private System.Windows.Forms.Button btnI2;
    }
}

