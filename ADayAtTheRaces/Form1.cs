using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtTheRaces
{
    public partial class Form1 : Form
    {
        Random MyRandomizer = new Random();
        //Arrays
        Greyhound[] GreyhoundArray = new Greyhound[4];
        Guy[] GuyArray = new Guy[3];
        Guy CurrentGuy;

        public Form1()
        {
            InitializeComponent();
            //Initalizing Greyhound Objects
            GreyhoundArray[0] = new Greyhound() { MyPictureBox = pictureBox1, StartingPosition = pictureBox1.Left, RaceTrackLength = racetrackPictureBox.Width - pictureBox1.Width, Randomizer = MyRandomizer };
            GreyhoundArray[1] = new Greyhound() { MyPictureBox = pictureBox2, StartingPosition = pictureBox2.Left, RaceTrackLength = racetrackPictureBox.Width - pictureBox2.Width, Randomizer = MyRandomizer };
            GreyhoundArray[2] = new Greyhound() { MyPictureBox = pictureBox3, StartingPosition = pictureBox3.Left, RaceTrackLength = racetrackPictureBox.Width - pictureBox3.Width, Randomizer = MyRandomizer };
            GreyhoundArray[3] = new Greyhound() { MyPictureBox = pictureBox4, StartingPosition = pictureBox4.Left, RaceTrackLength = racetrackPictureBox.Width - pictureBox4.Width, Randomizer = MyRandomizer };
            //Initalizing Guy Objects
            GuyArray[0] = new Guy() { Name = "Joe", Cash = 50, MyBet = new Bet(), MyLabel = joeBetLabel, MyRadioButton = joeRadioButton};
            GuyArray[1] = new Guy() { Name = "Bob", Cash = 50, MyBet = new Bet(), MyLabel = bobBetLabel, MyRadioButton = bobRadioButton };
            GuyArray[2] = new Guy() { Name = "Al", Cash = 50, MyBet = new Bet(), MyLabel = alBetLabel, MyRadioButton = alRadioButton };
            CurrentGuy = GuyArray[0];
            //Update Labels
            minimumBetLabel.Text = "Minimum bet = $" + betNumericUpDown.Minimum.ToString();
            bettorNameLabel.Text = GuyArray[0].Name;
            for (int i = 0; i < GuyArray.Length; i++)
            {
                GuyArray[i].UpdateLabels();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //loop through every dog and use the Run() method
            for (int i = 0; i < GreyhoundArray.Length; i++)
            {
                //stop the race and collect bets if one of the dogs wins
                if (GreyhoundArray[i].Run() == true)
                {
                    timer1.Stop();
                    MessageBox.Show("Dog #" + (i+1) + " wins!");
                    for (int q = 0; q < GuyArray.Length; q++)
                    {
                        GuyArray[q].Collect(i);
                        GuyArray[q].ClearBet();
                        GuyArray[q].UpdateLabels();
                    }
                }
            }
        }

        //return all dogs to starting position then start the race
        private void raceButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GreyhoundArray.Length; i++)
            {
                GreyhoundArray[i].TakeStartingPosition();
            }
            timer1.Start();
        }

        //use radio buttons to change who's currently betting
        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            CurrentGuy = null;
            CurrentGuy = GuyArray[0];
            bettorNameLabel.Text = GuyArray[0].Name;
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            CurrentGuy = null;
            CurrentGuy = GuyArray[1];
            bettorNameLabel.Text = GuyArray[1].Name;
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            CurrentGuy = null;
            CurrentGuy = GuyArray[2];
            bettorNameLabel.Text = GuyArray[2].Name;
        }

        //use the bet button to place the bet of the currently selected guy
        private void betButton_Click(object sender, EventArgs e)
        {
            CurrentGuy.PlaceBet((int)betNumericUpDown.Value, (int)dogNumericUpDown.Value);
        }
    }
}
