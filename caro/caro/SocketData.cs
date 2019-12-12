using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caro
{  [Serializable]
    public class SocketData
    {
        public int Command { get; set; }
        public Point? Point { get; set; }
        public string Message { get; set; }


        public  SocketData(int command ,string message, Point? point)
        {
            this.Command = command;
            this.Point = point;
            this.Message = message;
        }


    }
    public enum SocketCommand
    {
        SEND_POINT ,
        NEW_GAME ,
        PAUSE_GAME ,
        UNPAUSE_GAME,
        QUIT,
        NOTIFY,
        PLAYER_NAME,
        READY,
        FIRSTPLAY,
        CHAT,
        TIMEOUT
    }
}
