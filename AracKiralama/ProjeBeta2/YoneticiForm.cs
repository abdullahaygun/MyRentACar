using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kütüphanem;

namespace ProjeBeta2
{
    public partial class FormYonetici : Form
    {
        public ColorDialog colorDialog = new ColorDialog();
        public FontDialog FontDialog = new FontDialog();
        TimeSpan gunFarki;
        bool time1, time2, move;
        int moveX, moveY, menuWidth, positionMusteri, positionArac, gunFarki2, kalan, tam;
        string id, sifre, plaka, durum;
        Baglanti baglanti = new Baglanti();
        Musteri musteri = new Musteri();
        Arac arac = new Arac();
        SaveFileDialog sfd = new SaveFileDialog();
        string MailKime;
        string MailBaslik;
        string MailMesaj;
        public FormYonetici()
        {

            InitializeComponent();
        }

        public void FormYonetici_Load(object sender, EventArgs e)
        {
            this.Hide();
            LoadingScreen load = new LoadingScreen();
            load.ShowDialog();
            tab.Appearance = TabAppearance.FlatButtons; tab.ItemSize = new Size(0, 1); tab.SizeMode = TabSizeMode.Fixed;
            menuWidth = pMenu.Width;

            string[] AracMarka = {"Alfa Romeo","Aston Martin","Audi","Bently","BMW","Chevrolet","Ferrari","Fiat","Ford","Honda","Jaguar","Kia","Lamborghini",
            "Maserati","Mazda","McLaren","Mercedes - Benz","Nissan","Opel","Peugeot","Porsche","Renault","Tesla","Toyota","Volswagen","Volvo"};
            cmbAracMarka.Items.Clear(); cmbAracModel.Items.Clear();
            cmbAracMarka.Items.AddRange(AracMarka);
            cmbAracYıl.Items.Clear();
            cmbAracMotorG.Items.Clear();

            for (int i = 1970; i < Convert.ToInt32(DateTime.Now.ToString("yyyy")) + 2; i++)
            {
                cmbAracYıl.Items.Add(i);
            }
            for (int i = 75; i < 1500; i++)
            {
                cmbAracMotorG.Items.Add(i);
            }
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pMenu.Visible) pMenu.Visible = false;
            else pMenu.Visible = true;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized) this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();

        }

        private void btnMenuArac_Click(object sender, EventArgs e)
        {
            tArac.Start();
            if (pMusteriDrop.Size == pMusteriDrop.MaximumSize)
            {
                time2 = true;
                pMusteriDrop.Size = MinimumSize;
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void tMusteri_Tick(object sender, EventArgs e)
        {
            if (time2)
            {
                pMusteriDrop.Height += 10;
                if (pMusteriDrop.Size == pMusteriDrop.MaximumSize)
                {
                    tMusteri.Stop();
                    time2 = false;
                }
            }
            else
            {
                pMusteriDrop.Height -= 10;
                if (pMusteriDrop.Size == pMusteriDrop.MinimumSize)
                {
                    tMusteri.Stop();
                    time2 = true;
                }
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tMusteri.Start();
            if (pAracDrop.Size == pAracDrop.MaximumSize)
            {
                time1 = true;
                pAracDrop.Size = MinimumSize;
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }



        private void btnMenuGiris_Click(object sender, EventArgs e)
        {
            tab.SelectedTab = tabPage1;
            cmbAra.Text = null;
            txtAra.Text = "";
            cmbAracAra.Text = null;
            txtAracAra.Text = "";

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnMenuMusteriEkle_Click(object sender, EventArgs e)
        {
            cmbAra.Text = null;
            txtAra.Text = "";
            cmbAracAra.Text = null;
            txtAracAra.Text = "";

            lblMusteriResim.Text = "Resim Ekle";
            txtMusteriTc.Text = ""; txtMusteriAd.Text = ""; txtMusteriSoyad.Text = ""; dateMusteri.Value = DateTime.Now; txtMusteriMeslek.Text = ""; cmbMusteriMailAlan.SelectedIndex = 0;
            cmbMusteriCinsiyet.SelectedIndex = 0; ; txtMusteriTel.Text = ""; txtMusteriMail.Text = ""; txtMusteriAdres.Text = ""; cmbMusteriEhliyet.SelectedIndex = 0;
            txtMusteriSifre.Text = ""; picMusteri.Image = null;

            pAra.Visible = false;
            txtMusteriTc.Enabled = true; txtMusteriAd.Enabled = true; txtMusteriSoyad.Enabled = true; dateMusteri.Enabled = true; txtMusteriMeslek.Enabled = true; cmbMusteriMailAlan.Enabled = true;
            cmbMusteriCinsiyet.Enabled = true; ; txtMusteriTel.Enabled = true; txtMusteriMail.Enabled = true; txtMusteriAdres.Enabled = true; cmbMusteriEhliyet.Enabled = true;
            txtMusteriSifre.Enabled = true; lblMusteriResim.Enabled = true;
            positionMusteri = 1;
            btnMusteriEkle.Visible = true;
            btnMusteriSil.Visible = false;
            btnMusteriGüncel.Visible = false;
            tMusteri.Start();
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Girişinizi Doğru bir şekilde yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tab.SelectedTab = tabPage2;
                baglanti.göster("musteri", dataGrdMusteri, id, sifre);
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnMenuMusteriSil_Click(object sender, EventArgs e)
        {
            cmbAra.Text = null;
            txtAra.Text = "";
            cmbAracAra.Text = null;
            txtAracAra.Text = "";
            lblMusteriResim.Text = "";
            pAra.Visible = true;
            positionMusteri = 2;
            btnMusteriEkle.Visible = false;
            btnMusteriSil.Visible = true;
            btnMusteriGüncel.Visible = false;
            tMusteri.Start();
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Girişinizi Doğru bir şekilde yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tab.SelectedTab = tabPage2;

                baglanti.göster("musteri", dataGrdMusteri, id, sifre);
            }
            txtMusteriTc.Enabled = false; txtMusteriAd.Enabled = false; txtMusteriSoyad.Enabled = false; dateMusteri.Enabled = false; txtMusteriMeslek.Enabled = false; cmbMusteriMailAlan.Enabled = false;
            cmbMusteriCinsiyet.Enabled = false; ; txtMusteriTel.Enabled = false; txtMusteriMail.Enabled = false; txtMusteriAdres.Enabled = false; cmbMusteriEhliyet.Enabled = false;
            txtMusteriSifre.Enabled = false; lblMusteriResim.Enabled = false;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnMenuMusteriGüncel_Click(object sender, EventArgs e)
        {
            cmbAra.Text = null;
            txtAra.Text = "";
            cmbAracAra.Text = null;
            txtAracAra.Text = "";
            lblMusteriResim.Text = "Resim Güncelle";
            pAra.Visible = true;
            txtMusteriTc.Enabled = false; txtMusteriAd.Enabled = true; txtMusteriSoyad.Enabled = true; dateMusteri.Enabled = true; txtMusteriMeslek.Enabled = true; cmbMusteriMailAlan.Enabled = true;
            cmbMusteriCinsiyet.Enabled = true; ; txtMusteriTel.Enabled = true; txtMusteriMail.Enabled = true; txtMusteriAdres.Enabled = true; cmbMusteriEhliyet.Enabled = true;
            txtMusteriSifre.Enabled = true; lblMusteriResim.Enabled = true;
            positionMusteri = 3;
            btnMusteriEkle.Visible = false;
            btnMusteriSil.Visible = false;
            btnMusteriGüncel.Visible = true;
            tMusteri.Start();
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Girişinizi Doğru bir şekilde yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tab.SelectedTab = tabPage2;
                baglanti.göster("musteri", dataGrdMusteri, id, sifre);
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnMenuAracEkle_Click(object sender, EventArgs e)
        {
            cmbAra.Text = null;
            txtAra.Text = "";
            cmbAracAra.Text = null;
            txtAracAra.Text = "";
            lblAracResim.Text = "Resim Ekle";
            txtAracPlaka.Text = ""; cmbAracMarka.Text = null; cmbAracModel.Text = null; txtAracKm.Text = ""; cmbAracYıl.Text = null; cmbAracVites.Text = null;
            cmbAracYakıt.Text = null; ; cmbAracMotorG.Text = null; cmbAracCekis.Text = null; cmbAracKapi.Text = null; cmbAracKasaT.Text = null;
            cmbAracRenk.Text = null; txtAracFiyatGun.Text = ""; picArac.Image = null;

            pAraArac.Visible = false;

            txtAracPlaka.Enabled = true; cmbAracMarka.Enabled = true; cmbAracModel.Enabled = true; txtAracKm.Enabled = true; cmbAracYıl.Enabled = true; cmbAracVites.Enabled = true;
            cmbAracYakıt.Enabled = true; ; cmbAracMotorG.Enabled = true; cmbAracCekis.Enabled = true; cmbAracKapi.Enabled = true; cmbAracKasaT.Enabled = true;
            cmbAracRenk.Enabled = true; txtAracFiyatGun.Enabled = true; lblAracResim.Enabled = true;

            positionArac = 1;

            btnAracSil.Visible = false;
            btnAracGüncel.Visible = false;
            btnAracEkle.Visible = true;

            tArac.Start();

            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Girişinizi Doğru bir şekilde yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tab.SelectedTab = tabPage3;
                baglanti.göster("araba", dataGrdArac, id, sifre);
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnMenuAracGüncel_Click(object sender, EventArgs e)
        {
            cmbAra.Text = null;
            txtAra.Text = "";
            cmbAracAra.Text = null;
            txtAracAra.Text = "";

            lblAracResim.Text = "Resim Güncelle";

            txtAracPlaka.Text = ""; cmbAracMarka.Text = null; cmbAracModel.Text = null; txtAracKm.Text = ""; cmbAracYıl.Text = null; cmbAracVites.Text = null;
            cmbAracYakıt.Text = null; ; cmbAracMotorG.Text = null; cmbAracCekis.Text = null; cmbAracKapi.Text = null; cmbAracKasaT.Text = null;
            cmbAracRenk.Text = null; txtAracFiyatGun.Text = ""; picArac.Image = null;

            pAraArac.Visible = true;

            txtAracPlaka.Enabled = false; cmbAracMarka.Enabled = true; cmbAracModel.Enabled = true; txtAracKm.Enabled = true; cmbAracYıl.Enabled = true; cmbAracVites.Enabled = true;
            cmbAracYakıt.Enabled = true; ; cmbAracMotorG.Enabled = true; cmbAracCekis.Enabled = true; cmbAracKapi.Enabled = true; cmbAracKasaT.Enabled = true;
            cmbAracRenk.Enabled = true; txtAracFiyatGun.Enabled = true; lblAracResim.Enabled = true;

            positionArac = 3;

            btnAracSil.Visible = false;
            btnAracGüncel.Visible = true;
            btnAracEkle.Visible = false;

            tArac.Start();

            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Girişinizi Doğru bir şekilde yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tab.SelectedTab = tabPage3;
                baglanti.göster("araba", dataGrdArac, id, sifre);
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void brnMenuAracSil_Click(object sender, EventArgs e)
        {
            lblAracResim.Text = "";
            txtAracPlaka.Text = ""; cmbAracMarka.Text = null; cmbAracModel.Text = null; txtAracKm.Text = ""; cmbAracYıl.Text = null; cmbAracVites.Text = null;
            cmbAracYakıt.Text = null; ; cmbAracMotorG.Text = null; cmbAracCekis.Text = null; cmbAracKapi.Text = null; cmbAracKasaT.Text = null;
            cmbAracRenk.Text = null; txtAracFiyatGun.Text = ""; picArac.Image = null;

            pAraArac.Visible = true;

            txtAracPlaka.Enabled = false; cmbAracMarka.Enabled = false; cmbAracModel.Enabled = false; txtAracKm.Enabled = false; cmbAracYıl.Enabled = false; cmbAracVites.Enabled = false;
            cmbAracYakıt.Enabled = false; ; cmbAracMotorG.Enabled = false; cmbAracCekis.Enabled = false; cmbAracKapi.Enabled = false; cmbAracKasaT.Enabled = false;
            cmbAracRenk.Enabled = false; txtAracFiyatGun.Enabled = false; lblAracResim.Enabled = false;

            positionArac = 2;

            btnAracSil.Visible = true;
            btnAracGüncel.Visible = false;
            btnAracEkle.Visible = false;

            tArac.Start();

            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Girişinizi Doğru bir şekilde yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tab.SelectedTab = tabPage3;
                baglanti.göster("araba", dataGrdArac, id, sifre);
            }


            txtMusteriTc.Text = ""; txtMusteriAd.Text = ""; txtMusteriSoyad.Text = ""; dateMusteri.Value = DateTime.Now; txtMusteriMeslek.Text = ""; cmbMusteriMailAlan.SelectedIndex = 0;
            cmbMusteriCinsiyet.SelectedIndex = 0; ; txtMusteriTel.Text = ""; txtMusteriMail.Text = ""; txtMusteriAdres.Text = ""; cmbMusteriEhliyet.SelectedIndex = 0;
            txtMusteriSifre.Text = ""; picMusteri.Image = null;
            btnAracSil.Visible = true;
            btnAracGüncel.Visible = false;
            btnAracEkle.Visible = false;
            tArac.Start();
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Girişinizi Doğru bir şekilde yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tab.SelectedTab = tabPage3;
                baglanti.göster("araba", dataGrdArac, id, sifre);
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (pMenu.Visible == false) menuWidth = 0;
            else menuWidth = pMenu.Width;
            if (move) this.SetDesktopLocation(MousePosition.X - moveX - menuWidth, MousePosition.Y - moveY);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void pic_Click(object sender, EventArgs e)
        {
            pic.Visible = false;
            MessageBox.Show("Çıkış Yapıldı!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglanti.yoneticiGiris = false;
            id = "";
            sifre = "";

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void cmbAracMarka_DropDown(object sender, EventArgs e)
        {
            cmbAracModel.Text = "Seçiniz..";

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void cmbAracMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbAracModel.Items.Clear();
            string[][] AracModel = new string[26][];
            AracModel[0] = new string[8]; AracModel[1] = new string[5]; AracModel[2] = new string[6]; AracModel[3] = new string[2]; AracModel[4] = new string[6]; AracModel[5] = new string[6];
            AracModel[6] = new string[4]; AracModel[7] = new string[6]; AracModel[8] = new string[6]; AracModel[9] = new string[5]; AracModel[10] = new string[5]; AracModel[11] = new string[5];
            AracModel[12] = new string[3]; AracModel[13] = new string[3]; AracModel[14] = new string[5]; AracModel[15] = new string[2]; AracModel[16] = new string[10]; AracModel[17] = new string[5];
            AracModel[18] = new string[6]; AracModel[19] = new string[6]; AracModel[20] = new string[5]; AracModel[21] = new string[5]; AracModel[22] = new string[3]; AracModel[23] = new string[5];
            AracModel[24] = new string[5]; AracModel[25] = new string[4];

            AracModel[0][0] = "147"; AracModel[0][1] = "155"; AracModel[0][2] = "164"; AracModel[0][3] = "166"; AracModel[0][4] = "Giulietta"; AracModel[0][5] = "GT"; AracModel[0][6] = "GTV"; AracModel[0][7] = "MiTo";
            AracModel[1][0] = "DB9"; AracModel[1][1] = "DB11"; AracModel[1][2] = "Rapide"; AracModel[1][3] = "Vanquish"; AracModel[1][4] = "Vantage";
            AracModel[2][0] = "A3"; AracModel[2][1] = "A4"; AracModel[2][2] = "A6"; AracModel[2][3] = "A8"; AracModel[2][4] = "RS"; AracModel[2][5] = "TT";
            AracModel[3][0] = "Continental"; AracModel[3][1] = "Flying Spur";
            AracModel[4][0] = "3 Serisi"; AracModel[4][1] = "4 Serisi"; AracModel[4][2] = "5 Serisi"; AracModel[4][3] = "i Serisi"; AracModel[4][4] = "M Serisi"; AracModel[4][5] = "Z Serisi";
            AracModel[5][0] = "Aveo"; AracModel[5][1] = "Camaro"; AracModel[5][2] = "Corvette"; AracModel[5][3] = "Cruze"; AracModel[5][4] = "Lacetti"; AracModel[5][5] = "Spark";
            AracModel[6][0] = "458"; AracModel[6][1] = "599"; AracModel[6][2] = "California"; AracModel[6][3] = "F355";
            AracModel[7][0] = "Albea"; AracModel[7][1] = "Coupe"; AracModel[7][2] = "Egea"; AracModel[7][3] = "Linea"; AracModel[7][4] = "Palio"; AracModel[7][5] = "Uno";
            AracModel[8][0] = "C-Max"; AracModel[8][1] = "Fiesta"; AracModel[8][2] = "Focus"; AracModel[8][3] = "Mondeo"; AracModel[8][4] = "Mustang"; AracModel[8][5] = "Taunus";
            AracModel[9][0] = "Accord"; AracModel[9][1] = "Civic"; AracModel[9][2] = "CR-Z"; AracModel[9][3] = "Jazz"; AracModel[9][4] = "S2000";
            AracModel[10][0] = "S-Type"; AracModel[10][1] = "XE"; AracModel[10][2] = "XF"; AracModel[10][3] = "XJ"; AracModel[10][4] = "X-Type";
            AracModel[11][0] = "Ceed"; AracModel[11][1] = "Cerato"; AracModel[11][2] = "Magentis"; AracModel[11][3] = "Rio"; AracModel[11][4] = "Sephia";
            AracModel[12][0] = "Aventador"; AracModel[12][1] = "Gallardo"; AracModel[12][2] = "Huracan";
            AracModel[13][0] = "Ghibli"; AracModel[13][1] = "GranTurismo"; AracModel[13][2] = "GT";
            AracModel[14][0] = "3"; AracModel[14][1] = "6"; AracModel[14][2] = "323"; AracModel[14][3] = "MX"; AracModel[14][4] = "RX";
            AracModel[15][0] = "650S Spider"; AracModel[15][1] = "720S";
            AracModel[16][0] = "AMG GT"; AracModel[16][1] = "A Serisi"; AracModel[16][2] = "B Serisi"; AracModel[16][3] = "CLA"; AracModel[16][4] = "CLS"; AracModel[16][5] = "C Serisi"; AracModel[16][6] = "E Serisi"; AracModel[16][7] = "S Serisi"; AracModel[16][8] = "200"; AracModel[16][9] = "300";
            AracModel[17][0] = "Almera"; AracModel[17][1] = "GT-R"; AracModel[17][2] = "Micra"; AracModel[17][3] = "NX Coupe"; AracModel[17][4] = "Primera";
            AracModel[18][0] = "Astra"; AracModel[18][1] = "Corsa"; AracModel[18][2] = "Insignia"; AracModel[18][3] = "Omega"; AracModel[18][4] = "Tigra"; AracModel[18][5] = "Vectra";
            AracModel[19][0] = "206"; AracModel[19][1] = "207"; AracModel[19][2] = "301"; AracModel[19][3] = "307"; AracModel[19][4] = "308"; AracModel[19][5] = "RCZ";
            AracModel[20][0] = "718"; AracModel[20][1] = "911"; AracModel[20][2] = "Boxster"; AracModel[20][3] = "Cayman"; AracModel[20][4] = "Panamera";
            AracModel[21][0] = "Clio"; AracModel[21][1] = "Fluence"; AracModel[21][2] = "Laguna"; AracModel[21][3] = "Magene"; AracModel[21][4] = "Symbol";
            AracModel[22][0] = "Model 3"; AracModel[22][1] = "Model S"; AracModel[22][2] = "Model X";
            AracModel[23][0] = "Auris"; AracModel[23][1] = "Corolla"; AracModel[23][2] = "Corona"; AracModel[23][3] = "Verso"; AracModel[23][4] = "Yaris";
            AracModel[24][0] = "Bora"; AracModel[24][1] = "Golf"; AracModel[24][2] = "Jetta"; AracModel[24][3] = "Passat"; AracModel[24][4] = "Polo";
            AracModel[25][0] = "S40"; AracModel[25][1] = "S60"; AracModel[25][2] = "S80"; AracModel[25][3] = "V40";
            for (int i = 0; i < AracModel.Length; i++)
            {
                if (i == cmbAracMarka.SelectedIndex)
                {
                    for (int j = 0; j < AracModel[i].Length; j++)
                    {
                        cmbAracModel.Items.Add(AracModel[i][j]);
                    }
                    break;

                }
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnMenuAyarlar_Click(object sender, EventArgs e)
        {
            cmbAra.Text = null;
            txtAra.Text = "";
            cmbAracAra.Text = null;
            txtAracAra.Text = "";
            tab.SelectedTab = tabPage5;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void txtMusteriTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void txtMusteriAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void txtMusteriSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void txtMusteriMeslek_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void lblResimAracEkle_Click(object sender, EventArgs e)
        {
            arac.ResimEklemeArac(picArac);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void lblResimMusteriEkle_Click(object sender, EventArgs e)
        {
            musteri.ResimEklemeMusteri(picMusteri);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
            baglanti.MusteriSil(txtMusteriTc.Text.Trim());
            baglanti.göster("musteri", dataGrdMusteri, id, sifre);

            txtMusteriTc.Text = ""; txtMusteriAd.Text = ""; txtMusteriSoyad.Text = ""; dateMusteri.Value = DateTime.Now; txtMusteriMeslek.Text = ""; cmbMusteriMailAlan.Text = null;
            cmbMusteriCinsiyet.Text = null; ; txtMusteriTel.Text = ""; txtMusteriMail.Text = ""; txtMusteriAdres.Text = ""; cmbMusteriEhliyet.Text = null;
            txtMusteriSifre.Text = ""; picMusteri.Image = null;
            MessageBox.Show("Müşteri Silindi.", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void dataGrdMusteri_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (positionMusteri == 2 || positionMusteri == 3)
            {
                musteri.ResimPath = dataGrdMusteri.CurrentRow.Cells[11].Value.ToString();

                int i = dataGrdMusteri.CurrentRow.Cells[7].Value.ToString().IndexOf('@');
                txtMusteriTc.Text = dataGrdMusteri.CurrentRow.Cells[0].Value.ToString();
                txtMusteriAd.Text = dataGrdMusteri.CurrentRow.Cells[1].Value.ToString();
                txtMusteriSoyad.Text = dataGrdMusteri.CurrentRow.Cells[2].Value.ToString();
                dateMusteri.Text = dataGrdMusteri.CurrentRow.Cells[3].Value.ToString();
                txtMusteriMeslek.Text = dataGrdMusteri.CurrentRow.Cells[4].Value.ToString();
                if (dataGrdMusteri.CurrentRow.Cells[5].Value.ToString() == "Erkek") cmbMusteriCinsiyet.Text = "Erkek";

                else if (dataGrdMusteri.CurrentRow.Cells[5].Value.ToString() == "Kadın") cmbMusteriCinsiyet.Text = "Kadın";

                else
                {
                    cmbMusteriCinsiyet.Text = "Belirtmek İstemiyorum";
                }
                txtMusteriTel.Text = dataGrdMusteri.CurrentRow.Cells[6].Value.ToString();
                txtMusteriMail.Text = dataGrdMusteri.CurrentRow.Cells[7].Value.ToString().Substring(0, i);
                cmbMusteriMailAlan.Text = dataGrdMusteri.CurrentRow.Cells[7].Value.ToString().Substring(i + 1);
                txtMusteriAdres.Text = dataGrdMusteri.CurrentRow.Cells[8].Value.ToString();
                cmbMusteriEhliyet.Text = dataGrdMusteri.CurrentRow.Cells[9].Value.ToString();
                txtMusteriSifre.Text = dataGrdMusteri.CurrentRow.Cells[10].Value.ToString();
                picMusteri.ImageLocation = dataGrdMusteri.CurrentRow.Cells[11].Value.ToString();
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnMusteriGüncel_Click(object sender, EventArgs e)
        {
            baglanti.mukerrerKayıtMusteri("musteri", txtMusteriMail.Text, txtMusteriTc.Text);
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Giriş yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMusteriTc.Text = ""; txtMusteriAd.Text = ""; txtMusteriSoyad.Text = ""; dateMusteri.Value = DateTime.Now; txtMusteriMeslek.Text = ""; cmbMusteriMailAlan.Text = null;
                cmbMusteriCinsiyet.Text = null; ; txtMusteriTel.Text = ""; txtMusteriMail.Text = ""; txtMusteriAdres.Text = ""; cmbMusteriEhliyet.Text = null;
                txtMusteriSifre.Text = ""; picMusteri.Image = null;
            }
            else if (txtMusteriTc.Text == "" || txtMusteriAd.Text == "" || txtMusteriSoyad.Text == "" || txtMusteriMeslek.Text.Trim() == "" ||
               cmbMusteriCinsiyet.Text == "" || txtMusteriTel.Mask == "" || txtMusteriAdres.Text.Trim() == "" || txtMusteriMail.Text.Trim() == "" ||
               cmbMusteriEhliyet.Text == "" || cmbMusteriMailAlan.Text == "" || txtMusteriSifre.Text == "")
            {
                MessageBox.Show("Lütfen Boş Alanları Doldurunuz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (musteri.DateTimeYasHesabi(dateMusteri) < 18)
            {
                MessageBox.Show("Yaş Sınırı 18'dir!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtMusteriSifre.Text.Length < 5)
            {
                MessageBox.Show("Müşteri Şifresi 5 veya 5 Haneden Fazla Olmalıdır!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtMusteriTc.Text.Length != 11)
            {
                MessageBox.Show("Müşteri T.C. No 11 Hane Olmalıdır!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (pic.Visible && txtMusteriTc.Text != "" && txtMusteriAd.Text != "" && txtMusteriSoyad.Text != "" && txtMusteriMeslek.Text.Trim() != "" &&
               cmbMusteriCinsiyet.Text != "" && txtMusteriTel.Mask != "" && txtMusteriAdres.Text.Trim() != "" && txtMusteriMail.Text.Trim() != "" &&
               cmbMusteriEhliyet.Text != "" && cmbMusteriMailAlan.Text != "" && txtMusteriSifre.Text != "" && musteri.DateTimeYasHesabi(dateMusteri) >= 18 &&
               txtMusteriSifre.Text.Length >= 5)
            {
                if (musteri.Durum != true)
                {
                    musteri.ResimPath = picMusteri.ImageLocation.ToString();
                }
                baglanti.MusteriGüncelle(txtMusteriTc.Text.Trim(), txtMusteriAd.Text.Trim().ToUpper(), txtMusteriSoyad.Text.Trim().ToUpper(), txtMusteriTel.Text.Trim(),
                txtMusteriMail.Text.Trim() + "@" + cmbMusteriMailAlan.Text, txtMusteriAdres.Text.Trim(), cmbMusteriEhliyet.Text, txtMusteriMeslek.Text.Trim(),
                txtMusteriSifre.Text.Trim(), dateMusteri.Value.Date, cmbMusteriCinsiyet.Text, musteri.ResimYolu());
                baglanti.göster("musteri", dataGrdMusteri);

                txtMusteriTc.Text = ""; txtMusteriAd.Text = ""; txtMusteriSoyad.Text = ""; dateMusteri.Value = DateTime.Now; txtMusteriMeslek.Text = ""; cmbMusteriMailAlan.Text = null;
                cmbMusteriCinsiyet.Text = null; ; txtMusteriTel.Text = ""; txtMusteriMail.Text = ""; txtMusteriAdres.Text = ""; cmbMusteriEhliyet.Text = null;
                txtMusteriSifre.Text = ""; picMusteri.Image = null;
                MessageBox.Show("Müşteri Güncellendi.", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            if (cmbAra.SelectedIndex == 0)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "TC_No Like '" + txtAra.Text + "%'";
                dataGrdMusteri.DataSource = dv;
            }
            else if (cmbAra.SelectedIndex == 1)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Ad Like '" + txtAra.Text + "%'";
                dataGrdMusteri.DataSource = dv;
            }
            else if (cmbAra.SelectedIndex == 2)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Soyad Like '" + txtAra.Text + "%'";
                dataGrdMusteri.DataSource = dv;
            }

            else if (cmbAra.SelectedIndex == 3)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Meslek Like '" + txtAra.Text + "%'";
                dataGrdMusteri.DataSource = dv;
            }
            else if (cmbAra.SelectedIndex == 4)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Cinsiyet Like '" + txtAra.Text + "%'";
                dataGrdMusteri.DataSource = dv;
            }

            else if (cmbAra.SelectedIndex == 5)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Ehliyet Like '" + txtAra.Text + "%'";
                dataGrdMusteri.DataSource = dv;
            }
            else if (cmbAra.SelectedIndex == 6)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "E_Mail Like '" + txtAra.Text + "%'";
                dataGrdMusteri.DataSource = dv;
            }
            lblAra.Text = "Toplam:" + dataGrdMusteri.Rows.Count;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            txtSifre.UseSystemPasswordChar = false;
            pictureBox6.Image = ProjeBeta2.Properties.Resources._12817944411535694877_512;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void pictureBox6_MouseUp(object sender, MouseEventArgs e)
        {
            txtSifre.UseSystemPasswordChar = true;
            pictureBox6.Image = ProjeBeta2.Properties.Resources.img_539706;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnAracEkle_Click(object sender, EventArgs e)
        {
            baglanti.mukerrerKayitArac("araba", txtAracPlaka.Text.Trim());
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Giriş yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtAracPlaka.Text = ""; txtAracKm.Text = ""; txtAracFiyatGun.Text = ""; txtAracFiyatHafta.Text = ""; cmbAracMarka.Text = null; cmbAracModel.Text = null; cmbAracYıl.Text = null; cmbAracVites.Text = null;
                cmbAracYakıt.Text = null; cmbAracMotorG.Text = null; cmbAracCekis.Text = null; cmbAracKapi.Text = null; cmbAracKasaT.Text = null; cmbAracRenk.Text = null;
                cmbAracMarka.Text = null; picArac.Image = null;

            }
            else if (txtAracPlaka.Text == "" || txtAracKm.Text == "" || txtAracFiyatGun.Text == "" || txtAracFiyatHafta.Text == "" || cmbAracMarka.Text == null || cmbAracModel.Text == null || cmbAracYıl.Text == null ||
                cmbAracVites.Text == null || cmbAracYakıt.Text == null || cmbAracMotorG.Text == null || cmbAracCekis.Text == null || cmbAracKapi.Text == null || cmbAracKasaT.Text == null ||
                cmbAracRenk.Text == null || cmbAracMarka.Text == null || picArac.Image == null)
            {
                MessageBox.Show("Lütfen Boş Alanları Doldurunuz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (baglanti.aracKayitPlaka == false)
            {
                MessageBox.Show("Araç Sistemde Zaten Kayıtlıdır!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (pic.Visible == true && txtAracPlaka.Text != "" && txtAracKm.Text != "" && txtAracFiyatGun.Text != "" && txtAracFiyatHafta.Text != "" && cmbAracMarka.Text != null && cmbAracModel.Text != null
                && cmbAracYıl.Text != null && cmbAracVites.Text != null && cmbAracYakıt.Text != null && cmbAracMotorG.Text != null && cmbAracCekis.Text != null &&
                cmbAracKapi.Text != null && cmbAracKasaT.Text != null && cmbAracRenk.Text != null && cmbAracMarka.Text != null && picArac.Image != null && baglanti.aracKayitPlaka == true)
            {
                baglanti.AracEkle(txtAracPlaka.Text.Trim().ToUpper(), cmbAracMarka.Text, cmbAracModel.Text, txtAracKm.Text.Trim(), cmbAracYıl.Text, cmbAracVites.Text, cmbAracYakıt.Text, cmbAracMotorG.Text,
                    cmbAracCekis.Text, cmbAracKapi.Text, cmbAracKasaT.Text, cmbAracRenk.Text, arac.ResimYolu(), txtAracFiyatGun.Text.Trim(), txtAracFiyatHafta.Text.Trim());
                baglanti.göster("araba", dataGrdArac);

                txtAracPlaka.Text = ""; txtAracKm.Text = ""; txtAracFiyatGun.Text = ""; txtAracFiyatHafta.Text = ""; cmbAracMarka.Text = null; cmbAracModel.Text = null; cmbAracYıl.Text = null; cmbAracVites.Text = null;
                cmbAracYakıt.Text = null; cmbAracMotorG.Text = null; cmbAracCekis.Text = null; cmbAracKapi.Text = null; cmbAracKasaT.Text = null; cmbAracRenk.Text = null;
                cmbAracMarka.Text = null; picArac.Image = null;

                MessageBox.Show("Araç Kaydı Yapıldı.", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnAracSil_Click(object sender, EventArgs e)
        {
            baglanti.AracSil(txtAracPlaka.Text.Trim());
            baglanti.göster("araba", dataGrdArac, id, sifre);

            txtAracPlaka.Text = ""; txtAracKm.Text = ""; txtAracFiyatGun.Text = ""; cmbAracMarka.Text = null; cmbAracModel.Text = null; cmbAracYıl.Text = null; cmbAracVites.Text = null;
            cmbAracYakıt.Text = null; cmbAracMotorG.Text = null; cmbAracCekis.Text = null; cmbAracKapi.Text = null; cmbAracKasaT.Text = null; cmbAracRenk.Text = null;
            cmbAracMarka.Text = null; picArac.Image = null;
            MessageBox.Show("Araç Silindi.", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void dataGrdArac_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (positionArac == 2 || positionArac == 3)
            {
                arac.ResimPath = dataGrdArac.CurrentRow.Cells[12].Value.ToString();

                txtAracPlaka.Text = dataGrdArac.CurrentRow.Cells[0].Value.ToString();
                cmbAracMarka.Text = dataGrdArac.CurrentRow.Cells[1].Value.ToString();
                cmbAracModel.Text = dataGrdArac.CurrentRow.Cells[2].Value.ToString();
                txtAracKm.Text = dataGrdArac.CurrentRow.Cells[3].Value.ToString();
                cmbAracYıl.Text = dataGrdArac.CurrentRow.Cells[4].Value.ToString();
                cmbAracVites.Text = dataGrdArac.CurrentRow.Cells[5].Value.ToString();
                cmbAracYakıt.Text = dataGrdArac.CurrentRow.Cells[6].Value.ToString();
                cmbAracMotorG.Text = dataGrdArac.CurrentRow.Cells[7].Value.ToString();
                cmbAracCekis.Text = dataGrdArac.CurrentRow.Cells[8].Value.ToString();
                cmbAracKapi.Text = dataGrdArac.CurrentRow.Cells[9].Value.ToString();
                cmbAracKasaT.Text = dataGrdArac.CurrentRow.Cells[10].Value.ToString();
                cmbAracRenk.Text = dataGrdArac.CurrentRow.Cells[11].Value.ToString();
                picArac.ImageLocation = dataGrdArac.CurrentRow.Cells[12].Value.ToString();
                txtAracFiyatGun.Text = dataGrdArac.CurrentRow.Cells[13].Value.ToString();
                txtAracFiyatHafta.Text = dataGrdArac.CurrentRow.Cells[14].Value.ToString();
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void txtAracAra_TextChanged(object sender, EventArgs e)
        {
            if (cmbAracAra.SelectedIndex == 0)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Plaka Like '" + txtAracAra.Text + "%'";
                dataGrdArac.DataSource = dv;
            }
            else if (cmbAracAra.SelectedIndex == 1)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Marka Like '" + txtAracAra.Text + "%'";
                dataGrdArac.DataSource = dv;
            }
            else if (cmbAracAra.SelectedIndex == 2)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Model Like '" + txtAracAra.Text + "%'";
                dataGrdArac.DataSource = dv;
            }
            else if (cmbAracAra.SelectedIndex == 3)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Km Like '" + txtAracAra.Text + "%'";
                dataGrdArac.DataSource = dv;
            }
            else if (cmbAracAra.SelectedIndex == 4)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Yıl Like '" + txtAracAra.Text + "%'";
                dataGrdArac.DataSource = dv;
            }
            else if (cmbAracAra.SelectedIndex == 5)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Vites Like '" + txtAracAra.Text + "%'";
                dataGrdArac.DataSource = dv;
            }
            else if (cmbAracAra.SelectedIndex == 6)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Yakıt Like '" + txtAracAra.Text + "%'";
                dataGrdArac.DataSource = dv;
            }
            else if (cmbAracAra.SelectedIndex == 7)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Motor_Gücü Like '" + txtAracAra.Text + "%'";
                dataGrdArac.DataSource = dv;
            }
            else if (cmbAracAra.SelectedIndex == 8)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Çekiş Like '" + txtAracAra.Text + "%'";
                dataGrdArac.DataSource = dv;
            }
            else if (cmbAracAra.SelectedIndex == 9)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Kapı Like '" + txtAracAra.Text + "%'";
                dataGrdArac.DataSource = dv;
            }
            else if (cmbAracAra.SelectedIndex == 10)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Kasa_Tipi Like '" + txtAracAra.Text + "%'";
                dataGrdArac.DataSource = dv;
            }
            else if (cmbAracAra.SelectedIndex == 11)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Renk Like '" + txtAracAra.Text + "%'";
                dataGrdArac.DataSource = dv;
            }
            else if (cmbAracAra.SelectedIndex == 12)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Fiyat_Gun Like '" + txtAracAra.Text + "%'";
                dataGrdArac.DataSource = dv;
            }
            else if (cmbAracAra.SelectedIndex == 13)
            {
                DataView dv = baglanti.ds.Tables[0].DefaultView;
                dv.RowFilter = "Fiyat_Hafta Like '" + txtAracAra.Text + "%'";
                dataGrdArac.DataSource = dv;
            }
            lblAracAra.Text = "Toplam:" + dataGrdArac.Rows.Count;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnAyarlarRenk_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            if (cmbAyarlarRenk.SelectedIndex == 0)
            {
                pMenu.BackColor = colorDialog.Color;
            }
            else if (cmbAyarlarRenk.SelectedIndex == 1)
            {
                panel2.BackColor = colorDialog.Color;
            }
            else if (cmbAyarlarRenk.SelectedIndex == 2)
            {
                panel3.BackColor = colorDialog.Color;
            }
            else if (cmbAyarlarRenk.SelectedIndex == 3)
            {
                tabPage1.BackColor = colorDialog.Color;
            }
            else if (cmbAyarlarRenk.SelectedIndex == 4)
            {
                tabPage3.BackColor = colorDialog.Color;
            }
            else if (cmbAyarlarRenk.SelectedIndex == 5)
            {
                tabPage2.BackColor = colorDialog.Color;
            }
            else if (cmbAyarlarRenk.SelectedIndex == 7)
            {
                tabPage5.BackColor = colorDialog.Color;
            }
            else if (cmbAyarlarRenk.SelectedIndex == 8)
            {
                tabPage6.BackColor = colorDialog.Color;
            }
            else if (cmbAyarlarRenk.SelectedIndex == 9)
            {
                pMenu.ForeColor = colorDialog.Color;
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnKira_Click(object sender, EventArgs e)
        {
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Giriş yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cmbKiraMusteriTc.Items.Clear();
                cmbKiraPlaka.Items.Clear();
                baglanti.KiraMusteriCmbTc_PlakaDoldur(cmbKiraMusteriTc, cmbKiraPlaka);
                tab.SelectedTab = tabPage6;
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void cmbAraçKiraİslem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Giriş yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (cmbAraçKiraİslem.SelectedIndex == 0)
                {
                    baglanti.göster("araba", dataGrdKira);
                }
                else if (cmbAraçKiraİslem.SelectedIndex == 1)
                {
                    baglanti.gösterKirdakiler(dataGrdKira);
                }
                else if (cmbAraçKiraİslem.SelectedIndex == 2)
                {
                    baglanti.gösterMusait(dataGrdKira);
                }
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();

        }

        private void cmbKiraMusteriTc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Giriş yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                baglanti.KiraMusteriDoldur(cmbKiraMusteriTc.Text, txtKiraAd, txtKiraSoyad, txtKiraTel, picKiraMusteri);
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnKiraEkle_Click(object sender, EventArgs e)
        {
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Giriş yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (cmbKiraPlaka.Items.Count == 0)
                {
                    MessageBox.Show("Müsait Araç Şuanda Yok!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (txtKiraMarka.Text != "")
                    {
                        baglanti.KiraEkle(cmbKiraPlaka.Text, txtKiraMarka, txtKiraModel, txtKiraFiyatGun, txtKiraFiyatHafta, picKiraMusteri.ImageLocation, cmbKiraMusteriTc, txtKiraAd, txtKiraSoyad, txtKiraTel, picKiraArac.ImageLocation, dateKiraAlis, dateKiraVeris, lblKiraTutar);

                        MessageBox.Show("Kira Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (cmbAraçKiraİslem.SelectedIndex == 0)
                        {
                            baglanti.göster("araba", dataGrdKira);
                        }
                        else if (cmbAraçKiraİslem.SelectedIndex == 1)
                        {
                            baglanti.gösterKirdakiler(dataGrdKira);
                        }
                        else if (cmbAraçKiraİslem.SelectedIndex == 2)
                        {
                            baglanti.gösterMusait(dataGrdKira);
                        }

                        cmbKiraMusteriTc.Items.Clear();
                        cmbKiraPlaka.Items.Clear();
                        cmbKiraMusteriTc.Text = "";
                        cmbKiraPlaka.Text = "";
                        txtKiraMarka.Text = "";
                        txtKiraModel.Text = "";
                        txtKiraFiyatGun.Text = "";
                        txtKiraFiyatHafta.Text = "";
                        picKiraArac.ImageLocation = null;
                        txtKiraAd.Text = "";
                        txtKiraSoyad.Text = "";
                        txtKiraTel.Text = "";
                        dateKiraAlis.Value = DateTime.Now;
                        dateKiraVeris.Value = DateTime.Now;
                        lblKiraTutar.Text = "0";
                        lblKiraGun.Text = "0";
                        picKiraMusteri.ImageLocation = null;

                        baglanti.KiraMusteriCmbTc_PlakaDoldur(cmbKiraMusteriTc, cmbKiraPlaka);
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Araç Seçiniz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();

        }

        private void btnKiraAracDetay_Click(object sender, EventArgs e)
        {
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Giriş yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Clipboard.Clear();
                try
                {
                    Clipboard.SetText(cmbKiraPlaka.Text.ToString());
                    btnMenuAracSil.PerformClick();
                    cmbAracAra.SelectedIndex = 0;
                    txtAracAra.Text = Clipboard.GetText();
                    btnAracSil.Visible = false;
                }
                catch
                {
                    MessageBox.Show("Lütfen Araç Seçiniz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnKiraTeslim_Click(object sender, EventArgs e)
        {
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Giriş yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (durum == "KİRADA")
                {
                    baglanti.KiraTeslim(plaka);
                    if (cmbAraçKiraİslem.SelectedIndex == 0)
                    {
                        baglanti.göster("araba", dataGrdKira);
                    }
                    else if (cmbAraçKiraİslem.SelectedIndex == 1)
                    {
                        baglanti.gösterKirdakiler(dataGrdKira);
                    }
                    else if (cmbAraçKiraİslem.SelectedIndex == 2)
                    {
                        baglanti.gösterMusait(dataGrdKira);
                    }
                    btnKira.PerformClick();
                    MessageBox.Show("Araç Teslim Edildi.", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dataGrdKira.DataSource == null)
                {
                    MessageBox.Show("Lütfen Açılır Pencereden Seçiniz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbAraçKiraİslem.DroppedDown = true;
                }
                else if (durum != "KİRADA")
                {
                    MessageBox.Show("Bu Araç MÜSAİT Değil!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void dateKiraVeris_ValueChanged(object sender, EventArgs e)
        {
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Giriş yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (dateKiraAlis.Value > dateKiraVeris.Value || dateKiraAlis.Value.Day < DateTime.Now.Day)
                {
                    lblKiraGun.Text = "0";
                    MessageBox.Show("Lütfen Tarihleri Doğru Griniz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dateKiraAlis.Value = DateTime.Now;
                }
                else
                {
                    gunFarki = DateTime.Parse(dateKiraVeris.Text) - DateTime.Parse(dateKiraAlis.Text);
                    gunFarki2 = gunFarki.Days;
                    lblKiraGun.Text = gunFarki2.ToString();

                    kalan = Convert.ToInt32(lblKiraGun.Text) % 7;
                    tam = Convert.ToInt32(lblKiraGun.Text) / 7;

                    try
                    {
                        lblKiraTutar.Text = (Convert.ToInt32(txtKiraFiyatGun.Text) * kalan + Convert.ToInt32(txtKiraFiyatHafta.Text) * tam).ToString();
                    }
                    catch (Exception ex)
                    {

                    }

                }
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void dateKiraAlis_ValueChanged(object sender, EventArgs e)
        {
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Giriş yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (dateKiraAlis.Value > dateKiraVeris.Value || dateKiraAlis.Value.Day < DateTime.Now.Day)
                {
                    lblKiraGun.Text = "0";
                    MessageBox.Show("Lütfen Tarihleri Doğru Griniz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    gunFarki = DateTime.Parse(dateKiraVeris.Text) - DateTime.Parse(dateKiraAlis.Text);
                    gunFarki2 = gunFarki.Days;
                    lblKiraGun.Text = gunFarki2.ToString();

                    kalan = Convert.ToInt32(lblKiraGun.Text) % 7;
                    tam = Convert.ToInt32(lblKiraGun.Text) / 7;
                    try
                    {
                        lblKiraTutar.Text = (Convert.ToInt32(txtKiraFiyatGun.Text) * kalan + Convert.ToInt32(txtKiraFiyatHafta.Text) * tam).ToString();
                    }
                    catch (Exception ex)
                    {

                    }

                }


            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnKiraGeçmiş_Click(object sender, EventArgs e)
        {
            try
            {
                tab.SelectedTab = tabPage7;
                baglanti.KiraGecmis(dataGrdKiraGeçmiş, cmbKiraMusteriTc.Text);
            }
            catch
            {
                MessageBox.Show("Lütfen Müşteri Seçiniz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tab.SelectedTab = tabPage6;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sfd.Filter = "Excel Dosyası (*.xls)|*.xls";
            sfd.FileName = "Müşterilerin Kira Geçmişi.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                baglanti.ExportToExcel(dataGrdKiraGeçmiş, sfd.FileName);
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnMailGönder_Click(object sender, EventArgs e)
        {
            musteri.MailGönder(txtMailKime.Text, txtMailBaslik.Text, txtMailMesaj.Text);

            baglanti.MusteriEkle(txtMusteriTc.Text.Trim(), txtMusteriAd.Text.Trim().ToUpper(), txtMusteriSoyad.Text.Trim().ToUpper(), txtMusteriTel.Text.Trim(),
           txtMusteriMail.Text.Trim() + "@" + cmbMusteriMailAlan.Text, txtMusteriAdres.Text.Trim(), cmbMusteriEhliyet.Text, txtMusteriMeslek.Text.Trim().ToUpper(),
           txtMusteriSifre.Text.Trim(), dateMusteri.Value.Date, cmbMusteriCinsiyet.Text, musteri.ResimYolu());
            baglanti.göster("musteri", dataGrdMusteri);

            txtMusteriTc.Text = ""; txtMusteriAd.Text = ""; txtMusteriSoyad.Text = ""; dateMusteri.Value = DateTime.Now; txtMusteriMeslek.Text = ""; cmbMusteriMailAlan.Text = null;
            cmbMusteriCinsiyet.Text = null; ; txtMusteriTel.Text = ""; txtMusteriMail.Text = ""; txtMusteriAdres.Text = ""; cmbMusteriEhliyet.Text = null;
            txtMusteriSifre.Text = ""; picMusteri.Image = null;
            MessageBox.Show("Müşteri Kaydı Yapıldı!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);



            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnExportArac_Click(object sender, EventArgs e)
        {
            sfd.Filter = "Excel Dosyası (*.xls)|*.xls";
            sfd.FileName = "Araçlar.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                baglanti.ExportToExcel(dataGrdArac, sfd.FileName);
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnExportMusteri_Click(object sender, EventArgs e)
        {
            sfd.Filter = "Excel Dosyası (*.xls)|*.xls";
            sfd.FileName = "Müşteriler.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                baglanti.ExportToExcel(dataGrdMusteri, sfd.FileName);
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnExportKiradakiAraçlar_Click(object sender, EventArgs e)
        {
            if (cmbAraçKiraİslem.SelectedIndex == 0)
            {
                sfd.Filter = "Excel Dosyası (*.xls)|*.xls";
                sfd.FileName = "Tüm Araçlar.xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    baglanti.ExportToExcel(dataGrdKira, sfd.FileName);
                }

                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
            }
            else if (cmbAraçKiraİslem.SelectedIndex == 1)
            {
                sfd.Filter = "Excel Dosyası (*.xls)|*.xls";
                sfd.FileName = "Kiradaki Araçlar.xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    baglanti.ExportToExcel(dataGrdKira, sfd.FileName);
                }
            }
            else if (cmbAraçKiraİslem.SelectedIndex == 2)
            {
                sfd.Filter = "Excel Dosyası (*.xls)|*.xls";
                sfd.FileName = "Müsait Araçlar.xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    baglanti.ExportToExcel(dataGrdKira, sfd.FileName);
                }

            }

        }

        private void dataGrdKira_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            plaka = dataGrdKira.CurrentRow.Cells[0].Value.ToString();
            durum = dataGrdKira.CurrentRow.Cells[13].Value.ToString();

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void cmbKiraPlaka_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Giriş yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                baglanti.KiraAracDoldur(cmbKiraPlaka.Text, txtKiraMarka, txtKiraModel, txtKiraFiyatGun, txtKiraFiyatHafta, picKiraArac);
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnKiraMusteriDetay_Click(object sender, EventArgs e)
        {
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Giriş yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Clipboard.SetText(cmbKiraMusteriTc.Text.ToString());
                    btnMenuMusteriSil.PerformClick();
                    cmbAra.SelectedIndex = 0;
                    txtAra.Text = Clipboard.GetText();
                    btnMusteriSil.Visible = false;
                }
                catch
                {
                    MessageBox.Show("Lütfen Müşteri Seçiniz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnAracGüncel_Click(object sender, EventArgs e)
        {
            baglanti.mukerrerKayitArac("araba", txtAracPlaka.Text.Trim());
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Giriş yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtAracPlaka.Text = ""; txtAracKm.Text = ""; txtAracFiyatGun.Text = ""; txtAracFiyatHafta.Text = ""; cmbAracMarka.Text = null; cmbAracModel.Text = null; cmbAracYıl.Text = null; cmbAracVites.Text = null;
                cmbAracYakıt.Text = null; cmbAracMotorG.Text = null; cmbAracCekis.Text = null; cmbAracKapi.Text = null; cmbAracKasaT.Text = null; cmbAracRenk.Text = null;
                cmbAracMarka.Text = null; picArac.Image = null;

            }
            else if (txtAracPlaka.Text == "" || txtAracKm.Text == "" || txtAracFiyatGun.Text == "" || txtAracFiyatHafta.Text == "" || cmbAracMarka.Text == null || cmbAracModel.Text == null || cmbAracYıl.Text == null ||
                cmbAracVites.Text == null || cmbAracYakıt.Text == null || cmbAracMotorG.Text == null || cmbAracCekis.Text == null || cmbAracKapi.Text == null || cmbAracKasaT.Text == null ||
                cmbAracRenk.Text == null || cmbAracMarka.Text == null || picArac.Image == null)
            {
                MessageBox.Show("Lütfen Boş Alanları Doldurunuz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else if (pic.Visible == true && txtAracPlaka.Text != "" && txtAracKm.Text != "" && txtAracFiyatGun.Text != "" && txtAracFiyatHafta.Text != "" && cmbAracMarka.Text != null && cmbAracModel.Text != null
                && cmbAracYıl.Text != null && cmbAracVites.Text != null && cmbAracYakıt.Text != null && cmbAracMotorG.Text != null && cmbAracCekis.Text != null &&
                cmbAracKapi.Text != null && cmbAracKasaT.Text != null && cmbAracRenk.Text != null && cmbAracMarka.Text != null && picArac.Image != null)
            {
                if (arac.Durum != true)
                {
                    arac.ResimPath = picArac.ImageLocation.ToString();
                }
                baglanti.AracGüncelle(txtAracPlaka.Text.Trim(), cmbAracMarka.Text, cmbAracModel.Text, txtAracKm.Text.Trim(), cmbAracYıl.Text, cmbAracVites.Text, cmbAracYakıt.Text, cmbAracMotorG.Text
                    , cmbAracCekis.Text, cmbAracKapi.Text, cmbAracKasaT.Text, cmbAracRenk.Text, arac.ResimYolu(), txtAracFiyatGun.Text.Trim(), txtAracFiyatHafta.Text.Trim());
                baglanti.göster("araba", dataGrdArac);

                txtAracPlaka.Text = ""; txtAracKm.Text = ""; txtAracFiyatGun.Text = ""; txtAracFiyatHafta.Text = ""; cmbAracMarka.Text = null; cmbAracModel.Text = null; cmbAracYıl.Text = null; cmbAracVites.Text = null;
                cmbAracYakıt.Text = null; cmbAracMotorG.Text = null; cmbAracCekis.Text = null; cmbAracKapi.Text = null; cmbAracKasaT.Text = null; cmbAracRenk.Text = null;
                cmbAracMarka.Text = null; picArac.Image = null;
                MessageBox.Show("Araç Güncellendi.", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            baglanti.mukerrerKayıtMusteri("musteri", txtMusteriMail.Text, txtMusteriTc.Text);
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Giriş yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMusteriTc.Text = ""; txtMusteriAd.Text = ""; txtMusteriSoyad.Text = ""; dateMusteri.Value = DateTime.Now; txtMusteriMeslek.Text = ""; cmbMusteriMailAlan.Text = null;
                cmbMusteriCinsiyet.Text = null; ; txtMusteriTel.Text = ""; txtMusteriMail.Text = ""; txtMusteriAdres.Text = ""; cmbMusteriEhliyet.Text = null;
                txtMusteriSifre.Text = ""; picMusteri.Image = null;

            }
            else if (txtMusteriTc.Text == "" || txtMusteriAd.Text == "" || txtMusteriSoyad.Text == "" || txtMusteriMeslek.Text.Trim() == "" ||
               cmbMusteriCinsiyet.Text == "" || txtMusteriTel.Mask == "" || txtMusteriAdres.Text.Trim() == "" || txtMusteriMail.Text.Trim() == "" ||
               cmbMusteriEhliyet.Text == "" || cmbMusteriMailAlan.Text == "" || txtMusteriSifre.Text == "")
            {
                MessageBox.Show("Lütfen Boş Alanları Doldurunuz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (musteri.DateTimeYasHesabi(dateMusteri) < 18)
            {
                MessageBox.Show("Yaş Sınırı 18'dir!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtMusteriSifre.Text.Length < 5)
            {
                MessageBox.Show("Müşteri Şifresi 5 veya 5 Haneden Fazla Olmalıdır!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtMusteriTc.Text.Length != 11)
            {
                MessageBox.Show("Müşteri T.C. No 11 Hane Olmalıdır!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (baglanti.musteriKayitMusteri == false)
            {
                MessageBox.Show("Kullanıcı Sistemde Zaten Kayıtlıdır!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (pic.Visible && txtMusteriTc.Text != "" && txtMusteriAd.Text != "" && txtMusteriSoyad.Text != "" && txtMusteriMeslek.Text.Trim() != "" && baglanti.musteriKayitMusteri == true
             && cmbMusteriCinsiyet.Text != "" && txtMusteriTel.Mask != "" && txtMusteriAdres.Text.Trim() != "" && txtMusteriMail.Text.Trim() != "" &&
              cmbMusteriEhliyet.Text != "" && cmbMusteriMailAlan.Text != "" && txtMusteriSifre.Text != "" && musteri.DateTimeYasHesabi(dateMusteri) >= 18 &&
              txtMusteriSifre.Text.Length >= 5 && baglanti.musteriKayitMusteri == true)
            {
                if (cmbMusteriMailAlan.Text == "gmail.com")
                {
                    tab.SelectedTab = tabPage4;
                    MailKime = txtMusteriMail.Text + "@" + cmbMusteriMailAlan.Text;
                    MailBaslik = "Rentagon Kayıt";
                    MailMesaj = "Sayın;" + txtMusteriAd.Text + " " + txtMusteriSoyad.Text + Environment.NewLine + "\n Başarılı Bir Şekilde Kayıt Oldunuz";
                    txtMailKime.Text = MailKime;
                    txtMailBaslik.Text = MailBaslik;
                    txtMailMesaj.Text = MailMesaj;
                }
                else
                {
                    baglanti.MusteriEkle(txtMusteriTc.Text.Trim(), txtMusteriAd.Text.Trim().ToUpper(), txtMusteriSoyad.Text.Trim().ToUpper(), txtMusteriTel.Text.Trim(),
          txtMusteriMail.Text.Trim() + "@" + cmbMusteriMailAlan.Text, txtMusteriAdres.Text.Trim(), cmbMusteriEhliyet.Text, txtMusteriMeslek.Text.Trim().ToUpper(),
          txtMusteriSifre.Text.Trim(), dateMusteri.Value.Date, cmbMusteriCinsiyet.Text, musteri.ResimYolu());
                    baglanti.göster("musteri", dataGrdMusteri);

                    txtMusteriTc.Text = ""; txtMusteriAd.Text = ""; txtMusteriSoyad.Text = ""; dateMusteri.Value = DateTime.Now; txtMusteriMeslek.Text = ""; cmbMusteriMailAlan.Text = null;
                    cmbMusteriCinsiyet.Text = null; ; txtMusteriTel.Text = ""; txtMusteriMail.Text = ""; txtMusteriAdres.Text = ""; cmbMusteriEhliyet.Text = null;
                    txtMusteriSifre.Text = ""; picMusteri.Image = null;
                    MessageBox.Show("Müşteri Kaydı Yapıldı!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.YoneticiGirisi("adminler", txtid.Text.Trim(), txtSifre.Text.Trim());
            if (baglanti.yoneticiGiris)
            {
                id = txtid.Text;
                sifre = txtSifre.Text;
                pic.Visible = true;
                MessageBox.Show("Giriş Yapıldı!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Giriş Başarısız!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtid.Text = ""; txtSifre.Text = "";

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            moveX = e.X;
            moveY = e.Y;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void tArac_Tick(object sender, EventArgs e)
        {
            if (time1)
            {
                pAracDrop.Height += 10;
                if (pAracDrop.Size == pAracDrop.MaximumSize)
                {
                    tArac.Stop();
                    time1 = false;
                }
            }
            else
            {
                pAracDrop.Height -= 10;
                if (pAracDrop.Size == pAracDrop.MinimumSize)
                {
                    tArac.Stop();
                    time1 = true;
                }
            }


            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }


    }
}
