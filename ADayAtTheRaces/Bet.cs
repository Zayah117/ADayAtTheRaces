using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADayAtTheRaces
{
    public class Bet
    {
        //fields
        public int Ammount = 0;
        public int Dog;
        public Guy Bettor;

        //get the description of the bet and pass it to the labels on the form
        public string GetDescription()
        { 
            if (Ammount <= 0)
            {
                return Bettor.Name + " hasn't placed a bet.";
            }
            else
            {
                return Bettor.Name + " has placed $" + Ammount + " on dog " + Dog;
            }
        }
        //if you bet on the winning dog, return the ammount you bet. if you bet on a losing dog, return the negative ammount
        public int PayOut(int Winner)
        {
            if ((Winner + 1) == Dog)
            {
                return Ammount;
            }
            else
            {
                return -Ammount;
            }
        }
    }
}
