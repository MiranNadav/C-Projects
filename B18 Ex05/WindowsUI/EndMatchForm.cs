using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
using WindowsUI.Properties;


namespace WindowsUI
{
    public partial class EndMatchForm : Form
    {
        public EndMatchForm()
        {
            InitializeComponent();
            SoundPlayer winningSound = new SoundPlayer(Resources.WinningSound);
            winningSound.Play();
        }
    }
}
