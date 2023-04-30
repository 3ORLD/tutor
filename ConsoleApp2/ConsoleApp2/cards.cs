using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Card
    {
        public int Value { get; set; }
        public int Suit { get; set; }

        public virtual string GetDescription()
        {
            return $"Value: {Value}, Suit: {Suit}";
        }
    }
    public class SpecialCard : Card
    {
        public override string GetDescription()
        {
            return $"SPECIAL CARD - Value: {Value}, Suit: {Suit}";
        }
    }
}
