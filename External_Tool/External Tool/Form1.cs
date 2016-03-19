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

/// <summary>
/// Evan Keating
/// External Tool for editing a text file that will determine the values for attributes in the game
/// Array of strings was used to store values, will most likely change to dictionary for ease of use
/// </summary>

namespace External_Tool
{
    public partial class SettingsManager : Form
    {
        // array for holidng values from the lines
        string[] filelines2 = new string[4];
       

        public SettingsManager()
        {
            InitializeComponent();

            // call savelines method
            SaveLines();

            // set color
            // this.BackColor = Color.Black;
            // set text colors
        }

        // method for getting lines
        public void SaveLines()
        {
            // create reader to read file
            StreamReader input = null;

            try
            {
                // call in file for reader
                input = new StreamReader("GameSettings.txt");

                // read through the lines of the file and store the values
                for (int i = 0; i < filelines2.Length; i++)
                {
                    while (input.ReadLine() != null)
                    {
                        filelines2[i] = input.ReadLine();
                    }
                }
            }
            catch(FileNotFoundException ex)
            {

                // print out message stating is file wasnt found
                MessageBox.Show("Error: File was not found " + ex.Message);
                MessageBox.Show("Creating File From Scratch");

                // create the file by calling the writelines method
                WriteLines();
      
            }
            finally // make sure the file gets closed even if try fails
            {
                // close the file
                if (input != null) input.Close();
            }
            
            

        }

        // method for outputting to the file
        public void WriteLines()
        {
            // create streamwriter to save changed information to the settings file
            StreamWriter output = null;

            try
            {
                // call in file name for output
                output = new StreamWriter("GameSettings.txt");

                // set settings based on what is in the array of line values
                output.WriteLine(filelines2[0]);
                output.WriteLine(filelines2[1]);
                output.WriteLine(filelines2[2]);
                output.WriteLine(filelines2[3]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: An exception has occured" + ex.Message);
            }
            finally
            {
                // close the file to save changes
                if (output != null) output.Close();
            }
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
            // call the writelines method to save changes made in teh form
            WriteLines();
        }

        private void CancelBut_Click(object sender, EventArgs e)
        {
            // close form when cancled
            this.Close();
        }
    }
}
