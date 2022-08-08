using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace Kütüphanem
{
    public class Baglanti
    {
        SqlConnection con=new SqlConnection(@"Data Source=.\SQLExpress;Integrated Security = true; AttachDbFilename=|DataDirectory|\AracKira2.mdf;User Instance = true");
        //SqlConnection con = new SqlConnection(@"Data Source=AYGUN\SQLEXPRESS;Initial Catalog=AracKira;Integrated Security=True");
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        DataTable dt;
        public DataSet ds;
        public bool musteriKayitMusteri;
        public bool kullanıcıGiris;
        public bool yoneticiGiris;
        public bool aracKayitPlaka;



        // Ana Makine Yetkisi
        public void göster(string serverTabloAdi, DataGridView formTabloAdi)
        {
            try
            {
                da = new SqlDataAdapter("Select *From " + serverTabloAdi, con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, serverTabloAdi);
                formTabloAdi.DataSource = ds.Tables[serverTabloAdi];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Meydana Geldi!!" + Environment.NewLine + ex.ToString(), "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        // Admin Yetkisi
        public void göster(string serverTabloAdi, DataGridView formTabloAdi, string login, string password)
        {
            //con = new SqlConnection(@"Data Source=AYGUN\SQLEXPRESS;User ID=" + login + ";Password=" + password);
            con = new SqlConnection(@"Data Source=.\SQLExpress;User ID=" + login + ";Password=" + password);
            da = new SqlDataAdapter("Select *From " + serverTabloAdi, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, serverTabloAdi);
            formTabloAdi.DataSource = ds.Tables[serverTabloAdi];
            con.Close();

        }


        public void MusteriEkle(string tc, string ad, string soyad, string tel, string mail, string adres, string ehliyet, string meslek, string sifre, DateTime date, string cinsiyet, string resim)
        {
            string sorgu = "Insert into musteri (TC_No, Ad, Soyad, Dogum_Tarihi, Meslek, Cinsiyet, Telefon, E_Mail, Adres, Ehliyet, Sifre, Resim)" +
            " values (@TC_No, @Ad, @Soyad, @Dogum_Tarihi, @Meslek, @Cinsiyet, @Telefon, @E_Mail, @Adres, @Ehliyet,@Sifre,@Resim)";


            // Parametreli sorgu yaptım.
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@TC_No", tc);
            cmd.Parameters.AddWithValue("@Ad", ad);
            cmd.Parameters.AddWithValue("@Soyad", soyad);
            cmd.Parameters.AddWithValue("@Telefon", tel);
            cmd.Parameters.AddWithValue("@E_Mail", mail);
            cmd.Parameters.AddWithValue("@Adres", adres);
            cmd.Parameters.AddWithValue("@Meslek", meslek);
            cmd.Parameters.AddWithValue("@Ehliyet", ehliyet);
            cmd.Parameters.AddWithValue("@Sifre", sifre);
            cmd.Parameters.AddWithValue("@Dogum_Tarihi", date);
            cmd.Parameters.AddWithValue("@Cinsiyet", cinsiyet);
            cmd.Parameters.AddWithValue("@Resim", resim);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void MusteriGüncelle(string tc, string ad, string soyad, string tel, string mail, string adres, string ehliyet, string meslek, string sifre, DateTime date, string cinsiyet, string resim)
        {
            string sorgu = "Update musteri Set TC_No=@TC_No, Ad=@Ad,Soyad=@Soyad,Telefon=@Telefon,E_Mail=@E_Mail,Adres=@Adres," +
           "Meslek=@Meslek,Ehliyet=@Ehliyet,Sifre=@Sifre,Dogum_Tarihi=@Dogum_Tarihi," +
           "Cinsiyet=@Cinsiyet,Resim=@Resim Where TC_No=@TC_No";

            // Parametreli sorgu yaptım.
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@TC_No", tc);
            cmd.Parameters.AddWithValue("@Ad", ad);
            cmd.Parameters.AddWithValue("@Soyad", soyad);
            cmd.Parameters.AddWithValue("@Telefon", tel);
            cmd.Parameters.AddWithValue("@E_Mail", mail);
            cmd.Parameters.AddWithValue("@Adres", adres);
            cmd.Parameters.AddWithValue("@Meslek", meslek);
            cmd.Parameters.AddWithValue("@Ehliyet", ehliyet);
            cmd.Parameters.AddWithValue("@Sifre", sifre);
            cmd.Parameters.AddWithValue("@Dogum_Tarihi", date);
            cmd.Parameters.AddWithValue("@Cinsiyet", cinsiyet);
            cmd.Parameters.AddWithValue("@Resim", resim);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void MusteriSil(string tc)
        {
            try
            {
                string sorgu = "Delete From musteri Where TC_No=@TC_No";
                cmd = new SqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@TC_No", tc);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Meydana Geldi!!" + Environment.NewLine + ex.ToString(), "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }


        public void AracEkle(string plaka, string marka, string model, string km, string yıl, string vites, string yakıt, string motorG, string çekiş, string kapı, string kasaT, string renk, string resim, string fiyatGun, string fiyatHafta)
        {
            string sorgu = "Insert into araba (Plaka, Marka, Model, Yıl, Km, Vites, Yakıt, Motor_Gücü, Çekiş, Kapı, Kasa_Tipi, Renk, Resim, Fiyat_Gun,Fiyat_Hafta,Durum)" +
            " values (@Plaka, @Marka, @Model, @Yıl, @Km, @Vites, @Yakıt, @Motor_Gücü, @Çekiş, @Kapı, @Kasa_Tipi, @Renk, @Resim, @Fiyat_Gun,@Fiyat_Hafta,@Durum)";
            // Parametreli sorgu yaptım.
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Plaka", plaka);
            cmd.Parameters.AddWithValue("@Marka", marka);
            cmd.Parameters.AddWithValue("@Model", model);
            cmd.Parameters.AddWithValue("@Yıl", yıl);
            cmd.Parameters.AddWithValue("@Km", km);
            cmd.Parameters.AddWithValue("@Vites", vites);
            cmd.Parameters.AddWithValue("@Yakıt", yakıt);
            cmd.Parameters.AddWithValue("@Motor_Gücü", motorG);
            cmd.Parameters.AddWithValue("@Çekiş", çekiş);
            cmd.Parameters.AddWithValue("@Kapı", kapı);
            cmd.Parameters.AddWithValue("@Kasa_Tipi", kasaT);
            cmd.Parameters.AddWithValue("@Renk", renk);
            cmd.Parameters.AddWithValue("@Resim", resim);
            cmd.Parameters.AddWithValue("@Fiyat_Gun", fiyatGun);
            cmd.Parameters.AddWithValue("@Fiyat_Hafta", fiyatHafta);
            cmd.Parameters.AddWithValue("@Durum", "MÜSAİT");

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void AracGüncelle(string plaka, string marka, string model, string km, string yıl, string vites, string yakıt, string motorG, string çekiş, string kapı, string kasaT, string renk, string resim, string fiyatGun, string fiyatHafta)
        {
            string sorgu = "Update araba Set Plaka=@Plaka, Marka=@Marka, Model=@Model, Yıl=@Yıl, Km=@Km, Vites=@Vites," +
            " Yakıt=@Yakıt, Motor_Gücü=@Motor_Gücü, Çekiş=@Çekiş, Kapı=@Kapı, Kasa_Tipi=@Kasa_Tipi, Renk=@Renk, Resim=@Resim, Fiyat_Gun=@Fiyat_Gun,Fiyat_Hafta=@Fiyat_Hafta  Where Plaka=@Plaka";

            // Parametreli sorgu yaptım.
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Plaka", plaka);
            cmd.Parameters.AddWithValue("@Marka", marka);
            cmd.Parameters.AddWithValue("@Model", model);
            cmd.Parameters.AddWithValue("@Yıl", yıl);
            cmd.Parameters.AddWithValue("@Km", km);
            cmd.Parameters.AddWithValue("@Vites", vites);
            cmd.Parameters.AddWithValue("@Yakıt", yakıt);
            cmd.Parameters.AddWithValue("@Motor_Gücü", motorG);
            cmd.Parameters.AddWithValue("@Çekiş", çekiş);
            cmd.Parameters.AddWithValue("@Kapı", kapı);
            cmd.Parameters.AddWithValue("@Kasa_Tipi", kasaT);
            cmd.Parameters.AddWithValue("@Renk", renk);
            cmd.Parameters.AddWithValue("@Resim", resim);
            cmd.Parameters.AddWithValue("@Fiyat_Gun", fiyatGun);
            cmd.Parameters.AddWithValue("@Fiyat_Hafta", fiyatHafta);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void AracSil(string plaka)
        {
            string sorgu = "Delete From araba Where Plaka=@Plaka";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Plaka", plaka);
            con.Open();
            cmd.ExecuteNonQuery();

            con.Close();
        }


        public void mukerrerKayıtMusteri(string serverTabloAdi, string mail, string tc)
        {

            // Aynı Mail'e sahip birden fazla kişi olamadığından aşağıda koşul koydum ve çıktı olarak bool bir ifaede elde ettim.
            con.Open();
            cmd = new SqlCommand("select * from " + serverTabloAdi + " where E_Mail=@E_Mail or TC_No=@TC_No", con);
            cmd.Parameters.AddWithValue("@E_Mail", mail);
            cmd.Parameters.AddWithValue("@TC_No", tc);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) musteriKayitMusteri = false;
            else musteriKayitMusteri = true;
            con.Close();

        }


        public void mukerrerKayitArac(string serverTabloAdi, string plaka)
        {
            con.Open();
            cmd = new SqlCommand("select * from " + serverTabloAdi + " where Plaka=@Plaka", con);
            cmd.Parameters.AddWithValue("@Plaka", plaka);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) aracKayitPlaka = false;
            else aracKayitPlaka = true;

            con.Close();

        }


        public void KullaniciGirisi(string serverTabloAdi, string mail, string sifre)
        {
            try
            {
                // Tüm tabloda girilen Kullanıcı Mail ve Sifreyi arıyor, eğer yoksa bool ifade false varsa true değerini döndürüyor.
                con.Open();
                cmd = new SqlCommand("select * from " + serverTabloAdi + " where (E_Mail=@E_Mail) and (Sifre=@Sifre)", con);
                cmd.Parameters.AddWithValue("@E_Mail", mail);
                cmd.Parameters.AddWithValue("@Sifre", sifre);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) kullanıcıGiris = true;
                else kullanıcıGiris = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Meydana Geldi!!" + Environment.NewLine + ex.ToString(), "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }


        public void YoneticiGirisi(string serverTabloAdi, string id, string sifre)
        {
            try
            {
                // Tüm tabloda girilen Yönetici id ve Sifreyi arıyor, eğer yoksa bool ifade false varsa true değerini döndürüyor.
                con.Open();
                cmd = new SqlCommand("select * from " + serverTabloAdi + " where (sifre=@sifre) and (id=@id)", con);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr2 = cmd.ExecuteReader();
                if (dr2.Read()) yoneticiGiris = true;
                else yoneticiGiris = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Meydana Geldi!!" + Environment.NewLine + ex.ToString(), "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }



        public void KiraMusteriDoldur(string tc, TextBox ad, TextBox soyad, MaskedTextBox tel, PictureBox pic) // musteri tablosundaki girilen tcye göre o satıdaki bilgileri çektim.
        {

            string sorgu = "Select *From musteri where TC_No=@TC_No";
            con.Open();
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@TC_No", tc);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ad.Text = dr["Ad"].ToString();
                soyad.Text = dr["Soyad"].ToString();
                tel.Text = dr["Telefon"].ToString();
                pic.ImageLocation = dr["Resim"].ToString();

            }
            con.Close();

        }

        public void KiraAracDoldur(string plaka, TextBox marka, TextBox model, TextBox FiyatGun, TextBox FiyatHafta, PictureBox pic)// araba tablosundan girilen plaka ile o satıra ait bilgileri çektim.
        {

            string sorgu = "Select *From araba where Plaka=@Plaka";
            con.Open();
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Plaka", plaka);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                marka.Text = dr["Marka"].ToString();
                model.Text = dr["Model"].ToString();
                FiyatGun.Text = dr["Fiyat_Gun"].ToString();
                FiyatHafta.Text = dr["Fiyat_Hafta"].ToString();
                pic.ImageLocation = dr["Resim"].ToString();

            }
            con.Close();

        }
        public void KiraMusteriCmbTc_PlakaDoldur(ComboBox cmbTc, ComboBox cmbPlaka)// musteri tablosundaki tüm tcleri cmbTc'ye aktardım ve araba tablosundaki durumu müsait olan tüm arabaları cmbPlaka'ya aktardım.
        {

            string sorgu1 = "select * from musteri";
            con.Open();
            cmd = new SqlCommand(sorgu1, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbTc.Items.Add(dr["TC_No"]);
            }
            con.Close();

            string sorgu2 = "select * from araba where Durum=@Durum";
            con.Open();
            cmd = new SqlCommand(sorgu2, con);
            cmd.Parameters.AddWithValue("@Durum", "Müsait");
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbPlaka.Items.Add(dr["Plaka"]);
            }
            con.Close();

        }

        public void gösterKirdakiler(DataGridView formTabloAdi) // kira tablosundaki verileri çektim(KİRADA olanları).
        {
            con.Open();
            string kayit = "Select *From kira where Durum=@Durum";
            cmd = new SqlCommand(kayit, con);
            cmd.Parameters.AddWithValue("@Durum", "KİRADA");
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            formTabloAdi.DataSource = dt;
            con.Close();

        }


        public void gösterMusait(DataGridView formTabloAdi) // araba tablosundaki verileri çektim(MÜSAİT olanları). 
        {

            con.Open();
            string kayit = "Select *From araba where Durum=@Durum";
            cmd = new SqlCommand(kayit, con);
            cmd.Parameters.AddWithValue("@Durum", "MÜSAİT");
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            formTabloAdi.DataSource = dt;
            con.Close();

        }

        // araba tablosunun durumunu KİRADA olarak güncelledim ve kira tablosuna seçilen müşteri ve araba bilgilerini ekledim.
        public void KiraEkle(string plaka, TextBox marka, TextBox model, TextBox fiyatGun, TextBox fiyatHafta, string resimMusteri, ComboBox tc, TextBox ad, TextBox soyad, MaskedTextBox tel, string resimArac, DateTimePicker alış, DateTimePicker veriş, Label tutar)
        {
            string sorgu = "Update araba Set Durum=@Durum Where Plaka=@Plaka";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Plaka", plaka);
            cmd.Parameters.AddWithValue("@Durum", "KİRADA");

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            string sorgu2 = "Insert into kira (Plaka, Marka, Model, Fiyat_Gün, Fiyat_Hafta, TC_No, Ad, Soyad, Telefon, Arac_Resim, Musteri_Resim, Alış_Tarihi, Veriş_Tarihi, Durum,Tutar)" +
           " values (@Plaka, @Marka, @Model, @Fiyat_Gün, @Fiyat_Hafta, @TC_No, @Ad, @Soyad, @Telefon, @Arac_Resim, @Musteri_Resim, @Alış_Tarihi, @Veriş_Tarihi, @Durum,@Tutar)";

            cmd = new SqlCommand(sorgu2, con);
            cmd.Parameters.AddWithValue("@Plaka", plaka);
            cmd.Parameters.AddWithValue("@Marka", marka.Text);
            cmd.Parameters.AddWithValue("@Model", model.Text);
            cmd.Parameters.AddWithValue("@Fiyat_Gün", fiyatGun.Text);
            cmd.Parameters.AddWithValue("@Fiyat_Hafta", fiyatHafta.Text);
            cmd.Parameters.AddWithValue("@TC_No", tc.Text);
            cmd.Parameters.AddWithValue("@Ad", ad.Text);
            cmd.Parameters.AddWithValue("@Soyad", soyad.Text);
            cmd.Parameters.AddWithValue("@Telefon", tel.Text);
            cmd.Parameters.AddWithValue("@Arac_Resim", resimArac);
            cmd.Parameters.AddWithValue("@Musteri_Resim", resimMusteri);
            cmd.Parameters.AddWithValue("@Alış_Tarihi", alış.Value);
            cmd.Parameters.AddWithValue("@Veriş_Tarihi", veriş.Value);
            cmd.Parameters.AddWithValue("@Durum", "KİRADA");
            cmd.Parameters.AddWithValue("@Tutar", fiyatGun.Text);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void KiraTeslim(string plaka) // kira ve araba tablolarının durumlarını MÜSAİT yaptım.
        {
            string sorgu = "Update araba Set Durum=@Durum Where Plaka=@Plaka";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Plaka", plaka);
            cmd.Parameters.AddWithValue("@Durum", "MÜSAİT");

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            string sorgu2 = "Update kira Set Durum=@Durum Where Plaka=@Plaka";
            cmd = new SqlCommand(sorgu2, con);
            cmd.Parameters.AddWithValue("@Plaka", plaka);
            cmd.Parameters.AddWithValue("@Durum", "MÜSAİT");

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void KiraGecmis(DataGridView formTabloAdi, string tc) // kira tablosundaki verileri çektim(KİRADA olanları).
        {

            con.Open();
            string kayit = "Select *From kira where TC_No=@TC_No";
            cmd = new SqlCommand(kayit, con);
            cmd.Parameters.AddWithValue("@TC_No", tc);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            formTabloAdi.DataSource = dt;
            con.Close();

        }


        public void dataSet(DataGridView formTabloAdi)
        {
            da = new SqlDataAdapter("Select *From araba ", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "araba");
            formTabloAdi.DataSource = ds.Tables["araba"];
            con.Close();

        }

        public void KullanıcıMarkaDoldur(ComboBox marka, ComboBox model, ComboBox yıl, ComboBox vites, ComboBox yakıt, ComboBox motor, ComboBox çekiş, ComboBox kapı, ComboBox kasa, ComboBox renk)
        {
            string sorgu = "Select *From araba where Durum='MÜSAİT'";

            if (!string.IsNullOrEmpty(marka.Text))
            {
                sorgu += " and Marka=@Marka";
            }

            if (!string.IsNullOrEmpty(model.Text))
            {
                sorgu += " and Model=@Model";
            }

            if (!string.IsNullOrEmpty(yıl.Text))
            {
                sorgu += " and Yıl=@Yıl";
            }

            if (vites.Text != "")
            {
                sorgu += " and Vites=@Vites";
            }

            if (yakıt.Text != "")
            {
                sorgu += " and Yakıt=@Yakıt";
            }

            if (motor.Text != "")
            {
                sorgu += " and Motor_Gücü=@Motor_Gücü";
            }

            if (çekiş.Text != "")
            {
                sorgu += " and Çekiş=@Çekiş";
            }

            if (kapı.Text != "")
            {
                sorgu += " and Kapı=@Kapı";
            }

            if (kasa.Text != "")
            {
                sorgu += " and Kasa_Tipi=@Kasa_Tipi";
            }

            if (renk.Text != "")
            {
                sorgu += " and Renk=@Renk";
            }


            con.Open();
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Durum", "MÜSAİT");
            cmd.Parameters.AddWithValue("@Marka", marka.Text.ToString());
            cmd.Parameters.AddWithValue("@Model", model.Text.ToString());
            cmd.Parameters.AddWithValue("@Yıl", yıl.Text.ToString());
            cmd.Parameters.AddWithValue("@Vites", vites.Text);
            cmd.Parameters.AddWithValue("@Yakıt", yakıt.Text);
            cmd.Parameters.AddWithValue("@Motor_Gücü", motor.Text);
            cmd.Parameters.AddWithValue("@Çekiş", çekiş.Text);
            cmd.Parameters.AddWithValue("@Kapı", kapı.Text);
            cmd.Parameters.AddWithValue("@Kasa_Tipi", kasa.Text);
            cmd.Parameters.AddWithValue("@Renk", renk.Text);
            dr = cmd.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {

                i = marka.FindStringExact(dr["Marka"].ToString());
                if (i == -1)
                {
                    marka.Items.Add(dr["Marka"]);
                }
            }
            con.Close();
        }

        public void KullanıcıModelDoldur(ComboBox marka, ComboBox model, ComboBox yıl, ComboBox vites, ComboBox yakıt, ComboBox motor, ComboBox çekiş, ComboBox kapı, ComboBox kasa, ComboBox renk)
        {
            string sorgu = "Select *From araba where Durum='MÜSAİT'";

            if (!string.IsNullOrEmpty(marka.Text))
            {
                sorgu += " and Marka=@Marka";
            }

            if (!string.IsNullOrEmpty(model.Text))
            {
                sorgu += " and Model=@Model";
            }

            if (!string.IsNullOrEmpty(yıl.Text))
            {
                sorgu += " and Yıl=@Yıl";
            }

            if (vites.Text != "")
            {
                sorgu += " and Vites=@Vites";
            }

            if (yakıt.Text != "")
            {
                sorgu += " and Yakıt=@Yakıt";
            }

            if (motor.Text != "")
            {
                sorgu += " and Motor_Gücü=@Motor_Gücü";
            }

            if (çekiş.Text != "")
            {
                sorgu += " and Çekiş=@Çekiş";
            }

            if (kapı.Text != "")
            {
                sorgu += " and Kapı=@Kapı";
            }

            if (kasa.Text != "")
            {
                sorgu += " and Kasa_Tipi=@Kasa_Tipi";
            }

            if (renk.Text != "")
            {
                sorgu += " and Renk=@Renk";
            }


            con.Open();
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Durum", "MÜSAİT");
            cmd.Parameters.AddWithValue("@Marka", marka.Text.ToString());
            cmd.Parameters.AddWithValue("@Model", model.Text.ToString());
            cmd.Parameters.AddWithValue("@Yıl", yıl.Text.ToString());
            cmd.Parameters.AddWithValue("@Vites", vites.Text);
            cmd.Parameters.AddWithValue("@Yakıt", yakıt.Text);
            cmd.Parameters.AddWithValue("@Motor_Gücü", motor.Text);
            cmd.Parameters.AddWithValue("@Çekiş", çekiş.Text);
            cmd.Parameters.AddWithValue("@Kapı", kapı.Text);
            cmd.Parameters.AddWithValue("@Kasa_Tipi", kasa.Text);
            cmd.Parameters.AddWithValue("@Renk", renk.Text);
            dr = cmd.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                i = model.FindStringExact(dr["Model"].ToString());
                if (i == -1)
                {
                    model.Items.Add(dr["Model"]);
                }
            }
            con.Close();
        }

        public void KullanıcıYılDoldur(ComboBox marka, ComboBox model, ComboBox yıl, ComboBox vites, ComboBox yakıt, ComboBox motor, ComboBox çekiş, ComboBox kapı, ComboBox kasa, ComboBox renk)
        {
            string sorgu = "Select *From araba where Durum='MÜSAİT'";

            if (!string.IsNullOrEmpty(marka.Text))
            {
                sorgu += " and Marka=@Marka";
            }

            if (!string.IsNullOrEmpty(model.Text))
            {
                sorgu += " and Model=@Model";
            }

            if (!string.IsNullOrEmpty(yıl.Text))
            {
                sorgu += " and Yıl=@Yıl";
            }

            if (vites.Text != "")
            {
                sorgu += " and Vites=@Vites";
            }

            if (yakıt.Text != "")
            {
                sorgu += " and Yakıt=@Yakıt";
            }

            if (motor.Text != "")
            {
                sorgu += " and Motor_Gücü=@Motor_Gücü";
            }

            if (çekiş.Text != "")
            {
                sorgu += " and Çekiş=@Çekiş";
            }

            if (kapı.Text != "")
            {
                sorgu += " and Kapı=@Kapı";
            }

            if (kasa.Text != "")
            {
                sorgu += " and Kasa_Tipi=@Kasa_Tipi";
            }

            if (renk.Text != "")
            {
                sorgu += " and Renk=@Renk";
            }

            con.Open();
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Durum", "MÜSAİT");
            cmd.Parameters.AddWithValue("@Marka", marka.Text.ToString());
            cmd.Parameters.AddWithValue("@Model", model.Text.ToString());
            cmd.Parameters.AddWithValue("@Yıl", yıl.Text.ToString());
            cmd.Parameters.AddWithValue("@Vites", vites.Text);
            cmd.Parameters.AddWithValue("@Yakıt", yakıt.Text);
            cmd.Parameters.AddWithValue("@Motor_Gücü", motor.Text);
            cmd.Parameters.AddWithValue("@Çekiş", çekiş.Text);
            cmd.Parameters.AddWithValue("@Kapı", kapı.Text);
            cmd.Parameters.AddWithValue("@Kasa_Tipi", kasa.Text);
            cmd.Parameters.AddWithValue("@Renk", renk.Text);
            dr = cmd.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                i = yıl.FindStringExact(dr["Yıl"].ToString());
                if (i == -1)
                {
                    yıl.Items.Add(dr["Yıl"]);
                }
            }
            con.Close();
        }

        public void KullanıcıVitesDoldur(ComboBox marka, ComboBox model, ComboBox yıl, ComboBox vites, ComboBox yakıt, ComboBox motor, ComboBox çekiş, ComboBox kapı, ComboBox kasa, ComboBox renk)
        {
            string sorgu = "Select *From araba where Durum='MÜSAİT'";

            if (!string.IsNullOrEmpty(marka.Text))
            {
                sorgu += " and Marka=@Marka";
            }

            if (!string.IsNullOrEmpty(model.Text))
            {
                sorgu += " and Model=@Model";
            }

            if (!string.IsNullOrEmpty(yıl.Text))
            {
                sorgu += " and Yıl=@Yıl";
            }

            if (vites.Text != "")
            {
                sorgu += " and Vites=@Vites";
            }

            if (yakıt.Text != "")
            {
                sorgu += " and Yakıt=@Yakıt";
            }

            if (motor.Text != "")
            {
                sorgu += " and Motor_Gücü=@Motor_Gücü";
            }

            if (çekiş.Text != "")
            {
                sorgu += " and Çekiş=@Çekiş";
            }

            if (kapı.Text != "")
            {
                sorgu += " and Kapı=@Kapı";
            }

            if (kasa.Text != "")
            {
                sorgu += " and Kasa_Tipi=@Kasa_Tipi";
            }

            if (renk.Text != "")
            {
                sorgu += " and Renk=@Renk";
            }

            con.Open();
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Durum", "MÜSAİT");
            cmd.Parameters.AddWithValue("@Marka", marka.Text.ToString());
            cmd.Parameters.AddWithValue("@Model", model.Text.ToString());
            cmd.Parameters.AddWithValue("@Yıl", yıl.Text.ToString());
            cmd.Parameters.AddWithValue("@Vites", vites.Text);
            cmd.Parameters.AddWithValue("@Yakıt", yakıt.Text);
            cmd.Parameters.AddWithValue("@Motor_Gücü", motor.Text);
            cmd.Parameters.AddWithValue("@Çekiş", çekiş.Text);
            cmd.Parameters.AddWithValue("@Kapı", kapı.Text);
            cmd.Parameters.AddWithValue("@Kasa_Tipi", kasa.Text);
            cmd.Parameters.AddWithValue("@Renk", renk.Text);
            dr = cmd.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                i = vites.FindStringExact(dr["Vites"].ToString());
                if (i == -1)
                {
                    vites.Items.Add(dr["Vites"]);
                }
            }
            con.Close();
        }

        public void KullanıcıYakıtDoldur(ComboBox marka, ComboBox model, ComboBox yıl, ComboBox vites, ComboBox yakıt, ComboBox motor, ComboBox çekiş, ComboBox kapı, ComboBox kasa, ComboBox renk)
        {
            string sorgu = "Select *From araba where Durum='MÜSAİT'";

            if (!string.IsNullOrEmpty(marka.Text))
            {
                sorgu += " and Marka=@Marka";
            }

            if (!string.IsNullOrEmpty(model.Text))
            {
                sorgu += " and Model=@Model";
            }

            if (!string.IsNullOrEmpty(yıl.Text))
            {
                sorgu += " and Yıl=@Yıl";
            }

            if (vites.Text != "")
            {
                sorgu += " and Vites=@Vites";
            }

            if (yakıt.Text != "")
            {
                sorgu += " and Yakıt=@Yakıt";
            }

            if (motor.Text != "")
            {
                sorgu += " and Motor_Gücü=@Motor_Gücü";
            }

            if (çekiş.Text != "")
            {
                sorgu += " and Çekiş=@Çekiş";
            }

            if (kapı.Text != "")
            {
                sorgu += " and Kapı=@Kapı";
            }

            if (kasa.Text != "")
            {
                sorgu += " and Kasa_Tipi=@Kasa_Tipi";
            }

            if (renk.Text != "")
            {
                sorgu += " and Renk=@Renk";
            }

            con.Open();
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Durum", "MÜSAİT");
            cmd.Parameters.AddWithValue("@Marka", marka.Text.ToString());
            cmd.Parameters.AddWithValue("@Model", model.Text.ToString());
            cmd.Parameters.AddWithValue("@Yıl", yıl.Text.ToString());
            cmd.Parameters.AddWithValue("@Vites", vites.Text);
            cmd.Parameters.AddWithValue("@Yakıt", yakıt.Text);
            cmd.Parameters.AddWithValue("@Motor_Gücü", motor.Text);
            cmd.Parameters.AddWithValue("@Çekiş", çekiş.Text);
            cmd.Parameters.AddWithValue("@Kapı", kapı.Text);
            cmd.Parameters.AddWithValue("@Kasa_Tipi", kasa.Text);
            cmd.Parameters.AddWithValue("@Renk", renk.Text);
            dr = cmd.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                i = yakıt.FindStringExact(dr["Yakıt"].ToString());
                if (i == -1)
                {
                    yakıt.Items.Add(dr["Yakıt"]);
                }
            }
            con.Close();
        }

        public void KullanıcıMotorGDoldur(ComboBox marka, ComboBox model, ComboBox yıl, ComboBox vites, ComboBox yakıt, ComboBox motor, ComboBox çekiş, ComboBox kapı, ComboBox kasa, ComboBox renk)
        {
            string sorgu = "Select *From araba where Durum='MÜSAİT'";

            if (!string.IsNullOrEmpty(marka.Text))
            {
                sorgu += " and Marka=@Marka";
            }

            if (!string.IsNullOrEmpty(model.Text))
            {
                sorgu += " and Model=@Model";
            }

            if (!string.IsNullOrEmpty(yıl.Text))
            {
                sorgu += " and Yıl=@Yıl";
            }

            if (vites.Text != "")
            {
                sorgu += " and Vites=@Vites";
            }

            if (yakıt.Text != "")
            {
                sorgu += " and Yakıt=@Yakıt";
            }

            if (motor.Text != "")
            {
                sorgu += " and Motor_Gücü=@Motor_Gücü";
            }

            if (çekiş.Text != "")
            {
                sorgu += " and Çekiş=@Çekiş";
            }

            if (kapı.Text != "")
            {
                sorgu += " and Kapı=@Kapı";
            }

            if (kasa.Text != "")
            {
                sorgu += " and Kasa_Tipi=@Kasa_Tipi";
            }

            if (renk.Text != "")
            {
                sorgu += " and Renk=@Renk";
            }

            con.Open();
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Durum", "MÜSAİT");
            cmd.Parameters.AddWithValue("@Marka", marka.Text.ToString());
            cmd.Parameters.AddWithValue("@Model", model.Text.ToString());
            cmd.Parameters.AddWithValue("@Yıl", yıl.Text.ToString());
            cmd.Parameters.AddWithValue("@Vites", vites.Text);
            cmd.Parameters.AddWithValue("@Yakıt", yakıt.Text);
            cmd.Parameters.AddWithValue("@Motor_Gücü", motor.Text);
            cmd.Parameters.AddWithValue("@Çekiş", çekiş.Text);
            cmd.Parameters.AddWithValue("@Kapı", kapı.Text);
            cmd.Parameters.AddWithValue("@Kasa_Tipi", kasa.Text);
            cmd.Parameters.AddWithValue("@Renk", renk.Text);
            dr = cmd.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                i = motor.FindStringExact(dr["Motor_Gücü"].ToString());
                if (i == -1)
                {
                    motor.Items.Add(dr["Motor_Gücü"]);
                }
            }
            con.Close();
        }

        public void KullanıcıÇekişDoldur(ComboBox marka, ComboBox model, ComboBox yıl, ComboBox vites, ComboBox yakıt, ComboBox motor, ComboBox çekiş, ComboBox kapı, ComboBox kasa, ComboBox renk)
        {
            string sorgu = "Select *From araba where Durum='MÜSAİT'";

            if (!string.IsNullOrEmpty(marka.Text))
            {
                sorgu += " and Marka=@Marka";
            }

            if (!string.IsNullOrEmpty(model.Text))
            {
                sorgu += " and Model=@Model";
            }

            if (!string.IsNullOrEmpty(yıl.Text))
            {
                sorgu += " and Yıl=@Yıl";
            }

            if (vites.Text != "")
            {
                sorgu += " and Vites=@Vites";
            }

            if (yakıt.Text != "")
            {
                sorgu += " and Yakıt=@Yakıt";
            }

            if (motor.Text != "")
            {
                sorgu += " and Motor_Gücü=@Motor_Gücü";
            }

            if (çekiş.Text != "")
            {
                sorgu += " and Çekiş=@Çekiş";
            }

            if (kapı.Text != "")
            {
                sorgu += " and Kapı=@Kapı";
            }

            if (kasa.Text != "")
            {
                sorgu += " and Kasa_Tipi=@Kasa_Tipi";
            }

            if (renk.Text != "")
            {
                sorgu += " and Renk=@Renk";
            }

            con.Open();
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Durum", "MÜSAİT");
            cmd.Parameters.AddWithValue("@Marka", marka.Text.ToString());
            cmd.Parameters.AddWithValue("@Model", model.Text.ToString());
            cmd.Parameters.AddWithValue("@Yıl", yıl.Text.ToString());
            cmd.Parameters.AddWithValue("@Vites", vites.Text);
            cmd.Parameters.AddWithValue("@Yakıt", yakıt.Text);
            cmd.Parameters.AddWithValue("@Motor_Gücü", motor.Text);
            cmd.Parameters.AddWithValue("@Çekiş", çekiş.Text);
            cmd.Parameters.AddWithValue("@Kapı", kapı.Text);
            cmd.Parameters.AddWithValue("@Kasa_Tipi", kasa.Text);
            cmd.Parameters.AddWithValue("@Renk", renk.Text);
            dr = cmd.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                i = çekiş.FindStringExact(dr["Çekiş"].ToString());
                if (i == -1)
                {
                    çekiş.Items.Add(dr["Çekiş"]);
                }
            }
            con.Close();
        }

        public void KullanıcıKapıDoldur(ComboBox marka, ComboBox model, ComboBox yıl, ComboBox vites, ComboBox yakıt, ComboBox motor, ComboBox çekiş, ComboBox kapı, ComboBox kasa, ComboBox renk)
        {
            string sorgu = "Select *From araba where Durum='MÜSAİT'";

            if (!string.IsNullOrEmpty(marka.Text))
            {
                sorgu += " and Marka=@Marka";
            }

            if (!string.IsNullOrEmpty(model.Text))
            {
                sorgu += " and Model=@Model";
            }

            if (!string.IsNullOrEmpty(yıl.Text))
            {
                sorgu += " and Yıl=@Yıl";
            }

            if (vites.Text != "")
            {
                sorgu += " and Vites=@Vites";
            }

            if (yakıt.Text != "")
            {
                sorgu += " and Yakıt=@Yakıt";
            }

            if (motor.Text != "")
            {
                sorgu += " and Motor_Gücü=@Motor_Gücü";
            }

            if (çekiş.Text != "")
            {
                sorgu += " and Çekiş=@Çekiş";
            }

            if (kapı.Text != "")
            {
                sorgu += " and Kapı=@Kapı";
            }

            if (kasa.Text != "")
            {
                sorgu += " and Kasa_Tipi=@Kasa_Tipi";
            }

            if (renk.Text != "")
            {
                sorgu += " and Renk=@Renk";
            }

            con.Open();
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Durum", "MÜSAİT");
            cmd.Parameters.AddWithValue("@Marka", marka.Text.ToString());
            cmd.Parameters.AddWithValue("@Model", model.Text.ToString());
            cmd.Parameters.AddWithValue("@Yıl", yıl.Text.ToString());
            cmd.Parameters.AddWithValue("@Vites", vites.Text);
            cmd.Parameters.AddWithValue("@Yakıt", yakıt.Text);
            cmd.Parameters.AddWithValue("@Motor_Gücü", motor.Text);
            cmd.Parameters.AddWithValue("@Çekiş", çekiş.Text);
            cmd.Parameters.AddWithValue("@Kapı", kapı.Text);
            cmd.Parameters.AddWithValue("@Kasa_Tipi", kasa.Text);
            cmd.Parameters.AddWithValue("@Renk", renk.Text);
            dr = cmd.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                i = kapı.FindStringExact(dr["Kapı"].ToString());
                if (i == -1)
                {
                    kapı.Items.Add(dr["Kapı"]);
                }
            }
            con.Close();
        }

        public void KullanıcıKasaTDoldur(ComboBox marka, ComboBox model, ComboBox yıl, ComboBox vites, ComboBox yakıt, ComboBox motor, ComboBox çekiş, ComboBox kapı, ComboBox kasa, ComboBox renk)
        {
            string sorgu = "Select *From araba where Durum='MÜSAİT'";

            if (!string.IsNullOrEmpty(marka.Text))
            {
                sorgu += " and Marka=@Marka";
            }

            if (!string.IsNullOrEmpty(model.Text))
            {
                sorgu += " and Model=@Model";
            }

            if (!string.IsNullOrEmpty(yıl.Text))
            {
                sorgu += " and Yıl=@Yıl";
            }

            if (vites.Text != "")
            {
                sorgu += " and Vites=@Vites";
            }

            if (yakıt.Text != "")
            {
                sorgu += " and Yakıt=@Yakıt";
            }

            if (motor.Text != "")
            {
                sorgu += " and Motor_Gücü=@Motor_Gücü";
            }

            if (çekiş.Text != "")
            {
                sorgu += " and Çekiş=@Çekiş";
            }

            if (kapı.Text != "")
            {
                sorgu += " and Kapı=@Kapı";
            }

            if (kasa.Text != "")
            {
                sorgu += " and Kasa_Tipi=@Kasa_Tipi";
            }

            if (renk.Text != "")
            {
                sorgu += " and Renk=@Renk";
            }

            con.Open();
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Durum", "MÜSAİT");
            cmd.Parameters.AddWithValue("@Marka", marka.Text.ToString());
            cmd.Parameters.AddWithValue("@Model", model.Text.ToString());
            cmd.Parameters.AddWithValue("@Yıl", yıl.Text.ToString());
            cmd.Parameters.AddWithValue("@Vites", vites.Text);
            cmd.Parameters.AddWithValue("@Yakıt", yakıt.Text);
            cmd.Parameters.AddWithValue("@Motor_Gücü", motor.Text);
            cmd.Parameters.AddWithValue("@Çekiş", çekiş.Text);
            cmd.Parameters.AddWithValue("@Kapı", kapı.Text);
            cmd.Parameters.AddWithValue("@Kasa_Tipi", kasa.Text);
            cmd.Parameters.AddWithValue("@Renk", renk.Text);
            dr = cmd.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                i = kasa.FindStringExact(dr["Kasa_Tipi"].ToString());
                if (i == -1)
                {
                    kasa.Items.Add(dr["Kasa_Tipi"]);
                }
            }
            con.Close();
        }

        public void KullanıcıRenkDoldur(ComboBox marka, ComboBox model, ComboBox yıl, ComboBox vites, ComboBox yakıt, ComboBox motor, ComboBox çekiş, ComboBox kapı, ComboBox kasa, ComboBox renk)
        {
            string sorgu = "Select *From araba where Durum='MÜSAİT'";

            if (!string.IsNullOrEmpty(marka.Text))
                if (!string.IsNullOrEmpty(marka.Text))
                {
                    sorgu += " and Marka=@Marka";
                }

            if (!string.IsNullOrEmpty(model.Text))
            {
                sorgu += " and Model=@Model";
            }

            if (!string.IsNullOrEmpty(yıl.Text))
            {
                sorgu += " and Yıl=@Yıl";
            }

            if (vites.Text != "")
            {
                sorgu += " and Vites=@Vites";
            }

            if (yakıt.Text != "")
            {
                sorgu += " and Yakıt=@Yakıt";
            }

            if (motor.Text != "")
            {
                sorgu += " and Motor_Gücü=@Motor_Gücü";
            }

            if (çekiş.Text != "")
            {
                sorgu += " and Çekiş=@Çekiş";
            }

            if (kapı.Text != "")
            {
                sorgu += " and Kapı=@Kapı";
            }

            if (kasa.Text != "")
            {
                sorgu += " and Kasa_Tipi=@Kasa_Tipi";
            }

            if (renk.Text != "")
            {
                sorgu += " and Renk=@Renk";
            }

            con.Open();
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Durum", "MÜSAİT");
            cmd.Parameters.AddWithValue("@Marka", marka.Text.ToString());
            cmd.Parameters.AddWithValue("@Model", model.Text.ToString());
            cmd.Parameters.AddWithValue("@Yıl", yıl.Text.ToString());
            cmd.Parameters.AddWithValue("@Vites", vites.Text);
            cmd.Parameters.AddWithValue("@Yakıt", yakıt.Text);
            cmd.Parameters.AddWithValue("@Motor_Gücü", motor.Text);
            cmd.Parameters.AddWithValue("@Çekiş", çekiş.Text);
            cmd.Parameters.AddWithValue("@Kapı", kapı.Text);
            cmd.Parameters.AddWithValue("@Kasa_Tipi", kasa.Text);
            cmd.Parameters.AddWithValue("@Renk", renk.Text);
            dr = cmd.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                i = renk.FindStringExact(dr["Renk"].ToString());
                if (i == -1)
                {
                    renk.Items.Add(dr["Renk"]);
                }
            }
            con.Close();
        }

        public void Hesapla(ComboBox marka, ComboBox model, ComboBox yıl, ComboBox vites, ComboBox yakıt, ComboBox motor, ComboBox çekiş, ComboBox kapı, ComboBox kasa, ComboBox renk, PictureBox resim, TextBox FiyatGun, TextBox FiyatHafta, TextBox plaka, TextBox km)
        {
            string sorgu = "Select *From araba where Marka=@Marka and Model=@Model and Yıl=@Yıl and Vites=@Vites and Yakıt=@Yakıt and Motor_Gücü=@Motor_Gücü and Çekiş=@Çekiş and Kapı=@Kapı and Kasa_Tipi=@Kasa_Tipi and Renk=@Renk";
            con.Open();
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Durum", "MÜSAİT");
            cmd.Parameters.AddWithValue("@Marka", marka.Text.ToString());
            cmd.Parameters.AddWithValue("@Model", model.Text.ToString());
            cmd.Parameters.AddWithValue("@Yıl", yıl.Text.ToString());
            cmd.Parameters.AddWithValue("@Vites", vites.Text);
            cmd.Parameters.AddWithValue("@Yakıt", yakıt.Text);
            cmd.Parameters.AddWithValue("@Motor_Gücü", motor.Text);
            cmd.Parameters.AddWithValue("@Çekiş", çekiş.Text);
            cmd.Parameters.AddWithValue("@Kapı", kapı.Text);
            cmd.Parameters.AddWithValue("@Kasa_Tipi", kasa.Text);
            cmd.Parameters.AddWithValue("@Renk", renk.Text);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                resim.ImageLocation = dr["Resim"].ToString();
                FiyatGun.Text = dr["Fiyat_Gun"].ToString();
                FiyatHafta.Text = dr["Fiyat_Hafta"].ToString();
                plaka.Text = dr["Plaka"].ToString();
                km.Text = dr["Km"].ToString();
            }
            con.Close();

        }

        public void KiralamaMisafir(TextBox plaka, ComboBox marka, ComboBox model, TextBox fiyatGun, TextBox fiyatHafta, TextBox tc, TextBox ad, TextBox soyad, MaskedTextBox tel, string resimArac, DateTimePicker alış, DateTimePicker veriş, Label tutar) 
        {
            string sorgu = "Update araba Set Durum=@Durum Where Plaka=@Plaka";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Plaka", plaka.Text);
            cmd.Parameters.AddWithValue("@Durum", "KİRADA");

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            string sorgu2 = "Insert into kira (Plaka, Marka, Model, Fiyat_Gün, Fiyat_Hafta, TC_No, Ad, Soyad, Telefon, Arac_Resim, Alış_Tarihi, Veriş_Tarihi, Durum,Tutar)" +
           " values (@Plaka, @Marka, @Model, @Fiyat_Gün, @Fiyat_Hafta, @TC_No, @Ad, @Soyad, @Telefon, @Arac_Resim, @Alış_Tarihi, @Veriş_Tarihi, @Durum,@Tutar)";

            cmd = new SqlCommand(sorgu2, con);
            cmd.Parameters.AddWithValue("@Plaka", plaka.Text);
            cmd.Parameters.AddWithValue("@Marka", marka.Text);
            cmd.Parameters.AddWithValue("@Model", model.Text);
            cmd.Parameters.AddWithValue("@Fiyat_Gün", fiyatGun.Text);
            cmd.Parameters.AddWithValue("@Fiyat_Hafta", fiyatHafta.Text);
            cmd.Parameters.AddWithValue("@TC_No", tc.Text);
            cmd.Parameters.AddWithValue("@Ad", ad.Text);
            cmd.Parameters.AddWithValue("@Soyad", soyad.Text);
            cmd.Parameters.AddWithValue("@Telefon", tel.Text);
            cmd.Parameters.AddWithValue("@Arac_Resim", resimArac);
            cmd.Parameters.AddWithValue("@Alış_Tarihi", alış.Value);
            cmd.Parameters.AddWithValue("@Veriş_Tarihi", veriş.Value);
            cmd.Parameters.AddWithValue("@Durum", "KİRADA");
            cmd.Parameters.AddWithValue("@Tutar", fiyatGun.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            try
            {
                MessageBox.Show(plaka + " Plakalı Aracı Başarılı Bir Şekilde Kiraladınız..", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(" Hata Meydana Geldi!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public void MusteriAracKira(TextBox plaka, ComboBox marka, ComboBox model, TextBox fiyatGun, TextBox fiyatHafta, string resimMusteri, TextBox tc, TextBox ad, TextBox soyad, MaskedTextBox tel, string resimArac, DateTimePicker alış, DateTimePicker veriş, Label tutar)
        {
            string sorgu = "Update araba Set Durum=@Durum Where Plaka=@Plaka";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@Plaka", plaka.Text);
            cmd.Parameters.AddWithValue("@Durum", "KİRADA");

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            string sorgu2 = "Insert into kira (Plaka, Marka, Model, Fiyat_Gün, Fiyat_Hafta, TC_No, Ad, Soyad, Telefon, Arac_Resim, Musteri_Resim, Alış_Tarihi, Veriş_Tarihi, Durum,Tutar)" +
           " values (@Plaka, @Marka, @Model, @Fiyat_Gün, @Fiyat_Hafta, @TC_No, @Ad, @Soyad, @Telefon, @Arac_Resim, @Musteri_Resim, @Alış_Tarihi, @Veriş_Tarihi, @Durum,@Tutar)";

            cmd = new SqlCommand(sorgu2, con);
            cmd.Parameters.AddWithValue("@Plaka", plaka.Text);
            cmd.Parameters.AddWithValue("@Marka", marka.Text);
            cmd.Parameters.AddWithValue("@Model", model.Text);
            cmd.Parameters.AddWithValue("@Fiyat_Gün", fiyatGun.Text);
            cmd.Parameters.AddWithValue("@Fiyat_Hafta", fiyatHafta.Text);
            cmd.Parameters.AddWithValue("@TC_No", tc.Text);
            cmd.Parameters.AddWithValue("@Ad", ad.Text);
            cmd.Parameters.AddWithValue("@Soyad", soyad.Text);
            cmd.Parameters.AddWithValue("@Telefon", tel.Text);
            cmd.Parameters.AddWithValue("@Arac_Resim", resimArac);
            cmd.Parameters.AddWithValue("@Musteri_Resim", resimMusteri);
            cmd.Parameters.AddWithValue("@Alış_Tarihi", alış.Value);
            cmd.Parameters.AddWithValue("@Veriş_Tarihi", veriş.Value);
            cmd.Parameters.AddWithValue("@Durum", "KİRADA");
            cmd.Parameters.AddWithValue("@Tutar", fiyatGun.Text);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void MusteriBilgiDoldur(TextBox tc, TextBox ad, TextBox soyad, TextBox meslek, TextBox mail, ComboBox mailAlan, TextBox adres, ComboBox ehliyet, TextBox sifre, DateTimePicker date, MaskedTextBox tel, ComboBox cinsiyet, PictureBox resim, TextBox MailGüncel, TextBox SifreGüncel)
        {
            string sorgu = "Select *From musteri where E_Mail=@E_Mail and Sifre=@Sifre";
            con.Open();
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@E_Mail", mail.Text);
            cmd.Parameters.AddWithValue("@Sifre", sifre.Text);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tc.Text = dr["TC_No"].ToString();
                ad.Text = dr["Ad"].ToString();
                soyad.Text = dr["Soyad"].ToString();
                date.Value = Convert.ToDateTime(dr["Dogum_Tarihi"]);
                meslek.Text = dr["Meslek"].ToString();
                cinsiyet.Text = dr["Cinsiyet"].ToString();
                tel.Text = dr["Telefon"].ToString();
                int index = dr["E_Mail"].ToString().IndexOf('@');
                MailGüncel.Text = dr["E_Mail"].ToString().Substring(0, index);
                mailAlan.Text = dr["E_Mail"].ToString().Substring(index + 1);
                adres.Text = dr["Adres"].ToString();
                ehliyet.Text = dr["Ehliyet"].ToString();
                SifreGüncel.Text = dr["Sifre"].ToString();
                resim.ImageLocation = dr["Resim"].ToString();
            }
            con.Close();
        }


        public void ExportToExcel(DataGridView dataGrid, string dosyaAdi)
        {
            string stOut = "";
            string sHeaders = "";

            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                sHeaders = sHeaders.ToString() + Convert.ToString(dataGrid.Columns[i].HeaderText) + "\t";

            }
            stOut += sHeaders + "\r\n";

            for (int j = 0; j < dataGrid.RowCount - 1; j++)
            {
                string sLine = "";
                for (int k = 0; k < dataGrid.Rows[j].Cells.Count; k++)
                {
                    sLine = sLine.ToString() + Convert.ToString(dataGrid.Rows[j].Cells[k].Value) + "\t";

                }
                stOut += sLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOut);
            FileStream fs = new FileStream(dosyaAdi, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length);
            bw.Flush();
            bw.Close();
            fs.Close();
        }
    }
}
