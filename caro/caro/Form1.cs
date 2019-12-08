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
        bool otherPlayer = false;
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
            btnReady.Visible = false;
            btnPause.Enabled = false;
        }

        private void ChessBroad_WonGame(object sender, EventArgs e)
        {

            endGame(chessBroad.getCurrentPlayer() + " won ");
        }

        void endGame(string msg)
        {
            timerCoolDown.Stop();
            panelChessBroad.Enabled = false;
            btnPause.Enabled = false;
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
            sck = null;
        }

        private void btnLan_Click(object sender, EventArgs e)
        {
            Connect();
            
        }

        private void Connect()
        {
            if (sck != null) sck.Close();
            sck = new SocketMangaer();
            sck.IP = txbIP.Text;
            sck.PORT = (int)txtPort.Value;
            this.statusBar.Text = "processing....";
            Thread thread = new Thread(() =>
            {
                if (!sck.ConnectServer())
                {
                    bool kq = true;
                    sck.CreateServer(out kq);
                    if (kq == true)
                    {
                        if (!otherPlayQuit) this.statusBar.Text = "you are server";
                        else this.statusBar.Text = "other player is quit , now you are server";
                        this.FirstPlay = true;

                        btnLan.Enabled = false;
                        btnDiconnect.Enabled = true;

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
                        this.statusBar.Text = "cant connect pls check your port";
                    }
                    

                }
                else
                {
                    this.Invoke(new control(clientUI));
                    Listen();

                    sck.SendData(new SocketData((int)SocketCommand.PLAYER_NAME, txbPlayerName.Text, null));
                }

            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void clientUI()
        {
            btnReady.Visible = true;

            btnServerFirst.Enabled = false;
            btnClientFirst.Enabled = false;
            this.statusBar.Text = "you are client";
            this.FirstPlay = false;
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


        private void ProcessData(SocketData data)
        {
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
                        this.otherPlayer = true;
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
                case (int)SocketCommand.FIRSTPLAY:
                    {
                        if (data.Message == "2") this.FirstPlay = true;
                        else if (data.Message == "1") this.FirstPlay = false;
                    }
                    break;
                case (int)SocketCommand.QUIT:
                    {
                        this.otherPlayer = false;
                        this.Invoke(new control(ResetChessBroad));

                    }
                    break;
                case (int)SocketCommand.PAUSE_GAME:
                    {
                        this.Invoke(new control(Pause));
                    }
                    break;
                case (int)SocketCommand.UNPAUSE_GAME:
                    {
                        this.Invoke(new control(UnPause));

                    }
                    break;

                default:

                    break;
            }
            Listen();
        }
        bool otherPlayQuit = false;
        private void ResetChessBroad()
        {
            pcbCoolDown.Value = 0;

            timerCoolDown.Interval = constant.coolDownInterver;
            chessBroad.DrawChessBroad();

            panelChessBroad.Enabled = false;
            btnUnPause.Visible = false;
            btnPause.Enabled = false;
            otherPlayQuit = true;
            Connect();


        }
        private void ResetChessBroadAndDisconnect()
        {
            pcbCoolDown.Value = 0;

            timerCoolDown.Interval = constant.coolDownInterver;
            chessBroad.DrawChessBroad();

            panelChessBroad.Enabled = false;
            btnUnPause.Visible = false;
            btnPause.Enabled = false;
            otherPlayQuit = true;

            sck.Close();

        }

        private void PauseSender()
        {
            this.panelChessBroad.Enabled = false;
            this.timerCoolDown.Stop();
            this.btnUnPause.Visible = true;
        }
        private void Pause()
        {
            PauseSender();
            this.btnUnPause.Enabled = false;
            this.timerEnablePause.Start();
        }

        private void UnPause()
        {
            if (this.OtherPlayerName != chessBroad.getCurrentPlayer()) this.panelChessBroad.Enabled = true;
            this.timerCoolDown.Start();
            this.btnUnPause.Visible = false;
        }

        delegate void control();


        private void button1_Click(object sender, EventArgs e)
        {
            if (sck != null)
            {
                sck.SendData(new SocketData((int)SocketCommand.NEW_GAME, null, null));
                StartGame();
            }
        }

        private void StartGame()
        {
            if (ready)
            {
                chessBroad.DrawChessBroad();
                chessBroad.ResetCurrentPlayer();
                if (this.FirstPlay) panelChessBroad.Enabled = true;
                else { panelChessBroad.Enabled = false; chessBroad.changeCurrentColor(); chessBroad.changeCurrentPlayer(); }
                pcbCoolDown.Value = 0;
                btnPause.Enabled = true;
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
            else
                try { sck.SendData(new SocketData((int)SocketCommand.QUIT, null, null)); }
                catch { };


        }

        private void btnChangeName_Click(object sender, EventArgs e)
        {
            if (sck != null)
            {
                sck.SendData(new SocketData((int)SocketCommand.PLAYER_NAME, txbPlayerName.Text, null));
            }
            chessBroad.SetPlayerName(txbPlayerName.Text, this.OtherPlayerName);
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            if (sck != null)
            {
                sck.SendData(new SocketData((int)SocketCommand.READY, null, null));
                ready = !ready;
                if (ready) statusBar.Text = "you are ready";
                else statusBar.Text = "you are not ready";
            }
        }

        private void btnClientFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (btnClientFirst.Checked && sck != null)
            {
                sck.SendData(new SocketData((int)SocketCommand.FIRSTPLAY, "2", null));
                this.FirstPlay = false;
            }
        }

        private void btnServerFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (btnServerFirst.Checked && sck != null)
            {
                sck.SendData(new SocketData((int)SocketCommand.FIRSTPLAY, "1", null));
                this.FirstPlay = true;
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (sck != null)
            {
                sck.SendData(new SocketData((int)SocketCommand.PAUSE_GAME, null, null));
                PauseSender();
            }
        }



        private void btnUnPause_Click(object sender, EventArgs e)
        {
            if (sck != null)
            {
                sck.SendData(new SocketData((int)SocketCommand.UNPAUSE_GAME, null, null));
                UnPause();
            }
        }

        int countPauseTime = 0;
        private void timerEnablePause_Tick(object sender, EventArgs e)
        {
            countPauseTime++;
            if (countPauseTime >= constant.pauseTime)
            {
                this.btnUnPause.Enabled = true;
                countPauseTime = 0;
                this.timerEnablePause.Stop();
            }
        }

        private void btnDiconnect_Click(object sender, EventArgs e)
        {
            sck.SendData(new SocketData((int)SocketCommand.QUIT, null, null));
            Thread thread = new Thread(() =>
            {
              this.Invoke(new control(ResetChessBroadAndDisconnect));
            });
            thread.IsBackground = true;
            thread.Start();
            btnLan.Enabled = true;
            btnDiconnect.Enabled = false;
            this.statusBar.Text = "you are disconnected";
        }
    }
}
