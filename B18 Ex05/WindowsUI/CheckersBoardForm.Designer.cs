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
            this.Ef = new CheckersComponents.CheckersCheckBox();
            this.Cf = new CheckersComponents.CheckersCheckBox();
            this.Af = new CheckersComponents.CheckersCheckBox();
            this.Be = new CheckersComponents.CheckersCheckBox();
            this.De = new CheckersComponents.CheckersCheckBox();
            this.Fe = new CheckersComponents.CheckersCheckBox();
            this.Ed = new CheckersComponents.CheckersCheckBox();
            this.Cd = new CheckersComponents.CheckersCheckBox();
            this.Ad = new CheckersComponents.CheckersCheckBox();
            this.Bc = new CheckersComponents.CheckersCheckBox();
            this.Dc = new CheckersComponents.CheckersCheckBox();
            this.Fc = new CheckersComponents.CheckersCheckBox();
            this.Eb = new CheckersComponents.CheckersCheckBox();
            this.Cb = new CheckersComponents.CheckersCheckBox();
            this.Ab = new CheckersComponents.CheckersCheckBox();
            this.Ba = new CheckersComponents.CheckersCheckBox();
            this.Da = new CheckersComponents.CheckersCheckBox();
            this.Fa = new CheckersComponents.CheckersCheckBox();
            this.SuspendLayout();
            // 
            // player1Name
            // 
            this.player1Name.AutoSize = true;
            this.player1Name.Location = new System.Drawing.Point(28, 53);
            this.player1Name.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.player1Name.Name = "player1Name";
            this.player1Name.Size = new System.Drawing.Size(39, 13);
            this.player1Name.TabIndex = 0;
            this.player1Name.Text = "Label1";
            // 
            // player2Name
            // 
            this.player2Name.AutoSize = true;
            this.player2Name.Location = new System.Drawing.Point(146, 53);
            this.player2Name.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.player2Name.Name = "player2Name";
            this.player2Name.Size = new System.Drawing.Size(39, 13);
            this.player2Name.TabIndex = 1;
            this.player2Name.Text = "Label2";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(18, 80);
            this.button1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 42);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(91, 80);
            this.button3.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(38, 42);
            this.button3.TabIndex = 4;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Black;
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(128, 125);
            this.button4.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(38, 42);
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Black;
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(55, 125);
            this.button6.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(38, 42);
            this.button6.TabIndex = 5;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Black;
            this.button9.Enabled = false;
            this.button9.Location = new System.Drawing.Point(201, 125);
            this.button9.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(38, 42);
            this.button9.TabIndex = 8;
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Black;
            this.button11.Enabled = false;
            this.button11.Location = new System.Drawing.Point(165, 80);
            this.button11.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(38, 42);
            this.button11.TabIndex = 12;
            this.button11.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(165, 169);
            this.button2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 42);
            this.button2.TabIndex = 50;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Black;
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(201, 213);
            this.button5.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(38, 42);
            this.button5.TabIndex = 49;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Black;
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(128, 213);
            this.button7.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(38, 42);
            this.button7.TabIndex = 48;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Black;
            this.button8.Enabled = false;
            this.button8.Location = new System.Drawing.Point(55, 213);
            this.button8.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(38, 42);
            this.button8.TabIndex = 47;
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Black;
            this.button10.Enabled = false;
            this.button10.Location = new System.Drawing.Point(91, 169);
            this.button10.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(38, 42);
            this.button10.TabIndex = 46;
            this.button10.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Black;
            this.button13.Enabled = false;
            this.button13.Location = new System.Drawing.Point(18, 169);
            this.button13.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(38, 42);
            this.button13.TabIndex = 45;
            this.button13.UseVisualStyleBackColor = false;
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Black;
            this.button14.Enabled = false;
            this.button14.Location = new System.Drawing.Point(165, 258);
            this.button14.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(38, 42);
            this.button14.TabIndex = 62;
            this.button14.UseVisualStyleBackColor = false;
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Black;
            this.button15.Enabled = false;
            this.button15.Location = new System.Drawing.Point(201, 302);
            this.button15.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(38, 42);
            this.button15.TabIndex = 61;
            this.button15.UseVisualStyleBackColor = false;
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.Black;
            this.button16.Enabled = false;
            this.button16.Location = new System.Drawing.Point(128, 302);
            this.button16.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(38, 42);
            this.button16.TabIndex = 60;
            this.button16.UseVisualStyleBackColor = false;
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.Black;
            this.button17.Enabled = false;
            this.button17.Location = new System.Drawing.Point(55, 302);
            this.button17.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(38, 42);
            this.button17.TabIndex = 59;
            this.button17.UseVisualStyleBackColor = false;
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.Black;
            this.button18.Enabled = false;
            this.button18.Location = new System.Drawing.Point(91, 258);
            this.button18.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(38, 42);
            this.button18.TabIndex = 58;
            this.button18.UseVisualStyleBackColor = false;
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.Black;
            this.button19.Enabled = false;
            this.button19.Location = new System.Drawing.Point(18, 258);
            this.button19.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(38, 42);
            this.button19.TabIndex = 57;
            this.button19.UseVisualStyleBackColor = false;
            // 
            // Ef
            // 
            this.Ef.Appearance = System.Windows.Forms.Appearance.Button;
            this.Ef.BackColor = System.Drawing.Color.White;
            this.Ef.Location = new System.Drawing.Point(165, 302);
            this.Ef.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Ef.Name = "Ef";
            this.Ef.Size = new System.Drawing.Size(38, 42);
            this.Ef.Square = null;
            this.Ef.TabIndex = 68;
            this.Ef.Text = "X";
            this.Ef.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Ef.UseVisualStyleBackColor = false;
            // 
            // Cf
            // 
            this.Cf.Appearance = System.Windows.Forms.Appearance.Button;
            this.Cf.BackColor = System.Drawing.Color.White;
            this.Cf.Location = new System.Drawing.Point(91, 302);
            this.Cf.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Cf.Name = "Cf";
            this.Cf.Size = new System.Drawing.Size(38, 42);
            this.Cf.Square = null;
            this.Cf.TabIndex = 67;
            this.Cf.Text = "X";
            this.Cf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Cf.UseVisualStyleBackColor = false;
            // 
            // Af
            // 
            this.Af.Appearance = System.Windows.Forms.Appearance.Button;
            this.Af.BackColor = System.Drawing.Color.White;
            this.Af.Location = new System.Drawing.Point(18, 302);
            this.Af.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Af.Name = "Af";
            this.Af.Size = new System.Drawing.Size(38, 42);
            this.Af.Square = null;
            this.Af.TabIndex = 66;
            this.Af.Text = "X";
            this.Af.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Af.UseVisualStyleBackColor = false;
            // 
            // Be
            // 
            this.Be.Appearance = System.Windows.Forms.Appearance.Button;
            this.Be.BackColor = System.Drawing.Color.White;
            this.Be.Location = new System.Drawing.Point(55, 258);
            this.Be.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Be.Name = "Be";
            this.Be.Size = new System.Drawing.Size(38, 42);
            this.Be.Square = null;
            this.Be.TabIndex = 65;
            this.Be.Text = "X";
            this.Be.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Be.UseVisualStyleBackColor = false;
            // 
            // De
            // 
            this.De.Appearance = System.Windows.Forms.Appearance.Button;
            this.De.BackColor = System.Drawing.Color.White;
            this.De.Location = new System.Drawing.Point(128, 258);
            this.De.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.De.Name = "De";
            this.De.Size = new System.Drawing.Size(38, 42);
            this.De.Square = null;
            this.De.TabIndex = 64;
            this.De.Text = "X";
            this.De.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.De.UseVisualStyleBackColor = false;
            // 
            // Fe
            // 
            this.Fe.Appearance = System.Windows.Forms.Appearance.Button;
            this.Fe.BackColor = System.Drawing.Color.White;
            this.Fe.Location = new System.Drawing.Point(201, 258);
            this.Fe.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Fe.Name = "Fe";
            this.Fe.Size = new System.Drawing.Size(38, 42);
            this.Fe.Square = null;
            this.Fe.TabIndex = 63;
            this.Fe.Text = "X";
            this.Fe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Fe.UseVisualStyleBackColor = false;
            // 
            // Ed
            // 
            this.Ed.Appearance = System.Windows.Forms.Appearance.Button;
            this.Ed.BackColor = System.Drawing.Color.White;
            this.Ed.Location = new System.Drawing.Point(165, 213);
            this.Ed.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Ed.Name = "Ed";
            this.Ed.Size = new System.Drawing.Size(38, 42);
            this.Ed.Square = null;
            this.Ed.TabIndex = 56;
            this.Ed.UseVisualStyleBackColor = false;
            // 
            // Cd
            // 
            this.Cd.Appearance = System.Windows.Forms.Appearance.Button;
            this.Cd.BackColor = System.Drawing.Color.White;
            this.Cd.Location = new System.Drawing.Point(91, 213);
            this.Cd.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Cd.Name = "Cd";
            this.Cd.Size = new System.Drawing.Size(38, 42);
            this.Cd.Square = null;
            this.Cd.TabIndex = 55;
            this.Cd.UseVisualStyleBackColor = false;
            // 
            // Ad
            // 
            this.Ad.Appearance = System.Windows.Forms.Appearance.Button;
            this.Ad.BackColor = System.Drawing.Color.White;
            this.Ad.Location = new System.Drawing.Point(18, 213);
            this.Ad.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Ad.Name = "Ad";
            this.Ad.Size = new System.Drawing.Size(38, 42);
            this.Ad.Square = null;
            this.Ad.TabIndex = 54;
            this.Ad.UseVisualStyleBackColor = false;
            // 
            // Bc
            // 
            this.Bc.Appearance = System.Windows.Forms.Appearance.Button;
            this.Bc.BackColor = System.Drawing.Color.White;
            this.Bc.Location = new System.Drawing.Point(55, 169);
            this.Bc.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Bc.Name = "Bc";
            this.Bc.Size = new System.Drawing.Size(38, 42);
            this.Bc.Square = null;
            this.Bc.TabIndex = 53;
            this.Bc.UseVisualStyleBackColor = false;
            // 
            // Dc
            // 
            this.Dc.Appearance = System.Windows.Forms.Appearance.Button;
            this.Dc.BackColor = System.Drawing.Color.White;
            this.Dc.Location = new System.Drawing.Point(128, 169);
            this.Dc.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Dc.Name = "Dc";
            this.Dc.Size = new System.Drawing.Size(38, 42);
            this.Dc.Square = null;
            this.Dc.TabIndex = 52;
            this.Dc.UseVisualStyleBackColor = false;
            // 
            // Fc
            // 
            this.Fc.Appearance = System.Windows.Forms.Appearance.Button;
            this.Fc.BackColor = System.Drawing.Color.White;
            this.Fc.Location = new System.Drawing.Point(201, 169);
            this.Fc.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Fc.Name = "Fc";
            this.Fc.Size = new System.Drawing.Size(38, 42);
            this.Fc.Square = null;
            this.Fc.TabIndex = 51;
            this.Fc.UseVisualStyleBackColor = false;
            // 
            // Eb
            // 
            this.Eb.Appearance = System.Windows.Forms.Appearance.Button;
            this.Eb.BackColor = System.Drawing.Color.White;
            this.Eb.Location = new System.Drawing.Point(165, 125);
            this.Eb.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Eb.Name = "Eb";
            this.Eb.Size = new System.Drawing.Size(38, 42);
            this.Eb.Square = null;
            this.Eb.TabIndex = 44;
            this.Eb.Text = "O";
            this.Eb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Eb.UseVisualStyleBackColor = false;
            // 
            // Cb
            // 
            this.Cb.Appearance = System.Windows.Forms.Appearance.Button;
            this.Cb.BackColor = System.Drawing.Color.White;
            this.Cb.Location = new System.Drawing.Point(91, 125);
            this.Cb.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Cb.Name = "Cb";
            this.Cb.Size = new System.Drawing.Size(38, 42);
            this.Cb.Square = null;
            this.Cb.TabIndex = 43;
            this.Cb.Text = "O";
            this.Cb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Cb.UseVisualStyleBackColor = false;
            // 
            // Ab
            // 
            this.Ab.Appearance = System.Windows.Forms.Appearance.Button;
            this.Ab.BackColor = System.Drawing.Color.White;
            this.Ab.Location = new System.Drawing.Point(18, 124);
            this.Ab.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Ab.Name = "Ab";
            this.Ab.Size = new System.Drawing.Size(38, 42);
            this.Ab.Square = null;
            this.Ab.TabIndex = 42;
            this.Ab.Text = "O";
            this.Ab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Ab.UseVisualStyleBackColor = false;
            // 
            // Ba
            // 
            this.Ba.Appearance = System.Windows.Forms.Appearance.Button;
            this.Ba.BackColor = System.Drawing.Color.White;
            this.Ba.Location = new System.Drawing.Point(55, 80);
            this.Ba.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Ba.Name = "Ba";
            this.Ba.Size = new System.Drawing.Size(38, 42);
            this.Ba.Square = null;
            this.Ba.TabIndex = 41;
            this.Ba.Text = "O";
            this.Ba.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Ba.UseVisualStyleBackColor = false;
            // 
            // Da
            // 
            this.Da.Appearance = System.Windows.Forms.Appearance.Button;
            this.Da.BackColor = System.Drawing.Color.White;
            this.Da.Location = new System.Drawing.Point(128, 80);
            this.Da.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Da.Name = "Da";
            this.Da.Size = new System.Drawing.Size(38, 42);
            this.Da.Square = null;
            this.Da.TabIndex = 40;
            this.Da.Text = "O";
            this.Da.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Da.UseVisualStyleBackColor = false;
            // 
            // Fa
            // 
            this.Fa.Appearance = System.Windows.Forms.Appearance.Button;
            this.Fa.BackColor = System.Drawing.Color.White;
            this.Fa.Location = new System.Drawing.Point(201, 80);
            this.Fa.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Fa.Name = "Fa";
            this.Fa.Size = new System.Drawing.Size(38, 42);
            this.Fa.Square = null;
            this.Fa.TabIndex = 39;
            this.Fa.Text = "O";
            this.Fa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Fa.UseVisualStyleBackColor = false;
            // 
            // CheckersBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 385);
            this.Controls.Add(this.Ef);
            this.Controls.Add(this.Cf);
            this.Controls.Add(this.Af);
            this.Controls.Add(this.Be);
            this.Controls.Add(this.De);
            this.Controls.Add(this.Fe);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.Ed);
            this.Controls.Add(this.Cd);
            this.Controls.Add(this.Ad);
            this.Controls.Add(this.Bc);
            this.Controls.Add(this.Dc);
            this.Controls.Add(this.Fc);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.Eb);
            this.Controls.Add(this.Cb);
            this.Controls.Add(this.Ab);
            this.Controls.Add(this.Ba);
            this.Controls.Add(this.Da);
            this.Controls.Add(this.Fa);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.player2Name);
            this.Controls.Add(this.player1Name);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
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
        private CheckersComponents.CheckersCheckBox Fa;
        private CheckersComponents.CheckersCheckBox Da;
        private CheckersComponents.CheckersCheckBox Ba;
        private CheckersComponents.CheckersCheckBox Ab;
        private CheckersComponents.CheckersCheckBox Cb;
        private CheckersComponents.CheckersCheckBox Eb;
        private CheckersComponents.CheckersCheckBox Ed;
        private CheckersComponents.CheckersCheckBox Cd;
        private CheckersComponents.CheckersCheckBox Ad;
        private CheckersComponents.CheckersCheckBox Bc;
        private CheckersComponents.CheckersCheckBox Dc;
        private CheckersComponents.CheckersCheckBox Fc;
        private Button button2;
        private Button button5;
        private Button button7;
        private Button button8;
        private Button button10;
        private Button button13;
        private CheckersComponents.CheckersCheckBox Ef;
        private CheckersComponents.CheckersCheckBox Cf;
        private CheckersComponents.CheckersCheckBox Af;
        private CheckersComponents.CheckersCheckBox Be;
        private CheckersComponents.CheckersCheckBox De;
        private CheckersComponents.CheckersCheckBox Fe;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
        private Button button18;
        private Button button19;
    }
}