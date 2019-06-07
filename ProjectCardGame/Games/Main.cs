using ProjectCardGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Author: Alex Mitchelmore
// Date: 2019-05-25
// Final Project: Blackjack

namespace Games
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private Deck aDeck;
        private Hand Player = new Hand();

        #region Load
        private void Main_Load(object sender, EventArgs e)
        {
            SetUp();
        } 
        #endregion

        #region Buttons
        private void btnGame_Click(object sender, EventArgs e)
        {
            try
            {
                Player = aDeck.DealHand(2);
                ShowHand(Player);

                lblPlayer.Text = Player.GetHandValue().ToString();
                int PlayerHand = Convert.ToInt32(lblPlayer.Text);

                btnHit.Enabled = true;
                btnStay.Enabled = true;
                lblDealer.Text = "???";

                //Deck cannot be shuffled once the game has started
                btnShuffle.Enabled = false;

                //If the players hand is equal to 21 on the deal they win with a BlackJack
                if (Player.InstantWin(PlayerHand))
                {
                    MessageBox.Show("BLACKJACK!!!!! YOU WIN!!!");
                    GameOver();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            Shuffle myShuffle = new Shuffle(this);
            myShuffle.ShowDialog();

            //The cards have to be shuffled before the game can be played
            SetUp();
            btnGame.Enabled = true;
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            try
            {
                Player.AddCard(aDeck.DrawOneCard());
                ShowHand(Player);

                lblPlayer.Text = Player.GetHandValue().ToString();

                int PlayerHand = Convert.ToInt32(lblPlayer.Text);


                //If player hand value is greater then 21 they bust.
                if (Player.BustCheck(PlayerHand))
                {
                    MessageBox.Show("You busted. House Wins!");
                    GameOver();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }

        private void btnStay_Click(object sender, EventArgs e)
        {
            try
            {
                int PlayerHand = int.Parse(lblPlayer.Text);

                //Dealer will draw if his hand is equal to players hand
                Random rdm = new Random();
                int Dealer = rdm.Next(PlayerHand, 31);

                lblDealer.Text = Dealer.ToString();

                MessageBox.Show(Player.Winner(PlayerHand, Dealer));
                GameOver();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }
        #endregion

        #region Methods

        private void SetUp()
        {
            try
            {
                aDeck = new Deck();
                aDeck.Shuffle();
                btnHit.Enabled = false;
                btnStay.Enabled = false;
                btnGame.Enabled = false;
                btnShuffle.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void ShowHand(Hand theHand)
        {
            pnlCards.Controls.Clear();
            Card aCard;
            PictureBox aPic;

            for (int i = 0; i < theHand.Count; i++)
            {
                aCard = theHand[i];
                string path = @"images\" + aCard.FaceValue.ToString() + aCard.Suit.ToString() + ".jpg";

                aPic = new PictureBox()
                {
                    Image = Image.FromFile(path),
                    Text = aCard.FaceValue.ToString(),
                    Width = 71,
                    Height = 100,
                    Left = 75 * i

                };

                pnlCards.Controls.Add(aPic);
            }

        }

        private void GameOver()
        {
            lblPlayer.ResetText();
            lblDealer.Text = "???";

            pnlCards.Controls.Clear();
            SetUp();
        }
        #endregion
    }
}
