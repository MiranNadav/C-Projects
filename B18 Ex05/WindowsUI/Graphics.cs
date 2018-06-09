using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsUI
{
    public class Graphics
    {
        private static readonly Image sr_BlackChipWhiteBackground = Image.FromFile(@"C:\Users\shuhs\Documents\GitHub\C-Projects\B18 Ex05\Graphics\Chip-Black.jpg");
        private static readonly Image sr_BlackChipBlueBackground = Image.FromFile(@"C:\Users\shuhs\Documents\GitHub\C-Projects\B18 Ex05\Graphics\Chip_Black_Blue.jpg");
        private static readonly Image sr_RedChipWhiteBackground = Image.FromFile(@"C:\Users\shuhs\Documents\GitHub\C-Projects\B18 Ex05\Graphics\Chip-Red.jpg");
        private static readonly Image sr_RedChipBlueBackground = Image.FromFile(@"C:\Users\shuhs\Documents\GitHub\C-Projects\B18 Ex05\Graphics\Chip-Red-Blue.jpg");

        public Image BlackChipWhiteBackground
        {
            get
            {
                return sr_BlackChipWhiteBackground;
            }
        }

        public Image BlackChipBlueBackground
        {
            get
            {
                return sr_BlackChipBlueBackground;
            }
        }

        public Image RedChipWhiteBackground
        {
            get
            {
                return sr_RedChipWhiteBackground;
            }
        }

        public Image RedChipBlueBackground
        {
            get
            {
                return sr_RedChipBlueBackground;
            }
        }
    }
}
