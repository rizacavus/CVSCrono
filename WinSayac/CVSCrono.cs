using CVSCronoPro;
using System.Windows.Forms;

namespace WinSayac
{
    public partial class CVSCrono : Form
    {

        private TimeSpan usedTime;

        public DateTime StartTime { get; set; }

        public TimeSpan UsedTime
        {
            get => usedTime;
            set
            {
                usedTime = value;
                lblD.Text = usedTime.Days.ToString("00");
                lblH.Text = usedTime.Hours.ToString("00");
                lblM.Text = usedTime.Minutes.ToString("00");
                lblS.Text = usedTime.Seconds.ToString("00");
                Properties.Settings.Default.LastUsedTime = usedTime;
                Properties.Settings.Default.Save();
            }
        }

        public DateTime EndTime { get; set; }

        public CVSCrono()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartTime = DateTime.Now;
            tmr.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.LastUsedTime != (TimeSpan.Parse("00:00:00")))
            {
                UsedTime = Properties.Settings.Default.LastUsedTime;
            }
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tmr.Stop();
            UsedTime = TimeSpan.Parse("00:00:00");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            UsedTime = UsedTime.Add(TimeSpan.FromMilliseconds(tmr.Interval));
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            tmr.Stop();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            tmr.Stop();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            var f = new frmSetTime(UsedTime);
            f.Top -= this.Height;
            f.ShowDialog();
            if (f.IsOk)
                UsedTime = f.myTimeSpan;
        }

        private void CVSCrono_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false;
        }

        private void CVSCrono_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }
    }
}