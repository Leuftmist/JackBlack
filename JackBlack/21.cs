using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class _21
    {
        static int _householder1 = 0;
        
        public bool initialphase(bool brother)
        {
            PlayerDraw cards = new PlayerDraw();
            List<Card> HouseCard = new List<Card>();
            List<Card> PlayerCard = new List<Card>();
            HouseCard = cards.househand();
            PlayerCard = cards.playerhand();
            displayphase(HouseCard, PlayerCard);
            return true;

        }
        private void displayphase(List<Card> HouseCard, List<Card> PlayerCard)
        {
            Console.WriteLine("This is your hand");
            for (int x = 0; x < PlayerCard.Count; x++)
            {
                Console.WriteLine($"{PlayerCard[x].GetCardFace()} {PlayerCard[x].GetCardSuit()}  {PlayerCard[x].GetCardValue()}");
            }
            Console.WriteLine("This is the Opponent hand");
            Console.WriteLine($" {HouseCard[0].GetCardFace()}  {HouseCard[0].GetCardSuit()}  {HouseCard[0].GetCardValue()}" + " Hidden");
            Userinput(HouseCard, PlayerCard);
        }
        private void Userinput(List<Card> HouseCard, List<Card> PlayerCard)
        {
            
            bool loop = true;
            int householder = 0;
            int playerholder = 0;
            DeckOfCards doc = new DeckOfCards(true);
            string uinput = "";
            
            Console.WriteLine("Add or stand");
            uinput = Console.ReadLine().ToLower();

            while (loop == true)
            {

                
                if (uinput == "add")
                {
                    Houseturn(HouseCard, doc);
                    Add(PlayerCard, HouseCard, doc, loop);
                    uinput = Console.ReadLine().ToLower();
                }

                else if (uinput == "stand")
                {
                    Houseturn(HouseCard, doc);
                    Stand(PlayerCard, householder, HouseCard, playerholder);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, Please input Add or stand");
                    uinput = Console.ReadLine().ToLower();
                }
                
            }
        }
        private List<Card> Hit(List<Card> PlayerCard, DeckOfCards doc, bool loop)
        {
            PlayerCard.Add(doc.drawACard());
            return PlayerCard;
        }
        private void Stand(List<Card> PlayerCard, int householder, List<Card> HouseCard, int playerholder) 
        {
            int householder1 = 0;
            int playerholder1 = 0;
            householder = 0;
            for (int x = 0; x < PlayerCard.Count; x++)
            {
                playerholder = PlayerCard[x].GetCardValue();
                playerholder1 = playerholder + playerholder1;
                if(playerholder1 > 21)
                {
                    Console.WriteLine("Bust");
                }
            }
            for (int x = 0; x < HouseCard.Count; x++)
            {
                householder = HouseCard[x].GetCardValue();
                householder1 = householder + householder1;
                if(householder1 > 21)
                {
                    Console.WriteLine("Bust");
                }
            }
            Console.WriteLine(playerholder1 + " " + householder1);
            if(playerholder1 > householder1 && playerholder1 <= 21)
            {
                Console.WriteLine("Congratulations! Player wins!");
            }
            else if (householder1 > playerholder1 && householder1 <= 21)
            {
                Console.WriteLine("House wins!");
            }
            else if (householder1 == playerholder1 || householder1 > 21 && playerholder1 > 21)
            {
                Console.WriteLine("Draw!");
            }

        }
        private List<Card> Houseturn(List<Card> Card, DeckOfCards doc) 
        {
            int householder = 0;
            int householder1 = 0;
            for (int x = 0; x < Card.Count; x++)
            {
                householder = Card[x].GetCardValue();
                _householder1 = householder + householder1;
            }
            if(_householder1 < 16)
            {
                Card.Add(doc.drawACard());
            }
                
            return Card;
        }
        private void Add(List<Card> PlayerCard, List<Card> HouseCard, DeckOfCards doc, bool loop)
        {
            Hit(PlayerCard, doc, loop);
            Console.Clear();
            Console.WriteLine("This is your hand");
            for (int x = 0; x < PlayerCard.Count; x++)
            {
                Console.WriteLine($"{PlayerCard[x].GetCardFace()} {PlayerCard[x].GetCardSuit()}  {PlayerCard[x].GetCardValue()}");
            }
            Console.WriteLine("This is the Opponent hand");
            for (int y = 0; y < HouseCard.Count - 1; y++)
            {
                Console.WriteLine($" {HouseCard[y].GetCardFace()}  {HouseCard[y].GetCardSuit()}  {HouseCard[y].GetCardValue()}");
            }
            Console.WriteLine("The Last card of your opponent is hidden");
        }
        
        
        
    }
}
