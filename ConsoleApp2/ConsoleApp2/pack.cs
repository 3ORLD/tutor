using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Pack
    {
        private List<Card> _cards;
        private Random _random;

        public Pack()
        {
            _random = new Random();
            _cards = new List<Card>();
            for (int value = 1; value <= 13; value++)
            {
                for (int suit = 1; suit <= 4; suit++)
                {
                    _cards.Add(new Card { Value = value, Suit = suit });
                }
            }
        }

        public Card DrawCard()
        {
            int index = _random.Next(_cards.Count);
            Card drawnCard = _cards[index];
            _cards.RemoveAt(index);
            return drawnCard;
        }
    }
}
