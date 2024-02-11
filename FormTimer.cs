using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Timer
{

    public partial class FormTimer : Form
    {
        string text = "0";
        long tick = 0;
        long delta = 0;

        string type = "sec";

        bool paused = false;

        public FormTimer()
        {
            InitializeComponent();
        }

        private void FormTimer_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.Opacity = 0.8;
            this.FormBorderStyle = FormBorderStyle.None;

            paused = Program.settings.paused;



            this.delta = Program.settings.delta;
            this.tick = Program.settings.tick;

            this.type = Program.settings.type;

            if (this.paused)
            {
                this.pauseToolStripMenuItem.Text = "Resume";
            }
            else
            {
                this.pauseToolStripMenuItem.Text = "Pause";

                if (this.tick == 0)
                {
                    this.tick = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                }
            }

            this.Left = Program.settings.left;
            this.Top = Program.settings.top;

            this.Refresh();
        }

        private void FormTimer_Paint(object sender, PaintEventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {

            /* text*/
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            Font font = new Font("Courier", 64);

            long tick = (this.delta / 1000);

            if (this.paused)
            {
                tick = (this.delta) / 1000;
            }
            else
            {
                tick = (this.delta + (DateTimeOffset.Now.ToUnixTimeMilliseconds() - this.tick)) / 1000;
            }

            this.text = tick.ToString("00000");

            if (this.type == "minutes")
            {
                this.text = (tick / 60.0).ToString("00000.0");
            }

            if (this.type == "hours")
            {
                this.text = (tick / 60.0 / 60.0).ToString("00000.0");
            }

            if (this.type == "HH:MM:SS")
            {
                this.text = ((int)tick / 60 / 60).ToString("00") + ":" +
                ((int)tick / 60 % 60).ToString("00") + ":" +
                ((int)tick % 60).ToString("00");
            }

            if (this.type == "HH:MM")
            {
                this.text = ((int)tick / 60 / 60).ToString("00") + ":" +
                ((int)tick / 60 % 60).ToString("00");
            }

            if (this.type == "date")
            {
                this.text = DateTime.Now.ToString("yyyy-MM-dd");
            }

            if (this.type == "dayofweek")
            {
                this.text = DateTime.Now.DayOfWeek.ToString();
            }

            g.DrawString(this.text, font, Brushes.Gray, new PointF(5, 5));
            g.DrawString(this.text, font, Brushes.Black, new PointF(0, 0));

            SizeF textSize = g.MeasureString(text, font);

            /*windows size*/
            this.Width = (int)textSize.Width;
            this.Height = (int)textSize.Height;

            /*window shape*/
            RectangleF rectangle = new RectangleF(0, 0, textSize.Width, textSize.Height);
            int radius = 20;
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(rectangle.Location, sizeF);
            path.AddArc(arc, 180, 90);
            arc.X = rectangle.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rectangle.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rectangle.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            this.Region = new System.Drawing.Region(path);
        }

        private void timerTimer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void timerTimer_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTimer_Move(object sender, EventArgs e)
        {

        }

        private void FormTimer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.settings.paused = this.paused;
            Program.settings.type = this.type;
            Program.settings.delta = this.delta;
            Program.settings.tick = this.tick;
            Program.settings.left = this.Left;
            Program.settings.top = this.Top;
            Program.settings.width = this.Width;
            Program.settings.height = this.Height;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.delta = 0;
            this.tick = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.paused = !this.paused;

            if (this.paused)
            {
                this.pauseToolStripMenuItem.Text = "Resume";
                this.delta = this.delta + (DateTimeOffset.Now.ToUnixTimeMilliseconds() - this.tick);
                this.tick = 0;
            }
            else
            {
                this.pauseToolStripMenuItem.Text = "Pause";
                this.tick = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            }
        }

        private void secondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.type = "seconds";
        }

        private void minutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.type = "minutes";
        }

        private void hoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.type = "hours";
        }

        private void hHHHMMSSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.type = "HH:MM:SS";
        }

        private void hHMMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.type = "HH:MM";
        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.type = "date";
        }

        private void dayOfWeekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.type = "dayofweek";
        }
    }
}