﻿namespace SnakeGame
{
    partial class GameWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pbCanvas = new PictureBox();
            gameTimer = new System.Windows.Forms.Timer(components);
            lblScoreText = new Label();
            lblScoreNumber = new Label();
            lblGameEndText = new Label();
            label1 = new Label();
            StartButton = new Button();
            UserSettingsButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pbCanvas).BeginInit();
            SuspendLayout();
            // 
            // pbCanvas
            // 
            pbCanvas.BackColor = Color.Black;
            pbCanvas.Location = new Point(13, 13);
            pbCanvas.Name = "pbCanvas";
            pbCanvas.Size = new Size(880, 560);
            pbCanvas.TabIndex = 0;
            pbCanvas.TabStop = false;
            pbCanvas.Paint += UpdateGraphics;
            // 
            // lblScoreText
            // 
            lblScoreText.AutoSize = true;
            lblScoreText.Font = new Font("Malgun Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblScoreText.Location = new Point(13, 588);
            lblScoreText.Name = "lblScoreText";
            lblScoreText.Size = new Size(66, 25);
            lblScoreText.TabIndex = 1;
            lblScoreText.Text = "Score:";
            // 
            // lblScoreNumber
            // 
            lblScoreNumber.AutoSize = true;
            lblScoreNumber.Font = new Font("Malgun Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblScoreNumber.ImageAlign = ContentAlignment.MiddleLeft;
            lblScoreNumber.Location = new Point(76, 589);
            lblScoreNumber.Name = "lblScoreNumber";
            lblScoreNumber.Size = new Size(23, 25);
            lblScoreNumber.TabIndex = 2;
            lblScoreNumber.Text = "0";
            // 
            // lblGameEndText
            // 
            lblGameEndText.AutoSize = true;
            lblGameEndText.BackColor = Color.Black;
            lblGameEndText.Font = new Font("Malgun Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblGameEndText.ForeColor = Color.Red;
            lblGameEndText.Location = new Point(360, 200);
            lblGameEndText.Name = "lblGameEndText";
            lblGameEndText.Size = new Size(150, 25);
            lblGameEndText.TabIndex = 3;
            lblGameEndText.Text = "Game End Text";
            lblGameEndText.TextAlign = ContentAlignment.MiddleCenter;
            lblGameEndText.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Malgun Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(552, 588);
            label1.Name = "label1";
            label1.Size = new Size(341, 25);
            label1.TabIndex = 4;
            label1.Text = "Eat RED food, avoid GOLD blockers!";
            // 
            // StartButton
            // 
            StartButton.Location = new Point(284, 591);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(75, 23);
            StartButton.TabIndex = 5;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += OnClick_StartButton;
            // 
            // UserSettingsButton
            // 
            UserSettingsButton.Location = new Point(411, 591);
            UserSettingsButton.Name = "UserSettingsButton";
            UserSettingsButton.Size = new Size(75, 23);
            UserSettingsButton.TabIndex = 6;
            UserSettingsButton.Text = "Settings";
            UserSettingsButton.UseVisualStyleBackColor = true;
            UserSettingsButton.Click += ShowUserSettings;
            UserSettingsButton.KeyDown += KeyIsDown;
            UserSettingsButton.KeyUp += KeyIsUp;
            // 
            // GameWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 627);
            Controls.Add(UserSettingsButton);
            Controls.Add(StartButton);
            Controls.Add(label1);
            Controls.Add(lblGameEndText);
            Controls.Add(lblScoreNumber);
            Controls.Add(lblScoreText);
            Controls.Add(pbCanvas);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "GameWindow";
            Text = "Snake";
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)pbCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbCanvas;
        private Label lblScoreText;
        private Label lblScoreNumber;
        private Label lblGameEndText;
        private Label label1;
        private Button StartButton;
        internal System.Windows.Forms.Timer gameTimer;
        internal Button UserSettingsButton;
    }
}