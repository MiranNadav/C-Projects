using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsUI.Properties;
using B18_Ex02;

namespace WindowsUI
{
    public partial class GameSettingsForm : Form
    {
        public GameSettingsForm()
        {
            this.Icon = Resources.IconKing;
            InitializeComponent();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            bool isComputer = !SecondPlayerNameTextBox.Enabled;
            CheckersBoardForm checkersBoardForm = new CheckersBoardForm(Player1Name, Player2Name, SelectedBoardSize, isComputer);
            checkersBoardForm.ShowDialog();
        }

        private void checkBox_Checked(object sender, EventArgs e)
        {
            SecondPlayerNameTextBox.Enabled = (sender as CheckBox).Checked;
            if (!SecondPlayerNameTextBox.Enabled)
            {
                SecondPlayerNameTextBox.Text = "[Computer]";
            }
            else
            {
                SecondPlayerNameTextBox.Text = string.Empty;
            }
        }

        public TextBox SecondPlayerNameTextBox { get => secondPlayerNameTextBox; }
        public string Player1Name { get => firstPlayerNameTextBox.Text; }
        public string Player2Name { get => secondPlayerNameTextBox.Text; }

        public int SelectedBoardSize
        {
            get
            {
                if (radio6x6.Checked)
                {
                    return 6;
                }
                else if (radio8x8.Checked)
                {
                    return 8;
                }
                else if (radio10x10.Checked)
                {
                    return 10;
                }
                else
                {
                    return -1;
                }
            }
        }

        public class CheckersButton : Button
        {
            public CheckersButton() : base()
            {

            }
        }

        private void firstPlayerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            DoneButton.Enabled = true;
            if ((sender as TextBox).Text.Equals(string.Empty))
            {
                DoneButton.Enabled = false;
            }
        }

        private void secondPlayerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            DoneButton.Enabled = true;
            if ((sender as TextBox).Text.Equals(string.Empty))
            {
                DoneButton.Enabled = false;
            }
        }

        private void radio6x6_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
