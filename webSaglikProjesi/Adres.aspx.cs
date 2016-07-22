using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace webSaglikProjesi
{
    public partial class Adres : System.Web.UI.Page
    {
        DataModel.SaglikUrunleriEntities1 ent = new DataModel.SaglikUrunleriEntities1();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["uye"] != null)
                {
                    pnlUyeGirisi.Visible = false;
                    pnlAdres.Visible = true;

                    int degisenID = Convert.ToInt32(Session["uye"]);
                    var musteri = ent.Kullanicilar.Where(kullanici => kullanici.ID == degisenID).Select(k => k).FirstOrDefault();
                    pnlUyeGirisi.Visible = false;
                    pnlAdres.Visible = true;
                    txtTeslimAdresi.Text = musteri.Adres;
                    txtIlce.Text = musteri.Ilce;
                    txtIl.Text = musteri.Il;
                    txtTelefon.Text = musteri.Telefon;
                    txtTeslimAdresi.Focus();
                }
            }
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciadi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            var musteri = (from k in ent.Kullanicilar
                           where k.KullaniciAd == kullaniciadi && k.Sifre == sifre
                           select k).FirstOrDefault();

            if (musteri==null)
            {

                lblMesaj.Text = "Kullanıcı Adı ve Şifre Yanlış";
                txtKullaniciAdi.Focus();
            }
            else
            {
                lblMesaj.Text = "";
                Session["uye"] = musteri.ID;
                pnlUyeGirisi.Visible = false;
                pnlAdres.Visible = true;
                txtTeslimAdresi.Text = musteri.Adres;
                txtIlce.Text = musteri.Ilce;
                txtIl.Text = musteri.Il;
                txtTelefon.Text = musteri.Telefon;
                txtTeslimAdresi.Focus();
            }
        }

        protected void btnAdresOnay_Click(object sender, EventArgs e)
        {
            if(txtTeslimAdresi.Text.Trim() != "")
            {
                int degisenID = Convert.ToInt32(Session["uye"]);
                var güncelle = ent.Kullanicilar.Where(kullanici => kullanici.ID == degisenID).Select(k => k).First();
                güncelle.Adres = txtTeslimAdresi.Text;
                güncelle.Ilce = txtIlce.Text;
                güncelle.Il = txtIl.Text;
                güncelle.Telefon = txtTelefon.Text;
                try
                {
                    ent.SaveChanges();
                    Response.Write("<script style='javascript'>alert('Adres Onaylandı')</script>");
                    DataModel.Satislar satis = new DataModel.Satislar();
                    satis.KullaniciId = Convert.ToInt32(Session["uye"]);
                    satis.Tarih = DateTime.Now;
                    satis.TeslimTarihi = DateTime.Now.AddDays(3);
                    satis.Tutar = ToplamTutarBul();
                    satis.Miktar = ToplamAdetBul();
                    satis.Durumu = (byte)Models.cEnum.SatisDurumu.siparis;
                    ent.Satislar.Add(satis);
                    ent.SaveChanges();
                    //satış detayları satış no ya göre sepetten veritabanına aktarılacak.
                    DataModel.SatisDetaylari detay = new DataModel.SatisDetaylari();
                    //detay.SatisNo = satis.SatisNo;
                    int sonsatisno = ent.Satislar.Where(s => s.KullaniciId == satis.KullaniciId).ToList().Last().SatisNo;
                    DataTable dt = (DataTable)Session["sepet"];
                    foreach (DataRow urunler in dt.Rows)
                    {
                        detay.SatisNo = sonsatisno;
                        detay.UrunID = Convert.ToInt32(urunler["urunID"]);
                        detay.Adet= Convert.ToInt32(urunler["adet"]);
                        detay.BirimFiyat = Convert.ToDecimal(urunler["fiyat"]);
                        detay.Tutar = Convert.ToDecimal(urunler["tutar"]);
                        ent.SatisDetaylari.Add(detay);
                        ent.SaveChanges();
                    }
                    Response.Redirect("Odeme.aspx");
                }
                catch (Exception ex)
                {
                    string hata = ex.Message;
                }
            }
        }


        private int ToplamAdetBul()
        {
            int ToplamAdet = 0;
            DataTable dt = (DataTable)Session["sepet"];
            foreach (DataRow drow in dt.Rows)
            {
                ToplamAdet += Convert.ToInt32(drow["adet"]);
            }
            return ToplamAdet;
        }
        private decimal ToplamTutarBul()
        {
            decimal ToplamTutar = 0;
            DataTable dt = (DataTable)Session["sepet"];
            foreach (DataRow drow in dt.Rows)
            {
                ToplamTutar += Convert.ToDecimal(drow["tutar"]);
            }
            return ToplamTutar;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if(txtKullaniciAdi.Text.Trim() !="")
            {
                DataModel.Kullanicilar user = EmailKontrol(txtKullaniciAdi.Text);
                if (user != null)
                {
                    SmtpClient smtp = new SmtpClient();
                    smtp.Credentials = new NetworkCredential("wissendeneme@gmail.com", "wissen123");
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com"; // mail.domain.com kullanılır
                    smtp.EnableSsl = true;
                    // smtpClient ile gönderilecek mailmessage türünden bir mail tanımlamalıyız.
                    MailMessage ePosta = new MailMessage();
                    ePosta.From = new MailAddress("wissendeneme@gmail.com");
                    ePosta.To.Add(user.KullaniciAd);
                    ePosta.Subject = "Sağlık Ürünleri Şifre işlemi";
                    //ePosta.Body = "Kullanıcı Adı: " + user.KullaniciAd + "\nŞifre: " + user.Sifre;
                    StringBuilder sbmesaj = new StringBuilder();
                    sbmesaj.Append("Sayın " + user.Ad + " " + user.Soyad + ",<br />" + "Kullanıcı Adı: " + user.KullaniciAd + "<br />" + "Şifre: " + user.Sifre + "<br />");
                    sbmesaj.Append("<a href=\"" + Request.Url.Host + "/Adres.aspx\"> Alışverişe devam etmek için tıklayınız...</a>");
                    ePosta.Body = sbmesaj.ToString();
                    ePosta.IsBodyHtml = true;
                    try
                    {
                        smtp.Send(ePosta);
                        Response.Write("<script style='javascript'> alert('Şifre başarılı bir şekilde gönderilmiştir')</script>");
                    }
                    catch (Exception ex)
                    {
                        string hata = ex.Message;
                    }
                }
                else
                {
                    lblMesaj.Text = "Kullanıcı Adı kayıtlı değil";
                    txtKullaniciAdi.Focus();
                }
            }
        }
        private DataModel.Kullanicilar EmailKontrol(string email)
        {
            var kullanici = ent.Kullanicilar.Where(k => k.KullaniciAd == email && k.Silindi == false).Select(k => k).FirstOrDefault();
            return kullanici;
        }

    }
}