using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

// Author: Alex Mitchelmore
// Date: 2019-05-25
// Final Project: Blackjack

namespace ProjectCardGame
{
    public class Deck
    {
        public Deck()
        {
            MakeDeck();
        }

        private List<Card> deck = new List<Card>();

        private void MakeDeck()
        {
            for (int pickASuit = 0; pickASuit <= 3; pickASuit++)
            {
                for (int pickAValue = 0; pickAValue <= 12; pickAValue++)
                {
                    Card newCard = new Card((Suit)pickASuit, (FaceValue)pickAValue);
                    deck.Add(newCard);
                }
            }
        }

        public void Shuffle()
        {
            Random rGen = new Random();
            List<Card> newDeck = new List<Card>();

            while (deck.Count > 0)
            {
                int removeIndex = rGen.Next(0, (deck.Count - 1));
                Card removeObject = deck[removeIndex];
                deck.RemoveAt(removeIndex);
                newDeck.Add(removeObject);
            }

            deck = newDeck;
        }

        public Hand DealHand(int number)
        {
            if (deck.Count == 0)
            {
                throw new ConstraintException("There are no cards left in the deck. Redeal.");
            }

            Hand hand = new Hand();

            int countTo = deck.Count >= number ? number : deck.Count;

            for (int handIndex = 0; handIndex < countTo; handIndex++)
            {
                hand.AddCard(deck[0]);
                deck.RemoveAt(0);
            }

            return hand;
        }

        public Card DrawOneCard()
        {
            Card topCard;
            if (deck.Count > 0)
            {
                topCard = deck[0];
                deck.RemoveAt(0);
            }
            else
            {
                throw new ArgumentException("There are no cards in the deck - deal again");
            }

            return topCard;
        }
    }
}
