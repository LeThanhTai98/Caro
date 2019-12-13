using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        string playerName = null;
        string OtherPlayerName = null;
        private bool FirstPlay = false;
        bool ready = false;

        public Form1()
        {

            using (StreamWriter sw = new StreamWriter("E:\\test.txt", true))
            {
           

                
                sw.Flush();

                sw.Close();
            }

            Control.CheckForIllegalCrossThreadCalls = false;
          
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

            ChatBoard.Multiline = true;
            ChatBoard.ScrollBars = RichTextBoxScrollBars.Both;

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

            txbPlayerName.Enabled = true;
            btnChangeName.Enabled = true;

            if (!sck.isServer) this.statusBar.Text = "you are not ready";
            else this.statusBar.Text = "client is not ready";

            
            writeFile( msg);
            MessageBox.Show(msg);

            chessBroad.SetThisPlayer();

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
        void writeFile(string msg)
        {

            using (StreamWriter sw = new StreamWriter("E:\\test.txt", true))
            {
                sw.WriteLine("");

                DateTime now = DateTime.Now;

                sw.WriteLine("Time: " + now);

                sw.WriteLine("Participant: " + OtherPlayerName + " And " + txbPlayerName.Text);

                sw.WriteLine(msg);

               
                //sw.WriteLine(DateTime.Now.ToString() + Environment.NewLine);
                sw.Flush();

                sw.Close();
            }
            //String filepath = "E:\\test.txt";// đường dẫn của file muốn tạo

            //FileStream fs = new FileStream(filepath, FileMode.Create);//Tạo file mới tên là test.txt           

            //StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);//fs là 1 FileStream





            // Ghi và đóng file


        }

        void readFile()
        {
            //string[] lines = File.ReadAllLines(@"E:\test.txt");


            //foreach (string s in lines)
            //{
            //    textBox2.Text = s;

            //}
            string path = "E:\test.txt";

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str;
            //doc tat ca du lieu trong file luu vao str;
            str = sr.ReadToEnd();


            sr.Close();
            fs.Close();


        }
        private void panelChessBroad_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSendText_Click(object sender, EventArgs e)
        {
           if (sck != null && sck.HasClient())
            {
                sck.SendData(new SocketData((int)SocketCommand.CHAT, this.txtChat.Text, null));
                this.ChatBoard.Text += "\n" + this.playerName + " : " + this.txtChat.Text;
                this.txtChat.Clear();

            }
        }

        private void timerCoolDown_Tick(object sender, EventArgs e)
        {
            pcbCoolDown.PerformStep();
            if (pcbCoolDown.Value >= pcbCoolDown.Maximum)
            {
                string playName = null;
                if (this.playerName == chessBroad.getCurrentPlayer()) playName = this.OtherPlayerName;
                else playName = this.playerName;
                endGame("time out " + playName + " won");

                
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
                btnLan.Enabled = false;
                btnDiconnect.Enabled = true;
                if (!sck.ConnectServer())
                {
                    bool kq = true;
                    sck.CreateServer(out kq);

                    if (kq == true)
                    {
                        if (!otherPlayQuit) this.statusBar.Text = "you are server";
                        else this.statusBar.Text = "other player is quit ";
                        this.FirstPlay = true;
                        otherPlayQuit = false;


                        Thread listenThread = new Thread(() =>
                        {
                            while (true)
                            {

                                try
                                {
                                    SocketData data = (SocketData)sck.ReceiveData();
                                    ProcessData(data);

                                    if (btnServerFirst.Checked) {
                                        sck.SendData(new SocketData((int)SocketCommand.FIRSTPLAY, "1", null));

                                        this.FirstPlay = true;
                                    }
                                    else
                                    {
                                        sck.SendData(new SocketData((int)SocketCommand.FIRSTPLAY, "2", null));

                                        this.FirstPlay = false;
                                    }
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
                        panelChessBroad.Enabled = true;
                        chessBroad.OtherPlayerAction((Point)data.Point);
                       
                        pcbCoolDown.Value = 0;
                        timerCoolDown.Start();
                    }
                    break;
                case (int)SocketCommand.PLAYER_NAME:
                    {

                        if (data.Message != this.OtherPlayerName)
                        {
                            if (sck.isServer && OtherPlayerName == null) this.statusBar.Text = "client is connected";
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
                        if (data.Message == "2") {  this.btnClientFirst.Checked = true; }
                        else if (data.Message == "1") {  this.btnServerFirst.Checked = true; }
                    }
                    break;
                case (int)SocketCommand.QUIT:
                    {

                        this.otherPlayQuit = true;
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
                case (int)SocketCommand.CHAT:
                    {
                        this.Invoke(new chat(UpdateChat), new object[] { data.Message });
                    }
                    break;
           

                default:

                    break;
            }
            Listen();
        }

        private void UpdateChat(string s)
        {
            this.ChatBoard.Text += "\n" + this.OtherPlayerName + " : " + s;
        }

        bool otherPlayQuit = false;
        // for client 
        private void ResetChessBroad()
        {
            ReDrawChessBroad();

            if (sck.isServer)
            {
                Connect();
            }
            else
            {
                this.statusBar.Text = "server is closed";
                btnLan.Enabled = true;
                btnDiconnect.Enabled = false;
                sck.Close();
            }

        }
      
        private void ReDrawChessBroad()
        {
            pcbCoolDown.Value = 0;
            OtherPlayerName = null;
            timerCoolDown.Interval = constant.coolDownInterver;
            timerCoolDown.Stop();
            chessBroad.DrawChessBroad();

            panelChessBroad.Enabled = false;
            btnUnPause.Visible = false;
            btnPause.Enabled = false;
            btnClientFirst.Enabled = true;
            btnServerFirst.Enabled = true;


            btnReady.Visible = false;

            txbPlayerName.Enabled = true;
            btnChangeName.Enabled = true;
        }

        // for server
        private void ResetChessBroadAndDisconnect()
        {
            ReDrawChessBroad();

            sck.Close();

            otherPlayQuit = false;
            btnLan.Enabled = true;
            btnDiconnect.Enabled = false;
            this.statusBar.Text = "you are disconnected";
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


        delegate void chat(string s);
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
                this.txbPlayerName.Enabled = false;
                this.btnChangeName.Enabled = false;
                if (this.FirstPlay) panelChessBroad.Enabled = true;
                else { panelChessBroad.Enabled = false; chessBroad.SwapCurrentColor(); chessBroad.changeCurrentPlayer(); }
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

   // quit
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
            this.playerName = txbPlayerName.Text;
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
                if (sck.isServer)
                {
                    sck.SendData(new SocketData((int)SocketCommand.FIRSTPLAY, "2", null));

                    this.FirstPlay = false;
                }
                else this.FirstPlay = true;
            }
        }

        private void btnServerFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (btnServerFirst.Checked && sck != null)
            {
                if (sck.isServer)
                {
                    sck.SendData(new SocketData((int)SocketCommand.FIRSTPLAY, "1", null));

                    this.FirstPlay = true;
                }
                else this.FirstPlay = false;
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

        }
        public delegate void delPassData(TextBox text);
       

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            delPassData del = new delPassData(frm.funData);

            frm.Show();
        }
    }
}
