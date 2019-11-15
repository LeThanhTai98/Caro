using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caro
{
    public partial class Form1 : Form
    {
        chessBroadManager chessBroad;
        SocketMangaer sck;
        public Form1()
        {

            String playerName = null;
            using (Form form = new Form())
            {
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Text = "Login";
                TextBox text1 = new TextBox();

                text1.Width = 200;
                text1.Location = new Point(form.Width / 2 - text1.Size.Width / 2, form.Height / 2 - text1.Size.Height / 2 - 50);

                Label label2 = new Label();
                label2.Text = "WELCOME TO CARO GAME \n \n please enter player name";
                label2.Width = 200;
                label2.Height = 100;
                label2.Location = new Point(text1.Location.X, text1.Location.Y - 70);

                Button acceptBtn = new Button();
                acceptBtn.Text = "Accept";

                acceptBtn.Location = new Point(text1.Location.X, text1.Location.Y + 50);

                acceptBtn.Click += (o, e) =>
                {
                    if (string.IsNullOrEmpty(text1.Text))
                    {
                        MessageBox.Show("pls enter ur name", "player name is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else form.Close();
                };
                // form.Controls.Add(...);
                form.Controls.Add(text1);

                form.Controls.Add(label2);

                form.Controls.Add(acceptBtn);

                form.FormClosing += (o, e) =>
                {
                    playerName = text1.Text;
                };

                form.ShowDialog();
            }


            if (string.IsNullOrEmpty(playerName))
                Environment.Exit(1);

            InitializeComponent();

            sck = new SocketMangaer();

            txbPlayerName.Text = playerName;
            chessBroad = new chessBroadManager(panelChessBroad, txbPlayerName, ptcMark);

            chessBroad.PlayerMarked += ChessBroad_PlayerMarked;
            chessBroad.EndedGame += ChessBroad_EndedGame;
            chessBroad.WonGame += ChessBroad_WonGame;

            pcbCoolDown.Step = constant.coolDownStep;
            pcbCoolDown.Maximum = constant.coolDownTime;
            pcbCoolDown.Value = 0;

            timerCoolDown.Interval = constant.coolDownInterver;
            chessBroad.DrawChessBroad();

            panelChessBroad.Enabled = false;


        }

        private void ChessBroad_WonGame(object sender, EventArgs e)
        {

            endGame(chessBroad.getCurrentPlayer() + " won ");
        }

        void endGame(string msg)
        {
            timerCoolDown.Stop();
            panelChessBroad.Enabled = false;
            MessageBox.Show(msg);
        }
        private void ChessBroad_EndedGame(object sender, EventArgs e)
        {
            endGame("Het co ");
        }

        private void ChessBroad_PlayerMarked(object sender, EventArgs e)
        {
            timerCoolDown.Start();
            pcbCoolDown.Value = 0;
        }

        private void panelChessBroad_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSendText_Click(object sender, EventArgs e)
        {

        }

        private void timerCoolDown_Tick(object sender, EventArgs e)
        {
            pcbCoolDown.PerformStep();
            if (pcbCoolDown.Value >= pcbCoolDown.Maximum)
            {

                endGame("het gio " + chessBroad.getCurrentPlayer() + " lost ");

            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
                txbIP.Text = sck.GetLocalIPv4(NetworkInterfaceType.Wireless80211);

                if (string.IsNullOrEmpty(txbIP.Text))
                {
                    txbIP.Text = sck.GetLocalIPv4(NetworkInterfaceType.Ethernet);
                }
            
        }

        private void btnLan_Click(object sender, EventArgs e)
        {
            sck.IP = txbIP.Text;
            if (!sck.ConnectServer()) {
                sck.CreateServer();
                MessageBox.Show("server");
                Thread listenThread = new Thread(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(500);
                        try
                        {
                            string data = (string)sck.ReceiveData();
                            chessBroad.SetPlayerName(txbPlayerName.Text , data);
                            sck.SendData(txbPlayerName.Text);
                            break;
                        }
                        catch
                        {

                        }
                    }
                });
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            else
            {
                MessageBox.Show("client");
                Thread listenThread = new Thread(() =>
                {
                    string data = (string)sck.ReceiveData();
                    chessBroad.SetPlayerName(data, txbPlayerName.Text);
                });
                listenThread.IsBackground = true;
                listenThread.Start();

                sck.SendData(txbPlayerName.Text);
            }
        }

        void Listen()
        {
            string data = (string)sck.ReceiveData();

            MessageBox.Show(data);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            
            
            chessBroad.DrawChessBroad();

            timerCoolDown.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure ? ", "confirm", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }
    }
}
