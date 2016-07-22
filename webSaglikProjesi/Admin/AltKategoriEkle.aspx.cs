using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webSaglikProjesi.Admin
{
    public partial class AltKategoriEkle : System.Web.UI.Page
    {
        DataModel.SaglikUrunleriEntities1 ent = new DataModel.SaglikUrunleriEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["user"]==null)
                {
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    var kategori = ent.Kategoriler.Where(k => k.Silindi == false).Select(k => k).ToList();
                    ddlKategoriler.DataTextField = "KategoriAd";
                    ddlKategoriler.DataValueField = "ID";
                    ddlKategoriler.DataSource = kategori;
                    ddlKategoriler.DataBind();

                    Panel pnlAdminIslemleri = (Panel)this.Master.FindControl("pnlAdminIslemleri");
                    pnlAdminIslemleri.Visible = true;
                    
                    AltKategorilerbyKategoriID(Convert.ToInt32(ddlKategoriler.SelectedValue));
                }
            }

        }

        protected void ddlKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            AltKategorilerbyKategoriID(Convert.ToInt32(ddlKategoriler.SelectedValue));
        }

        private void AltKategorilerbyKategoriID(int kategoriId)
        {
            var altkategori = ent.AltKategoriler.Where(k => k.Silindi == false && k.KategoriId == kategoriId).Select(k => k).ToList();

            gvAltKategoriler.DataSource = altkategori;
            gvAltKategoriler.DataBind();
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            Temizle();
            btnKaydet.Enabled = true;
            btnSil.Enabled = false;
        }
        private void Temizle()
        {
            txtAltkategoriAd.Text = "";
            txtAçıklama.Text = "";
            txtAltkategoriAd.Focus();
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (AltKategoriVarMi())
            {
                int kategoriId = Convert.ToInt32(ddlKategoriler.SelectedValue);
                int altkategoriId = Convert.ToInt32(gvAltKategoriler.SelectedDataKey.Value.ToString());
                var altkategori = ent.AltKategoriler.Where(kat => kat.ID == altkategoriId && kat.KategoriId == kategoriId).Select(k => k).First();
                altkategori.AltKategoriAd = txtAltkategoriAd.Text;
                altkategori.Aciklama = txtAçıklama.Text;
                try
                {
                    ent.SaveChanges();
                    AltKategorilerbyKategoriID(kategoriId);
                    Temizle();
                    btnKaydet.Enabled = false;
                    btnSil.Enabled = false;
                }
                catch (Exception ex)
                {
                    string hata = ex.Message;
                }
            }
            else
            {
                int kategoriId = Convert.ToInt32(ddlKategoriler.SelectedValue);

                DataModel.AltKategoriler altkategori = new DataModel.AltKategoriler();
                altkategori.AltKategoriAd = txtAltkategoriAd.Text;
                altkategori.Aciklama = txtAçıklama.Text;
                altkategori.KategoriId = kategoriId;

                ent.AltKategoriler.Add(altkategori);
                try
                {
                    ent.SaveChanges();
                    AltKategorilerbyKategoriID(kategoriId);
                }
                catch (Exception ex)
                {
                    string hata = ex.Message;
                }
            }
        }

        private bool AltKategoriVarMi()
        {
            int kategoriId = Convert.ToInt32(ddlKategoriler.SelectedValue);
            int altkategoriId = Convert.ToInt32(gvAltKategoriler.SelectedDataKey.Value.ToString());
            var altkategori = ent.AltKategoriler.Where(altkat => altkat.ID == altkategoriId && altkat.KategoriId == kategoriId).Select(k => k).First();
            if (altkategori != null) return true;
            return false;
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            int altkategoriId = Convert.ToInt32(gvAltKategoriler.SelectedDataKey.Value.ToString());
            var altkategori = ent.AltKategoriler.Where(kat => kat.ID == altkategoriId).Select(k => k).First();
            altkategori.Silindi = true;
            try
            {
                ent.SaveChanges();

                int kategoriId = Convert.ToInt32(ddlKategoriler.SelectedValue);
                AltKategorilerbyKategoriID(kategoriId);
                Temizle();
                btnKaydet.Enabled = false;
                btnSil.Enabled = false;
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
            }
        }

        protected void gvKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtAltkategoriAd.Text =HttpUtility.HtmlDecode(gvAltKategoriler.SelectedRow.Cells[1].Text);
            txtAçıklama.Text = HttpUtility.HtmlDecode(gvAltKategoriler.SelectedRow.Cells[2].Text);
            btnKaydet.Enabled = true;
            btnSil.Enabled = true;
        }
    }
}