namespace zombieShooter
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblAmno = new System.Windows.Forms.Label();
            this.lblKill = new System.Windows.Forms.Label();
            this.lblHealth = new System.Windows.Forms.Label();
            this.lblHealthBar = new System.Windows.Forms.ProgressBar();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblContinueButton = new System.Windows.Forms.Button();
            this.lblExitButton = new System.Windows.Forms.Button();
            this.lblPauseButton = new System.Windows.Forms.Button();
            this.lblPlayPicture = new System.Windows.Forms.PictureBox();
            this.lblExitPicture = new System.Windows.Forms.PictureBox();
            this.lblPauseBorder = new System.Windows.Forms.PictureBox();
            this.lblGameOver = new System.Windows.Forms.PictureBox();
            this.lblTrap3 = new System.Windows.Forms.PictureBox();
            this.lblTrap2 = new System.Windows.Forms.PictureBox();
            this.lblTrap1 = new System.Windows.Forms.PictureBox();
            this.hehe = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlayPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExitPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPauseBorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGameOver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTrap3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTrap2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTrap1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hehe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAmno
            // 
            this.lblAmno.AutoSize = true;
            this.lblAmno.Font = new System.Drawing.Font("Museo Sans For Dell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmno.Location = new System.Drawing.Point(13, 13);
            this.lblAmno.Name = "lblAmno";
            this.lblAmno.Size = new System.Drawing.Size(127, 33);
            this.lblAmno.TabIndex = 0;
            this.lblAmno.Text = "Amno: 0";
            // 
            // lblKill
            // 
            this.lblKill.AutoSize = true;
            this.lblKill.Font = new System.Drawing.Font("Museo Sans For Dell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKill.Location = new System.Drawing.Point(191, 13);
            this.lblKill.Name = "lblKill";
            this.lblKill.Size = new System.Drawing.Size(102, 33);
            this.lblKill.TabIndex = 1;
            this.lblKill.Text = "Kills: 0";
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.Font = new System.Drawing.Font("Museo Sans For Dell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHealth.Location = new System.Drawing.Point(591, 13);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(118, 33);
            this.lblHealth.TabIndex = 2;
            this.lblHealth.Text = "Health: ";
            // 
            // lblHealthBar
            // 
            this.lblHealthBar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblHealthBar.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblHealthBar.Location = new System.Drawing.Point(715, 16);
            this.lblHealthBar.Name = "lblHealthBar";
            this.lblHealthBar.Size = new System.Drawing.Size(192, 30);
            this.lblHealthBar.TabIndex = 3;
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameEngine);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Museo Sans For Dell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(342, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 33);
            this.label1.TabIndex = 10;
            this.label1.Text = "Trap: ";
            // 
            // lblContinueButton
            // 
            this.lblContinueButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblContinueButton.Font = new System.Drawing.Font("Helvetica", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContinueButton.ForeColor = System.Drawing.Color.White;
            this.lblContinueButton.Location = new System.Drawing.Point(816, 414);
            this.lblContinueButton.Name = "lblContinueButton";
            this.lblContinueButton.Size = new System.Drawing.Size(268, 78);
            this.lblContinueButton.TabIndex = 19;
            this.lblContinueButton.Text = "Continue?";
            this.lblContinueButton.UseVisualStyleBackColor = false;
            this.lblContinueButton.Visible = false;
            this.lblContinueButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.isContinueKeyClicked);
            // 
            // lblExitButton
            // 
            this.lblExitButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblExitButton.Font = new System.Drawing.Font("Helvetica", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExitButton.ForeColor = System.Drawing.SystemColors.Control;
            this.lblExitButton.Location = new System.Drawing.Point(816, 517);
            this.lblExitButton.Name = "lblExitButton";
            this.lblExitButton.Size = new System.Drawing.Size(268, 78);
            this.lblExitButton.TabIndex = 20;
            this.lblExitButton.Text = "Exit Game";
            this.lblExitButton.UseVisualStyleBackColor = false;
            this.lblExitButton.Visible = false;
            this.lblExitButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.isExitButtonClicked);
            // 
            // lblPauseButton
            // 
            this.lblPauseButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPauseButton.Font = new System.Drawing.Font("Russo One", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPauseButton.ForeColor = System.Drawing.Color.White;
            this.lblPauseButton.Location = new System.Drawing.Point(715, 306);
            this.lblPauseButton.Name = "lblPauseButton";
            this.lblPauseButton.Size = new System.Drawing.Size(424, 78);
            this.lblPauseButton.TabIndex = 21;
            this.lblPauseButton.Text = "Pause";
            this.lblPauseButton.UseVisualStyleBackColor = false;
            this.lblPauseButton.Visible = false;
            // 
            // lblPlayPicture
            // 
            this.lblPlayPicture.BackColor = System.Drawing.Color.White;
            this.lblPlayPicture.Image = ((System.Drawing.Image)(resources.GetObject("lblPlayPicture.Image")));
            this.lblPlayPicture.Location = new System.Drawing.Point(680, 414);
            this.lblPlayPicture.Name = "lblPlayPicture";
            this.lblPlayPicture.Size = new System.Drawing.Size(130, 78);
            this.lblPlayPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lblPlayPicture.TabIndex = 23;
            this.lblPlayPicture.TabStop = false;
            this.lblPlayPicture.Visible = false;
            // 
            // lblExitPicture
            // 
            this.lblExitPicture.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblExitPicture.Image = global::zombieShooter.Properties.Resources.exit;
            this.lblExitPicture.Location = new System.Drawing.Point(680, 517);
            this.lblExitPicture.Name = "lblExitPicture";
            this.lblExitPicture.Size = new System.Drawing.Size(130, 78);
            this.lblExitPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lblExitPicture.TabIndex = 22;
            this.lblExitPicture.TabStop = false;
            this.lblExitPicture.Visible = false;
            // 
            // lblPauseBorder
            // 
            this.lblPauseBorder.BackColor = System.Drawing.Color.Black;
            this.lblPauseBorder.Location = new System.Drawing.Point(544, 282);
            this.lblPauseBorder.Name = "lblPauseBorder";
            this.lblPauseBorder.Size = new System.Drawing.Size(772, 370);
            this.lblPauseBorder.TabIndex = 18;
            this.lblPauseBorder.TabStop = false;
            this.lblPauseBorder.Visible = false;
            // 
            // lblGameOver
            // 
            this.lblGameOver.Image = global::zombieShooter.Properties.Resources.gameover;
            this.lblGameOver.Location = new System.Drawing.Point(-5, -125);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(2080, 1300);
            this.lblGameOver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lblGameOver.TabIndex = 14;
            this.lblGameOver.TabStop = false;
            this.lblGameOver.Visible = false;
            // 
            // lblTrap3
            // 
            this.lblTrap3.Image = global::zombieShooter.Properties.Resources.trap;
            this.lblTrap3.Location = new System.Drawing.Point(527, 12);
            this.lblTrap3.Name = "lblTrap3";
            this.lblTrap3.Size = new System.Drawing.Size(33, 33);
            this.lblTrap3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lblTrap3.TabIndex = 13;
            this.lblTrap3.TabStop = false;
            // 
            // lblTrap2
            // 
            this.lblTrap2.Image = global::zombieShooter.Properties.Resources.trap;
            this.lblTrap2.Location = new System.Drawing.Point(473, 12);
            this.lblTrap2.Name = "lblTrap2";
            this.lblTrap2.Size = new System.Drawing.Size(33, 33);
            this.lblTrap2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lblTrap2.TabIndex = 12;
            this.lblTrap2.TabStop = false;
            // 
            // lblTrap1
            // 
            this.lblTrap1.Image = global::zombieShooter.Properties.Resources.trap;
            this.lblTrap1.Location = new System.Drawing.Point(422, 12);
            this.lblTrap1.Name = "lblTrap1";
            this.lblTrap1.Size = new System.Drawing.Size(33, 33);
            this.lblTrap1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lblTrap1.TabIndex = 11;
            this.lblTrap1.TabStop = false;
            // 
            // hehe
            // 
            this.hehe.Image = ((System.Drawing.Image)(resources.GetObject("hehe.Image")));
            this.hehe.Location = new System.Drawing.Point(668, 306);
            this.hehe.Name = "hehe";
            this.hehe.Size = new System.Drawing.Size(100, 100);
            this.hehe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hehe.TabIndex = 8;
            this.hehe.TabStop = false;
            this.hehe.Visible = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::zombieShooter.Properties.Resources.zdown;
            this.pictureBox4.Location = new System.Drawing.Point(787, 107);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(71, 71);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Tag = "zombie";
            // 
            // player
            // 
            this.player.Image = global::zombieShooter.Properties.Resources.up;
            this.player.Location = new System.Drawing.Point(359, 262);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(71, 100);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 6;
            this.player.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::zombieShooter.Properties.Resources.zup;
            this.pictureBox2.Location = new System.Drawing.Point(368, 506);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(71, 71);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "zombie";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::zombieShooter.Properties.Resources.zdown;
            this.pictureBox1.Location = new System.Drawing.Point(19, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "zombie";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(916, 533);
            this.Controls.Add(this.lblPlayPicture);
            this.Controls.Add(this.lblExitPicture);
            this.Controls.Add(this.lblPauseButton);
            this.Controls.Add(this.lblExitButton);
            this.Controls.Add(this.lblContinueButton);
            this.Controls.Add(this.lblPauseBorder);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.lblTrap3);
            this.Controls.Add(this.lblTrap2);
            this.Controls.Add(this.lblTrap1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hehe);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.player);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblHealthBar);
            this.Controls.Add(this.lblHealth);
            this.Controls.Add(this.lblKill);
            this.Controls.Add(this.lblAmno);
            this.Name = "Form1";
            this.Text = "ZombieShooter";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.lblPlayPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExitPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPauseBorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGameOver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTrap3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTrap2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTrap1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hehe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAmno;
        private System.Windows.Forms.Label lblKill;
        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.ProgressBar lblHealthBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox hehe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox lblTrap1;
        private System.Windows.Forms.PictureBox lblTrap2;
        private System.Windows.Forms.PictureBox lblTrap3;
        private System.Windows.Forms.PictureBox lblGameOver;
        private System.Windows.Forms.PictureBox lblPauseBorder;
        private System.Windows.Forms.Button lblContinueButton;
        private System.Windows.Forms.Button lblExitButton;
        private System.Windows.Forms.Button lblPauseButton;
        private System.Windows.Forms.PictureBox lblExitPicture;
        private System.Windows.Forms.PictureBox lblPlayPicture;
    }
}

