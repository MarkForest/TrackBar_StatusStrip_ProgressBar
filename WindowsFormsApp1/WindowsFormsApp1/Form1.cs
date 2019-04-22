using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Color> colors = null;
        public Form1()
        {
            InitializeComponent();
            InitialNumeric();
            InitialPictureBox();
            InitialToolTips();
            InitialTrackBar();

        }

        private void InitialTrackBar()
        {
            colors = new List<Color> {
                Color.Red, Color.Blue, Color.Coral, Color.Green, Color.Yellow, Color.Brown, Color.Gray, Color.Black, Color.Orange, Color.Pink
            };
            trackBar1.Minimum = 1;
            trackBar1.Maximum = colors.Count;
            trackBar1.ValueChanged += TrackBar1_ValueChanged;
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.BackColor = colors[trackBar1.Value-1];
            Console.WriteLine(trackBar1.Value);
        }

        private void InitialToolTips()
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(progressBar1, "Hi, This is best progressbar of world");
            tip.IsBalloon = true;
            tip.InitialDelay = 1;
            tip.AutoPopDelay = 5000;
            tip.ToolTipTitle = "Информация о элементе";     
            tip.ToolTipIcon = ToolTipIcon.Info;
        }

        private void InitialPictureBox()
        {
            pictureBox1.Image = Image.FromFile("1.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            
        }

        private void InitialNumeric()
        {
            numericUpDown1.Minimum = 16;
            numericUpDown1.Maximum = 80;
            numericUpDown1.Increment = 1;
            //numericUpDown1.DecimalPlaces = 1;
            numericUpDown1.ReadOnly = true;
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
           

        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(pictureBox1.Location.X + Int32.Parse(numericUpDown1.Value.ToString()), pictureBox1.Location.Y);
        }

        private void InitialProgressBar()
        {
            //Minimum, Maximum, Value, Step, PerfomeStep()
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            InitialProgressBar();
            for (int i = 0; i < progressBar1.Maximum; i++)
            {
                progressBar1.PerformStep();
                label1.Text = $"Value = {progressBar1.Value}";  
                Console.WriteLine(progressBar1.Value);
                if (progressBar1.Value % 10 == 0)
                {
                    //Console.Beep();
                    if(trackBar1.Value < trackBar1.Maximum)
                        trackBar1.Value += 1;
                    if (trackBar1.Value == 5)
                        Process.Start("https://www.youtube.com/watch?v=QkFBj3bGuCM");
                }
                Thread.Sleep(150);
                this.Update();
            }
        }
    }
}
