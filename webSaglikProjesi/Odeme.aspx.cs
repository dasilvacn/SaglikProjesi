using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webSaglikProjesi
{
    public partial class Odeme : System.Web.UI.Page
    {
        DataModel.SaglikUrunleriEntities1 ent = new DataModel.SaglikUrunleriEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int id = Convert.ToInt32(Session["uye"]);
                if(Session["uye"] != null)
                {
                    var kullanici = ent.Kullanicilar.Where(k => k.ID == id).Select(k => k).FirstOrDefault();
                    lblAdi.Text = kullanici.Ad;
                    lblSoyadi.Text = kullanici.Soyad;
                    lblTutar.Text = ToplamTutarBul().ToString("C");
                }
            }
        }

        protected void btnHavaleEFT_Click(object sender, EventArgs e)
        {
            pnlHavaleEFT.Visible = true;
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

        protected void btnKrediKarti_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuvenliCikis_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Default.aspx");
        }

        protected void btnAlisveriseDevam_Click(object sender, EventArgs e)
        {
            Session.Remove("sepet");
            Response.Redirect("Default.aspx");
        }
    }
}