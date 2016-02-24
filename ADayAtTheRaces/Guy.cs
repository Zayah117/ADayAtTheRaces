using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtTheRaces
{
    public class Guy
    {
        //fields
        public string Name;
        public Bet MyBet;
        public int Cash;
        public RadioButton MyRadioButton;
        public Label MyLabel;

        //my method to update the guys' labels
        public void UpdateLabels()
        {
            MyBet.Bettor = this;
            MyLabel.Text = MyBet.GetDescription();
            MyRadioButton.Text = Name + " has $" + Cash;
        }
        //clearing the bet and setting the ammount to 0
        public void ClearBet()
        {
            MyBet = null;
            MyBet = new Bet();
        }
        //my method for placing bets (called with the betButton)
        public void PlaceBet(int BetAmmount, int DogToWin)
        {
            if (Cash >= BetAmmount)
            {
                MyBet.Ammount = BetAmmount;
                MyBet.Dog = DogToWin;
                this.UpdateLabels();
            }
            else
            {
                MessageBox.Show(this.Name + " doesn't have that much money.");
            }
        }
        //My collect method calls the payout method from the Bet Class
        public void Collect(int Winner)
        {
            this.Cash += MyBet.PayOut(Winner);
        }
    }
}
