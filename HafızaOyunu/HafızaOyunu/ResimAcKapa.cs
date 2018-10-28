using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HafızaOyunu
{
    class ResimAcKapa
    {
        public static List<int> bulunanlar = new List<int>();
        public static void resimleriKapat(Form1 form1)
        {
            int durum = 1;
            for (int i = 0; i < 40; i++)
            {
                durum = 1;
                for (int j = 0; i < bulunanlar.Count; j++)
                    if (bulunanlar[j] == i + 1)
                        durum = 0;
                if (durum == 1)
                {
                    PictureBox resim = (PictureBox)form1.panel1.Controls["resim" + (i + 1)];
                    resim.ImageLocation = "";
                }
            }

            form1.acikResim = 0;
        }

        public static void tekResimKapat(int indeks, Form1 form1)
        {
            PictureBox resim = (PictureBox)form1.panel1.Controls["resim" + indeks];

            resim.Enabled = true;
            resim.ImageLocation = "";
            //resim.Visible = false;
            //MessageBox.Show("resim kapandı");
        }



        public static void resimAc(Form1 form1, PictureBox resim)
        {

            int indexNo = int.Parse(resim.Name.Split('m')[1]);
            //  MessageBox.Show("acikresim : " + form1.acikResim);
            if (form1.acikResim < 2)
            {
                //    MessageBox.Show("" + indexNo);
                resim.Enabled = false;
                resim.ImageLocation = "resimler/" + ResimYerlestir.sira[indexNo - 1] + ".jpg";
                form1.acikResimler[form1.acikResim] = indexNo;
                form1.acikResim++;
                //  MessageBox.Show("kapanacak");
                form1.panel1.Enabled = true;
                form1.timerResim.Enabled = true;

            }


            if (form1.acikResim == 2 && AcikResimKontrol.eslesmeKontrol(form1) == 1)
            {
                form1.panel1.Enabled = false;
                AcikResimKontrol.eslesmeKontrol(form1);
                form1.timerResim.Enabled = false;
                form1.timerKapat.Enabled = false;
                if (User.SiradakiOyuncu == 1)
                    form1.user1.dogruArtir();
                else
                    form1.user2.dogruArtir();
                form1.acikResim = 0;

                form1.panel1.Enabled = true;
            }


            if (form1.acikResim == 2 && AcikResimKontrol.eslesmeKontrol(form1) == 0)
            {
                form1.panel1.Enabled = false;
                form1.timerResim.Enabled = false;

                // form1.acikResim = 0;
                form1.timerKapat.Enabled = true;
                User.OyuncuDegistir();
            }
        }

    }
}
