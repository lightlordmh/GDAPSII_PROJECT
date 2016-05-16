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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.EasySetBox = new System.Windows.Forms.GroupBox();
            this.HardButton = new System.Windows.Forms.RadioButton();
            this.MediumButton = new System.Windows.Forms.RadioButton();
            this.EasyButton = new System.Windows.Forms.RadioButton();
            this.CustomBox = new System.Windows.Forms.GroupBox();
            this.EnemySpeedBox = new System.Windows.Forms.GroupBox();
            this.EnemyAvg = new System.Windows.Forms.RadioButton();
            this.EnemyFast = new System.Windows.Forms.RadioButton();
            this.EnemySlow = new System.Windows.Forms.RadioButton();
            this.LightSetBox = new System.Windows.Forms.GroupBox();
            this.LightLowBut = new System.Windows.Forms.RadioButton();
            this.LightMedBut = new System.Windows.Forms.RadioButton();
            this.LightFullBut = new System.Windows.Forms.RadioButton();
            this.LightOffBut = new System.Windows.Forms.RadioButton();
            this.ApplyBut = new System.Windows.Forms.Button();
            this.CancelBut = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.HelpBut = new System.Windows.Forms.Button();
            this.EasySetBox.SuspendLayout();
            this.CustomBox.SuspendLayout();
            this.EnemySpeedBox.SuspendLayout();
            this.LightSetBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Moire", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Adjust Settings";
            // 
            // EasySetBox
            // 
            this.EasySetBox.Controls.Add(this.HardButton);
            this.EasySetBox.Controls.Add(this.MediumButton);
            this.EasySetBox.Controls.Add(this.EasyButton);
            this.EasySetBox.Font = new System.Drawing.Font("Moire", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EasySetBox.Location = new System.Drawing.Point(141, 75);
            this.EasySetBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EasySetBox.Name = "EasySetBox";
            this.EasySetBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EasySetBox.Size = new System.Drawing.Size(372, 100);
            this.EasySetBox.TabIndex = 1;
            this.EasySetBox.TabStop = false;
            this.EasySetBox.Text = "Easy Settings";
            this.toolTip1.SetToolTip(this.EasySetBox, "3 preset game difficulties");
            // 
            // HardButton
            // 
            this.HardButton.AutoSize = true;
            this.HardButton.Font = new System.Drawing.Font("Moire", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HardButton.Location = new System.Drawing.Point(268, 44);
            this.HardButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HardButton.Name = "HardButton";
            this.HardButton.Size = new System.Drawing.Size(64, 21);
            this.HardButton.TabIndex = 3;
            this.HardButton.TabStop = true;
            this.HardButton.Text = "Hard";
            this.HardButton.UseVisualStyleBackColor = true;
            this.HardButton.CheckedChanged += new System.EventHandler(this.HardButton_CheckedChanged);
            // 
            // MediumButton
            // 
            this.MediumButton.AutoSize = true;
            this.MediumButton.Font = new System.Drawing.Font("Moire", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MediumButton.Location = new System.Drawing.Point(147, 44);
            this.MediumButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MediumButton.Name = "MediumButton";
            this.MediumButton.Size = new System.Drawing.Size(85, 21);
            this.MediumButton.TabIndex = 4;
            this.MediumButton.TabStop = true;
            this.MediumButton.Text = "Medium";
            this.MediumButton.UseVisualStyleBackColor = true;
            this.MediumButton.CheckedChanged += new System.EventHandler(this.MediumButton_CheckedChanged);
            // 
            // EasyButton
            // 
            this.EasyButton.AutoSize = true;
            this.EasyButton.Font = new System.Drawing.Font("Moire", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EasyButton.Location = new System.Drawing.Point(43, 44);
            this.EasyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EasyButton.Name = "EasyButton";
            this.EasyButton.Size = new System.Drawing.Size(62, 21);
            this.EasyButton.TabIndex = 2;
            this.EasyButton.TabStop = true;
            this.EasyButton.Text = "Easy";
            this.EasyButton.UseVisualStyleBackColor = true;
            this.EasyButton.CheckedChanged += new System.EventHandler(this.EasyButton_CheckedChanged);
            // 
            // CustomBox
            // 
            this.CustomBox.Controls.Add(this.EnemySpeedBox);
            this.CustomBox.Controls.Add(this.LightSetBox);
            this.CustomBox.Font = new System.Drawing.Font("Moire", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomBox.Location = new System.Drawing.Point(12, 207);
            this.CustomBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CustomBox.Name = "CustomBox";
            this.CustomBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CustomBox.Size = new System.Drawing.Size(669, 418);
            this.CustomBox.TabIndex = 2;
            this.CustomBox.TabStop = false;
            this.CustomBox.Text = "Custom Settings";
            this.toolTip1.SetToolTip(this.CustomBox, "Settings for fine manipulation of the game\'s difficulty");
            // 
            // EnemySpeedBox
            // 
            this.EnemySpeedBox.Controls.Add(this.EnemyAvg);
            this.EnemySpeedBox.Controls.Add(this.EnemyFast);
            this.EnemySpeedBox.Controls.Add(this.EnemySlow);
            this.EnemySpeedBox.Font = new System.Drawing.Font("Moire", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnemySpeedBox.Location = new System.Drawing.Point(23, 243);
            this.EnemySpeedBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EnemySpeedBox.Name = "EnemySpeedBox";
            this.EnemySpeedBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EnemySpeedBox.Size = new System.Drawing.Size(612, 100);
            this.EnemySpeedBox.TabIndex = 1;
            this.EnemySpeedBox.TabStop = false;
            this.EnemySpeedBox.Text = "Enemy Speed";
            this.toolTip1.SetToolTip(this.EnemySpeedBox, "Set the Speed of the Enemy");
            // 
            // EnemyAvg
            // 
            this.EnemyAvg.AutoSize = true;
            this.EnemyAvg.Location = new System.Drawing.Point(253, 41);
            this.EnemyAvg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EnemyAvg.Name = "EnemyAvg";
            this.EnemyAvg.Size = new System.Drawing.Size(92, 22);
            this.EnemyAvg.TabIndex = 2;
            this.EnemyAvg.TabStop = true;
            this.EnemyAvg.Text = "Average";
            this.EnemyAvg.UseVisualStyleBackColor = true;
            this.EnemyAvg.CheckedChanged += new System.EventHandler(this.EnemyAvg_CheckedChanged);
            // 
            // EnemyFast
            // 
            this.EnemyFast.AutoSize = true;
            this.EnemyFast.Location = new System.Drawing.Point(536, 41);
            this.EnemyFast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EnemyFast.Name = "EnemyFast";
            this.EnemyFast.Size = new System.Drawing.Size(62, 22);
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
            this.EnemySlow.Size = new System.Drawing.Size(65, 22);
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
            this.LightSetBox.Font = new System.Drawing.Font("Moire", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LightSetBox.Location = new System.Drawing.Point(23, 46);
            this.LightSetBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LightSetBox.Name = "LightSetBox";
            this.LightSetBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LightSetBox.Size = new System.Drawing.Size(612, 100);
            this.LightSetBox.TabIndex = 0;
            this.LightSetBox.TabStop = false;
            this.LightSetBox.Text = "Flashlight Brightness";
            this.toolTip1.SetToolTip(this.LightSetBox, "Set the area visable to the player when the Flashlight is turned on");
            // 
            // LightLowBut
            // 
            this.LightLowBut.AutoSize = true;
            this.LightLowBut.Location = new System.Drawing.Point(174, 41);
            this.LightLowBut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LightLowBut.Name = "LightLowBut";
            this.LightLowBut.Size = new System.Drawing.Size(60, 22);
            this.LightLowBut.TabIndex = 2;
            this.LightLowBut.TabStop = true;
            this.LightLowBut.Text = "33%";
            this.LightLowBut.UseVisualStyleBackColor = true;
            this.LightLowBut.CheckedChanged += new System.EventHandler(this.LightLowBut_CheckedChanged);
            // 
            // LightMedBut
            // 
            this.LightMedBut.AutoSize = true;
            this.LightMedBut.Location = new System.Drawing.Point(345, 41);
            this.LightMedBut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LightMedBut.Name = "LightMedBut";
            this.LightMedBut.Size = new System.Drawing.Size(60, 22);
            this.LightMedBut.TabIndex = 3;
            this.LightMedBut.TabStop = true;
            this.LightMedBut.Text = "66%";
            this.LightMedBut.UseVisualStyleBackColor = true;
            this.LightMedBut.CheckedChanged += new System.EventHandler(this.LightMedBut_CheckedChanged);
            // 
            // LightFullBut
            // 
            this.LightFullBut.AutoSize = true;
            this.LightFullBut.Location = new System.Drawing.Point(536, 41);
            this.LightFullBut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LightFullBut.Name = "LightFullBut";
            this.LightFullBut.Size = new System.Drawing.Size(70, 22);
            this.LightFullBut.TabIndex = 4;
            this.LightFullBut.TabStop = true;
            this.LightFullBut.Text = "100%";
            this.LightFullBut.UseVisualStyleBackColor = true;
            this.LightFullBut.CheckedChanged += new System.EventHandler(this.LightFullBut_CheckedChanged);
            // 
            // LightOffBut
            // 
            this.LightOffBut.AutoSize = true;
            this.LightOffBut.Location = new System.Drawing.Point(20, 41);
            this.LightOffBut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LightOffBut.Name = "LightOffBut";
            this.LightOffBut.Size = new System.Drawing.Size(51, 22);
            this.LightOffBut.TabIndex = 1;
            this.LightOffBut.TabStop = true;
            this.LightOffBut.Text = "Off";
            this.LightOffBut.UseVisualStyleBackColor = true;
            this.LightOffBut.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // ApplyBut
            // 
            this.ApplyBut.Font = new System.Drawing.Font("Moire", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyBut.Location = new System.Drawing.Point(12, 658);
            this.ApplyBut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ApplyBut.Name = "ApplyBut";
            this.ApplyBut.Size = new System.Drawing.Size(91, 34);
            this.ApplyBut.TabIndex = 4;
            this.ApplyBut.Text = "Apply";
            this.toolTip1.SetToolTip(this.ApplyBut, "Save the changes and close the external tool");
            this.ApplyBut.UseVisualStyleBackColor = true;
            this.ApplyBut.Click += new System.EventHandler(this.ApplyBut_Click);
            // 
            // CancelBut
            // 
            this.CancelBut.Font = new System.Drawing.Font("Moire", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBut.Location = new System.Drawing.Point(556, 658);
            this.CancelBut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CancelBut.Name = "CancelBut";
            this.CancelBut.Size = new System.Drawing.Size(91, 34);
            this.CancelBut.TabIndex = 5;
            this.CancelBut.Text = "Cancel";
            this.toolTip1.SetToolTip(this.CancelBut, "Close the external tool without saving");
            this.CancelBut.UseVisualStyleBackColor = true;
            this.CancelBut.Click += new System.EventHandler(this.CancelBut_Click);
            // 
            // HelpBut
            // 
            this.HelpBut.Font = new System.Drawing.Font("Moire", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpBut.Location = new System.Drawing.Point(575, 9);
            this.HelpBut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HelpBut.Name = "HelpBut";
            this.HelpBut.Size = new System.Drawing.Size(100, 28);
            this.HelpBut.TabIndex = 6;
            this.HelpBut.Text = "Help";
            this.toolTip1.SetToolTip(this.HelpBut, "Brings up the help menu");
            this.HelpBut.UseVisualStyleBackColor = true;
            this.HelpBut.Click += new System.EventHandler(this.HelpBut_Click);
            // 
            // SettingsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 706);
            this.Controls.Add(this.HelpBut);
            this.Controls.Add(this.CancelBut);
            this.Controls.Add(this.ApplyBut);
            this.Controls.Add(this.CustomBox);
            this.Controls.Add(this.EasySetBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SettingsManager";
            this.Text = "Settings Manager";
            this.EasySetBox.ResumeLayout(false);
            this.EasySetBox.PerformLayout();
            this.CustomBox.ResumeLayout(false);
            this.EnemySpeedBox.ResumeLayout(false);
            this.EnemySpeedBox.PerformLayout();
            this.LightSetBox.ResumeLayout(false);
            this.LightSetBox.PerformLayout();
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
        private System.Windows.Forms.Button ApplyBut;
        private System.Windows.Forms.Button CancelBut;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button HelpBut;
    }
}

