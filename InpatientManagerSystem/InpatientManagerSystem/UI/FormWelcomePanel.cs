using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

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

            // Set initial time and date
            UpdateTimeAndDate();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTimeAndDate();
        }

        private void UpdateTimeAndDate()
        {
            DateTime now = DateTime.Now;

            // Update time label - only show time
            lblTime.Text = now.ToString("HH:mm:ss");

            // Update date label - show day of week and date
            CultureInfo viCulture = new CultureInfo("vi-VN");
            string dayOfWeek = viCulture.DateTimeFormat.GetDayName(now.DayOfWeek);
            // Capitalize first letter
            dayOfWeek = char.ToUpper(dayOfWeek[0]) + dayOfWeek.Substring(1);

            lblDate.Text = $"{dayOfWeek}, {now:dd/MM/yyyy}";
        }

        private void lblTime_Click(object sender, EventArgs e)
        {
            // Optional: Click to refresh time immediately
            UpdateTimeAndDate();
        }

        private void lblDate_Click(object sender, EventArgs e)
        {
            // Optional: Click to refresh date immediately
            UpdateTimeAndDate();
        }
    }
}
