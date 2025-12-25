using System;
using System.Drawing;
using System.Windows.Forms;

namespace InpatientManagerSystem.UI
{
    public partial class FormWelcomePanel : Form
    {
        private Timer timer;

        public FormWelcomePanel()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            // Create and configure timer
            timer = new Timer();
            timer.Interval = 1000; // Update every 1 second
            timer.Tick += Timer_Tick;
            timer.Start();

            // Set initial time
            UpdateTime();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            // Update time label with current date and time
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void lblTime_Click(object sender, EventArgs e)
        {
            // Optional: Click to refresh time immediately
            UpdateTime();
        }
    }
}
