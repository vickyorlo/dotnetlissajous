using System;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace lissajou
{
    public partial class Form1 : Form
    {

        public double XAngleSpeed;
        public double YAngleSpeed;
        public double Time;
        public double AngleDifference;
        private double _x;
        private double _y;

        public Form1()
        {
            InitializeComponent();
            XAngleSpeed = 5;
            YAngleSpeed = 10;
            AngleDifference = Math.PI/4;
            DrawCurve();
        }

        private void DrawCurve()
        {
            lissajouChart.Series[0].Points.Clear();
            for (Time = 0; Time < 2*Math.PI; Time += 0.01)
            {
                _x = Math.Sin(XAngleSpeed*Time);
                _y = Math.Sin((YAngleSpeed*Time) + AngleDifference*(Math.PI/180));
                lissajouChart.Series[0].Points.AddXY(_x, _y);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            XAngleSpeed = trackBar1.Value;
            numericUpDown1.Text = trackBar1.Value.ToString();
            DrawCurve();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            YAngleSpeed = 11-trackBar2.Value;
            numericUpDown2.Text = (11-trackBar2.Value).ToString();
            DrawCurve();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            AngleDifference = trackBar3.Value;
            numericUpDown3.Text = trackBar3.Value.ToString();
            DrawCurve();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            XAngleSpeed = (double)numericUpDown1.Value;
            trackBar1.Value = (int)numericUpDown1.Value;
            DrawCurve();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            YAngleSpeed = (double)numericUpDown2.Value;
            trackBar2.Value = 11-(int) numericUpDown2.Value;
            DrawCurve();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            AngleDifference = (double)numericUpDown3.Value;
            trackBar3.Value = (int)numericUpDown3.Value;
            DrawCurve();
        }
    }
}
