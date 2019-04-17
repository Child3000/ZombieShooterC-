using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace zombieShooter
{
    class TimeBomer
    {
        WindowsMediaPlayer explosionSound = new WindowsMediaPlayer();
        PictureBox timeBomer;
        Random rnd = new Random();
        Timer tmBomb;

        int count = 0;

        public TimeBomer(Form form)
        {
            timeBomer = new PictureBox();

            timeBomer.Image = Properties.Resources.timebomb;
            timeBomer.SizeMode = PictureBoxSizeMode.Zoom;
            timeBomer.Size = new System.Drawing.Size(100, 100);
            timeBomer.Tag = "bomb";

            timeBomer.Left = rnd.Next(0, 900);
            timeBomer.Top = rnd.Next(0, 800);

            form.Controls.Add(timeBomer);
            timeBomer.BringToFront();

            tmBomb = new Timer();
            tmBomb.Interval = 700;
            tmBomb.Tick += new EventHandler(tmBomb_Tick);
            tmBomb.Start();
        }

        private void tmBomb_Tick (object sender, EventArgs e)
        {
            if (count > 0)
            {
                Form1.runOnce = true;

                tmBomb.Stop();
                //tmBomb.Dispose();
                timeBomer.Dispose();
                tmBomb = null;
                timeBomer = null;
                count = 0;
                return;
            }

            timeBomer.Image = Properties.Resources.animexplosion;
            timeBomer.Tag = "explosion";           // Identify explosion had occurred
            explosionSound.URL = "D:/Users/Desktop/zombieAsset/mpexplosion.mp3";
            explosionSound.controls.play();
            count++;
        }

    }
}
