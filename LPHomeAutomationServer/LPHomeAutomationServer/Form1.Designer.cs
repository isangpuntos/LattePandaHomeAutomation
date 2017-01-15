namespace LPHomeAutomationServer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.conn2 = new System.Windows.Forms.Label();
            this.serialPortLabel = new System.Windows.Forms.Label();
            this.conn1 = new System.Windows.Forms.Label();
            this.socketLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.o6 = new System.Windows.Forms.Label();
            this.o5 = new System.Windows.Forms.Label();
            this.o4 = new System.Windows.Forms.Label();
            this.o3 = new System.Windows.Forms.Label();
            this.o2 = new System.Windows.Forms.Label();
            this.o1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Liberation Sans", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(461, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "LattePanda Home Automation Server";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.conn2);
            this.groupBox1.Controls.Add(this.serialPortLabel);
            this.groupBox1.Controls.Add(this.conn1);
            this.groupBox1.Controls.Add(this.socketLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 94);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Status";
            // 
            // conn2
            // 
            this.conn2.BackColor = System.Drawing.Color.Red;
            this.conn2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.conn2.Location = new System.Drawing.Point(290, 60);
            this.conn2.Name = "conn2";
            this.conn2.Size = new System.Drawing.Size(226, 17);
            this.conn2.TabIndex = 3;
            this.conn2.Text = "Disconnected";
            this.conn2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serialPortLabel
            // 
            this.serialPortLabel.AutoSize = true;
            this.serialPortLabel.Location = new System.Drawing.Point(290, 33);
            this.serialPortLabel.Name = "serialPortLabel";
            this.serialPortLabel.Size = new System.Drawing.Size(125, 15);
            this.serialPortLabel.TabIndex = 2;
            this.serialPortLabel.Text = "Serial Port Connection:";
            // 
            // conn1
            // 
            this.conn1.BackColor = System.Drawing.Color.Red;
            this.conn1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.conn1.Location = new System.Drawing.Point(6, 60);
            this.conn1.Name = "conn1";
            this.conn1.Size = new System.Drawing.Size(226, 17);
            this.conn1.TabIndex = 1;
            this.conn1.Text = "Not Ready";
            this.conn1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // socketLabel
            // 
            this.socketLabel.AutoSize = true;
            this.socketLabel.Location = new System.Drawing.Point(6, 33);
            this.socketLabel.Name = "socketLabel";
            this.socketLabel.Size = new System.Drawing.Size(83, 15);
            this.socketLabel.TabIndex = 0;
            this.socketLabel.Text = "Network State:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.o6);
            this.groupBox2.Controls.Add(this.o5);
            this.groupBox2.Controls.Add(this.o4);
            this.groupBox2.Controls.Add(this.o3);
            this.groupBox2.Controls.Add(this.o2);
            this.groupBox2.Controls.Add(this.o1);
            this.groupBox2.Location = new System.Drawing.Point(11, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(543, 185);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Outlet Status";
            // 
            // o6
            // 
            this.o6.BackColor = System.Drawing.Color.Red;
            this.o6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.o6.Location = new System.Drawing.Point(290, 141);
            this.o6.Name = "o6";
            this.o6.Size = new System.Drawing.Size(226, 17);
            this.o6.TabIndex = 7;
            this.o6.Text = "Outlet6";
            this.o6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // o5
            // 
            this.o5.BackColor = System.Drawing.Color.Red;
            this.o5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.o5.Location = new System.Drawing.Point(6, 141);
            this.o5.Name = "o5";
            this.o5.Size = new System.Drawing.Size(226, 17);
            this.o5.TabIndex = 6;
            this.o5.Text = "Outlet5";
            this.o5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // o4
            // 
            this.o4.BackColor = System.Drawing.Color.Red;
            this.o4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.o4.Location = new System.Drawing.Point(290, 87);
            this.o4.Name = "o4";
            this.o4.Size = new System.Drawing.Size(226, 17);
            this.o4.TabIndex = 5;
            this.o4.Text = "Outlet4";
            this.o4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // o3
            // 
            this.o3.BackColor = System.Drawing.Color.Red;
            this.o3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.o3.Location = new System.Drawing.Point(6, 87);
            this.o3.Name = "o3";
            this.o3.Size = new System.Drawing.Size(226, 17);
            this.o3.TabIndex = 4;
            this.o3.Text = "Outlet3";
            this.o3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // o2
            // 
            this.o2.BackColor = System.Drawing.Color.Red;
            this.o2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.o2.Location = new System.Drawing.Point(290, 36);
            this.o2.Name = "o2";
            this.o2.Size = new System.Drawing.Size(226, 17);
            this.o2.TabIndex = 3;
            this.o2.Text = "Outlet2";
            this.o2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // o1
            // 
            this.o1.BackColor = System.Drawing.Color.Red;
            this.o1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.o1.Location = new System.Drawing.Point(6, 36);
            this.o1.Name = "o1";
            this.o1.Size = new System.Drawing.Size(226, 17);
            this.o1.TabIndex = 1;
            this.o1.Text = "Outlet1";
            this.o1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 380);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft New Tai Lue", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label serialPortLabel;
        private System.Windows.Forms.Label socketLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label conn2;
        private System.Windows.Forms.Label conn1;
        private System.Windows.Forms.Label o6;
        private System.Windows.Forms.Label o5;
        private System.Windows.Forms.Label o4;
        private System.Windows.Forms.Label o3;
        private System.Windows.Forms.Label o2;
        private System.Windows.Forms.Label o1;
    }
}

