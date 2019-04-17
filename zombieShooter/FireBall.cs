using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zombieShooter
{
    class FireBall
    {
        public PictureBox fireBall;
        Random rnd = new Random();
        Timer tmFireBall = new Timer();
        int speed;
        object bossTag;
        public static bool onceImage;

        public FireBall(Form form, PictureBox boss)
        {
            bossTag = boss.Tag;
            speed = 15;

            fireBall = new PictureBox();
            fireBall.SizeMode = PictureBoxSizeMode.StretchImage;
            fireBall.Tag = "fireball";

            fireBall.Left = boss.Left + boss.Width / 2;
            fireBall.Top = boss.Top + boss.Height / 2;

            form.Controls.Add(fireBall);
            fireBall.BringToFront();

            tmFireBall.Interval = 20;
            tmFireBall.Tick += new EventHandler(tmFireBall_Tick);
            tmFireBall.Start();
        }

        public void tmFireBall_Tick(object sender, EventArgs e)
        {
            if(bossTag == "leftboss")
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
        }

        public void MoveRight()
        {
            if(onceImage)
            {
                fireBall.Image = Properties.Resources.fireToRight;
                onceImage = false;
            }

            if (fireBall.Left < 800)
            {
                fireBall.Left += speed;
            }
            else
            {
                Destroy();
            }
        }

        public void MoveLeft()
        {
            if (onceImage)
            {
                fireBall.Image = Properties.Resources.fireToLeft;
                onceImage = false;
            }

            if(fireBall.Left > 0)
            {
                fireBall.Left -= speed;
            }
            else
            {
                Destroy();
            }
        }

        public void Destroy()
        {
            Form1.fireBallMove = false;
            Form1.runOnce = true;
            tmFireBall.Stop();
           //tmFireBall.Dispose();
            fireBall.Dispose();
        }
    }
}
