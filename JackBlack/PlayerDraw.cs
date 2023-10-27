using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class PlayerDraw
    {
        DeckOfCards _carddraw = new DeckOfCards(true);
        public List<Card> househand()
        {
            
            List<Card> HouseCards = new List<Card>();
            HouseCards = _carddraw.drawACard(2);
            return HouseCards;
        }
        public List<Card> playerhand()
        {
            
            List<Card> playerCards = new List<Card>();
            playerCards = _carddraw.drawACard(2);
            return playerCards;
        }
    }
}
