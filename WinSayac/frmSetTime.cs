using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVSCronoPro
{
    public partial class frmSetTime : Form
    {
        public TimeSpan myTimeSpan { get; set; }
        public bool IsOk = false;

        public frmSetTime(TimeSpan myTimeSpan)
        {
            InitializeComponent();
            this.myTimeSpan = myTimeSpan;
            nD.Text = myTimeSpan.Days.ToString("00");
            nH.Text = myTimeSpan.Hours.ToString("00");
            nM.Text = myTimeSpan.Minutes.ToString("00");
            nS.Text = myTimeSpan.Seconds.ToString("00");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            myTimeSpan = TimeSpan.Parse("00:00:00");
            myTimeSpan = myTimeSpan.Add(TimeSpan.FromDays(Convert.ToDouble(nD.Value)));
            myTimeSpan = myTimeSpan.Add(TimeSpan.FromHours(Convert.ToDouble(nH.Value)));
            myTimeSpan = myTimeSpan.Add(TimeSpan.FromMinutes(Convert.ToDouble(nM.Value)));
            myTimeSpan = myTimeSpan.Add(TimeSpan.FromSeconds(Convert.ToDouble(nS.Value)));
            IsOk = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IsOk = false;
            this.Close();
        }
    }
}
