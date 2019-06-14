using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meloman
{
    public partial class fGame : Form
    {
        Random rnd = new Random();
        int musicDuration = Victorina.musicDuration;
        bool[] players = new bool[2];

        public fGame()
        {
            InitializeComponent();
        }

       public void MakeMusic()// function for random music
        {
            if (Victorina.list.Count == 0)
            {
                EndGame();

            }
            else
            {
                musicDuration = Victorina.musicDuration;
                int n = rnd.Next(0, Victorina.list.Count);
                WMP.URL = Victorina.list[n];
                Victorina.answer = System.IO.Path.GetFileNameWithoutExtension(WMP.URL);
                Victorina.list.RemoveAt(n);
                lblMelodyCount.Text = Victorina.list.Count.ToString();// to see how many songs are to listen
                players[0] = false;
                players[1] = false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            timer1.Start();
            MakeMusic();
        }

        private void fGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            WMP.Ctlcontrols.stop(); // for stopping music when you close form of out game
            timer1.Stop(); // and timer stopping
        }

        private void fGame_Load(object sender, EventArgs e)
        {
            lblMelodyCount.Text = Victorina.list.Count.ToString();
            progressBar1.Maximum = Victorina.gameDuration;
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            lblMusicDuration.Text = musicDuration.ToString();
        }

       public void EndGame()
        {
            timer1.Stop();
            WMP.Ctlcontrols.stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            musicDuration--;
            lblMusicDuration.Text = musicDuration.ToString();
            if (progressBar1.Value == progressBar1.Maximum)
            {
                EndGame();
                return;
            }
            if (musicDuration == 0) MakeMusic();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            GamePause();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            GamePlay();
        }

        public void GamePause()
        {
            timer1.Stop();
            WMP.Ctlcontrols.pause();
        }

        void GamePlay()
        {
            timer1.Start();
            WMP.Ctlcontrols.play();
        }

        private void fGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer1.Enabled == false) return;
            if (players[0]==false && e.KeyData == Keys.A)
            {
                GamePause();
                fMessage fm = new fMessage();
                fm.lblMessage.Text = "Player 1";
                players[0] = true;
                if(fm.ShowDialog() == DialogResult.Yes)
                {
                    lblCounter1.Text = Convert.ToString(Convert.ToInt32(lblCounter1.Text) + 1);
                    MakeMusic();
                }
                GamePlay();
            }
            if (players[1] == false && e.KeyData == Keys.P)
            {
                GamePause();
                fMessage fm = new fMessage();
                fm.lblMessage.Text = "Player 2";
                players[1] = true;
                if (fm.ShowDialog() == DialogResult.Yes)
                {
                    lblCounter2.Text = Convert.ToString(Convert.ToInt32(lblCounter2.Text) + 1);
                    MakeMusic();
                }
                GamePlay();
            }
        }

        private void WMP_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            //begin with random part of music
            if (Victorina.randomStart)
                if (WMP.openState == WMPLib.WMPOpenState.wmposMediaOpen)
                    WMP.Ctlcontrols.currentPosition = rnd.Next(0, (int)WMP.currentMedia.duration / 2);// duration is double, so we must make this (int)
            //duration of music/2, in other words this is our "random part"
        }

        private void lblCounter1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                lblCounter1.Text = Convert.ToString(Convert.ToInt32(lblCounter1.Text) + 1);
            if (e.Button == MouseButtons.Right)
                lblCounter1.Text = Convert.ToString(Convert.ToInt32(lblCounter1.Text) - 1);
        }

        private void lblCounter2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                lblCounter2.Text = Convert.ToString(Convert.ToInt32(lblCounter2.Text) + 1);
            if (e.Button == MouseButtons.Right)
                lblCounter2.Text = Convert.ToString(Convert.ToInt32(lblCounter2.Text) - 1);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblMusicDuration_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblMelodyCount_Click(object sender, EventArgs e)
        {

        }
    }
}
