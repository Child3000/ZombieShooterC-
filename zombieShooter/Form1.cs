using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zombieShooter
{
    public partial class Form1 : Form
    {
        #region Variable Declaration
        bool goUp,
            goDown,
            goLeft,
            goRight;

        string facing = "up";
        double playerHealth = 100;
        int speed = 10;
        int amno = 10;
        int zombieSpeed = 3;
        int score = 0;
        bool gameOver = false;
        Random rnd = new Random();
        #endregion 

        public Form1()
        {
            InitializeComponent();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (gameOver)
                return;

            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
                facing = "left";
                player.Image = Properties.Resources.left;
            }

            if(e.KeyCode == Keys.Right)
            {
                goRight = true;
                facing = "right";
                player.Image = Properties.Resources.right;
            }

            if(e.KeyCode == Keys.Up)
            {
                goUp = true;
                facing = "up";
                player.Image = Properties.Resources.up;
            }

            if(e.KeyCode == Keys.Down)
            {
                goDown = true;
                facing = "down";
                player.Image = Properties.Resources.down;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (gameOver)
                return;

            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

            if(e.KeyCode == Keys.Space && amno > 0)
            {
                Shoot(facing);
                amno--;
                if (amno < 1)
                    DropAmno();
            }
        }

        private void gameEngine(object sender, EventArgs e)
        {
            // Display amno, kill and health

            lblAmno.Text = "Amno: " + amno;
            lblKill.Text = "Kills: " + score;

            if(playerHealth > 0)
                lblHealthBar.Value = Convert.ToInt32(playerHealth);
            else
            {
                gameTimer.Stop();
                gameOver = true;

                // Show player's dead image
                player.Image = Properties.Resources.dead;
            }

            // Control the color of HealthBar
            if(playerHealth <= 20.0)
            {
                lblHealthBar.ForeColor = Color.Red;
            }

            // Control movement : Left
            if(goLeft && player.Left > 0)
            {
                // Player moves left
                player.Left -= speed;
            }

            // Control movement : Right
            if(goRight && player.Left + player.Width < 930)
            {
                // Player moves right
                player.Left += speed;
            }

            // Control movement : Up
            if(goUp && player.Top > 50)
            {
                // Player moves up
                player.Top -= speed;
            }
            
            // Control movement : Down
            if(goDown && player.Top + player.Height < 690)
            {
                // Player moves down
                player.Top += speed;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if (x.Tag == "amno" &&
                       ((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                    {
                        this.Controls.Remove((PictureBox)x);
                        ((PictureBox)x).Dispose();
                        amno += 5;
                    }

                    if (x.Tag == "bullet")
                    {
                        // If bullet exceeds playground environment
                        // Destroy them
                        if (((PictureBox)x).Left < 1 || ((PictureBox)x).Left > 930 ||
                            ((PictureBox)x).Top < 10 || ((PictureBox)x).Top > 700)
                        {
                            this.Controls.Remove((PictureBox)x);
                            ((PictureBox)x).Dispose();
                        }
                    }

                    if(x.Tag == "zombie")
                    {
                        if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                            playerHealth--;

                        if(((PictureBox)x).Left < player.Left)
                        {
                            ((PictureBox)x).Left += zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zright;
                        }

                        if (((PictureBox)x).Left > player.Left)
                        {
                            ((PictureBox)x).Left -= zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zleft;
                        }

                        if (((PictureBox)x).Top < player.Top)
                        {
                            ((PictureBox)x).Top += zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zdown;
                        }

                        if (((PictureBox)x).Top > player.Top)
                        {
                            ((PictureBox)x).Top -= zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zup;
                        }
                    }
                }

                foreach(Control j in this.Controls)
                {
                    if ((j is PictureBox && j.Tag == "bullet") &&
                        (x is PictureBox && x.Tag == "zombie"))
                    {
                        if(j.Bounds.IntersectsWith(x.Bounds))
                        {
                            // Destroy zombie
                            this.Controls.Remove(x);
                            x.Dispose();

                            // Destroy bullet
                            this.Controls.Remove(j);
                            j.Dispose();

                            // Add kills
                            score++;

                            // Make zombies
                            MakeZombie();
                        }
                    }
                }
            }


               // DropAmno();
        }

        // Supply Amno
        private void DropAmno()
        {
            PictureBox amno = new PictureBox();

            amno.Image = Properties.Resources.ammo_Image;
            amno.SizeMode = PictureBoxSizeMode.AutoSize;
            amno.Tag = "amno";

            amno.Left = rnd.Next(10, 890);
            amno.Top = rnd.Next(50, 600);

            this.Controls.Add(amno);
            amno.BringToFront();
            player.BringToFront();
        }

        // Shooting
        private void Shoot(string direct)
        {
            bullet shoot = new bullet();
            shoot.direction = direct;
            shoot.bulletLeft = player.Left + (player.Width / 2);
            shoot.bulletTop = player.Top + (player.Height / 2);
            shoot.mkBullet(this);
        }

        // Make Zombie
        private void MakeZombie()
        {
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown; // default image
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;

            // Setting position
            zombie.Left = rnd.Next(0, 900);
            zombie.Top = rnd.Next(0, 800);

            this.Controls.Add(zombie);
            player.BringToFront();
        }
    }
}
