using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kütüphanem;

namespace ProjeKullanıcı
{
    public partial class FormKullanıcı : Form
    {
        public DataSet ds;
        string mail, sifre, tc;
        int moveX, moveY, menuWidth;
        bool move;
        Baglanti baglanti = new Baglanti();
        Musteri musteri = new Musteri();
        Arac arac = new Arac();
        public ColorDialog colorDialog = new ColorDialog();
        public FormKullanıcı()
        {
            InitializeComponent();
        }

        private void FormKullanıcı_Load(object sender, EventArgs e)
        {
            this.Hide();
            LoadingScreen load = new LoadingScreen();
            load.ShowDialog();
            tab.Appearance = TabAppearance.FlatButtons; tab.ItemSize = new Size(0, 1); tab.SizeMode = TabSizeMode.Fixed;
            menuWidth = pMenu.Width;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pMenu.Visible) pMenu.Visible = false;
            else pMenu.Visible = true;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblMusteriResim.Text = "Resim Ekle";
            btnMusteriGüncel.Visible = false;
            btnMusteriKayıtOl.Visible = true;
            label3.Enabled = true;
            txtMusteriTc.Enabled = true;
            txtMusteriSifreT.Visible = true;
            label27.Visible = true;
            tab.SelectedTab = tabPage2;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.KullaniciGirisi("musteri", txtMail.Text.Trim(), txtSifre.Text.Trim());
            if (baglanti.kullanıcıGiris)
            {
                btnMenuGiris.Enabled = false;
                mail = txtMail.Text;
                sifre = txtSifre.Text;
                pic.Visible = true;
                MessageBox.Show("Giriş Yapıldı!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                baglanti.MusteriBilgiDoldur(txtMusteriTc, txtMusteriAd, txtMusteriSoyad, txtMusteriMeslek, txtMail, cmbMusteriMailAlan, txtMusteriAdres, cmbMusteriEhliyet, txtSifre, dateMusteri, txtMusteriTel, cmbMusteriCinsiyet, picMusteri, txtMusteriMail, txtMusteriSifre);
                tc = txtMusteriTc.Text;
                tab.SelectedTab = tabPage3;
            }
            else
            {
                MessageBox.Show("Giriş Başarısız!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtMail.Text = ""; txtSifre.Text = "";

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnMenuGiris_Click(object sender, EventArgs e)
        {
            tab.SelectedTab = tabPage1;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tab.SelectedTab = tabPage3;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnMusteriKayıtOl_Click(object sender, EventArgs e)
        {
            
            baglanti.mukerrerKayıtMusteri("musteri", txtMusteriMail.Text, txtMusteriTc.Text);

            if (txtMusteriTc.Text == "" || txtMusteriAd.Text == "" || txtMusteriSoyad.Text == "" || txtMusteriMeslek.Text.Trim() == "" ||
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
            else if (txtMusteriTc.Text != "" && txtMusteriAd.Text != "" && txtMusteriSoyad.Text != "" && txtMusteriMeslek.Text.Trim() != ""
              && cmbMusteriCinsiyet.Text != "" && txtMusteriTel.Mask != "" && txtMusteriAdres.Text.Trim() != "" && txtMusteriMail.Text.Trim() != "" &&
               cmbMusteriEhliyet.Text != "" && cmbMusteriMailAlan.Text != "" && txtMusteriSifre.Text != "" && musteri.DateTimeYasHesabi(dateMusteri) >= 18 &&
               txtMusteriSifre.Text.Length >= 5 && baglanti.musteriKayitMusteri == true)
            {
                if (txtMusteriSifre.Text == txtMusteriSifreT.Text)
                {
                    if (cmbMusteriMailAlan.Text == "gmail.com")
                    {
                        musteri.MailGönder(txtMusteriMail.Text + "@" + cmbMusteriMailAlan.Text, "Rentagon Kayıt", "Tebrikler Başarılı Bir Şekilde Kayıt Oldunuz RentACar(Rentagon)");
                        baglanti.MusteriEkle(txtMusteriTc.Text.Trim(), txtMusteriAd.Text.Trim().ToUpper(), txtMusteriSoyad.Text.Trim().ToUpper(), txtMusteriTel.Text.Trim(),
               txtMusteriMail.Text.Trim() + "@" + cmbMusteriMailAlan.Text, txtMusteriAdres.Text.Trim(), cmbMusteriEhliyet.Text, txtMusteriMeslek.Text.Trim().ToUpper(),
               txtMusteriSifre.Text.Trim(), dateMusteri.Value.Date, cmbMusteriCinsiyet.Text, musteri.ResimYolu());

                        txtMusteriTc.Text = ""; txtMusteriAd.Text = ""; txtMusteriSoyad.Text = ""; dateMusteri.Value = DateTime.Now; txtMusteriMeslek.Text = ""; cmbMusteriMailAlan.Text = null;
                        cmbMusteriCinsiyet.Text = null; ; txtMusteriTel.Text = ""; txtMusteriMail.Text = ""; txtMusteriAdres.Text = ""; cmbMusteriEhliyet.Text = null;
                        txtMusteriSifre.Text = ""; picMusteri.Image = null;
                        MessageBox.Show("Kayıt Olundu, Giriş Yapabilrsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tab.SelectedTab = tabPage1;
                    }
                    else
                    {
                        baglanti.MusteriEkle(txtMusteriTc.Text.Trim(), txtMusteriAd.Text.Trim().ToUpper(), txtMusteriSoyad.Text.Trim().ToUpper(), txtMusteriTel.Text.Trim(),
               txtMusteriMail.Text.Trim() + "@" + cmbMusteriMailAlan.Text, txtMusteriAdres.Text.Trim(), cmbMusteriEhliyet.Text, txtMusteriMeslek.Text.Trim().ToUpper(),
               txtMusteriSifre.Text.Trim(), dateMusteri.Value.Date, cmbMusteriCinsiyet.Text, musteri.ResimYolu());

                        txtMusteriTc.Text = ""; txtMusteriAd.Text = ""; txtMusteriSoyad.Text = ""; dateMusteri.Value = DateTime.Now; txtMusteriMeslek.Text = ""; cmbMusteriMailAlan.Text = null;
                        cmbMusteriCinsiyet.Text = null; ; txtMusteriTel.Text = ""; txtMusteriMail.Text = ""; txtMusteriAdres.Text = ""; cmbMusteriEhliyet.Text = null;
                        txtMusteriSifre.Text = ""; picMusteri.Image = null;
                        MessageBox.Show("Kayıt Olundu, Giriş Yapabilrsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tab.SelectedTab = tabPage1;
                    }
                    
                }
                else
                {
                    MessageBox.Show("Şifre Tekrarı Şifre ile Aynı Olmalıdır!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void lblMusteriResim_Click(object sender, EventArgs e)
        {
            musteri.ResimEklemeMusteri(picMusteri);

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

        private void pic_Click(object sender, EventArgs e)
        {
            MusteriTemizle();
            btnMenuGiris.Enabled = true;
            pic.Visible = false;
            tab.SelectedTab = tabPage1;
            MessageBox.Show("Çıkış Yapıldı!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglanti.yoneticiGiris = false;
            mail = "";
            sifre = "";

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void texwtBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnMusteriEkle_Click_1(object sender, EventArgs e)
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
                MessageBox.Show("Müşteri Güncellendi.", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnMenuKira_Click(object sender, EventArgs e)
        {
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Giriş yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tab.SelectedTab = tabPage3;
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void cmbAracMarka_DropDown(object sender, EventArgs e)
        {
            baglanti.KullanıcıMarkaDoldur(cmbAracMarka, cmbAracModel, cmbAracYıl, cmbAracVites, cmbAracYakıt, cmbAracMotorG, cmbAracCekis, cmbAracKapi, cmbAracKasaT, cmbAracRenk);
            cmbAracMarka.SelectedItem = null;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void cmbAracYıl_DropDown(object sender, EventArgs e)
        {
            baglanti.KullanıcıYılDoldur(cmbAracMarka, cmbAracModel, cmbAracYıl, cmbAracVites, cmbAracYakıt, cmbAracMotorG, cmbAracCekis, cmbAracKapi, cmbAracKasaT, cmbAracRenk);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void cmbAracModel_DropDown(object sender, EventArgs e)
        {
            baglanti.KullanıcıModelDoldur(cmbAracMarka, cmbAracModel, cmbAracYıl, cmbAracVites, cmbAracYakıt, cmbAracMotorG, cmbAracCekis, cmbAracKapi, cmbAracKasaT, cmbAracRenk);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void cmbAracVites_DropDown(object sender, EventArgs e)
        {
            baglanti.KullanıcıVitesDoldur(cmbAracMarka, cmbAracModel, cmbAracYıl, cmbAracVites, cmbAracYakıt, cmbAracMotorG, cmbAracCekis, cmbAracKapi, cmbAracKasaT, cmbAracRenk);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void cmbAracYakıt_DropDown(object sender, EventArgs e)
        {
            baglanti.KullanıcıYakıtDoldur(cmbAracMarka, cmbAracModel, cmbAracYıl, cmbAracVites, cmbAracYakıt, cmbAracMotorG, cmbAracCekis, cmbAracKapi, cmbAracKasaT, cmbAracRenk);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void cmbAracMotorG_DropDown(object sender, EventArgs e)
        {
            baglanti.KullanıcıMotorGDoldur(cmbAracMarka, cmbAracModel, cmbAracYıl, cmbAracVites, cmbAracYakıt, cmbAracMotorG, cmbAracCekis, cmbAracKapi, cmbAracKasaT, cmbAracRenk);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void cmbAracCekis_DropDown(object sender, EventArgs e)
        {
            baglanti.KullanıcıÇekişDoldur(cmbAracMarka, cmbAracModel, cmbAracYıl, cmbAracVites, cmbAracYakıt, cmbAracMotorG, cmbAracCekis, cmbAracKapi, cmbAracKasaT, cmbAracRenk);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void cmbAracKapi_DropDown(object sender, EventArgs e)
        {
            baglanti.KullanıcıKapıDoldur(cmbAracMarka, cmbAracModel, cmbAracYıl, cmbAracVites, cmbAracYakıt, cmbAracMotorG, cmbAracCekis, cmbAracKapi, cmbAracKasaT, cmbAracRenk);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void cmbAracKasaT_DropDown(object sender, EventArgs e)
        {
            baglanti.KullanıcıKasaTDoldur(cmbAracMarka, cmbAracModel, cmbAracYıl, cmbAracVites, cmbAracYakıt, cmbAracMotorG, cmbAracCekis, cmbAracKapi, cmbAracKasaT, cmbAracRenk);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void cmbAracRenk_DropDown(object sender, EventArgs e)
        {
            baglanti.KullanıcıRenkDoldur(cmbAracMarka, cmbAracModel, cmbAracYıl, cmbAracVites, cmbAracYakıt, cmbAracMotorG, cmbAracCekis, cmbAracKapi, cmbAracKasaT, cmbAracRenk);

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            KiraTemizle();
            grpMusteriKira.Visible = false;
            btnKirala.Visible = false;
            dateKiraAlis.Value = DateTime.Now;
            dateKiraVeris.Value = DateTime.Now;
            lblKiraTutar.Text = "";
            lblKiraGun.Text = "";

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

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbAracMarka.Text) || string.IsNullOrEmpty(cmbAracModel.Text) || string.IsNullOrEmpty(cmbAracYıl.Text) || string.IsNullOrEmpty(cmbAracVites.Text) || string.IsNullOrEmpty(cmbAracYakıt.Text) || string.IsNullOrEmpty(cmbAracMotorG.Text) || string.IsNullOrEmpty(cmbAracCekis.Text) || string.IsNullOrEmpty(cmbAracKapi.Text) || string.IsNullOrEmpty(cmbAracKasaT.Text) || string.IsNullOrEmpty(cmbAracRenk.Text))
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                baglanti.Hesapla(cmbAracMarka, cmbAracModel, cmbAracYıl, cmbAracVites, cmbAracYakıt, cmbAracMotorG, cmbAracCekis, cmbAracKapi, cmbAracKasaT, cmbAracRenk, picArac, txtAracFiyatGun, txtAracFiyatHafta, txtAracPlaka, txtAracKm);
                btnKirala.Visible = true;
                grpMusteriKira.Visible = true;
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnKirala_Click(object sender, EventArgs e)
        {
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage6;
            }
            else
            {
                baglanti.MusteriAracKira(txtAracPlaka, cmbAracMarka, cmbAracModel, txtAracFiyatGun, txtAracFiyatHafta, picMusteri.ImageLocation, txtMusteriTc, txtMusteriAd, txtMusteriSoyad, txtMusteriTel, picArac.ImageLocation, dateKiraAlis, dateKiraVeris, lblKiraTutar);
                KiraTemizle();
            }
            btnKirala.Visible = false;
            grpMusteriKira.Visible = false;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TimeSpan gün = DateTime.Parse(dateKiraVeris.Text) - DateTime.Parse(dateKiraAlis.Text);
            lblKiraGun.Text = gün.Days.ToString();

            int kalan = Convert.ToInt32(lblKiraGun.Text) % 7;
            int tam = Convert.ToInt32(lblKiraGun.Text) / 7;

            lblKiraTutar.Text = (Convert.ToInt32(txtAracFiyatGun.Text) * kalan + Convert.ToInt32(txtAracFiyatHafta.Text) * tam).ToString();

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnMenuDüzenle_Click(object sender, EventArgs e)
        {
            if (pic.Visible == false)
            {
                tab.SelectedTab = tabPage1;
                MessageBox.Show("Lütfen Giriş yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                lblMusteriResim.Text = "Güncelle";
                btnMusteriKayıtOl.Visible = false;
                btnMusteriGüncel.Visible = true;
                label3.Enabled = false;
                txtMusteriTc.Enabled = false;
                txtMusteriSifreT.Visible = false;
                label27.Visible = false;
                tab.SelectedTab = tabPage2;
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnKiraMisafir_Click(object sender, EventArgs e)
        {
            if (txtTcMisafir.Text.Length != 11)
            {
                MessageBox.Show("Lütfen T.C. No'nuzu 11 Hane Giriniz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(txtAdMisafir.Text) || string.IsNullOrEmpty(txtSoyadMisafir.Text) || string.IsNullOrEmpty(txtTelMisafir.Text))
            {
                MessageBox.Show("Lütfen Boşlukları Doldurunuz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtTcMisafir.Text.Length == 11 && !string.IsNullOrEmpty(txtAdMisafir.Text) && !string.IsNullOrEmpty(txtSoyadMisafir.Text) && !string.IsNullOrEmpty(txtTelMisafir.Text))
            {
                baglanti.KiralamaMisafir(txtAracPlaka, cmbAracMarka, cmbAracModel, txtAracFiyatGun, txtAracFiyatHafta, txtTcMisafir, txtAdMisafir, txtSoyadMisafir, txtTelMisafir, picArac.ImageLocation, dateKiraAlis, dateKiraVeris, lblKiraTutar);
                KiraTemizle();
                txtTcMisafir.Text = "";
                txtAdMisafir.Text = "";
                txtSoyadMisafir.Text = "";
                txtTelMisafir.Text = "";
                tab.SelectedTab = tabPage3;
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Dosyası (*.xls)|*.xls";
            sfd.FileName = "KiraGeçmişim.xls";
            if(sfd.ShowDialog()== DialogResult.OK)
            {
                musteri.ExportToExcel(dataGrdKiraGeçmiş, sfd.FileName);
            }

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnMenuAyarlar_Click(object sender, EventArgs e)
        {
            tab.SelectedTab = tabPage5;

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

        private void btnMenuHakkında_Click(object sender, EventArgs e)
        {
            tab.SelectedTab = tabPage4;


            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            txtSifre.UseSystemPasswordChar = false;
            pictureBox6.Image = ProjeKullanıcı.Properties.Resources._12817944411535694877_512;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void pictureBox6_MouseUp(object sender, MouseEventArgs e)
        {
            txtSifre.UseSystemPasswordChar = true;
            pictureBox6.Image = ProjeKullanıcı.Properties.Resources.img_539706;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void btnKiraGecmis_Click(object sender, EventArgs e)
        {
            if (pic.Visible)
            {
                tab.SelectedTab = tabPage7;
                baglanti.KiraGecmis(dataGrdKiraGeçmiş,tc);
            }
            else
            {
                MessageBox.Show("Bu Özellikten Sadece Kayıtlı Kullanıcılar Faydalanabilir!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public void KiraTemizle()
        {
            txtAracFiyatGun.Text = ""; txtAracFiyatHafta.Text = ""; txtAracPlaka.Text = ""; txtAracKm.Text = "";
            cmbAracMarka.Items.Clear(); cmbAracModel.Items.Clear(); cmbAracYıl.Items.Clear(); cmbAracVites.Items.Clear(); cmbAracYakıt.Items.Clear();
            cmbAracMotorG.Items.Clear(); cmbAracCekis.Items.Clear(); cmbAracKapi.Items.Clear(); cmbAracKasaT.Items.Clear(); cmbAracRenk.Items.Clear();
            picArac.ImageLocation = null;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        public void MusteriTemizle()
        {
            txtMusteriTc.Text = "";
            txtMusteriAd.Text = "";
            txtMusteriSoyad.Text = "";
            dateMusteri.Value = DateTime.Now;
            txtMusteriMeslek.Text = "";
            cmbMusteriCinsiyet.Text = null;
            txtMusteriTel.Text = "";
            txtMusteriMail.Text = "";
            cmbMusteriMailAlan.Text = null;
            txtMusteriAdres.Text = "";
            cmbMusteriEhliyet.Text = null;
            txtMusteriSifre.Text = "";
            txtMusteriSifreT.Text = "";
            picMusteri.ImageLocation = null;

            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

    }
}
