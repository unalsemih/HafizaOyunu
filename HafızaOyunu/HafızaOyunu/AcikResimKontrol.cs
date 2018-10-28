using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HafızaOyunu
{
    class AcikResimKontrol
    {
        // public static Form1 form1;

        public static int eslesmeKontrol(Form1 form1)
        {
            if (ResimYerlestir.sira[form1.acikResimler[0] - 1] == ResimYerlestir.sira[form1.acikResimler[1] - 1])//Eğer eşleşme dogruysa oyuncunun dogru sayısı artar.
            {

                ResimAcKapa.bulunanlar.Add(form1.acikResimler[0]);
                PictureBox resim = (PictureBox)form1.panel1.Controls["resim" + form1.acikResimler[0]];
                resim.Enabled = false;
                ResimAcKapa.bulunanlar.Add(form1.acikResimler[1]);
                PictureBox resim1 = (PictureBox)form1.panel1.Controls["resim" + form1.acikResimler[1]];
                resim1.Enabled = false;


                return 1;
            }
            else
            {
                User.OyuncuDegistir();//eşleşme yanlışsa oyuncu değiştirilir.
                return 0;
            }
        }

    }
}
