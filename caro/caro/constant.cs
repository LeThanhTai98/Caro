using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caro
{
   public static class  constant
    {
        public static int chess_WIDTH = 150;
        public static int chess_HEIGHT = 150;
        public static int chessBroad_WIDTH = 4;
        public static int chessBroad_HEIGHT = 3;
        //
        private static Button btn = new Button();
        public static Color chessOneColor = Color.Red;
        public static Color chessTwoColor = Color.Blue;
        /// 
        public static int coolDownStep = 100;
        public static int coolDownTime = 10000;
        public static int coolDownInterver = 100;


        public static Color getButtonColor()
        {
            return btn.BackColor;
        }
    }
}
