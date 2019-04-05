using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeedForGold
{
    public abstract class Objekti : PictureBox
    {
        public abstract void Pomeri();

        public bool Kontakt(PictureBox auto)
        {
            if (this.Bottom >= auto.Top && Convert.ToInt32(this.Tag) == Convert.ToInt32(auto.Tag))
                return true;
            else
                return false;

        }

        public abstract int Oznaka();

    }
}