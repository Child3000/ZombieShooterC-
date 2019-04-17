using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using WMPLib;
using System.Media;

namespace zombieShooter
{
    public partial class Form1 : Form
    {
        #region Music Declaration

        WindowsMediaPlayer player1 = new WindowsMediaPlayer();
        WindowsMediaPlayer playerShoot = new WindowsMediaPlayer();
        WindowsMediaPlayer zombieDie = new WindowsMediaPlayer();
        WindowsMediaPlayer gameOverSound = new WindowsMediaPlayer();
        WindowsMediaPlayer noAmmoSound = new WindowsMediaPlayer();
        WindowsMediaPlayer putTrapSound = new WindowsMediaPlayer();
        WindowsMediaPlayer zombietrapped = new WindowsMediaPlayer();
        WindowsMediaPlayer pickUpAmmo = new WindowsMediaPlayer();
        WindowsMediaPlayer medicSound = new WindowsMediaPlayer();
        string url = "D:/Users/Desktop/zombieAsset/";

        SoundPlayer sound;
        SoundPlayer sound2;
        SoundPlayer sound3;

        #endregion

        #region Tick Declaration

        System.Windows.Forms.Timer tmHeal = new System.Windows.Forms.Timer();     // tmHeal will drop heal each 10s
        System.Windows.Forms.Timer tmAmno = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer tmMakeDecision = new System.Windows.Forms.Timer();
        System.Timers.Timer zMove;
        System.Timers.Timer tmShoot;
        System.Timers.Timer tmExplosion;

        #endregion

        #region Boss Declaration

        Boss boss;
        bool bossExplosion = false;
        bool bossFireBall = false;
        bool bossVisibleChange = false;
        public static bool fireBallMove = false;

        #endregion

        #region Variable Declaration

        bool goUp,
            goDown,
            goLeft,
            goRight,
            zombieMove = false,
            zombieMove2 = false,
            zombieMove3 = false;

        //int[] zombieHPMove = new int[2];
        bool isExistHPZombie = false;
        bool isNormalFace = false;
        bool isHPZombieMove = true;
        bool isSmileFace = true;
        bool isAngryFace = true;
        bool respawnBoss = true;
        bool isMedic = true;
        public static bool runOnce = true;

        string facing = "up";
        public static double playerHealth = 100;
        int speed = 10;
        int amno = 10, specialAmno = 0;
        int zombieSpeed = 3;                    // Normal zombie Speed
        int hpzombieSpeed = 1;                  // hpzombie Speed
        int speedzombieSpeed = 5;               // speed Zombie Speed
        int score = 0;
        int trapNum = 3;
        bool gameOver = false;

        int zombieBar_1 = 0;                    // HP zombie health
        int count = 0, count2 = 0, count3 = 0;
        int shootCount = 1;

        Random rnd = new Random();
        #endregion 

        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
            PlayBackgroundMusic();
            // Setting tmHeal
            tmHeal.Interval = 10000;    // 10s
            tmHeal.Tick += new EventHandler(tmHeal_Tick);
            tmHeal.Start();

            // Setting amno
            tmAmno.Interval = 10000;
            tmAmno.Tick += new EventHandler(tmAmno_Tick);
            tmAmno.Start();
            
            // Setting shoot
            tmShoot = new System.Timers.Timer(500);
            // tmShoot.Interval = 500;
            tmShoot.AutoReset = false;
            tmShoot.Elapsed += new ElapsedEventHandler(tmShoot_Tick);

            // Setting zombie movement
            zMove = new System.Timers.Timer(3000);
            // zMove.Interval = 3000;
            zMove.AutoReset = false;
            zMove.Elapsed += new ElapsedEventHandler(zMove_Tick);

            // Setting Boss Explosion cooldown
            tmExplosion = new System.Timers.Timer(2000);
            tmExplosion.AutoReset = false;
            tmExplosion.Elapsed += new ElapsedEventHandler(tmExplosion_Tick);

