using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sleeper
{
    public partial class frmSleeper : Form
    {
        public frmSleeper()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTime.Visible = true;
            btnSleep.Visible = true; // hide buttons/labels
            btnCancel.Visible = false; // show new button & coundown label
            lblCountdown.Visible = false;

            timer1.Enabled = false;
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            txtTime.Visible = false;
            btnSleep.Visible = false; // hide buttons/labels
            btnCancel.Visible = true; // show new button & coundown label
            lblCountdown.Visible = true;

            lblCountdown.Text = txtTime.Text;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int timeLeft = Convert.ToInt32(lblCountdown.Text.ToString());
            timeLeft--;
            lblCountdown.Text = Convert.ToString(timeLeft);

            if (timeLeft == 0) // Sleep time.
            {
                timer1.Enabled = false;
                btnCancel.PerformClick();
                Application.SetSuspendState(PowerState.Suspend, false, false);
            }


        }
    }
}
