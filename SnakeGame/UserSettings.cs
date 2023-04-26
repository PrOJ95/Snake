using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SnakeGame
{
    public partial class UserSettings : Form
    {
        public UserSettings()
        {
            InitializeComponent();
        }
        private void LoadSettings(object sender, EventArgs e)
        {
            chkboxSpeedUpToggle.Checked = Properties.Settings.Default.SpeedCheckboxState;
            chkboxBlockerToggle.Checked = Properties.Settings.Default.BlockerCheckboxState;
        }

        private void SaveSettings(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SpeedCheckboxState = chkboxSpeedUpToggle.Checked;
            Properties.Settings.Default.BlockerCheckboxState = chkboxBlockerToggle.Checked;
            Properties.Settings.Default.Save();
        }

        private void On_SaveButtonClick(object sender, EventArgs e)
        {
            GameWindow.blockersActive = chkboxBlockerToggle.Checked;
            GameWindow.speedUpActive = chkboxSpeedUpToggle.Checked;
            Close();
        }
    }
}