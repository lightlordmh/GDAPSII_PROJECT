using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace External_Tool
{
    public partial class SettingsManager : Form
    {

        // how to edit text file
        StreamWriter output = null;
        StreamReader input = null;
        string[] filelines2;

        public SettingsManager()
        {
            InitializeComponent();
            // set defualt values for text in the file
            output.WriteLine("DIMMED");
            output.WriteLine("NORMAL");
            output.WriteLine("TWO");
            output.WriteLine("AVERAGE");
            output.Close();

            // set color
            //this.BackColor = Color.Black;
            // set text colors
        }

        // method for getting lines
        public void SaveLines()
        {

            // array for holding lines from text file
            string[] filelines = new string[4];


            for (int i = 0; i < filelines.Length; i = 0)
            {
                while (input.ReadLine() != null)
                {
                    filelines[i] = input.ReadLine();
                }
            }
            input.Close();
            filelines2 = filelines;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // change setting for when flashlight is selected to be off
            if(LightOffBut.Checked == true)
            {
                filelines2[0] = "OFF";
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void EasyButton_CheckedChanged(object sender, EventArgs e)
        {
            // change settings for EASY
            if (EasyButton.Checked == true)
            {
                LightFullBut.Checked = true;
                EnemySlow.Checked = true;
                LevelOne.Checked = true;
                EasyRiddle.Checked = true;
                filelines2[0] = "FULL";
                filelines2[1] = "SLOW";
                filelines2[2] = "ONE";
                filelines2[3] = "SIMPLE";
            }

        }

        private void MediumButton_CheckedChanged(object sender, EventArgs e)
        {
            // change settings for MEDIUM
            if(MediumButton.Checked == true)
            {
                LightMedBut.Checked = true;
                EnemyAvg.Checked = true;
                LevelTwo.Checked = true;
                AvgRiddle.Checked = true;
                filelines2[0] = "DIMMED";
                filelines2[1] = "NORMAL";
                filelines2[2] = "TWO";
                filelines2[3] = "AVERAGE";
            }
        }

        private void HardButton_CheckedChanged(object sender, EventArgs e)
        {
            // change setting for HARD
            if(HardButton.Checked == true)
            {
                LightLowBut.Checked = true;
                EnemyFast.Checked = true;
                LevelThree.Checked = true;
                HardRiddle.Checked = true;
                filelines2[0] = "LOW";
                filelines2[1] = "FAST";
                filelines2[2] = "THREE";
                filelines2[3] = "CHALLENGING";
            }
        }

        private void LevelFour_CheckedChanged(object sender, EventArgs e)
        {
            // change setting for when level 4 is slected for starting level
            if(LevelFour.Checked == true)
            {
                filelines2[2] = "FOUR";
            }
        }

        private void NeedToSolve_CheckedChanged(object sender, EventArgs e)
        {
            // change settings for is the riddle needs to be solved
            if(NeedToSolve.Checked == true)
            {
                filelines2[3] = "SOLVEIT";
            }
        }

        private void ApplyBut_Click(object sender, EventArgs e)
        {
            // set settings based on what is in the array
            output.WriteLine(filelines2[0]);
            output.WriteLine(filelines2[1]);
            output.WriteLine(filelines2[2]);
            output.WriteLine(filelines2[3]);
        }

        private void CancelBut_Click(object sender, EventArgs e)
        {
            // close form when cancled
            //this.Close();
        }


    }
}
