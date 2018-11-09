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
            this.lvBTdev = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnF1 = new System.Windows.Forms.Button();
            this.txtF1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInitEng
            // 
            this.btnInitEng.Location = new System.Drawing.Point(19, 13);
            this.btnInitEng.Name = "btnInitEng";
            this.btnInitEng.Size = new System.Drawing.Size(108, 23);
            this.btnInitEng.TabIndex = 0;
            this.btnInitEng.Text = "Initialize engine";
            this.btnInitEng.UseVisualStyleBackColor = true;
            this.btnInitEng.Click += new System.EventHandler(this.btnInitEng_Click);
            // 
            // btnListDevices
            // 
            this.btnListDevices.Location = new System.Drawing.Point(6, 21);
            this.btnListDevices.Name = "btnListDevices";
            this.btnListDevices.Size = new System.Drawing.Size(108, 23);
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
            this.groupBox1.Location = new System.Drawing.Point(13, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 396);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BT";
            // 
            // lvBTdev
            // 
            this.lvBTdev.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvBTdev.Location = new System.Drawing.Point(6, 50);
            this.lvBTdev.Name = "lvBTdev";
            this.lvBTdev.Size = new System.Drawing.Size(254, 146);
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
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(6, 202);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(108, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect to device";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtF1);
            this.groupBox2.Controls.Add(this.btnF1);
            this.groupBox2.Location = new System.Drawing.Point(285, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 396);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Feedback";
            // 
            // btnF1
            // 
            this.btnF1.Location = new System.Drawing.Point(52, 21);
            this.btnF1.Name = "btnF1";
            this.btnF1.Size = new System.Drawing.Size(84, 23);
            this.btnF1.TabIndex = 0;
            this.btnF1.Text = "Vibrate";
            this.btnF1.UseVisualStyleBackColor = true;
            this.btnF1.Click += new System.EventHandler(this.btnF1_Click);
            // 
            // txtF1
            // 
            this.txtF1.Location = new System.Drawing.Point(7, 21);
            this.txtF1.Name = "txtF1";
            this.txtF1.Size = new System.Drawing.Size(39, 22);
            this.txtF1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnInitEng);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
    }
}

