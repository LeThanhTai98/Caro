using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caro
{
    public class player
    {
        public string Name { get; set; }

        public int color { get; set; }

        public Image Mark { get; set; }

        public player(string name , Image mark)
        {
            this.Name = name;
            this.Mark = mark;
        }
        public player(string name,int color)
        {
            this.Name = name;
            this.color = color;
        }
    }
}
