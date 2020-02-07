using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace RinseandRepeat
{
    public partial class Form1 : Form
    {
        public Stopwatch watch { get; set; }
        public Form1()
        {
            InitializeComponent();           
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            writeToPort(new Point(e.X, e.Y));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Port.Open();
            watch = Stopwatch.StartNew();
        }

        public void writeToPort(Point coordinates) 
        {
            if (watch.ElapsedMilliseconds > 15) 
            {
                watch = Stopwatch.StartNew();
                Port.Write(string.Format("X{0}Y{1}", 
                (180 - coordinates.X / (Size.Width / 180),
                (coordinates.Y / (Size.Height / 180)))));

            }
        }
    }
}
