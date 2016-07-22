using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webSaglikProjesi.Admin
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        DataModel.SaglikUrunleriEntities1 ent = new DataModel.SaglikUrunleriEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtKullaniciAdi.Focus();
            }
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            var musteri = (from k in ent.Kullanicilar
                           where k.KullaniciAd == txtKullaniciAdi.Text && k.Sifre == txtSifre.Text && k.Admin == true && k.Silindi == false
                           select k).FirstOrDefault();

            if (musteri != null)
            {
                lblMesaj.Text = "";
                Session["user"] = musteri.ID;
                Response.Redirect("Admin.aspx");
            }
            else
            {
                lblMesaj.Visible = true;
                lblMesaj.Text = "Kullanıcı Adı ve Şifre Yanlış";
                txtKullaniciAdi.Focus();
            }
        }
    }
}