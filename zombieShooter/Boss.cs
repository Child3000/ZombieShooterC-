using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace zombieShooter
{
    class Boss
    {
        WindowsMediaPlayer deathSound = new WindowsMediaPlayer();
        Timer tmDeath = new Timer();

        private const int MAX_HEALTH = 20;
        private const int MIN_HEALTH = 0;

        private int health;
        private int speed;

        public PictureBox boss;
        public FireBall fireBall;
        public ProgressBar healthBar;

        private bool moveLeft = true;
        
        public Boss(Form form, PictureBox target)
        {
            tmDeath.Interval = 600;
            tmDeath.Tick += new EventHandler(tmDeath_Tick);
            health = MAX_HEALTH;
            speed = 2;

            boss = new PictureBox();
            boss.Image = Properties.Resources.normalboss;
            boss.SizeMode = PictureBoxSizeMode.Zoom;
            boss.Size = new System.Drawing.Size(100, 100);
            boss.Tag = "boss";

            int midPosition = form.Width / 2;

            #region Boss's Respawn Place

            if (target.Left < form.Left + midPosition)
            {
                boss.Left = form.Left + form.Width;
                boss.Tag = "rightboss";
            }
            else
            {
                boss.Left = form.Left;
                boss.Tag = "leftboss";
            }

            boss.Top = form.Top + form.Height / 2;

            #endregion


            #region Setting Up HealthBar

            healthBar = new ProgressBar();
            healthBar.Maximum = MAX_HEALTH;
            healthBar.Minimum = MIN_HEALTH;
            healthBar.Tag = "bosshealthbar";
            healthBar.ForeColor = System.Drawing.Color.DarkBlue;


            #endregion

            form.Controls.Add(boss);
            form.Controls.Add(healthBar);
            healthBar.BringToFront();
        }

        public void Move(PictureBox target)
        {
            HealthBarMove(boss);
            if(boss.Top <= target.Top)
            {
                boss.Top += speed;
            }
            else if (boss.Top > target.Top)
            {
                boss.Top -= speed;
            }

        }

        public void HealthBarMove (PictureBox boss)
        {
            healthBar.Left = boss.Left;
            healthBar.Top = boss.Top - boss.Height / 3;

            
        }

        public void SetFireExplosion(Form form, PictureBox target)
        {
            TimeBomer bomb = new TimeBomer(form);
        }

        public void SetHorizontalFireBall(Form form)
        {
            boss.Left = form.Left + form.Width / 2;
            boss.Top = form.Top + form.Height / 2;
            FireBall.onceImage = true;
            fireBall = new FireBall(form, boss);
        }

        public void Damaged(int value)
        {
            Health -= value;

            if(Health < 1)
            {
                boss.Image = Properties.Resources.blackboss;
                deathSound.URL = "D:/Users/Desktop/zombieAsset/mpbossdie.mp3";
                deathSound.controls.play();
                tmDeath.Start();
            }
        }

        private void tmDeath_Tick(object sender, EventArgs e)
        {
            healthBar.Dispose();
            boss.Dispose();
        }

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }

        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (value > 0)
                {
                    speed = value;
                }
            }
        }
    }
}
