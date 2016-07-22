using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webSaglikProjesi.Models;

namespace webSaglikProjesi
{
    public partial class Default : System.Web.UI.Page
    {
        DataModel.SaglikUrunleriEntities1 ent = new DataModel.SaglikUrunleriEntities1();
        cSepet spt = new cSepet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                UrunleriGetir();
        }
        private void UrunleriGetir()
        {
            var Uruns = (from urun in ent.Urunler
                         where urun.Silindi == false
                         select urun).ToList();
            dlstUrunler.DataSource = Uruns;
            dlstUrunler.DataBind();

            if(Session["sepet"]!=null)
            {
                SepetozetiOluştur();
            }
        }

        private void SepetozetiOluştur()
        {
            DataTable dt = (DataTable)Session["sepet"];
            GridView gvSepetOzeti = (GridView)this.Master.FindControl("gvSepetOzeti");
            gvSepetOzeti.Columns[0].FooterText = "Toplam :";
            gvSepetOzeti.Columns[0].FooterStyle.HorizontalAlign = HorizontalAlign.Right;
            gvSepetOzeti.Columns[1].FooterText = ToplamTutarBul().ToString();
            gvSepetOzeti.Columns[1].FooterStyle.HorizontalAlign = HorizontalAlign.Right;
            gvSepetOzeti.DataSource = dt;
            gvSepetOzeti.DataBind();
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
        protected void dlstUrunler_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "detay")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("Details.aspx?urunid=" + id);
            }
            else if (e.CommandName == "sepet")
            {
                if (Session["sepet"] == null)
                {
                    Session["sepet"] = spt.YeniSepet();
                }
                DataTable dt = (DataTable)Session["sepet"];
                DataRow dr;
                int id = Convert.ToInt32(e.CommandArgument);
                Label lblUrunAdi = (Label)e.Item.FindControl("lblUrunAdi");
                Label lblFiyat = (Label)e.Item.FindControl("lblFiyat");
                string[] fiyat = lblFiyat.Text.Split(' ');
                lblFiyat.Text = fiyat[0];
                TextBox txtAdet = (TextBox)e.Item.FindControl("txtAdet");
                bool Varmi = false;
                foreach (DataRow drow in dt.Rows)
                {
                    if (drow["urunID"].ToString() == id.ToString())
                    {
                        Varmi = true;
                        drow["adet"] = Convert.ToInt32(drow["adet"]) + Convert.ToInt32(txtAdet.Text);
                        drow["tutar"] = Convert.ToDecimal(drow["tutar"]) + Convert.ToInt32(txtAdet.Text) * Convert.ToDecimal(lblFiyat.Text);
                        break;
                    }
                }
                if(!Varmi)
                {
                    dr = dt.NewRow();

                    dr["urunID"] = id;
                    dr["urunAd"] = lblUrunAdi.Text;
                    dr["adet"] = Convert.ToInt32(txtAdet.Text);
                    dr["fiyat"] = Convert.ToDecimal(lblFiyat.Text);
                    dr["tutar"] = Convert.ToDecimal(dr["fiyat"]) * Convert.ToInt32(dr["adet"]);
                    dt.Rows.Add(dr);
                }

                Session["sepet"] = dt;
                SepetozetiOluştur();
            }
        }

        protected void dlstUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}