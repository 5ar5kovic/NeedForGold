using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeedForGold
{
    public class Zlatnik : Objekti
    {
        private static int brojac = 0;
        public Zlatnik()
        {
            string ime = "zlatnik" + (++brojac);
            this.Name = ime;

            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.StretchImage;

            this.ImageLocation = "../slike/coin.png";
            
        }

        public override int Oznaka()
        {
            return 2;
        }

        public override void Pomeri()
        {
            this.Top += 15;
        }

    }
}