using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Kütüphanem
{
    public class Musteri
    {
        private string tc;
        private string ad;
        private string soyad;
        private string meslek;
        private string cinsiyet;
        private string tel;
        private string mail;
        private string adres;
        private string e_No;
        private string e_Türü;
        private string sifre;
        private string resim;
        private DateTime dogum;

        private bool durum = false;
        private string resimPath = "Belirtilmedi.";
        public OpenFileDialog open = new OpenFileDialog();

        public string Tc { get => tc; set => tc = value; }
        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
        public string Meslek { get => meslek; set => meslek = value; }
        public string Cinsiyet { get => cinsiyet; set => cinsiyet = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Adres { get => adres; set => adres = value; }
        public string E_No { get => e_No; set => e_No = value; }
        public string E_Türü { get => e_Türü; set => e_Türü = value; }
        public string Sifre { get => sifre; set => sifre = value; }
        public string Resim { get => resim; set => resim = value; }
        public DateTime Dogum { get => dogum; set => dogum = value; }
        public bool Durum { get => durum; set => durum = value; }
        public string ResimPath { get => resimPath; set => resimPath = value; }

        // Durum diye bir bool tanımlamamın sebebi eğer resmi olupta güncellemeyen biri resmini kaybetmemesi sebebiyle ekledim.
        public void ResimEklemeMusteri(PictureBox pic)
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


        public int DateTimeYasHesabi(DateTimePicker date)
        {
            DateTime d = DateTime.Now;
            TimeSpan y = d - date.Value;
            int yas = y.Days / 365;

            return yas;
        }


        public void MailGönder(string mailKime, string mailBaslik, string mailMesaj)
        {
            try
            {
                System.Net.NetworkCredential cred = new System.Net.NetworkCredential("RentACarCompanyForever@gmail.com", "rentacar2000");

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = new System.Net.Mail.MailAddress("RentACarCompanyForever@gmail.com", "Abdullah AYGÜN");
                mail.To.Add(mailKime);
                mail.Subject = mailBaslik;
                mail.IsBodyHtml = true;
                mail.Body = mailMesaj;
                mail.Attachments.Clear();


                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = cred;
                smtp.Send(mail);
                //MessageBox.Show("Mesaj Kişinin Mail Adresine Gönderildi!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Meydana Geldi!!" + Environment.NewLine + ex.ToString(), "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
