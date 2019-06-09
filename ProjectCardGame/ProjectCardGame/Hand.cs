using System.Collections.Generic;
using System.Data;
using System.Linq;

// Author: Alex Mitchelmore
// Date: 2019-05-25
// Final Project: Blackjack

namespace ProjectCardGame
{
    public class Hand
    {
        private List<Card> cards = new List<Card>();

        public int Count
        {
            get
            {
                return cards.Count();
            }
        }

        public Card this[int index]
        {
            get
            {
                return cards[index];
            }
        }

        public void AddCard(Card newCard)
        {
            if (ConstainsCard(newCard))
            {
                throw new ConstraintException(newCard.FaceValue.ToString() + " of " + newCard.Suit.ToString() + " already exists in the hand.");
            }
            cards.Add(newCard);
        }

        private bool ConstainsCard(Card cardToCheck)
        {
            foreach (Card card in cards)
            {
                if (card.FaceValue == cardToCheck.FaceValue && card.Suit == cardToCheck.Suit)
                {
                    return true;
                }
            }

            return false;
        }

        public void RemoveCard(Card theCard)
        {
            if (cards.Contains(theCard))
            {
                cards.Remove(theCard);
            }
            else
            {
                throw new ConstraintException(theCard.FaceValue.ToString() + " of " +
                    theCard.Suit.ToString() + " does not exist in the Hand");
            }
        }

        public void RemoveCard(int index)
        {
            if (index <= cards.Count - 1)
            {
                cards.RemoveAt(index);
            }
            else
            {
                throw new DataException("Index value exceeds the number of cards in the hand.");
            }
        }

        public void RemoveCard(Suit theSuit, FaceValue theFaceValue)
        {
            foreach (Card card in cards)
            {
                if (card.Suit == theSuit && card.FaceValue == theFaceValue)
                {
                    cards.Remove(card);
                    return;
                }
            }
            throw new DataException(theFaceValue.ToString() + " of " + theSuit.ToString() + " does not exist in the Hand.");
        }

        public int GetHandValue()
        {
            int value = 0;

            foreach (Card card in cards)
            {
                if (card.FaceValue == FaceValue.Ace)
                {
                    //When an ace is drawn it is valued at 11.
                    value += 11;
                }
                else if (card.FaceValue == FaceValue.Ace || card.FaceValue == FaceValue.Jack || card.FaceValue == FaceValue.Queen || card.FaceValue == FaceValue.King)
                {
                    //All face value cards are valued at 10
                    value += 10;
                }
                else
                {
                    //All other cards are valued at there pip
                    value += (int)card.FaceValue + 1;
                }

            }

            return value;
        }

        public string Winner(int Player, int Dealer)
        {
            string msg = "";

            if (Dealer > 21)
            {
                msg += "The house has busted. You Win!";
            }
            else if (Player > Dealer)
            {
                msg += "You have the better hand. You Win!";
            }
            else if (Player < Dealer)
            {
                msg += "The house has the better hand. The House Wins!";
            }
            else
            {
                //A tie in hand values means the house wins
                msg += "You have tied with the house. The House Wins!";
            }

            return msg;
        }

        public bool InstantWin(int Player)
        {
            if (Player == 21)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool BustCheck(int value)
        {
            if (value > 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
