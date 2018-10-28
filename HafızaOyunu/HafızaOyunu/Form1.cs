using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HafızaOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int> resimler = new List<int>();

        int sayi, durum = 1, z = 0;
        public int saniye = 0;
        public int siradakiOyuncu = 1;
        public int acikResim = 0;
        public int[] acikResimler = new int[2];
        public User user1, user2;


        private void resimClick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            ResimAcKapa.resimAc(this, (PictureBox)sender);

        }

        private void timerKapat_Tick(object sender, EventArgs e)
        {
            ResimAcKapa.tekResimKapat(acikResimler[0], this);
            ResimAcKapa.tekResimKapat(acikResimler[1], this);
            acikResim = 0;
            timerKapat.Enabled = false;
            panel1.Enabled = true;


        }

        private void timerResim_Tick(object sender, EventArgs e)
        {
            ResimAcKapa.tekResimKapat(acikResimler[0], this);
            User.OyuncuDegistir();
            if(acikResim==2)
            ResimAcKapa.tekResimKapat(acikResimler[1], this);
      //      MessageBox.Show("kapandı" + acikResimler[0]);
            
            timerResim.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye++;
            label1.Text = saniye.ToString();
            if (saniye == 5)
            {
                saniye = 0;
                ResimAcKapa.resimleriKapat(this);
                timer1.Enabled = false;
                panel1.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            user1 = new User(1,this);
            user2 = new User(2,this);

            ResimIndex resimIndex = new ResimIndex();
            resimIndex.indexOlustur();
            ResimYerlestir resimYerlestir = new ResimYerlestir(ResimIndex.sira, this);
            resimYerlestir.yerlestir();
            User.SiradakiOyuncu = 1;
        }
    }


    public class User
    {

        private static int siradakiOyuncu = 1;
        int dogruBilinen = 0;
        int userNo; // 1. ya da 2. oyuncu
        public static Form1 form1;

        public static int SiradakiOyuncu { get => siradakiOyuncu;
            set { siradakiOyuncu = value;
                if (siradakiOyuncu == 1)
                { form1.lbl1Oyuncu.BackColor = Color.DarkGreen;
                    form1.lbl1Oyuncu.ForeColor = Color.White;
                    form1.lbl2Oyuncu.ForeColor = Color.Black;
                    form1.lbl2Oyuncu.BackColor = Color.Transparent;
                }
                else
                { form1.lbl2Oyuncu.BackColor = Color.DarkGreen;
                    form1.lbl2Oyuncu.ForeColor = Color.White;
                    form1.lbl1Oyuncu.ForeColor = Color.Black;
                    form1.lbl1Oyuncu.BackColor = Color.Transparent;
                }


            }
        }

        public User(int userNo,Form1 form1)
        {
            this.userNo = userNo;
            User.form1 = form1;
        }
        public void dogruArtir()
        {
            dogruBilinen++;
            if (SiradakiOyuncu == 1)
                form1.lbl1Bilen.Text = dogruBilinen.ToString();
            else
                form1.lbl2Bilen.Text = dogruBilinen.ToString();

            if (dogruBilinen == 11)
            {
                MessageBox.Show("Tebrikler Kazandınız...");
               
            }
            if (form1.user1.dogruBilinen == 10 && form1.user2.dogruBilinen == 10)
                MessageBox.Show("BERABERE KALDINIZ...");
        }



        public static void OyuncuDegistir()
        {
            if (User.SiradakiOyuncu == 1)
                 User.SiradakiOyuncu = 2;
             
            
            else User.SiradakiOyuncu = 1;
            form1.lblSiradaki.Text = "" + User.SiradakiOyuncu + ".oyuncu oynuyor";
            form1.saniye = 0;
           
        }

    }




   

   





    class ResimYerlestir
    {
        static Form1 form;
        public static int[] sira;
        public ResimYerlestir(int[] sira,Form1 form)
        {
            ResimYerlestir.sira = sira;
            ResimYerlestir.form = form;
        }

        public void yerlestir()
        {
            for (int i = 1; i <= 40; i++)
            {
                PictureBox resim = (PictureBox)form.panel1.Controls["resim" + i.ToString()];
                resim.ImageLocation = "resimler/" + sira[i-1] + ".jpg";

            }
        }


    }
    class ResimIndex
    {
        public static int[] sira = new int[40];
        int sayi = 0,durum=0;
        Random rnd = new Random();
        public void indexOlustur()
        {
            for (int j = 0; j < 40; j++)
            {
                
                sayi = rnd.Next(1, 21);
                while(sayiVarmi(sayi,sira)==1)
                {
                    sayi = rnd.Next(1, 21);

                }
                sira[j] = sayi;

            }
            for (int i = 0; i < sira.Length; i++)
                Console.WriteLine(sira[i].ToString());
        }


        public int sayiVarmi(int s,int[] dizi)
        {
            int var = 0;
            for(int i=0; i<dizi.Length; i++)
            {
                if(dizi[i]==s)//s sayisi dizide var mı bunu kontrol ediyorum ...
                {
                    var++;
                }
            }
            if (var == 1 || var == 0)
                return 0;
            else
            return var=1;
              
        }

    }


    }


