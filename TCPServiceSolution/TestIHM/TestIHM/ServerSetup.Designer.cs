namespace TestIHM
{
    partial class ServerSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerSetup));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.TextBox();
            this.IPPart1 = new System.Windows.Forms.TextBox();
            this.IPPart2 = new System.Windows.Forms.TextBox();
            this.IPPart3 = new System.Windows.Forms.TextBox();
            this.IPPort4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(78, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(193)))), ((int)(((byte)(37)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(260, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port :";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(123, 156);
            this.Port.MaxLength = 5;
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(149, 20);
            this.Port.TabIndex = 5;
            this.Port.Text = "8001";
            this.Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Port.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // IPPart1
            // 
            this.IPPart1.Location = new System.Drawing.Point(123, 128);
            this.IPPart1.MaxLength = 3;
            this.IPPart1.Name = "IPPart1";
            this.IPPart1.Size = new System.Drawing.Size(33, 20);
            this.IPPart1.TabIndex = 1;
            this.IPPart1.Text = "127";
            this.IPPart1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IPPart1.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // IPPart2
            // 
            this.IPPart2.Location = new System.Drawing.Point(162, 128);
            this.IPPart2.MaxLength = 3;
            this.IPPart2.Name = "IPPart2";
            this.IPPart2.Size = new System.Drawing.Size(33, 20);
            this.IPPart2.TabIndex = 2;
            this.IPPart2.Text = "0";
            this.IPPart2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IPPart2.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // IPPart3
            // 
            this.IPPart3.Location = new System.Drawing.Point(201, 128);
            this.IPPart3.MaxLength = 3;
            this.IPPart3.Name = "IPPart3";
            this.IPPart3.Size = new System.Drawing.Size(34, 20);
            this.IPPart3.TabIndex = 3;
            this.IPPart3.Text = "0";
            this.IPPart3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IPPart3.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // IPPort4
            // 
            this.IPPort4.Location = new System.Drawing.Point(241, 128);
            this.IPPort4.MaxLength = 3;
            this.IPPort4.Name = "IPPort4";
            this.IPPort4.Size = new System.Drawing.Size(31, 20);
            this.IPPort4.TabIndex = 4;
            this.IPPort4.Text = "1";
            this.IPPort4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IPPort4.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // ServerSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(284, 243);
            this.Controls.Add(this.IPPort4);
            this.Controls.Add(this.IPPart3);
            this.Controls.Add(this.IPPart2);
            this.Controls.Add(this.IPPart1);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 281);
            this.MinimumSize = new System.Drawing.Size(300, 281);
            this.Name = "ServerSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat Server";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.TextBox IPPart1;
        private System.Windows.Forms.TextBox IPPart2;
        private System.Windows.Forms.TextBox IPPart3;
        private System.Windows.Forms.TextBox IPPort4;
    }
}

