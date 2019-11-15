using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caro
{
    public class chessBroadManager
    {
        private Panel chessBroad;
        private List<player> listPlayer;
        private int currentPlayer = 0;
        private List<List<Button>> Matrix;


        public TextBox playerName { get; set; }

        public PictureBox mark { get; set; }

        private event EventHandler playerMarked;
        public event EventHandler PlayerMarked
        {
            add
            {
                playerMarked += value;
            }
            remove
            {
                playerMarked -= value;
            }
        }

        private event EventHandler endGame;
        public event EventHandler EndedGame
        {
            add
            {
                endGame += value;
            }
            remove
            {
                endGame -= value;
            }
        }
        private event EventHandler winGame;
        public event EventHandler WonGame
        {
            add
            {
                winGame += value;
            }
            remove
            {
                winGame -= value;
            }
        }
        //initialize
        public chessBroadManager(Panel chessBroad , TextBox playerName , PictureBox mark )
        {
            this.chessBroad = chessBroad;
            this.listPlayer = new List<player>()
            {//lam them : cho nguoi choi chon ten
                new player ( playerName.Text,1),
                new player ("player2",2)
            };
            this.playerName = playerName;
            this.mark = mark;
            currentPlayer = 0;
    
            setCurrentPlayer();
         
        }
        
        public void  DrawChessBroad()
        {
            chessBroad.Controls.Clear();
            Matrix = new List<List<Button>>();
            Button oldBtn = new Button() { Width = 0, Location = new Point(0, 0) };
            chessBroad.Enabled = true;
            for (int j = 0; j < constant.chessBroad_HEIGHT; j++)
            {
                Matrix.Add(new List<Button>());
                for (int i = 0; i < constant.chessBroad_WIDTH; i++)
                {
                    Button btn = new Button()
                    {
                        Width = constant.chess_WIDTH,
                        Height = constant.chess_HEIGHT,
                        Location = new Point(oldBtn.Location.X + oldBtn.Width, oldBtn.Location.Y),
                        Tag = j.ToString()
                    //   , BackgroundImageLayout = ImageLayout.Stretch
                    };
                    btn.Click += Btn_Click; 
                    chessBroad.Controls.Add(btn);
                    oldBtn = btn;

                    Matrix[j].Add(btn);
                }
                oldBtn.Location = new Point(0, oldBtn.Location.Y + constant.chess_HEIGHT);
                oldBtn.Width = 0;
                oldBtn.Height = 0;
            }
            
        }

        public void EndGame()
        {
          if (endGame != null)
            {
                endGame(this, new EventArgs());
            }                  
        }
        private bool isEndGame(Button btn)
        {

            return  isEndGameOutOffChess(btn);
        }

        public void WinGame()
        {
            if (winGame != null)
            {
                winGame(this, new EventArgs());
            }
        }
        private bool isWinGame(Button btn)
        {

            return isEndGameHorizontal(btn) || isEndGameVertical(btn) || isEndGamePrimary(btn) || isEndGamesub(btn) ;
        }

        private Point getChessPoint(Button btn)
        {
            

            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = Matrix[vertical].IndexOf(btn);

            Point point = new Point(horizontal,vertical);

            return point;
        }
        private bool isEndGameHorizontal(Button btn)
        {
            Point point = getChessPoint(btn);

            int countLeft = 0;
            int countRight = 0;


            for (int i = point.X; i >= 0; i--)
            {
                if (Matrix[point.Y][i].BackColor == btn.BackColor)
                {
                    countLeft++;
                }
                else break;
            }
            for (int i = point.X + 1; i <= constant.chessBroad_WIDTH; i++)
            {
                if (Matrix[point.Y][i].BackColor == btn.BackColor)
                {
                    countRight++;
                }
                else break;
            }

            return countLeft + countRight == 3;
        }
        private bool isEndGameVertical(Button btn)
        {

            Point point = getChessPoint(btn);

            int countTop = 0;
            int countBottom = 0;


            for (int i = point.Y; i >= 0; i--)
            {
                if (Matrix[i][point.X].BackColor == btn.BackColor)
                {
                    countTop++;
                }
                else break;
            }
            for (int i = point.Y + 1; i < constant.chessBroad_HEIGHT; i++)
            {
                if (Matrix[i][point.X].BackColor == btn.BackColor)
                {
                    countBottom++;
                }
                else break;
            }

            return countTop + countBottom == 3;
        }

        internal void SetPlayerName(string text, string data)
        {
            listPlayer[0].Name = text;
            listPlayer[1].Name = data;
        }

        private bool isEndGamePrimary(Button btn)
        {

            Point point = getChessPoint(btn);

            int countTop = 0;
            int countBottom = 0;


            for (int i = 0; i <= point.X; i++)
            {   if (point.X - i < 0 || point.Y - i < 0)
                    break;
                if (Matrix[point.Y - i][point.X - i].BackColor == btn.BackColor)
                {
                    countTop++;
                }
                else break;
            }
            for (int i = 1; i <= constant.chessBroad_WIDTH; i++)
            {
                if (point.X + i >= constant.chessBroad_HEIGHT  || point.Y + i >= constant.chessBroad_WIDTH - 1)
                    break;

                    if (Matrix[point.Y + i][point.X + i].BackColor == btn.BackColor)
                {
                    countBottom++;
                }
                else break;
            }

            return countTop + countBottom == 3;
        }
        private bool isEndGamesub(Button btn)
        {

            Point point = getChessPoint(btn);

            int countTop = 0;
            int countBottom = 0;


            for (int i = 0; i <= constant.chessBroad_HEIGHT; i++)
                        {
                if (point.X + i >= constant.chessBroad_HEIGHT || point.Y - i < 0)
                    break;
                if (Matrix[point.X + i][point.Y - i].BackColor == btn.BackColor)
                {
                    countTop++;
                }
                else break;
            }
            for (int i = 1; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y + i >= constant.chessBroad_WIDTH - 1 )
                    break;

                if (Matrix[point.X- i][point.Y + i].BackColor == btn.BackColor && point.Y - i != point.X && point.X + i != point.Y)
                {
                    countBottom++;
                }
                else break;
            }

            return countTop + countBottom == 3;
        }

        private bool isEndGameOutOffChess(Button btn)
        {
            for (int j = 0; j < constant.chessBroad_HEIGHT; j++)
                for (int i = 0; i < constant.chessBroad_WIDTH-1; i++)
                    if (Matrix[j][i].BackColor == constant.getButtonColor()) return false;
            return true;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.BackColor != constant.getButtonColor())
                return;
            // btn.BackgroundImage 
            changeChessColor(btn);

            if (playerMarked != null)
                playerMarked(this, new EventArgs());
            if (isWinGame(btn))
            {
                WinGame();
                return;
            }
            if (isEndGame(btn))
            {
                EndGame();
                return;
            }
            changeCurrentPlayer();
           
        }
        public string getCurrentPlayer()
        {
            return listPlayer[currentPlayer].Name;
        }
        private void changeChessColor(Button btn)
        {
            if (listPlayer[currentPlayer].color == 1) btn.BackColor = constant.chessOneColor;
            else btn.BackColor = constant.chessTwoColor;

        }

        private void changeCurrentPlayer()
        {
            
            if (currentPlayer == listPlayer.Count - 1) currentPlayer = 0;
            else currentPlayer++;

            setCurrentPlayer();

        }

        private void setCurrentPlayer()
        {
            playerName.Text = listPlayer[currentPlayer].Name;

            if (listPlayer[currentPlayer].color == 1) mark.BackColor = constant.chessOneColor;
            else mark.BackColor = constant.chessTwoColor;
        }

    }
}
