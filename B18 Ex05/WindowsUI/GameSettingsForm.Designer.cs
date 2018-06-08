using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsUI
{
    partial class GameSettingsForm
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
            this.DoneButton = new System.Windows.Forms.Button();
            this.radio6x6 = new System.Windows.Forms.RadioButton();
            this.radio10x10 = new System.Windows.Forms.RadioButton();
            this.radio8x8 = new System.Windows.Forms.RadioButton();
            this.boardSizeLabel = new System.Windows.Forms.Label();
            this.playersLabel = new System.Windows.Forms.Label();
            this.player1Label = new System.Windows.Forms.Label();
            this.player2Label = new System.Windows.Forms.Label();
            this.secondPlayerCheckBox = new System.Windows.Forms.CheckBox();
            this.firstPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.secondPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DoneButton
            // 
            this.DoneButton.Enabled = false;
            this.DoneButton.Location = new System.Drawing.Point(382, 370);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(216, 65);
            this.DoneButton.TabIndex = 0;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // radio6x6
            // 
            this.radio6x6.AutoSize = true;
            this.radio6x6.Location = new System.Drawing.Point(63, 90);
            this.radio6x6.Name = "radio6x6";
            this.radio6x6.Size = new System.Drawing.Size(112, 36);
            this.radio6x6.TabIndex = 1;
            this.radio6x6.TabStop = true;
            this.radio6x6.Text = "6 x 6";
            this.radio6x6.UseVisualStyleBackColor = true;
            // 
            // radio10x10
            // 
            this.radio10x10.AutoSize = true;
            this.radio10x10.Location = new System.Drawing.Point(382, 90);
            this.radio10x10.Name = "radio10x10";
            this.radio10x10.Size = new System.Drawing.Size(144, 36);
            this.radio10x10.TabIndex = 2;
            this.radio10x10.TabStop = true;
            this.radio10x10.Text = "10 x 10";
            this.radio10x10.UseVisualStyleBackColor = true;
            // 
            // radio8x8
            // 
            this.radio8x8.AutoSize = true;
            this.radio8x8.Location = new System.Drawing.Point(224, 90);
            this.radio8x8.Name = "radio8x8";
            this.radio8x8.Size = new System.Drawing.Size(112, 36);
            this.radio8x8.TabIndex = 3;
            this.radio8x8.TabStop = true;
            this.radio8x8.Text = "8 x 8";
            this.radio8x8.UseVisualStyleBackColor = true;
            // 
            // boardSizeLabel
            // 
            this.boardSizeLabel.AutoSize = true;
            this.boardSizeLabel.Location = new System.Drawing.Point(57, 35);
            this.boardSizeLabel.Name = "boardSizeLabel";
            this.boardSizeLabel.Size = new System.Drawing.Size(162, 32);
            this.boardSizeLabel.TabIndex = 4;
            this.boardSizeLabel.Text = "Board Size:";
            // 
            // playersLabel
            // 
            this.playersLabel.AutoSize = true;
            this.playersLabel.Location = new System.Drawing.Point(57, 166);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(118, 32);
            this.playersLabel.TabIndex = 5;
            this.playersLabel.Text = "Players:";
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.Location = new System.Drawing.Point(78, 224);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(127, 32);
            this.player1Label.TabIndex = 6;
            this.player1Label.Text = "Player 1:";
            // 
            // player2Label
            // 
            this.player2Label.AutoSize = true;
            this.player2Label.Location = new System.Drawing.Point(124, 284);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(127, 32);
            this.player2Label.TabIndex = 7;
            this.player2Label.Text = "Player 2:";
            // 
            // secondPlayerCheckBox
            // 
            this.secondPlayerCheckBox.AutoSize = true;
            this.secondPlayerCheckBox.Location = new System.Drawing.Point(84, 284);
            this.secondPlayerCheckBox.Name = "secondPlayerCheckBox";
            this.secondPlayerCheckBox.Size = new System.Drawing.Size(34, 33);
            this.secondPlayerCheckBox.TabIndex = 8;
            this.secondPlayerCheckBox.UseVisualStyleBackColor = true;
            this.secondPlayerCheckBox.Click += new System.EventHandler(this.checkBox_Checked);
            // 
            // firstPlayerNameTextBox
            // 
            this.firstPlayerNameTextBox.Location = new System.Drawing.Point(311, 224);
            this.firstPlayerNameTextBox.Name = "firstPlayerNameTextBox";
            this.firstPlayerNameTextBox.Size = new System.Drawing.Size(215, 38);
            this.firstPlayerNameTextBox.TabIndex = 9;
            this.firstPlayerNameTextBox.TextChanged += new System.EventHandler(this.firstPlayerNameTextBox_TextChanged);
            // 
            // secondPlayerNameTextBox
            // 
            this.secondPlayerNameTextBox.Enabled = false;
            this.secondPlayerNameTextBox.Location = new System.Drawing.Point(311, 281);
            this.secondPlayerNameTextBox.Name = "secondPlayerNameTextBox";
            this.secondPlayerNameTextBox.Size = new System.Drawing.Size(215, 38);
            this.secondPlayerNameTextBox.TabIndex = 10;
            this.secondPlayerNameTextBox.Text = "[Computer]";
            this.secondPlayerNameTextBox.TextChanged += new System.EventHandler(this.secondPlayerNameTextBox_TextChanged);
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 450);
            this.Controls.Add(this.secondPlayerNameTextBox);
            this.Controls.Add(this.firstPlayerNameTextBox);
            this.Controls.Add(this.secondPlayerCheckBox);
            this.Controls.Add(this.player2Label);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.playersLabel);
            this.Controls.Add(this.boardSizeLabel);
            this.Controls.Add(this.radio8x8);
            this.Controls.Add(this.radio10x10);
            this.Controls.Add(this.radio6x6);
            this.Controls.Add(this.DoneButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button DoneButton;
        private RadioButton radio6x6;
        private RadioButton radio10x10;
        private RadioButton radio8x8;
        private Label boardSizeLabel;
        private Label playersLabel;
        private Label player1Label;
        private Label player2Label;
        private CheckBox secondPlayerCheckBox;
        private TextBox firstPlayerNameTextBox;
        private TextBox secondPlayerNameTextBox;

       

    }
}

