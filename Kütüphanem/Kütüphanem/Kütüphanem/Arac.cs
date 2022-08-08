using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kütüphanem
{
    public class Arac
    {
        private bool durum = false;
        private string resimPath = "Belirtilmedi.";
        public OpenFileDialog open = new OpenFileDialog();
        private string plaka;
        private string marka;
        private string model;
        private string km;
        private string yil;
        private string vites;
        private string yakit;
        private string motorG;
        private string cekis;
        private string kapi;
        private string kasaT;
        private string renk;
        private string hasar;
        private string resim;

        public string Plaka { get => plaka; set => plaka = value; }
        public string Marka { get => marka; set => marka = value; }
        public string Model { get => model; set => model = value; }
        public string Km { get => km; set => km = value; }
        public string Yil { get => yil; set => yil = value; }
        public string Vites { get => vites; set => vites = value; }
        public string Yakit { get => yakit; set => yakit = value; }
        public string MotorG { get => motorG; set => motorG = value; }
        public string Cekis { get => cekis; set => cekis = value; }
        public string Kapi { get => kapi; set => kapi = value; }
        public string KasaT { get => kasaT; set => kasaT = value; }
        public string Renk { get => renk; set => renk = value; }
        public string Hasar { get => hasar; set => hasar = value; }
        public string Resim { get => resim; set => resim = value; }
        public bool Durum { get => durum; set => durum = value; }
        public string ResimPath { get => resimPath; set => resimPath = value; }

        public void ResimEklemeArac(PictureBox pic)
        {
            try
            {
                open.Filter = "Resim Dosyası|*.jpg; *.jpeg; *.gif; *.bmp;";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pic.Image = Image.FromFile(open.FileName);
                    ResimPath = open.FileName.ToString();
                    Durum = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Meydana Geldi!!" + Environment.NewLine + ex.ToString(), "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public string ResimYolu()
        {
            return ResimPath;
        }
    }
}
