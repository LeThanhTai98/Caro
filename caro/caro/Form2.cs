using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caro
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBox1.Multiline = true;
            textBox1.ScrollBars = ScrollBars.Both;
        }

        
        public void funData(TextBox txtForm1)
        {
            textBox1.Text = txtForm1.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string path = "E:\\test.txt";
            //duong dan toi file sinh vien tren o cung cua ban;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str;
            //doc tat ca du lieu trong file luu vao str;
            str = sr.ReadToEnd();
            //set text cua textbox1 = str;
            textBox1.Text = str;
            sr.Close();
            fs.Close();
        }
    }
}
