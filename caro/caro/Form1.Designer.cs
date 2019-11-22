namespace caro
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
            this.components = new System.ComponentModel.Container();
            this.panelChessBroad = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSendText = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnChangeName = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLan = new System.Windows.Forms.Button();
            this.txbIP = new System.Windows.Forms.TextBox();
            this.ptcMark = new System.Windows.Forms.PictureBox();
            this.pcbCoolDown = new System.Windows.Forms.ProgressBar();
            this.txbPlayerName = new System.Windows.Forms.TextBox();
            this.timerCoolDown = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptcMark)).BeginInit();
            this.SuspendLayout();
            // 
            // panelChessBroad
            // 
            this.panelChessBroad.BackColor = System.Drawing.SystemColors.Control;
            this.panelChessBroad.Location = new System.Drawing.Point(12, 12);
            this.panelChessBroad.Name = "panelChessBroad";
            this.panelChessBroad.Size = new System.Drawing.Size(452, 471);
            this.panelChessBroad.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.btnSendText);
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Location = new System.Drawing.Point(498, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(254, 173);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChessBroad_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(-2, 122);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(185, 49);
            this.textBox1.TabIndex = 0;
            // 
            // btnSendText
            // 
            this.btnSendText.Location = new System.Drawing.Point(180, 122);
            this.btnSendText.Name = "btnSendText";
            this.btnSendText.Size = new System.Drawing.Size(72, 49);
            this.btnSendText.TabIndex = 1;
            this.btnSendText.Text = "Send";
            this.btnSendText.UseVisualStyleBackColor = true;
            this.btnSendText.Click += new System.EventHandler(this.btnSendText_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(-2, -2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(254, 173);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnChangeName);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnLan);
            this.panel3.Controls.Add(this.txbIP);
            this.panel3.Controls.Add(this.ptcMark);
            this.panel3.Controls.Add(this.pcbCoolDown);
            this.panel3.Controls.Add(this.txbPlayerName);
            this.panel3.Location = new System.Drawing.Point(498, 199);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(254, 284);
            this.panel3.TabIndex = 2;
            // 
            // btnChangeName
            // 
            this.btnChangeName.Location = new System.Drawing.Point(142, -1);
            this.btnChangeName.Name = "btnChangeName";
            this.btnChangeName.Size = new System.Drawing.Size(110, 23);
            this.btnChangeName.TabIndex = 8;
            this.btnChangeName.Text = "Change Name";
            this.btnChangeName.UseVisualStyleBackColor = true;
            this.btnChangeName.Click += new System.EventHandler(this.btnChangeName_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(137, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 75);
            this.button2.TabIndex = 7;
            this.button2.Text = "Quit Game";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 75);
            this.button1.TabIndex = 6;
            this.button1.Text = "Start Game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLan
            // 
            this.btnLan.Location = new System.Drawing.Point(3, 173);
            this.btnLan.Name = "btnLan";
            this.btnLan.Size = new System.Drawing.Size(124, 23);
            this.btnLan.TabIndex = 4;
            this.btnLan.Text = "Lan";
            this.btnLan.UseVisualStyleBackColor = true;
            this.btnLan.Click += new System.EventHandler(this.btnLan_Click);
            // 
            // txbIP
            // 
            this.txbIP.Location = new System.Drawing.Point(0, 147);
            this.txbIP.Name = "txbIP";
            this.txbIP.Size = new System.Drawing.Size(124, 20);
            this.txbIP.TabIndex = 3;
            this.txbIP.Text = "127.0.0.1";
            // 
            // ptcMark
            // 
            this.ptcMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptcMark.Location = new System.Drawing.Point(137, 91);
            this.ptcMark.Name = "ptcMark";
            this.ptcMark.Size = new System.Drawing.Size(124, 105);
            this.ptcMark.TabIndex = 2;
            this.ptcMark.TabStop = false;
            // 
            // pcbCoolDown
            // 
            this.pcbCoolDown.Location = new System.Drawing.Point(-2, 118);
            this.pcbCoolDown.Name = "pcbCoolDown";
            this.pcbCoolDown.Size = new System.Drawing.Size(124, 23);
            this.pcbCoolDown.TabIndex = 1;
            // 
            // txbPlayerName
            // 
            this.txbPlayerName.Location = new System.Drawing.Point(0, 0);
            this.txbPlayerName.Name = "txbPlayerName";
            this.txbPlayerName.Size = new System.Drawing.Size(124, 20);
            this.txbPlayerName.TabIndex = 0;
            // 
            // timerCoolDown
            // 
            this.timerCoolDown.Tick += new System.EventHandler(this.timerCoolDown_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 495);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelChessBroad);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptcMark)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelChessBroad;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLan;
        private System.Windows.Forms.TextBox txbIP;
        private System.Windows.Forms.PictureBox ptcMark;
        private System.Windows.Forms.ProgressBar pcbCoolDown;
        private System.Windows.Forms.TextBox txbPlayerName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSendText;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timerCoolDown;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnChangeName;
    }
}