            // Setting Boss Decision
            tmMakeDecision.Interval = 2000;
            tmMakeDecision.Tick += new EventHandler(tmMakeDecision_Tick);
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (gameOver)
                return;

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goLeft = true;
                facing = "left";
                player.Image = Properties.Resources.left;
            }

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = true;
                facing = "right";
                player.Image = Properties.Resources.right;
            }

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                goUp = true;
                facing = "up";
                player.Image = Properties.Resources.up;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                goDown = true;
                facing = "down";
                player.Image = Properties.Resources.down;
            }

            if (e.KeyCode == Keys.Escape )
            {
                DisplayPauseMenu();
            }

            if (e.KeyCode == Keys.Space && shootCount == 1)
            {
                if (amno > 0)
                {
                    Shoot(facing);
                    playerShoot.URL = url + "wshoot.mp3";
                    if (amno < 1)
                    {
                        DropAmno();
                    }

                    shootCount = 0;
                    tmShoot.Start();
                }
                else
                {
                    noAmmoSound.URL = url + "noammo.mp3";
                    noAmmoSound.controls.play();
                }

            }

            if (e.KeyCode == Keys.Q && trapNum > 0)
            {
                putTrapSound.URL = url + "trap.mp3";
                putTrapSound.controls.play();
                InitializeTrap();
                trapNum--;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (gameOver)
                return;

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                goDown = false;
            }
        }

        private void gameEngine(object sender, EventArgs e)
        {
            // Display amno, kill and health
            #region Display UI

            lblAmno.Text = "Amno: " + amno;
            lblKill.Text = "Kills: " + score;

            #endregion

            #region Display Health Bar
            if (playerHealth > 0)
                lblHealthBar.Value = Convert.ToInt32(playerHealth);
            else
            {
                #region GameOver
                gameTimer.Stop();
                gameOver = true;

                // Show player's dead image
                player.Image = Properties.Resources.dead;
                gameOverSound.URL = url + "youlose.mp3";
                lblGameOver.SizeMode = PictureBoxSizeMode.StretchImage;
                lblGameOver.BringToFront();
                lblGameOver.Visible = true;

                player1.controls.pause();
                tmHeal.Stop();
                tmAmno.Stop();
                #endregion
            }
            #endregion

            #region Display Trap UI

            if (trapNum == 2)
            {
                lblTrap3.Visible = false;
            }

            else if (trapNum == 1)
            {
                lblTrap2.Visible = false;
            }

            else if (trapNum < 1)
            {
                lblTrap1.Visible = false;
            }

            #endregion

            #region Display Boss's Health

            if(!respawnBoss)
            {
                if (boss.Health > 0)
                    boss.healthBar.Value = boss.Health;
                else
                { 
                    boss.healthBar.Value = 0;
                }
            }

            #endregion

            #region HealthColor
            if (playerHealth <= 20.0)
            {
                lblHealthBar.ForeColor = Color.Red;
            }

            else if (playerHealth <= 50.0)
            {
                lblHealthBar.ForeColor = Color.GreenYellow;
            }
            else if (playerHealth <= 75.0)
            {
                lblHealthBar.ForeColor = Color.ForestGreen;
            }
            else
            {
                lblHealthBar.ForeColor = Color.BlueViolet;
            }
            #endregion

            #region Ammo COlor

            if (amno < 4)
                lblAmno.ForeColor = Color.Red;
            else if (amno <= 10)
                lblAmno.ForeColor = Color.White;
            else
                lblAmno.ForeColor = Color.Black;

            #endregion

            #region Play Medic Sound

            if(playerHealth <= 20)
            {
                if(isMedic)
                {
                    medicSound.URL = url + "medic.mp3";
                    medicSound.controls.play();
                    isMedic = false;
                }
            }
            else
            {
                isMedic = true;
            }

            #endregion

            #region PlayerMovement
            // Control movement : Left
            if (goLeft && player.Left > 0)
            {
                // Player moves left
                player.Left -= speed;
            }

            // Control movement : Right
            if (goRight && player.Left + player.Width < 900)
            {
                // Player moves right
                player.Left += speed;
            }

            // Control movement : Up
            if (goUp && player.Top > 50)
            {
                // Player moves up
                player.Top -= speed;
            }

            // Control movement : Down
            if (goDown && player.Top + player.Height < 650)
            {
                // Player moves down
                player.Top += speed;
            }
            #endregion

            #region Boss Respawned Condition

            if(score > 3 && respawnBoss)
            {
                boss = new Boss(this, player);
                respawnBoss = false;
            }

            #endregion

            #region Boss Make Decision

            if (!respawnBoss)
            {
                tmMakeDecision.Start();
            }

            #endregion

            #region Boss Movement

            if (!respawnBoss)
            {
                boss.Move(player);
            }

            #endregion

            #region Boss Decided Explosion

            if (!respawnBoss && bossExplosion)
            {
                boss.SetFireExplosion(this, player);
                bossExplosion = false;
                //tmExplosion.Start();
            }

            #endregion

            #region Boss Decided FireBall

            if(!respawnBoss && bossFireBall)
            {
                boss.SetHorizontalFireBall(this);
                fireBallMove = true;
                bossFireBall = false;
            }

            #endregion

            #region Boss Decided Invisible / Visible

            //if(bossVisibleChange)
            //{
            //    boss.ChangeVisibility();
            //    bossVisibleChange = false;
            //}

            #endregion

            #region FireBall Movement

            if ( !respawnBoss && fireBallMove)
            {
                if(boss.fireBall.fireBall.Bounds.IntersectsWith(player.Bounds))
                {
                    playerHealth -= 30;
                    boss.fireBall.Destroy();
                }
                if(boss.boss.Left < player.Left)
                {
                    boss.fireBall.MoveRight();
                }
                else
                {
                    boss.fireBall.MoveLeft();
                }

            }

            #endregion

            #region Boss Hurts Player?

            if( !respawnBoss && boss.boss.Bounds.IntersectsWith(player.Bounds))
            {
                playerHealth -= 3;
            }

            #endregion

            foreach (Control x in this.Controls)
            {
                if (x is ProgressBar)
                {
                    #region ZombieBar Movement

                    if (x.Tag == "hpzombiebar")
                    {
                        if (!isExistHPZombie)
                        {
                            this.Controls.Remove(x);
                            x.Dispose();
                        }
                        else
                        {
                            if (isHPZombieMove)
                            {
                                #region Display Zombie Bar
                                if (zombieBar_1 < 0)
                                    zombieBar_1 = 0;

                                if (zombieBar_1 > 0)
                                    ((ProgressBar)x).Value = Convert.ToInt32(zombieBar_1);
                                #endregion

                                if (x.Left < player.Left)
                                {
                                    // Move right
                                    x.Left += hpzombieSpeed;
                                }

                                if (x.Left > player.Left)
                                {
                                    // Move Left
                                    x.Left -= hpzombieSpeed;
                                }

                                if (x.Top < player.Top)
                                {
                                    // Move down
                                    x.Top += hpzombieSpeed;
                                }

                                if (x.Top > player.Top)
                                {
                                    // Move Up
                                    x.Top -= hpzombieSpeed;
                                }
                            }
                        }

                    }
                    #endregion
                }
                if (x is PictureBox)
                {

                    #region Bomb Hurts Player?

                    if( x.Tag == "explosion")
                    {
                        if(x.Bounds.IntersectsWith(player.Bounds))
                        {
                            playerHealth -= 5;
                        }
                    }

                    #endregion

                    #region Player Hurts Boss

                    if( !respawnBoss && x.Tag == "bullet")
                    {
                        if(x.Bounds.IntersectsWith(boss.boss.Bounds))
                        {
                            this.Controls.Remove(x);
                            x.Dispose();
                            boss.Damaged(1);
                        }
                    }

                    #endregion

                    #region Player Pick Up Amno
                    if (x.Tag == "amno" &&
                       ((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                    {
                        this.Controls.Remove((PictureBox)x);
                        ((PictureBox)x).Dispose();

                        pickUpAmmo.URL = url + "pickupammo.mp3";
                        pickUpAmmo.controls.play();
                        amno += 5;
                    }
                    #endregion

                    #region Destroy Out Range Bullet
                    if (x.Tag == "bullet" || x.Tag == "sbullet")
                    {
                        if (((PictureBox)x).Left < 1 || ((PictureBox)x).Left > 1000 ||
                            ((PictureBox)x).Top < 10 || ((PictureBox)x).Top > 1100)
                        {
                            this.Controls.Remove((PictureBox)x);
                            ((PictureBox)x).Dispose();
                        }
                    }
                    #endregion

                    #region Player Pick Up Heal
                    if (x.Tag == "heal" && x.Bounds.IntersectsWith(player.Bounds))
                    {
                        playerHealth += 30;
                        if (playerHealth > 100)
                            playerHealth = 100;

                        this.Controls.Remove(x);
                        x.Dispose();
                    }
                    #endregion

                    #region Normal Zombie Movement

                    if (x.Tag == "zombie")
                    {

                        #region Reduce Player Health
                        if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                            playerHealth--;
                        #endregion

                        if (((PictureBox)x).Left < player.Left)
                        {
                            // Move right
                            ((PictureBox)x).Left += zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zright;
                        }

                        if (((PictureBox)x).Left > player.Left)
                        {
                            // Move Left
                            ((PictureBox)x).Left -= zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zleft;
                        }

                        if (((PictureBox)x).Top < player.Top)
                        {
                            // Move down
                            ((PictureBox)x).Top += zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zdown;
                        }

                        if (((PictureBox)x).Top > player.Top)
                        {
                            // Move Up
                            ((PictureBox)x).Top -= zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zup;
                        }
                    }
                    #endregion

                    #region Speedy Zombie Movement

                    if (x.Tag == "speedzombie")
                    {
                        #region Reduce Player Health
                        if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                            playerHealth--;
                        #endregion

                        if (((PictureBox)x).Left < player.Left)
                        {
                            // Move right
                            ((PictureBox)x).Left += speedzombieSpeed;
                        }

                        if (((PictureBox)x).Left > player.Left)
                        {
                            // Move Left
                            ((PictureBox)x).Left -= speedzombieSpeed;
                        }

                        if (((PictureBox)x).Top < player.Top)
                        {
                            // Move down
                            ((PictureBox)x).Top += speedzombieSpeed;
                        }

                        if (((PictureBox)x).Top > player.Top)
                        {
                            // Move Up
                            ((PictureBox)x).Top -= speedzombieSpeed;
                        }
                    }


                    #endregion

                    #region HP Zombie Movement

                    if (x.Tag == "hpzombie")
                    {
                        #region Reduce Player Health
                        if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                            playerHealth--;
                        #endregion

                        if (((PictureBox)x).Left < player.Left)
                        {
                            // Move right
                            ((PictureBox)x).Left += hpzombieSpeed;
                        }

                        if (((PictureBox)x).Left > player.Left)
                        {
                            // Move Left
                            ((PictureBox)x).Left -= hpzombieSpeed;
                        }

                        if (((PictureBox)x).Top < player.Top)
                        {
                            // Move down
                            ((PictureBox)x).Top += hpzombieSpeed;
                        }

                        if (((PictureBox)x).Top > player.Top)
                        {
                            // Move Up
                            ((PictureBox)x).Top -= hpzombieSpeed;
                        }
                    }

                    #endregion

                    #region Trapped Zombie

                    if (x.Tag == "tzombie" && (zombieMove || zombieMove2 || zombieMove3))
                    {
                        x.Tag = "zombie";

                        if (count2 == 0)
                            zombieMove = false;

                        else if (count2 == 1)
                            zombieMove2 = false;
                        else
                            zombieMove3 = false;

                        count2++;
                        count3++;
                    }
                    #endregion

                    #region Trapped HP Zombie
                    if (x.Tag == "thpzombie" && (zombieMove || zombieMove2 || zombieMove3))
                    {
                        x.Tag = "hpzombie";
                        isHPZombieMove = true;
                        if (zombieMove)
                            zombieMove = false;

                        else if (zombieMove2)
                            zombieMove2 = false;
                        else
                            zombieMove3 = false;

                        //count2++;
                        count3++;
                    }
                    #endregion

                }

                foreach (Control j in this.Controls)
                {
                    if (j is PictureBox && x is PictureBox)
                    {
                        #region Bullet Hits Zombie

                        if ((j.Tag == "bullet" || j.Tag == "sbullet") && x.Tag == "zombie")
                        {
                            if (j.Bounds.IntersectsWith(x.Bounds))
                            {
                                #region Destroy Zombie

                                zombieDie.URL = url + "mzdie.mp3";
                                zombieDie.controls.play();
                                this.Controls.Remove(x);
                                x.Dispose();

                                #endregion

                                #region Destroy Bullet

                                if (j.Tag != "sbullet")
                                {
                                    this.Controls.Remove(j);
                                    j.Dispose();
                                }

                                #endregion

                                score++;

                                #region Make Zombie

                                if (!isExistHPZombie)
                                    MakeHPZombie();

                                MakeZombie();

                                #endregion
                            }
                        }
                        #endregion

                        #region Bullet Hits HP Zombie

                        if (x.Tag == "hpzombie")
                        {

                            if (playerHealth <= 40.0)
                            {
                                if (isSmileFace)
                                {
                                    sound = new SoundPlayer(url + "wlaugh.wav");
                                    sound.Play();

                                    ((PictureBox)x).Image = Properties.Resources.hpzombiesmile;
                                    hpzombieSpeed = 3;
                                    isNormalFace = true;
                                    isAngryFace = true;
                                    isSmileFace = false;
                                }
                            }
                            else
                            {
                                if (isNormalFace)
                                {
                                    hpzombieSpeed = 1;
                                    ((PictureBox)x).Image = Properties.Resources.hpzombie;
                                    isNormalFace = false;
                                    isSmileFace = true;
                                    isAngryFace = true;
                                }
                            }


                            if (j.Tag == "sbullet")
                            {
                                if (j.Bounds.IntersectsWith(x.Bounds))
                                {
                                    zombieBar_1 -= 3;

                                    if (zombieBar_1 < 0)
                                    {
                                        isExistHPZombie = false;
                                        this.Controls.Remove(x);
                                        x.Dispose();
                                        SetDefaultFace();

                                    }
                                }
                            }

                            if (j.Tag == "bullet")
                            {
                                if (j.Bounds.IntersectsWith(x.Bounds))
                                {
                                    #region HP Zombie Face
                                    if (playerHealth > 40.0)
                                    {
                                        if (isAngryFace)
                                        {
                                            ((PictureBox)x).Image = Properties.Resources.hpzombieangry;
                                            //sound.Stop();
                                            sound2 = new SoundPlayer(url + "angry.wav");
                                            sound2.Play();
                                            hpzombieSpeed = 1;
                                            isAngryFace = false;
                                        }
                                    }

                                    #endregion

                                    zombieBar_1--;

                                    this.Controls.Remove(j);
                                    j.Dispose();

                                    if (zombieBar_1 < 0)
                                    {
                                        isExistHPZombie = false;
                                        this.Controls.Remove(x);
                                        x.Dispose();
                                        SetDefaultFace();
                                    }
                                }
                            }
                        }


                        #endregion

                        #region Zombie is Trapped

                        if (j.Tag == "trap")
                        {
                            if (x.Tag == "zombie" && j.Bounds.IntersectsWith(x.Bounds))
                            {
                                zombietrapped.URL = url + "ztrap.mp3";
                                zombietrapped.controls.play();
                                x.Tag = "tzombie";

                                #region Remove Trap

                                this.Controls.Remove(j);
                                j.Dispose();

                                #endregion
                                zMove.Start();
                            }

                            if (x.Tag == "hpzombie" && j.Bounds.IntersectsWith(x.Bounds))
                            {
                                zombietrapped.URL = url + "ztrap.mp3";
                                zombietrapped.controls.play();

                                x.Tag = "thpzombie";
                                isHPZombieMove = false;

                                #region Remove Trap

                                this.Controls.Remove(j);
                                j.Dispose();

                                #endregion
                                zMove.Start();
                            }
                        }
                        #endregion
                    }
                }
            }
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

        private void tmHeal_Tick(object sender, EventArgs e)
        {
            DropHeal();
        }

        private void tmAmno_Tick(object sender, EventArgs e)
        {
            DropAmno();
        }

        private void tmShoot_Tick(object source, ElapsedEventArgs e)
        {
            shootCount = 1;
        }

        // Supply Heal
        private void DropHeal()
        {
            PictureBox Heal = new PictureBox();
            Heal.Image = Properties.Resources.heal;
            Heal.SizeMode = PictureBoxSizeMode.Zoom;
            Heal.Tag = "heal";

            Heal.Left = rnd.Next(10, 890);
            Heal.Top = rnd.Next(50, 600);

            this.Controls.Add(Heal);
            Heal.BringToFront();
            player.BringToFront();
        }

        private void isContinueKeyClicked(object sender, MouseEventArgs e)
        {
            player.Enabled = true;
            DisplayPauseMenu();
        }

        private void isExitButtonClicked(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        // Shooting
        private void Shoot(string direct)
        {
            if (score % 15 == 0 && score != 0 && specialAmno == 0)
            {
                specialAmno = 5;
            }
            bullet shoot = new bullet();
            shoot.direction = direct;
            shoot.bulletLeft = player.Left + (player.Width / 2);
            shoot.bulletTop = player.Top + (player.Height / 2);
            if (specialAmno > 0)
            {
                shoot.mkSpecialBullet(this);
                specialAmno--;
            }
            else
            {
                shoot.mkBullet(this);
                amno--;
            }

        }

        // Make Zombie
        private void MakeZombie()
        {
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown; // default image
            zombie.BackColor = Color.Transparent;
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;

            // Setting position
            zombie.Left = rnd.Next(0, 900);
            zombie.Top = rnd.Next(0, 800);

            this.Controls.Add(zombie);
            // player.BringToFront();
        }

        private void MakeHPZombie()
        {
            isExistHPZombie = true;

            PictureBox hpZombie = new PictureBox();
            hpZombie.Tag = "hpzombie";
            hpZombie.Image = Properties.Resources.hpzombie;
            hpZombie.SizeMode = PictureBoxSizeMode.Zoom;
            hpZombie.Size = new Size(100, 100);

            hpZombie.Left = rnd.Next(0, 900);
            hpZombie.Top = rnd.Next(0, 800);

            ProgressBar hpZombieHealthBar = new ProgressBar();
            hpZombieHealthBar.Tag = "hpzombiebar";
            hpZombieHealthBar.Left = hpZombie.Left;
            hpZombieHealthBar.Top = hpZombie.Top - (hpZombie.Height / 3);
            hpZombieHealthBar.Maximum = 15;

            zombieBar_1 = 15;
            hpZombieHealthBar.Value = Convert.ToInt32(zombieBar_1);


            this.Controls.Add(hpZombieHealthBar);
            this.Controls.Add(hpZombie);

        }

        private void MakeSpeedZombie()
        {
            PictureBox speedZombie = new PictureBox();
            speedZombie.Tag = "speedzombie";
            speedZombie.Image = Properties.Resources.szombie;
            speedZombie.SizeMode = PictureBoxSizeMode.Zoom;

            speedZombie.Left = rnd.Next(0, 900);
            speedZombie.Top = rnd.Next(0, 800);

            this.Controls.Add(speedZombie);
        }

        private void InitializeTrap()
        {
            PictureBox trap = new PictureBox();
            trap.Image = Properties.Resources.trap;
            trap.SizeMode = PictureBoxSizeMode.StretchImage;
            trap.Tag = "trap";

            trap.Left = player.Left;
            trap.Top = player.Top;

            this.Controls.Add(trap);
            trap.BringToFront();
            player.BringToFront();
        }

        private void zMove_Tick(object source, ElapsedEventArgs e)
        {
            if (count == 0)
                zombieMove = true;
            else if (count == 1)
                zombieMove2 = true;
            else
                zombieMove3 = true;

            count++;
        }

        private void tmExplosion_Tick(object source, ElapsedEventArgs e)
        {
            bossExplosion = true;
        }

        private void SetDefaultFace()
        {
            isSmileFace = true;
            isAngryFace = true;
            isNormalFace = false;
        }

        private void PlayBackgroundMusic()
        {
            player1.URL = url + "1hbgm.mp3";
            player1.settings.volume = 35;
            player1.controls.play();
        }

        private void DisplayPauseMenu()
        {
            lblPauseButton.Visible = !lblPauseButton.Visible;
            lblContinueButton.Visible = !lblContinueButton.Visible;
            lblExitButton.Visible = !lblExitButton.Visible;
            lblPlayPicture.Visible = !lblPlayPicture.Visible;
            lblExitPicture.Visible = !lblExitPicture.Visible;
            lblPauseBorder.Visible = !lblPauseBorder.Visible;


            gameTimer.Enabled = !gameTimer.Enabled;
            tmHeal.Enabled = !tmHeal.Enabled;
            tmAmno.Enabled = !tmAmno.Enabled;
            
        }

        private void tmMakeDecision_Tick(object sender, EventArgs e)
        {
            MakeDecision();
        }

        // Decision is made each every time interval
        private void MakeDecision()
        {
            int ranNum = rnd.Next(0, 100);
            if (runOnce )
            {
                if (ranNum <= 50)
                {
                    // Bombing attack for 3 times
                    bossExplosion = true;
                    runOnce = false;
                }
                else
                {
                    // FireBall attack for 3 times
                    bossFireBall = true;
                    runOnce = false;
                }
            }
            
        }


    }

}
