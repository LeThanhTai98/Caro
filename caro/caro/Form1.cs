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
        string OtherPlayerName = null;
        private bool FirstPlay = false;
        bool ready = false;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
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
            if (!sck.isServer) this.statusBar.Text = "you are not ready";
            else this.statusBar.Text = "client is not ready";
        }
        private void ChessBroad_EndedGame(object sender, EventArgs e)
        {
            endGame("Out of chess ");
        }

        private void ChessBroad_PlayerMarked(object sender, ButtonClickEvent e)
        {
            sck.SendData(new SocketData((int)SocketCommand.SEND_POINT, null, e.ClickPoint));
            panelChessBroad.Enabled = false;
            pcbCoolDown.Value = 0;
            timerCoolDown.Start();
           
            Listen();
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
                this.statusBar.Text = "you are server";

                this.FirstPlay = true;

                Thread listenThread = new Thread(() =>
                {
                    while (true)
                    {

                        try
                        {
                            SocketData data = (SocketData)sck.ReceiveData();
                            ProcessData(data);
                            
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
                btnStartGame.Visible = false;
                btnReady.Visible = true;
                this.statusBar.Text = "you are client";
                Listen();
                this.FirstPlay = false;
                sck.SendData(new SocketData((int)SocketCommand.PLAYER_NAME, txbPlayerName.Text, null));
            }
        }

        void Listen()
        {

            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)sck.ReceiveData();
                    ProcessData(data);
                }
                catch (Exception ex)
                {
                    var a = ex;
                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();

        }


        private void ProcessData(SocketData data) {
            switch (data.Command)
            {
                case (int)SocketCommand.NOTIFY:
                    {
                        MessageBox.Show(data.Message);
                    }
                    break;
                case (int)SocketCommand.SEND_POINT:
                    {
                        chessBroad.OtherPlayerAction((Point)data.Point);
                        panelChessBroad.Enabled = true;
                        pcbCoolDown.Value = 0;
                        timerCoolDown.Start();
                    }
                    break;
                case (int)SocketCommand.PLAYER_NAME:
                    {
                        if (data.Message != this.OtherPlayerName)
                        {
                            this.OtherPlayerName = data.Message;
                            chessBroad.SetPlayerName(txbPlayerName.Text, this.OtherPlayerName);
                            sck.SendData(new SocketData((int)SocketCommand.PLAYER_NAME, txbPlayerName.Text, null));
                        }
                    }

                    break;
                case (int)SocketCommand.NEW_GAME:
                    {
                        this.Invoke(new control(StartGame));
                    }
                    break;
                case (int)SocketCommand.READY:
                    {
                        this.ready = !this.ready;
                        this.statusBar.Text = "client is ready";
                    }
                    break;
                default:
                    break;
            }
            Listen();
        }
        delegate void control();
        

        private void button1_Click(object sender, EventArgs e)
        {

            sck.SendData(new SocketData((int)SocketCommand.NEW_GAME, null, null));
            StartGame();
        }

        private void StartGame()
        {   if (ready)
            {
                chessBroad.DrawChessBroad();
                chessBroad.ResetCurrentPlayer();
                if (this.FirstPlay) panelChessBroad.Enabled = true;
                else { panelChessBroad.Enabled = false; chessBroad.changeCurrentColor(); chessBroad.changeCurrentPlayer(); }
                pcbCoolDown.Value = 0;
                timerCoolDown.Start();
                this.ready = false;
            }
            else
            {
                if (sck.isServer)
                {
                    statusBar.Text = "client is not ready";
                }
                else
                {
                    statusBar.Text = "Server ask for starting game";
                }
            }
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

        private void btnChangeName_Click(object sender, EventArgs e)
        {
            sck.SendData(new SocketData((int)SocketCommand.PLAYER_NAME, txbPlayerName.Text, null));
            chessBroad.SetPlayerName(txbPlayerName.Text, this.OtherPlayerName);
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            sck.SendData(new SocketData((int)SocketCommand.READY, null, null));
            ready = !ready;
            if (ready) statusBar.Text = "you are ready";
            else statusBar.Text = "you are not ready";
        }
    }
}
