namespace External_Tool
{
    partial class SettingsManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.EasySetBox = new System.Windows.Forms.GroupBox();
            this.HardButton = new System.Windows.Forms.RadioButton();
            this.MediumButton = new System.Windows.Forms.RadioButton();
            this.EasyButton = new System.Windows.Forms.RadioButton();
            this.CustomBox = new System.Windows.Forms.GroupBox();
            this.RiddleBox = new System.Windows.Forms.GroupBox();
            this.AvgRiddle = new System.Windows.Forms.RadioButton();
            this.HardRiddle = new System.Windows.Forms.RadioButton();
            this.NeedToSolve = new System.Windows.Forms.RadioButton();
            this.EasyRiddle = new System.Windows.Forms.RadioButton();
            this.EnemySpeedBox = new System.Windows.Forms.GroupBox();
            this.EnemyAvg = new System.Windows.Forms.RadioButton();
            this.EnemyFast = new System.Windows.Forms.RadioButton();
            this.EnemySlow = new System.Windows.Forms.RadioButton();
            this.LightSetBox = new System.Windows.Forms.GroupBox();
            this.LightLowBut = new System.Windows.Forms.RadioButton();
            this.LightMedBut = new System.Windows.Forms.RadioButton();
            this.LightFullBut = new System.Windows.Forms.RadioButton();
            this.LightOffBut = new System.Windows.Forms.RadioButton();
            this.BegLvlBox = new System.Windows.Forms.GroupBox();
            this.LevelTwo = new System.Windows.Forms.RadioButton();
            this.LevelThree = new System.Windows.Forms.RadioButton();
            this.LevelFour = new System.Windows.Forms.RadioButton();
            this.LevelOne = new System.Windows.Forms.RadioButton();
            this.ApplyBut = new System.Windows.Forms.Button();
            this.CancelBut = new System.Windows.Forms.Button();
            this.EasySetBox.SuspendLayout();
            this.CustomBox.SuspendLayout();
            this.RiddleBox.SuspendLayout();
            this.EnemySpeedBox.SuspendLayout();
            this.LightSetBox.SuspendLayout();
            this.BegLvlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mistral", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(216, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Adjust Settings";
            // 
            // EasySetBox
            // 
            this.EasySetBox.Controls.Add(this.HardButton);
            this.EasySetBox.Controls.Add(this.MediumButton);
            this.EasySetBox.Controls.Add(this.EasyButton);
            this.EasySetBox.Font = new System.Drawing.Font("Mistral", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EasySetBox.Location = new System.Drawing.Point(141, 75);
            this.EasySetBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EasySetBox.Name = "EasySetBox";
            this.EasySetBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EasySetBox.Size = new System.Drawing.Size(372, 100);
            this.EasySetBox.TabIndex = 1;
            this.EasySetBox.TabStop = false;
            this.EasySetBox.Text = "Easy Settings";
            // 
            // HardButton
            // 
            this.HardButton.AutoSize = true;
            this.HardButton.Font = new System.Drawing.Font("Mistral", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HardButton.Location = new System.Drawing.Point(259, 42);
            this.HardButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HardButton.Name = "HardButton";
            this.HardButton.Size = new System.Drawing.Size(58, 24);
            this.HardButton.TabIndex = 3;
            this.HardButton.TabStop = true;
            this.HardButton.Text = "Hard";
            this.HardButton.UseVisualStyleBackColor = true;
            this.HardButton.CheckedChanged += new System.EventHandler(this.HardButton_CheckedChanged);
            // 
            // MediumButton
            // 
            this.MediumButton.AutoSize = true;
            this.MediumButton.Font = new System.Drawing.Font("Mistral", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MediumButton.Location = new System.Drawing.Point(125, 42);
            this.MediumButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MediumButton.Name = "MediumButton";
            this.MediumButton.Size = new System.Drawing.Size(73, 24);
            this.MediumButton.TabIndex = 4;
            this.MediumButton.TabStop = true;
            this.MediumButton.Text = "Medium";
            this.MediumButton.UseVisualStyleBackColor = true;
            this.MediumButton.CheckedChanged += new System.EventHandler(this.MediumButton_CheckedChanged);
            // 
            // EasyButton
            // 
            this.EasyButton.AutoSize = true;
            this.EasyButton.Font = new System.Drawing.Font("Mistral", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EasyButton.Location = new System.Drawing.Point(5, 42);
            this.EasyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EasyButton.Name = "EasyButton";
            this.EasyButton.Size = new System.Drawing.Size(55, 24);
            this.EasyButton.TabIndex = 2;
            this.EasyButton.TabStop = true;
            this.EasyButton.Text = "Easy";
            this.EasyButton.UseVisualStyleBackColor = true;
            this.EasyButton.CheckedChanged += new System.EventHandler(this.EasyButton_CheckedChanged);
            // 
            // CustomBox
            // 
            this.CustomBox.Controls.Add(this.RiddleBox);
            this.CustomBox.Controls.Add(this.EnemySpeedBox);
            this.CustomBox.Controls.Add(this.LightSetBox);
            this.CustomBox.Font = new System.Drawing.Font("Mistral", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomBox.Location = new System.Drawing.Point(12, 207);
            this.CustomBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CustomBox.Name = "CustomBox";
            this.CustomBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CustomBox.Size = new System.Drawing.Size(669, 418);
            this.CustomBox.TabIndex = 2;
            this.CustomBox.TabStop = false;
            this.CustomBox.Text = "Custom Settings";
            // 
            // RiddleBox
            // 
            this.RiddleBox.Controls.Add(this.AvgRiddle);
            this.RiddleBox.Controls.Add(this.HardRiddle);
            this.RiddleBox.Controls.Add(this.NeedToSolve);
            this.RiddleBox.Controls.Add(this.EasyRiddle);
            this.RiddleBox.Font = new System.Drawing.Font("Mistral", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RiddleBox.Location = new System.Drawing.Point(0, 313);
            this.RiddleBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RiddleBox.Name = "RiddleBox";
            this.RiddleBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RiddleBox.Size = new System.Drawing.Size(664, 100);
            this.RiddleBox.TabIndex = 2;
            this.RiddleBox.TabStop = false;
            this.RiddleBox.Text = "Riddle Settings";
            // 
            // AvgRiddle
            // 
            this.AvgRiddle.AutoSize = true;
            this.AvgRiddle.Location = new System.Drawing.Point(249, 26);
            this.AvgRiddle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AvgRiddle.Name = "AvgRiddle";
            this.AvgRiddle.Size = new System.Drawing.Size(73, 26);
            this.AvgRiddle.TabIndex = 3;
            this.AvgRiddle.TabStop = true;
            this.AvgRiddle.Text = "Average";
            this.AvgRiddle.UseVisualStyleBackColor = true;
            this.AvgRiddle.CheckedChanged += new System.EventHandler(this.AvgRiddle_CheckedChanged);
            // 
            // HardRiddle
            // 
            this.HardRiddle.AutoSize = true;
            this.HardRiddle.Location = new System.Drawing.Point(461, 26);
            this.HardRiddle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HardRiddle.Name = "HardRiddle";
            this.HardRiddle.Size = new System.Drawing.Size(129, 26);
            this.HardRiddle.TabIndex = 2;
            this.HardRiddle.TabStop = true;
            this.HardRiddle.Text = "Head Scratching";
            this.HardRiddle.UseVisualStyleBackColor = true;
            this.HardRiddle.CheckedChanged += new System.EventHandler(this.HardRiddle_CheckedChanged);
            // 
            // NeedToSolve
            // 
            this.NeedToSolve.AutoSize = true;
            this.NeedToSolve.Location = new System.Drawing.Point(167, 73);
            this.NeedToSolve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NeedToSolve.Name = "NeedToSolve";
            this.NeedToSolve.Size = new System.Drawing.Size(267, 26);
            this.NeedToSolve.TabIndex = 1;
            this.NeedToSolve.TabStop = true;
            this.NeedToSolve.Text = "Keys Don\'t appear until Riddle Solved";
            this.NeedToSolve.UseVisualStyleBackColor = true;
            this.NeedToSolve.CheckedChanged += new System.EventHandler(this.NeedToSolve_CheckedChanged);
            // 
            // EasyRiddle
            // 
            this.EasyRiddle.AutoSize = true;
            this.EasyRiddle.Location = new System.Drawing.Point(5, 26);
            this.EasyRiddle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EasyRiddle.Name = "EasyRiddle";
            this.EasyRiddle.Size = new System.Drawing.Size(60, 26);
            this.EasyRiddle.TabIndex = 0;
            this.EasyRiddle.TabStop = true;
            this.EasyRiddle.Text = "Easy";
            this.EasyRiddle.UseVisualStyleBackColor = true;
            this.EasyRiddle.CheckedChanged += new System.EventHandler(this.EasyRiddle_CheckedChanged);
            // 
            // EnemySpeedBox
            // 
            this.EnemySpeedBox.Controls.Add(this.EnemyAvg);
            this.EnemySpeedBox.Controls.Add(this.EnemyFast);
            this.EnemySpeedBox.Controls.Add(this.EnemySlow);
            this.EnemySpeedBox.Font = new System.Drawing.Font("Mistral", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnemySpeedBox.Location = new System.Drawing.Point(379, 49);
            this.EnemySpeedBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EnemySpeedBox.Name = "EnemySpeedBox";
            this.EnemySpeedBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EnemySpeedBox.Size = new System.Drawing.Size(285, 100);
            this.EnemySpeedBox.TabIndex = 1;
            this.EnemySpeedBox.TabStop = false;
            this.EnemySpeedBox.Text = "Enemy Speed";
            // 
            // EnemyAvg
            // 
            this.EnemyAvg.AutoSize = true;
            this.EnemyAvg.Location = new System.Drawing.Point(99, 41);
            this.EnemyAvg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EnemyAvg.Name = "EnemyAvg";
            this.EnemyAvg.Size = new System.Drawing.Size(73, 26);
            this.EnemyAvg.TabIndex = 2;
            this.EnemyAvg.TabStop = true;
            this.EnemyAvg.Text = "Average";
            this.EnemyAvg.UseVisualStyleBackColor = true;
            this.EnemyAvg.CheckedChanged += new System.EventHandler(this.EnemyAvg_CheckedChanged);
            // 
            // EnemyFast
            // 
            this.EnemyFast.AutoSize = true;
            this.EnemyFast.Location = new System.Drawing.Point(209, 41);
            this.EnemyFast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EnemyFast.Name = "EnemyFast";
            this.EnemyFast.Size = new System.Drawing.Size(57, 26);
            this.EnemyFast.TabIndex = 1;
            this.EnemyFast.TabStop = true;
            this.EnemyFast.Text = "Fast";
            this.EnemyFast.UseVisualStyleBackColor = true;
            this.EnemyFast.CheckedChanged += new System.EventHandler(this.EnemyFast_CheckedChanged);
            // 
            // EnemySlow
            // 
            this.EnemySlow.AutoSize = true;
            this.EnemySlow.Location = new System.Drawing.Point(20, 41);
            this.EnemySlow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EnemySlow.Name = "EnemySlow";
            this.EnemySlow.Size = new System.Drawing.Size(59, 26);
            this.EnemySlow.TabIndex = 0;
            this.EnemySlow.TabStop = true;
            this.EnemySlow.Text = "Slow";
            this.EnemySlow.UseVisualStyleBackColor = true;
            this.EnemySlow.CheckedChanged += new System.EventHandler(this.EnemySlow_CheckedChanged);
            // 
            // LightSetBox
            // 
            this.LightSetBox.Controls.Add(this.LightLowBut);
            this.LightSetBox.Controls.Add(this.LightMedBut);
            this.LightSetBox.Controls.Add(this.LightFullBut);
            this.LightSetBox.Controls.Add(this.LightOffBut);
            this.LightSetBox.Font = new System.Drawing.Font("Mistral", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LightSetBox.Location = new System.Drawing.Point(7, 49);
            this.LightSetBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LightSetBox.Name = "LightSetBox";
            this.LightSetBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LightSetBox.Size = new System.Drawing.Size(365, 100);
            this.LightSetBox.TabIndex = 0;
            this.LightSetBox.TabStop = false;
            this.LightSetBox.Text = "Flashlight Brightness";
            // 
            // LightLowBut
            // 
            this.LightLowBut.AutoSize = true;
            this.LightLowBut.Location = new System.Drawing.Point(92, 41);
            this.LightLowBut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LightLowBut.Name = "LightLowBut";
            this.LightLowBut.Size = new System.Drawing.Size(56, 26);
            this.LightLowBut.TabIndex = 2;
            this.LightLowBut.TabStop = true;
            this.LightLowBut.Text = "33%";
            this.LightLowBut.UseVisualStyleBackColor = true;
            this.LightLowBut.CheckedChanged += new System.EventHandler(this.LightLowBut_CheckedChanged);
            // 
            // LightMedBut
            // 
            this.LightMedBut.AutoSize = true;
            this.LightMedBut.Location = new System.Drawing.Point(176, 41);
            this.LightMedBut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LightMedBut.Name = "LightMedBut";
            this.LightMedBut.Size = new System.Drawing.Size(56, 26);
            this.LightMedBut.TabIndex = 3;
            this.LightMedBut.TabStop = true;
            this.LightMedBut.Text = "66%";
            this.LightMedBut.UseVisualStyleBackColor = true;
            this.LightMedBut.CheckedChanged += new System.EventHandler(this.LightMedBut_CheckedChanged);
            // 
            // LightFullBut
            // 
            this.LightFullBut.AutoSize = true;
            this.LightFullBut.Location = new System.Drawing.Point(251, 41);
            this.LightFullBut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LightFullBut.Name = "LightFullBut";
            this.LightFullBut.Size = new System.Drawing.Size(67, 26);
            this.LightFullBut.TabIndex = 4;
            this.LightFullBut.TabStop = true;
            this.LightFullBut.Text = "100%";
            this.LightFullBut.UseVisualStyleBackColor = true;
            this.LightFullBut.CheckedChanged += new System.EventHandler(this.LightFullBut_CheckedChanged);
            // 
            // LightOffBut
            // 
            this.LightOffBut.AutoSize = true;
            this.LightOffBut.Location = new System.Drawing.Point(5, 41);
            this.LightOffBut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LightOffBut.Name = "LightOffBut";
            this.LightOffBut.Size = new System.Drawing.Size(49, 26);
            this.LightOffBut.TabIndex = 1;
            this.LightOffBut.TabStop = true;
            this.LightOffBut.Text = "Off";
            this.LightOffBut.UseVisualStyleBackColor = true;
            this.LightOffBut.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // BegLvlBox
            // 
            this.BegLvlBox.Controls.Add(this.LevelTwo);
            this.BegLvlBox.Controls.Add(this.LevelThree);
            this.BegLvlBox.Controls.Add(this.LevelFour);
            this.BegLvlBox.Controls.Add(this.LevelOne);
            this.BegLvlBox.Font = new System.Drawing.Font("Mistral", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BegLvlBox.Location = new System.Drawing.Point(12, 386);
            this.BegLvlBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BegLvlBox.Name = "BegLvlBox";
            this.BegLvlBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BegLvlBox.Size = new System.Drawing.Size(664, 100);
            this.BegLvlBox.TabIndex = 3;
            this.BegLvlBox.TabStop = false;
            this.BegLvlBox.Text = "Beginning Level";
            // 
            // LevelTwo
            // 
            this.LevelTwo.AutoSize = true;
            this.LevelTwo.Location = new System.Drawing.Point(183, 41);
            this.LevelTwo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LevelTwo.Name = "LevelTwo";
            this.LevelTwo.Size = new System.Drawing.Size(71, 26);
            this.LevelTwo.TabIndex = 3;
            this.LevelTwo.TabStop = true;
            this.LevelTwo.Text = "Level 2";
            this.LevelTwo.UseVisualStyleBackColor = true;
            this.LevelTwo.CheckedChanged += new System.EventHandler(this.LevelTwo_CheckedChanged);
            // 
            // LevelThree
            // 
            this.LevelThree.AutoSize = true;
            this.LevelThree.Location = new System.Drawing.Point(365, 41);
            this.LevelThree.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LevelThree.Name = "LevelThree";
            this.LevelThree.Size = new System.Drawing.Size(70, 26);
            this.LevelThree.TabIndex = 2;
            this.LevelThree.TabStop = true;
            this.LevelThree.Text = "Level 3";
            this.LevelThree.UseVisualStyleBackColor = true;
            this.LevelThree.CheckedChanged += new System.EventHandler(this.radioButton10_CheckedChanged);
            // 
            // LevelFour
            // 
            this.LevelFour.AutoSize = true;
            this.LevelFour.Location = new System.Drawing.Point(532, 41);
            this.LevelFour.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LevelFour.Name = "LevelFour";
            this.LevelFour.Size = new System.Drawing.Size(70, 26);
            this.LevelFour.TabIndex = 1;
            this.LevelFour.TabStop = true;
            this.LevelFour.Text = "Level 4";
            this.LevelFour.UseVisualStyleBackColor = true;
            this.LevelFour.CheckedChanged += new System.EventHandler(this.LevelFour_CheckedChanged);
            // 
            // LevelOne
            // 
            this.LevelOne.AutoSize = true;
            this.LevelOne.Location = new System.Drawing.Point(5, 41);
            this.LevelOne.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LevelOne.Name = "LevelOne";
            this.LevelOne.Size = new System.Drawing.Size(70, 26);
            this.LevelOne.TabIndex = 0;
            this.LevelOne.TabStop = true;
            this.LevelOne.Text = "Level 1";
            this.LevelOne.UseVisualStyleBackColor = true;
            this.LevelOne.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // ApplyBut
            // 
            this.ApplyBut.Font = new System.Drawing.Font("Mistral", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyBut.Location = new System.Drawing.Point(12, 658);
            this.ApplyBut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ApplyBut.Name = "ApplyBut";
            this.ApplyBut.Size = new System.Drawing.Size(91, 34);
            this.ApplyBut.TabIndex = 4;
            this.ApplyBut.Text = "Apply";
            this.ApplyBut.UseVisualStyleBackColor = true;
            this.ApplyBut.Click += new System.EventHandler(this.ApplyBut_Click);
            // 
            // CancelBut
            // 
            this.CancelBut.Font = new System.Drawing.Font("Mistral", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBut.Location = new System.Drawing.Point(556, 658);
            this.CancelBut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CancelBut.Name = "CancelBut";
            this.CancelBut.Size = new System.Drawing.Size(91, 34);
            this.CancelBut.TabIndex = 5;
            this.CancelBut.Text = "Cancel";
            this.CancelBut.UseVisualStyleBackColor = true;
            this.CancelBut.Click += new System.EventHandler(this.CancelBut_Click);
            // 
            // SettingsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 706);
            this.Controls.Add(this.CancelBut);
            this.Controls.Add(this.ApplyBut);
            this.Controls.Add(this.BegLvlBox);
            this.Controls.Add(this.CustomBox);
            this.Controls.Add(this.EasySetBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SettingsManager";
            this.Text = "Settings Manager";
            this.EasySetBox.ResumeLayout(false);
            this.EasySetBox.PerformLayout();
            this.CustomBox.ResumeLayout(false);
            this.RiddleBox.ResumeLayout(false);
            this.RiddleBox.PerformLayout();
            this.EnemySpeedBox.ResumeLayout(false);
            this.EnemySpeedBox.PerformLayout();
            this.LightSetBox.ResumeLayout(false);
            this.LightSetBox.PerformLayout();
            this.BegLvlBox.ResumeLayout(false);
            this.BegLvlBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox EasySetBox;
        private System.Windows.Forms.RadioButton HardButton;
        private System.Windows.Forms.RadioButton MediumButton;
        private System.Windows.Forms.RadioButton EasyButton;
        private System.Windows.Forms.GroupBox CustomBox;
        private System.Windows.Forms.RadioButton LightFullBut;
        private System.Windows.Forms.RadioButton LightMedBut;
        private System.Windows.Forms.RadioButton LightLowBut;
        private System.Windows.Forms.RadioButton LightOffBut;
        private System.Windows.Forms.GroupBox LightSetBox;
        private System.Windows.Forms.GroupBox EnemySpeedBox;
        private System.Windows.Forms.RadioButton EnemyAvg;
        private System.Windows.Forms.RadioButton EnemyFast;
        private System.Windows.Forms.RadioButton EnemySlow;
        private System.Windows.Forms.GroupBox BegLvlBox;
        private System.Windows.Forms.RadioButton LevelOne;
        private System.Windows.Forms.RadioButton LevelTwo;
        private System.Windows.Forms.RadioButton LevelThree;
        private System.Windows.Forms.RadioButton LevelFour;
        private System.Windows.Forms.GroupBox RiddleBox;
        private System.Windows.Forms.RadioButton AvgRiddle;
        private System.Windows.Forms.RadioButton HardRiddle;
        private System.Windows.Forms.RadioButton NeedToSolve;
        private System.Windows.Forms.RadioButton EasyRiddle;
        private System.Windows.Forms.Button ApplyBut;
        private System.Windows.Forms.Button CancelBut;
    }
}

