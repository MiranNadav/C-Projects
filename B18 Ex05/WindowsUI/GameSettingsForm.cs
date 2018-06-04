using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using B18_Ex02;

namespace WindowsUI
{
    public partial class GameSettingsForm : Form
    {
        public GameSettingsForm()
        {
            InitializeComponent();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            CheckersBoardForm checkersBoardForm = new CheckersBoardForm(Player1Name, Player2Name, SelectedBoardSize);
            checkersBoardForm.ShowDialog();

        }

        private void checkBox_Checked(object sender, EventArgs e)
        {
            SecondPlayerNameTextBox.Enabled = (sender as CheckBox).Checked;
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
    }
}
