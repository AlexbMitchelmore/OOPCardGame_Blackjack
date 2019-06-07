using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Author: Alex Mitchelmore
// Date: 2019-05-25
// Final Project: Blackjack

namespace Games
{
    public partial class Shuffle : Form
    {
        public Shuffle(Main main)
        {
            myMain = main;
            InitializeComponent();
        }

        private Main myMain;

        private void Shuffle_Load(object sender, EventArgs e)
        {
           SoundPlayer player = new SoundPlayer(@"c:\mywavfile.wav");
            player.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
