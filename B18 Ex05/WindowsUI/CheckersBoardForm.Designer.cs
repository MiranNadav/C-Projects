using System.Windows.Forms;

namespace WindowsUI
{
    partial class CheckersBoardForm
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
            this.player1Name = new System.Windows.Forms.Label();
            this.player2Name = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.checkersButton13 = new CheckersComponents.CheckersCheckBox();
            this.checkersButton14 = new CheckersComponents.CheckersCheckBox();
            this.checkersButton15 = new CheckersComponents.CheckersCheckBox();
            this.checkersButton16 = new CheckersComponents.CheckersCheckBox();
            this.checkersButton17 = new CheckersComponents.CheckersCheckBox();
            this.checkersButton18 = new CheckersComponents.CheckersCheckBox();
            this.checkersButton7 = new CheckersComponents.CheckersCheckBox();
            this.checkersButton8 = new CheckersComponents.CheckersCheckBox();
            this.checkersButton9 = new CheckersComponents.CheckersCheckBox();
            this.checkersButton10 = new CheckersComponents.CheckersCheckBox();
            this.checkersButton11 = new CheckersComponents.CheckersCheckBox();
            this.checkersButton12 = new CheckersComponents.CheckersCheckBox();
            this.checkersButton6 = new CheckersComponents.CheckersCheckBox();
            this.checkersButton5 = new CheckersComponents.CheckersCheckBox();
            this.checkersButton4 = new CheckersComponents.CheckersCheckBox();
            this.checkersButton3 = new CheckersComponents.CheckersCheckBox();
            this.checkersButton2 = new CheckersComponents.CheckersCheckBox();
            this.checkersButton1 = new CheckersComponents.CheckersCheckBox();
            this.SuspendLayout();
            // 
            // player1Name
            // 
            this.player1Name.AutoSize = true;
            this.player1Name.Location = new System.Drawing.Point(75, 127);
            this.player1Name.Name = "player1Name";
            this.player1Name.Size = new System.Drawing.Size(102, 32);
            this.player1Name.TabIndex = 0;
            this.player1Name.Text = "Label1";
            // 
            // player2Name
            // 
            this.player2Name.AutoSize = true;
            this.player2Name.Location = new System.Drawing.Point(388, 127);
            this.player2Name.Name = "player2Name";
            this.player2Name.Size = new System.Drawing.Size(102, 32);
            this.player2Name.TabIndex = 1;
            this.player2Name.Text = "Label2";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(47, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 100);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(243, 191);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 100);
            this.button3.TabIndex = 4;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Black;
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(342, 297);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 100);
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Black;
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(146, 297);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 100);
            this.button6.TabIndex = 5;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Black;
            this.button9.Enabled = false;
            this.button9.Location = new System.Drawing.Point(535, 297);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(100, 100);
            this.button9.TabIndex = 8;
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Black;
            this.button11.Enabled = false;
            this.button11.Location = new System.Drawing.Point(439, 191);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(100, 100);
            this.button11.TabIndex = 12;
            this.button11.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(439, 403);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 100);
            this.button2.TabIndex = 50;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Black;
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(535, 509);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 100);
            this.button5.TabIndex = 49;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Black;
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(342, 509);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 100);
            this.button7.TabIndex = 48;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Black;
            this.button8.Enabled = false;
            this.button8.Location = new System.Drawing.Point(146, 509);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 100);
            this.button8.TabIndex = 47;
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Black;
            this.button10.Enabled = false;
            this.button10.Location = new System.Drawing.Point(243, 403);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(100, 100);
            this.button10.TabIndex = 46;
            this.button10.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Black;
            this.button13.Enabled = false;
            this.button13.Location = new System.Drawing.Point(47, 403);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(100, 100);
            this.button13.TabIndex = 45;
            this.button13.UseVisualStyleBackColor = false;
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Black;
            this.button14.Enabled = false;
            this.button14.Location = new System.Drawing.Point(439, 615);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(100, 100);
            this.button14.TabIndex = 62;
            this.button14.UseVisualStyleBackColor = false;
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Black;
            this.button15.Enabled = false;
            this.button15.Location = new System.Drawing.Point(535, 721);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(100, 100);
            this.button15.TabIndex = 61;
            this.button15.UseVisualStyleBackColor = false;
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.Black;
            this.button16.Enabled = false;
            this.button16.Location = new System.Drawing.Point(342, 721);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(100, 100);
            this.button16.TabIndex = 60;
            this.button16.UseVisualStyleBackColor = false;
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.Black;
            this.button17.Enabled = false;
            this.button17.Location = new System.Drawing.Point(146, 721);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(100, 100);
            this.button17.TabIndex = 59;
            this.button17.UseVisualStyleBackColor = false;
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.Black;
            this.button18.Enabled = false;
            this.button18.Location = new System.Drawing.Point(243, 615);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(100, 100);
            this.button18.TabIndex = 58;
            this.button18.UseVisualStyleBackColor = false;
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.Black;
            this.button19.Enabled = false;
            this.button19.Location = new System.Drawing.Point(47, 615);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(100, 100);
            this.button19.TabIndex = 57;
            this.button19.UseVisualStyleBackColor = false;
            // 
            // checkersButton13
            // 
            this.checkersButton13.BackColor = System.Drawing.Color.White;
            this.checkersButton13.Location = new System.Drawing.Point(439, 721);
            this.checkersButton13.Name = "checkersButton13";
            this.checkersButton13.Size = new System.Drawing.Size(100, 100);
            this.checkersButton13.TabIndex = 68;
            this.checkersButton13.UseVisualStyleBackColor = false;
            // 
            // checkersButton14
            // 
            this.checkersButton14.BackColor = System.Drawing.Color.White;
            this.checkersButton14.Location = new System.Drawing.Point(243, 721);
            this.checkersButton14.Name = "checkersButton14";
            this.checkersButton14.Size = new System.Drawing.Size(100, 100);
            this.checkersButton14.TabIndex = 67;
            this.checkersButton14.UseVisualStyleBackColor = false;
            // 
            // checkersButton15
            // 
            this.checkersButton15.BackColor = System.Drawing.Color.White;
            this.checkersButton15.Location = new System.Drawing.Point(47, 720);
            this.checkersButton15.Name = "checkersButton15";
            this.checkersButton15.Size = new System.Drawing.Size(100, 100);
            this.checkersButton15.TabIndex = 66;
            this.checkersButton15.UseVisualStyleBackColor = false;
            // 
            // checkersButton16
            // 
            this.checkersButton16.BackColor = System.Drawing.Color.White;
            this.checkersButton16.Location = new System.Drawing.Point(146, 615);
            this.checkersButton16.Name = "checkersButton16";
            this.checkersButton16.Size = new System.Drawing.Size(100, 100);
            this.checkersButton16.TabIndex = 65;
            this.checkersButton16.UseVisualStyleBackColor = false;
            // 
            // checkersButton17
            // 
            this.checkersButton17.BackColor = System.Drawing.Color.White;
            this.checkersButton17.Location = new System.Drawing.Point(342, 615);
            this.checkersButton17.Name = "checkersButton17";
            this.checkersButton17.Size = new System.Drawing.Size(100, 100);
            this.checkersButton17.TabIndex = 64;
            this.checkersButton17.UseVisualStyleBackColor = false;
            // 
            // checkersButton18
            // 
            this.checkersButton18.BackColor = System.Drawing.Color.White;
            this.checkersButton18.Location = new System.Drawing.Point(535, 615);
            this.checkersButton18.Name = "checkersButton18";
            this.checkersButton18.Size = new System.Drawing.Size(100, 100);
            this.checkersButton18.TabIndex = 63;
            this.checkersButton18.UseVisualStyleBackColor = false;
            // 
            // checkersButton7
            // 
            this.checkersButton7.BackColor = System.Drawing.Color.White;
            this.checkersButton7.Location = new System.Drawing.Point(439, 509);
            this.checkersButton7.Name = "checkersButton7";
            this.checkersButton7.Size = new System.Drawing.Size(100, 100);
            this.checkersButton7.TabIndex = 56;
            this.checkersButton7.UseVisualStyleBackColor = false;
            // 
            // checkersButton8
            // 
            this.checkersButton8.BackColor = System.Drawing.Color.White;
            this.checkersButton8.Location = new System.Drawing.Point(243, 508);
            this.checkersButton8.Name = "checkersButton8";
            this.checkersButton8.Size = new System.Drawing.Size(100, 100);
            this.checkersButton8.TabIndex = 55;
            this.checkersButton8.UseVisualStyleBackColor = false;
            // 
            // checkersButton9
            // 
            this.checkersButton9.BackColor = System.Drawing.Color.White;
            this.checkersButton9.Location = new System.Drawing.Point(47, 508);
            this.checkersButton9.Name = "checkersButton9";
            this.checkersButton9.Size = new System.Drawing.Size(100, 100);
            this.checkersButton9.TabIndex = 54;
            this.checkersButton9.UseVisualStyleBackColor = false;
            // 
            // checkersButton10
            // 
            this.checkersButton10.BackColor = System.Drawing.Color.White;
            this.checkersButton10.Location = new System.Drawing.Point(146, 403);
            this.checkersButton10.Name = "checkersButton10";
            this.checkersButton10.Size = new System.Drawing.Size(100, 100);
            this.checkersButton10.TabIndex = 53;
            this.checkersButton10.UseVisualStyleBackColor = false;
            // 
            // checkersButton11
            // 
            this.checkersButton11.BackColor = System.Drawing.Color.White;
            this.checkersButton11.Location = new System.Drawing.Point(342, 403);
            this.checkersButton11.Name = "checkersButton11";
            this.checkersButton11.Size = new System.Drawing.Size(100, 100);
            this.checkersButton11.TabIndex = 52;
            this.checkersButton11.UseVisualStyleBackColor = false;
            // 
            // checkersButton12
            // 
            this.checkersButton12.BackColor = System.Drawing.Color.White;
            this.checkersButton12.Location = new System.Drawing.Point(535, 403);
            this.checkersButton12.Name = "checkersButton12";
            this.checkersButton12.Size = new System.Drawing.Size(100, 100);
            this.checkersButton12.TabIndex = 51;
            this.checkersButton12.UseVisualStyleBackColor = false;
            // 
            // checkersButton6
            // 
            this.checkersButton6.BackColor = System.Drawing.Color.White;
            this.checkersButton6.Location = new System.Drawing.Point(439, 297);
            this.checkersButton6.Name = "checkersButton6";
            this.checkersButton6.Size = new System.Drawing.Size(100, 100);
            this.checkersButton6.TabIndex = 44;
            this.checkersButton6.UseVisualStyleBackColor = false;
            // 
            // checkersButton5
            // 
            this.checkersButton5.BackColor = System.Drawing.Color.White;
            this.checkersButton5.Location = new System.Drawing.Point(243, 297);
            this.checkersButton5.Name = "checkersButton5";
            this.checkersButton5.Size = new System.Drawing.Size(100, 100);
            this.checkersButton5.TabIndex = 43;
            this.checkersButton5.UseVisualStyleBackColor = false;
            // 
            // checkersButton4
            // 
            this.checkersButton4.BackColor = System.Drawing.Color.White;
            this.checkersButton4.Location = new System.Drawing.Point(47, 296);
            this.checkersButton4.Name = "checkersButton4";
            this.checkersButton4.Size = new System.Drawing.Size(100, 100);
            this.checkersButton4.TabIndex = 42;
            this.checkersButton4.UseVisualStyleBackColor = false;
            // 
            // checkersButton3
            // 
            this.checkersButton3.BackColor = System.Drawing.Color.White;
            this.checkersButton3.Location = new System.Drawing.Point(146, 191);
            this.checkersButton3.Name = "checkersButton3";
            this.checkersButton3.Size = new System.Drawing.Size(100, 100);
            this.checkersButton3.TabIndex = 41;
            this.checkersButton3.UseVisualStyleBackColor = false;
            // 
            // checkersButton2
            // 
            this.checkersButton2.BackColor = System.Drawing.Color.White;
            this.checkersButton2.Location = new System.Drawing.Point(342, 191);
            this.checkersButton2.Name = "checkersButton2";
            this.checkersButton2.Size = new System.Drawing.Size(100, 100);
            this.checkersButton2.TabIndex = 40;
            this.checkersButton2.UseVisualStyleBackColor = false;
            // 
            // checkersButton1
            // 
            this.checkersButton1.BackColor = System.Drawing.Color.White;
            this.checkersButton1.Location = new System.Drawing.Point(535, 191);
            this.checkersButton1.Name = "checkersButton1";
            this.checkersButton1.Size = new System.Drawing.Size(100, 100);
            this.checkersButton1.TabIndex = 39;
            this.checkersButton1.UseVisualStyleBackColor = false;
            // 
            // CheckersBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 919);
            this.Controls.Add(this.checkersButton13);
            this.Controls.Add(this.checkersButton14);
            this.Controls.Add(this.checkersButton15);
            this.Controls.Add(this.checkersButton16);
            this.Controls.Add(this.checkersButton17);
            this.Controls.Add(this.checkersButton18);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.checkersButton7);
            this.Controls.Add(this.checkersButton8);
            this.Controls.Add(this.checkersButton9);
            this.Controls.Add(this.checkersButton10);
            this.Controls.Add(this.checkersButton11);
            this.Controls.Add(this.checkersButton12);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.checkersButton6);
            this.Controls.Add(this.checkersButton5);
            this.Controls.Add(this.checkersButton4);
            this.Controls.Add(this.checkersButton3);
            this.Controls.Add(this.checkersButton2);
            this.Controls.Add(this.checkersButton1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.player2Name);
            this.Controls.Add(this.player1Name);
            this.Name = "CheckersBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Damka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label player1Name;
        private Label player2Name;
        private Button button1;
        private Button button3;
        private Button button4;
        private Button button6;
        private Button button9;
        private Button button11;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private CheckersComponents.CheckersCheckBox checkersButton1;
        private CheckersComponents.CheckersCheckBox checkersButton2;
        private CheckersComponents.CheckersCheckBox checkersButton3;
        private CheckersComponents.CheckersCheckBox checkersButton4;
        private CheckersComponents.CheckersCheckBox checkersButton5;
        private CheckersComponents.CheckersCheckBox checkersButton6;
        private CheckersComponents.CheckersCheckBox checkersButton7;
        private CheckersComponents.CheckersCheckBox checkersButton8;
        private CheckersComponents.CheckersCheckBox checkersButton9;
        private CheckersComponents.CheckersCheckBox checkersButton10;
        private CheckersComponents.CheckersCheckBox checkersButton11;
        private CheckersComponents.CheckersCheckBox checkersButton12;
        private Button button2;
        private Button button5;
        private Button button7;
        private Button button8;
        private Button button10;
        private Button button13;
        private CheckersComponents.CheckersCheckBox checkersButton13;
        private CheckersComponents.CheckersCheckBox checkersButton14;
        private CheckersComponents.CheckersCheckBox checkersButton15;
        private CheckersComponents.CheckersCheckBox checkersButton16;
        private CheckersComponents.CheckersCheckBox checkersButton17;
        private CheckersComponents.CheckersCheckBox checkersButton18;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
        private Button button18;
        private Button button19;
    }
}