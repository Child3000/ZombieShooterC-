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
            this.lblAmno = new System.Windows.Forms.Label();
            this.lblKill = new System.Windows.Forms.Label();
            this.lblHealth = new System.Windows.Forms.Label();
            this.lblHealthBar = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
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
            this.lblKill.Location = new System.Drawing.Point(298, 13);
            this.lblKill.Name = "lblKill";
            this.lblKill.Size = new System.Drawing.Size(102, 33);
            this.lblKill.TabIndex = 1;
            this.lblKill.Text = "Kills: 0";
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.Font = new System.Drawing.Font("Museo Sans For Dell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHealth.Location = new System.Drawing.Point(537, 13);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(118, 33);
            this.lblHealth.TabIndex = 2;
            this.lblHealth.Text = "Health: ";
            // 
            // lblHealthBar
            // 
            this.lblHealthBar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblHealthBar.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblHealthBar.Location = new System.Drawing.Point(684, 16);
            this.lblHealthBar.Name = "lblHealthBar";
            this.lblHealthBar.Size = new System.Drawing.Size(192, 30);
            this.lblHealthBar.TabIndex = 3;
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
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameEngine);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(919, 658);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
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
    }
}

