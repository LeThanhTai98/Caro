﻿namespace caro
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
            this.btnSendText = new System.Windows.Forms.Button();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.ChatBoard = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDiconnect = new System.Windows.Forms.Button();
            this.btnUnPause = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.NumericUpDown();
            this.btnClientFirst = new System.Windows.Forms.RadioButton();
            this.btnServerFirst = new System.Windows.Forms.RadioButton();
            this.btnReady = new System.Windows.Forms.Button();
            this.btnChangeName = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnLan = new System.Windows.Forms.Button();
            this.txbIP = new System.Windows.Forms.TextBox();
            this.ptcMark = new System.Windows.Forms.PictureBox();
            this.pcbCoolDown = new System.Windows.Forms.ProgressBar();
            this.txbPlayerName = new System.Windows.Forms.TextBox();
            this.timerCoolDown = new System.Windows.Forms.Timer(this.components);
            this.timerEnablePause = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptcMark)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelChessBroad
            // 
            this.panelChessBroad.BackColor = System.Drawing.SystemColors.Control;
            this.panelChessBroad.Location = new System.Drawing.Point(12, 27);
            this.panelChessBroad.Name = "panelChessBroad";
            this.panelChessBroad.Size = new System.Drawing.Size(452, 471);
            this.panelChessBroad.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnSendText);
            this.panel2.Controls.Add(this.txtChat);
            this.panel2.Controls.Add(this.ChatBoard);
            this.panel2.Location = new System.Drawing.Point(498, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(254, 173);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChessBroad_Paint);
            // 
            // btnSendText
            // 
            this.btnSendText.Location = new System.Drawing.Point(178, 120);
            this.btnSendText.Name = "btnSendText";
            this.btnSendText.Size = new System.Drawing.Size(72, 49);
            this.btnSendText.TabIndex = 1;
            this.btnSendText.Text = "Send";
            this.btnSendText.UseVisualStyleBackColor = true;
            this.btnSendText.Click += new System.EventHandler(this.btnSendText_Click);
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(-2, 120);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(185, 49);
            this.txtChat.TabIndex = 0;
            // 
            // ChatBoard
            // 
            this.ChatBoard.Location = new System.Drawing.Point(-5, -2);
            this.ChatBoard.Name = "ChatBoard";
            this.ChatBoard.ReadOnly = true;
            this.ChatBoard.Size = new System.Drawing.Size(254, 173);
            this.ChatBoard.TabIndex = 2;
            this.ChatBoard.Text = "";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnDiconnect);
            this.panel3.Controls.Add(this.btnUnPause);
            this.panel3.Controls.Add(this.btnPause);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtPort);
            this.panel3.Controls.Add(this.btnClientFirst);
            this.panel3.Controls.Add(this.btnServerFirst);
            this.panel3.Controls.Add(this.btnReady);
            this.panel3.Controls.Add(this.btnChangeName);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.btnStartGame);
            this.panel3.Controls.Add(this.btnLan);
            this.panel3.Controls.Add(this.txbIP);
            this.panel3.Controls.Add(this.ptcMark);
            this.panel3.Controls.Add(this.pcbCoolDown);
            this.panel3.Controls.Add(this.txbPlayerName);
            this.panel3.Location = new System.Drawing.Point(498, 214);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(254, 284);
            this.panel3.TabIndex = 2;
            // 
            // btnDiconnect
            // 
            this.btnDiconnect.Enabled = false;
            this.btnDiconnect.Location = new System.Drawing.Point(136, 173);
            this.btnDiconnect.Name = "btnDiconnect";
            this.btnDiconnect.Size = new System.Drawing.Size(118, 23);
            this.btnDiconnect.TabIndex = 18;
            this.btnDiconnect.Text = "disconnect";
            this.btnDiconnect.UseVisualStyleBackColor = true;
            this.btnDiconnect.Click += new System.EventHandler(this.btnDiconnect_Click);
            // 
            // btnUnPause
            // 
            this.btnUnPause.Location = new System.Drawing.Point(8, 28);
            this.btnUnPause.Name = "btnUnPause";
            this.btnUnPause.Size = new System.Drawing.Size(244, 23);
            this.btnUnPause.TabIndex = 17;
            this.btnUnPause.Text = "unpause";
            this.btnUnPause.UseVisualStyleBackColor = true;
            this.btnUnPause.Visible = false;
            this.btnUnPause.Click += new System.EventHandler(this.btnUnPause_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(7, 28);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(246, 23);
            this.btnPause.TabIndex = 16;
            this.btnPause.Text = "pause game";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "timer";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(40, 137);
            this.txtPort.Maximum = new decimal(new int[] {
            298954296,
            2,
            0,
            0});
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(87, 20);
            this.txtPort.TabIndex = 12;
            this.txtPort.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            // 
            // btnClientFirst
            // 
            this.btnClientFirst.AutoSize = true;
            this.btnClientFirst.Location = new System.Drawing.Point(137, 56);
            this.btnClientFirst.Name = "btnClientFirst";
            this.btnClientFirst.Size = new System.Drawing.Size(84, 17);
            this.btnClientFirst.TabIndex = 11;
            this.btnClientFirst.Text = "client go first";
            this.btnClientFirst.UseVisualStyleBackColor = true;
            this.btnClientFirst.CheckedChanged += new System.EventHandler(this.btnClientFirst_CheckedChanged);
            // 
            // btnServerFirst
            // 
            this.btnServerFirst.AutoSize = true;
            this.btnServerFirst.Checked = true;
            this.btnServerFirst.Location = new System.Drawing.Point(7, 56);
            this.btnServerFirst.Name = "btnServerFirst";
            this.btnServerFirst.Size = new System.Drawing.Size(88, 17);
            this.btnServerFirst.TabIndex = 10;
            this.btnServerFirst.TabStop = true;
            this.btnServerFirst.Text = "server go first";
            this.btnServerFirst.UseVisualStyleBackColor = true;
            this.btnServerFirst.CheckedChanged += new System.EventHandler(this.btnServerFirst_CheckedChanged);
            // 
            // btnReady
            // 
            this.btnReady.Location = new System.Drawing.Point(7, 203);
            this.btnReady.Name = "btnReady";
            this.btnReady.Size = new System.Drawing.Size(117, 75);
            this.btnReady.TabIndex = 9;
            this.btnReady.Text = "Ready";
            this.btnReady.UseVisualStyleBackColor = true;
            this.btnReady.Click += new System.EventHandler(this.btnReady_Click);
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
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(7, 202);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(117, 75);
            this.btnStartGame.TabIndex = 6;
            this.btnStartGame.Text = "Start Game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLan
            // 
            this.btnLan.Location = new System.Drawing.Point(7, 173);
            this.btnLan.Name = "btnLan";
            this.btnLan.Size = new System.Drawing.Size(118, 23);
            this.btnLan.TabIndex = 4;
            this.btnLan.Text = "Connect";
            this.btnLan.UseVisualStyleBackColor = true;
            this.btnLan.Click += new System.EventHandler(this.btnLan_Click);
            // 
            // txbIP
            // 
            this.txbIP.Location = new System.Drawing.Point(40, 108);
            this.txbIP.Name = "txbIP";
            this.txbIP.Size = new System.Drawing.Size(84, 20);
            this.txbIP.TabIndex = 3;
            this.txbIP.Text = "127.0.0.1";
            // 
            // ptcMark
            // 
            this.ptcMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptcMark.Location = new System.Drawing.Point(137, 79);
            this.ptcMark.Name = "ptcMark";
            this.ptcMark.Size = new System.Drawing.Size(124, 78);
            this.ptcMark.TabIndex = 2;
            this.ptcMark.TabStop = false;
            // 
            // pcbCoolDown
            // 
            this.pcbCoolDown.Location = new System.Drawing.Point(40, 79);
            this.pcbCoolDown.Name = "pcbCoolDown";
            this.pcbCoolDown.Size = new System.Drawing.Size(82, 23);
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
            // timerEnablePause
            // 
            this.timerEnablePause.Tick += new System.EventHandler(this.timerEnablePause_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(764, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.menuToolStripMenuItem.Text = "play history";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(0, 17);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 500);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(764, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 522);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelChessBroad);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptcMark)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelChessBroad;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLan;
        private System.Windows.Forms.PictureBox ptcMark;
        private System.Windows.Forms.ProgressBar pcbCoolDown;
        private System.Windows.Forms.TextBox txbPlayerName;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Button btnSendText;
        private System.Windows.Forms.RichTextBox ChatBoard;
        private System.Windows.Forms.Timer timerCoolDown;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnChangeName;
        private System.Windows.Forms.Button btnReady;
        private System.Windows.Forms.RadioButton btnClientFirst;
        private System.Windows.Forms.RadioButton btnServerFirst;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtPort;
        private System.Windows.Forms.TextBox txbIP;
        private System.Windows.Forms.Button btnUnPause;
        private System.Windows.Forms.Timer timerEnablePause;
        private System.Windows.Forms.Button btnDiconnect;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusBar;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

