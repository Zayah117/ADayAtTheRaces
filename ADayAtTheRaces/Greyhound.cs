using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtTheRaces
{
    public class Greyhound
    {
        //fields
        public int StartingPosition;
        public int RaceTrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random Randomizer;

        public bool Run()
        {
            //move forward 1-4 spaces at random
            Location += Randomizer.Next(4);
            //update picturebox
            MyPictureBox.Left = StartingPosition + Location;
            //return true if I won the race
            if (Location >= RaceTrackLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //put the dogs back in starting position
        public void TakeStartingPosition()
        {
            Location = 0;
            MyPictureBox.Left = StartingPosition;
        }
    }
}
