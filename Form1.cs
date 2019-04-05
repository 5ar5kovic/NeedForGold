using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeedForGold
{
    public partial class Form1 : Form
    {
        private List<Panel> l1;
        private int trenutnaPozicija = 1;
        private PictureBox auto;
        private List<Objekti> objekti;
        private Timer timer1, timer2;
        private Random rand;
        private int brojpoena;
        private int trenutnabrzina;
        public Form1()
        {
            rand = new Random();
            l1 = new List<Panel>();
 
            InitializeComponent();
           
            for (int i = 0; i < 3; i++)
            {
                string name = "panel";
                int vrednost = i + 2;
                name += vrednost;
                Panel p1 = (this.Controls.Find(name, true)[0])as Panel;
                l1.Add(p1);
            }
            NovaIgra();
        }

        private void Pomeraj(object sender, EventArgs e)
        {
     
            for (int i = 0; i < objekti.Count; i++)
            {
               
                objekti.ElementAt(i).Pomeri();
                if (objekti.ElementAt(i).Kontakt(auto))
                {
                    if (objekti.ElementAt(i).Oznaka() == 2)
                    {
                        objekti.ElementAt(i).Parent = null;
                        this.Controls.Remove(objekti.ElementAt(i));
                        objekti.ElementAt(i).Dispose();
                        objekti.RemoveAt(i);
                        brojpoena++;
                        label2.Text = brojpoena.ToString();

                    }
                    else
                    {
                        timer1.Stop();
                        timer2.Stop();
                        
                        DialogResult dlg = MessageBox.Show("Nova igra","Kraj igre",MessageBoxButtons.YesNo);
                        if (dlg == DialogResult.Yes)
                        {

                            while (objekti.Count != 0)
                            {
                                this.Controls.Remove(Controls.Find(objekti.ElementAt(0).Name, true)[0]);
                                objekti.ElementAt(0).Parent = null;
                                objekti.ElementAt(0).SendToBack();
                                objekti.ElementAt(0).Dispose();
                                objekti.RemoveAt(0);
                            }
                            
                            NovaIgra();
                        }
                        else
                        {
                            this.Close();
                        }

                        

                    }

                }
                else if (objekti.ElementAt(i).Top >= pictureBox1.Bottom)
                {
                    Objekti tmp = Controls.Find(objekti.ElementAt(i).Name, true)[0] as Objekti;
                    this.Controls.Remove(tmp);
                    tmp.Parent = null;
                    tmp.Dispose();
                    objekti.Remove(tmp);
                    
                }

            }
        }

        private void NovaIgra()
        {
            objekti = new List<Objekti>();
            brojpoena = 0;
            trenutnabrzina = 1;
            label2.Text = "0";
            label4.Text = "1";
            timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Tick += Kreiranje;
            timer1.Start();
            timer2 = new Timer();
            timer2.Interval = rand.Next(60, 120);
            timer2.Tick += Pomeraj;
            timer2.Start();
            auto = pictureBox1;
        }

        private void Kreiranje(object sender, EventArgs e)
        {
            Objekti obj = null;
            if (rand.Next(0, 100) >= 50)
            {
                obj = new Zlatnik();
            }
            else
            {
                obj = new Rupa();
            }

            int polje = rand.Next(0, 3);
            obj.Tag = polje;
            this.Controls.Add(obj);
            obj.Parent = l1.ElementAt(polje);
            // Da se slika razvuce tokom celog polja
            obj.Width = obj.Parent.Width;
             
            objekti.Add(obj);

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 27){
                this.Close();
            }
            else if (e.KeyChar == 'a' || e.KeyChar == 'A')
            {
                if (trenutnaPozicija != 0)
                {
                    trenutnaPozicija--;
                    pictureBox1.Parent = l1.ElementAt(trenutnaPozicija);
                    pictureBox1.Tag = trenutnaPozicija;
                }
                
            }
            else if (e.KeyChar == 'd' || e.KeyChar == 'D')
            {
                if (trenutnaPozicija != 2)
                {
                    trenutnaPozicija++;
                    pictureBox1.Parent = l1.ElementAt(trenutnaPozicija);
                    pictureBox1.Tag = trenutnaPozicija;
                }
            }
            else if (e.KeyChar == 'w' || e.KeyChar == 'W')
            {
                if (trenutnabrzina != 4)
                {
                    trenutnabrzina *= 2;
                    timer1.Stop();
                    timer2.Stop();
                    timer1.Interval = 1000 / trenutnabrzina;
                    timer2.Interval = 100 / trenutnabrzina;
                    timer1.Start();
                    timer2.Start();
                    label4.Text = trenutnabrzina.ToString();
                }
            }
            else if (e.KeyChar == 's' || e.KeyChar == 'S')
            {
                if (trenutnabrzina != 1)
                {
                    trenutnabrzina /= 2;
                    timer1.Stop();
                    timer2.Stop();
                    timer1.Interval = 1000 / trenutnabrzina;
                    timer2.Interval = 100 / trenutnabrzina;
                    timer1.Start();
                    timer2.Start();
                    label4.Text = trenutnabrzina.ToString();
                }
            }

        }
    }
}