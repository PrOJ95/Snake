namespace SnakeGame
{
    partial class UserSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            chkboxSpeedUpToggle = new CheckBox();
            chkboxBlockerToggle = new CheckBox();
            btnCloseSettings = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(451, 297);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // chkboxSpeedUpToggle
            // 
            chkboxSpeedUpToggle.AutoSize = true;
            chkboxSpeedUpToggle.Location = new Point(27, 43);
            chkboxSpeedUpToggle.Name = "chkboxSpeedUpToggle";
            chkboxSpeedUpToggle.Size = new Size(166, 19);
            chkboxSpeedUpToggle.TabIndex = 1;
            chkboxSpeedUpToggle.Text = "Speed up after eating food";
            chkboxSpeedUpToggle.UseVisualStyleBackColor = true;
            // 
            // chkboxBlockerToggle
            // 
            chkboxBlockerToggle.AutoSize = true;
            chkboxBlockerToggle.Location = new Point(27, 12);
            chkboxBlockerToggle.Name = "chkboxBlockerToggle";
            chkboxBlockerToggle.Size = new Size(164, 19);
            chkboxBlockerToggle.TabIndex = 2;
            chkboxBlockerToggle.Text = "Randomly spawn blockers";
            chkboxBlockerToggle.UseVisualStyleBackColor = true;
            // 
            // btnCloseSettings
            // 
            btnCloseSettings.Location = new Point(77, 76);
            btnCloseSettings.Name = "btnCloseSettings";
            btnCloseSettings.Size = new Size(75, 23);
            btnCloseSettings.TabIndex = 3;
            btnCloseSettings.Text = "Save";
            btnCloseSettings.UseVisualStyleBackColor = true;
            btnCloseSettings.Click += On_SaveButtonClick;
            // 
            // UserSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 111);
            Controls.Add(btnCloseSettings);
            Controls.Add(chkboxBlockerToggle);
            Controls.Add(chkboxSpeedUpToggle);
            Controls.Add(label1);
            Name = "UserSettings";
            Text = "Settings";
            this.FormClosing += this.SaveSettings;
            this.Load += this.LoadSettings;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CheckBox chkboxSpeedUpToggle;
        private CheckBox chkboxBlockerToggle;
        private Button btnCloseSettings;
    }
}