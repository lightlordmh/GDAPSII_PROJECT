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
/// Values range from 1-3 (Easy, Medium, Hard) with the value 0 given to Very Hard values when applicable
/// </summary>

namespace External_Tool
{
    public partial class SettingsManager : Form
    {
        // array for holidng values from the lines
        string[] filelines2 = new string[4];
        // dictionary for holding values
        Dictionary<string, int> settingVals = new Dictionary<string, int>();
       

        public SettingsManager()
        {
            InitializeComponent();

            // have message box tell instructions to user
            MessageBox.Show("Please select the settings you would prefer for the game");

            // call savelines method
            SaveLines();

            // create the keys for the dictionary
            settingVals.Add("Flashlight", 2);
            settingVals.Add("EnemySpeed", 2);
            settingVals.Add("Level", 2);
            settingVals.Add("Riddles", 2);
            
            // set color
            this.BackColor = Color.Black;

            // set text colors
            label1.ForeColor = Color.White;
            EasyRiddle.ForeColor = Color.White;
            EasyButton.ForeColor = Color.White;
            MediumButton.ForeColor = Color.White;
            HardRiddle.ForeColor = Color.White;
            AvgRiddle.ForeColor = Color.White;
            EnemyAvg.ForeColor = Color.White;
            EnemyFast.ForeColor = Color.White;
            EnemySlow.ForeColor = Color.White;
            LightFullBut.ForeColor = Color.White;
            LightLowBut.ForeColor = Color.White;
            LightMedBut.ForeColor = Color.White;
            LightOffBut.ForeColor = Color.White;
            HardButton.ForeColor = Color.White;
            LevelFour.ForeColor = Color.White;
            LevelOne.ForeColor = Color.White;
            LevelThree.ForeColor = Color.White;
            LevelTwo.ForeColor = Color.White;
            NeedToSolve.ForeColor = Color.White;
            RiddleBox.ForeColor = Color.White;
            EasySetBox.ForeColor = Color.White;
            EnemySpeedBox.ForeColor = Color.White;
            BegLvlBox.ForeColor = Color.White;
            LightSetBox.ForeColor = Color.White;
            CustomBox.ForeColor = Color.White;
            ApplyBut.ForeColor = Color.White;
            CancelBut.ForeColor = Color.White;
            HelpBut.ForeColor = Color.White;
            ApplyBut.BackColor = Color.DarkGray;
            CancelBut.BackColor = Color.DarkGray;
            HelpBut.BackColor = Color.DarkGray;
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

                // set settings based on what is in the dictionary
                output.WriteLine(settingVals["Flashlight"]);
                output.WriteLine(settingVals["EnemySpeed"]);
                output.WriteLine(settingVals["Level"]);
                output.WriteLine(settingVals["Riddles"]);

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
                settingVals["Flashlight"] = 0;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            // change settings for when level one is chosen
            if (LevelOne.Checked == true) settingVals["Level"] = 1;
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            // change settings for when level three is chosen
            if (LevelThree.Checked == true) settingVals["Level"] = 3;
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
                settingVals["Flashlight"] = 3;
                settingVals["EnemySpeed"] = 1;
                settingVals["Levels"] = 1;
                settingVals["Riddles"] = 1;
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
                settingVals["Flashlight"] = 2;
                settingVals["EnemySpeed"] = 2;
                settingVals["Levels"] = 2;
                settingVals["Riddles"] = 2;
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
                settingVals["Flashlight"] = 1;
                settingVals["EnemySpeed"] = 3;
                settingVals["Levels"] = 3;
                settingVals["Riddles"] = 3;
            }
        }

        private void LevelFour_CheckedChanged(object sender, EventArgs e)
        {
            // change setting for when level 4 is slected for starting level
            if(LevelFour.Checked == true)
            {
                settingVals["Level"] = 0;
            }
        }

        private void NeedToSolve_CheckedChanged(object sender, EventArgs e)
        {
            // change settings for is the riddle needs to be solved
            if(NeedToSolve.Checked == true)
            {
                settingVals["Riddles"] = 0;
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

        private void LightLowBut_CheckedChanged(object sender, EventArgs e)
        {
            // change settings for when 33% light is chosen
            if (LightLowBut.Checked == true) settingVals["Flashlight"] = 1;
        }

        private void LightMedBut_CheckedChanged(object sender, EventArgs e)
        {
            // change settings for when 66% light is chosen
            if (LightMedBut.Checked == true) settingVals["Flashlight"] = 2;
        }

        private void LightFullBut_CheckedChanged(object sender, EventArgs e)
        {
            // change settings for when 100% light is chosen
            if (LightFullBut.Checked == true) settingVals["Flashlight"] = 3;
        }

        private void EnemySlow_CheckedChanged(object sender, EventArgs e)
        {
            // change settings for when slow speed is chosen
            if (EnemySlow.Checked == true) settingVals["EnemySpeed"] = 1;
        }

        private void EnemyAvg_CheckedChanged(object sender, EventArgs e)
        {
            // change settings for when average speed is chosen
            if (EnemyAvg.Checked == true) settingVals["EnemySpeed"] = 2;
        }

        private void EnemyFast_CheckedChanged(object sender, EventArgs e)
        {
            // change settings for when fast speed is chosen
            if (EnemyFast.Checked == true) settingVals["EnemySpeed"] = 3;
        }

        private void LevelTwo_CheckedChanged(object sender, EventArgs e)
        {
            // change settings for when level two is chosen
            if (LevelTwo.Checked == true) settingVals["Level"] = 2;
        }

        private void EasyRiddle_CheckedChanged(object sender, EventArgs e)
        {
            // change settings for when easy riddles is chosen
            if (EasyRiddle.Checked == true) settingVals["Riddles"] = 1;
        }

        private void AvgRiddle_CheckedChanged(object sender, EventArgs e)
        {
            // change settings for when average riddles is chosen
            if (AvgRiddle.Checked == true) settingVals["Riddles"] = 2;
        }

        private void HardRiddle_CheckedChanged(object sender, EventArgs e)
        {
            // change settings for when Hard riddles is chosen
            if (HardRiddle.Checked == true) settingVals["Riddles"] = 3;
        }
        
        private void HelpBut_Click(object sender, EventArgs e)
        {
            // Display a messagebox informing the user of the functions of the settings
            MessageBox.Show("Need Help?" + Environment.NewLine + 
                "Here is a quick tutorial :3" + Environment.NewLine + Environment.NewLine +
                "Easy Settings:" +Environment.NewLine +
                "   A general difficulty preset (Easy,Medium, and Hard)" + Environment.NewLine +
                "Custom settings:"+ Environment.NewLine + 
                "   Controls the difficulty of individual aspects of the game" + Environment.NewLine +
                "Flashlight Brightness:" + Environment.NewLine +
                "   Sets the area visable to the player when the flashlight is turned on" + Environment.NewLine +
                "Enemy Speed:" + Environment.NewLine +
                "   Changes the speed the enemy will move" + Environment.NewLine +
                "Beginning Level:" + Environment.NewLine +
                "   Sets the first game map to be played on" + Environment.NewLine +
                "Riddle Settings:" + Environment.NewLine +
                "   Changes the difficulty of riddles and wether to spawn key objects");
        }
    }
}
