using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeedForGold
{
    public class Rupa : Objekti
    {
        private static int brojac = 0;
        public Rupa()
        {
            string ime = "rupa" + (++brojac);

            this.Name = ime;

            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.StretchImage;

            this.ImageLocation = "../slike/prepreka.png";
        }

        public override int Oznaka()
        {
            return 1;
        }

        public override void Pomeri()
        {
            this.Top += 10;
        }

       
    }
}