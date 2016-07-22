using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webSaglikProjesi
{
    public partial class UyeKayit : System.Web.UI.Page
    {

        DataModel.SaglikUrunleriEntities1 ent = new DataModel.SaglikUrunleriEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cbxOkudum.Checked)
            {
                if (EmailKontrol(txtEmail.Text))
                {
                    lblMesaj.Text = "Aynı mail adresi zaten kayıtlı!";
                    txtEmail.Focus();
                }
                else
                {
                    DataModel.Kullanicilar kullanici = new DataModel.Kullanicilar();
                    kullanici.Ad = txtAd.Text;
                    kullanici.Adres = txtTeslimAdresi.Text;
                    kullanici.Il = txtIl.Text;
                    kullanici.Ilce = txtIlce.Text;
                    kullanici.KullaniciAd = txtEmail.Text;
                    kullanici.Sifre = txtSifre.Text; // md5 şifrelenerek veritabanına atılabilir.
                    kullanici.Soyad = txtSoyad.Text;
                    kullanici.TcNo = txtTcNo.Text;
                    kullanici.Telefon = txtTelefon.Text;
                    ent.Kullanicilar.Add(kullanici);
                    try
                    {
                        ent.SaveChanges();
                        lblMesaj.Text = "üye kaydı işleminiz gerçekleştirilmiştir.";

                    }
                    catch (Exception ex)
                    {
                        string hata = ex.Message;
                    }
                }
            }
            else
            {
                lblMesaj.Text = "Gizlilik sözleşmesini okudum işaretlenmelidir.";
            }
        }

        private bool EmailKontrol(string email)
        {
            var kullanici = ent.Kullanicilar.Where(k => k.KullaniciAd == email && k.Silindi == false).Select(k => k).FirstOrDefault();
            return Convert.ToBoolean(kullanici);
        }

        protected void cbxOkudum_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxOkudum.Checked)
            {
                lblMesaj.Text = "";
            }
        }
    }
}