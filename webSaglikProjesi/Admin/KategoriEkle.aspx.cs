using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webSaglikProjesi.Admin
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        DataModel.SaglikUrunleriEntities1 ent = new DataModel.SaglikUrunleriEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    Kategoriler();
                    Panel pnlAdminIslemleri = (Panel)this.Master.FindControl("pnlAdminIslemleri");
                    pnlAdminIslemleri.Visible = true;
                }
            }
        }

        private void Kategoriler()
        {
            var kategoriler = ent.Kategoriler.Where(k => k.Silindi == false).Select(k => k).ToList();
            gvKategoriler.DataSource = kategoriler;
            gvKategoriler.DataBind();
        }

        protected void gvKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKategoriAd.Text = HttpUtility.HtmlDecode(gvKategoriler.SelectedRow.Cells[1].Text);
            txtAçıklama.Text = HttpUtility.HtmlDecode(gvKategoriler.SelectedRow.Cells[2].Text);
            btnKaydet.Enabled = true;
            btnSil.Enabled = true;
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            Temizle();
            btnKaydet.Enabled = true;
            btnSil.Enabled = false;
        }

        private void Temizle()
        {
            txtKategoriAd.Text = "";
            txtAçıklama.Text = "";
            txtKategoriAd.Focus();
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if(KategoriVarMi())
            {
                int kategoriId = Convert.ToInt32(gvKategoriler.SelectedDataKey.Value.ToString());
                var kategori = ent.Kategoriler.Where(kat => kat.ID == kategoriId).Select(k => k).First();
                kategori.KategoriAd = txtKategoriAd.Text;
                kategori.Aciklama = txtAçıklama.Text;
                try
                {
                    ent.SaveChanges();
                    Kategoriler();
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
                DataModel.Kategoriler kategori = new DataModel.Kategoriler();
                kategori.KategoriAd = txtKategoriAd.Text;
                kategori.Aciklama = txtAçıklama.Text;
                ent.Kategoriler.Add(kategori);
                try
                {
                    ent.SaveChanges();
                    Kategoriler();
                }
                catch (Exception ex)
                {
                    string hata = ex.Message;
                }
            }
        }

        private bool KategoriVarMi()
        {
            int kategoriId = Convert.ToInt32(gvKategoriler.SelectedDataKey.Value.ToString());
            var kategori = ent.Kategoriler.Where(kat => kat.ID == kategoriId).Select(k => k).First();
            if (kategori != null) return true;
            return false;
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            int kategoriId = Convert.ToInt32(gvKategoriler.SelectedDataKey.Value.ToString());
            var kategori = ent.Kategoriler.Where(kat => kat.ID == kategoriId).Select(k => k).First();
            kategori.Silindi = true;
            try
            {
                ent.SaveChanges();
                Kategoriler();
                Temizle();
                btnKaydet.Enabled = false;
                btnSil.Enabled = false;
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
            }
        }
    }
}