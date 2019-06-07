// Author: Alex Mitchelmore
// Date: 2019-05-25
// Final Project: Blackjack

namespace ProjectCardGame
{
    public class Card
    {
        public Card (Suit newSuit, FaceValue newValue)
        {
            Suit = newSuit;
            FaceValue = newValue;
          
        }

        public Suit Suit { get; }
        public FaceValue FaceValue { get; }
    }
}
