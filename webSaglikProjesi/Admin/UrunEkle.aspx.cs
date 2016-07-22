using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webSaglikProjesi.Admin
{
    public partial class UrunEkle : System.Web.UI.Page
    {
        DataModel.SaglikUrunleriEntities1 ent = new DataModel.SaglikUrunleriEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null)
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
                    UrunleriGetir();
                    
                }
            }
        }

        private void UrunleriGetir()
        {
            var urun = ent.Urunler.Where(u => u.Silindi == false).Select(u => u).ToList();
            gvUrunler.DataSource = urun;
            gvUrunler.DataBind();
        }

        private void AltKategorilerbyKategoriID(int kategoriId)
        {
            var altkategori = ent.AltKategoriler.Where(k => k.Silindi == false && k.KategoriId == kategoriId).Select(k => k).ToList();

            ddlAltKategoriler.DataTextField = "AltKategoriAd";
            ddlAltKategoriler.DataValueField = "ID";
            ddlAltKategoriler.DataSource = altkategori;
            ddlAltKategoriler.DataBind();
        }

        protected void gvUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlekle.Visible = true;
            string[] urunkodu = HttpUtility.HtmlDecode(gvUrunler.SelectedRow.Cells[1].Text).Split('-');
            txtUrunKodu.Text =urunkodu[1] ;
            txtUrunAdi.Text= HttpUtility.HtmlDecode(gvUrunler.SelectedRow.Cells[2].Text);
            txtStok.Text = HttpUtility.HtmlDecode(gvUrunler.SelectedRow.Cells[3].Text);
            txtFiyat.Text = HttpUtility.HtmlDecode(gvUrunler.SelectedRow.Cells[4].Text);
            txtAçıklama.Text = HttpUtility.HtmlDecode(gvUrunler.SelectedRow.Cells[5].Text);
            Session["urun"] = gvUrunler.SelectedDataKey.Value.ToString();
            btnKaydet.Enabled = true;
            btnSil.Enabled = true;
        }

        protected void ddlKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            AltKategorilerbyKategoriID(Convert.ToInt32(ddlKategoriler.SelectedValue));
            UrunleriGetirByKAtegoriNo(Convert.ToInt32(ddlKategoriler.SelectedValue));
        }

        private void UrunleriGetirByKAtegoriNo(int kategoriId)
        {
            var urun = ent.Urunler.Where(u => u.Silindi == false && u.UrunKategoriNo == kategoriId).Select(u => u).ToList();

            gvUrunler.DataSource = urun;
            gvUrunler.DataBind();
        }

        protected void ddlAltKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            UrunleriGetirbyAltKategori(Convert.ToInt32(ddlAltKategoriler.SelectedValue));
        }

        private void UrunleriGetirbyAltKategori(int altKategoriId)
        {
           var urun = ent.Urunler.Where(u => u.Silindi == false && u.UrunAltKategoriNo == altKategoriId).Select(u => u).ToList();

            gvUrunler.DataSource = urun;
            gvUrunler.DataBind();
        }

        private void Temizle()
        {
            txtUrunAdi.Text = "";
            txtAçıklama.Text = "";
            txtStok.Text = "";
            txtFiyat.Text = "";
            txtUrunKodu.Text = "";
            txtUrunKodu.Focus();
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (UrunVarmi())
            {
                int urunid = Convert.ToInt32(Session["urun"]);

                var urun = ent.Urunler.Where(u => u.UrunID == urunid).Select(k => k).FirstOrDefault();

                urun.UrunKodu = "REF-" + txtUrunKodu.Text;
                urun.UrunAd = txtUrunAdi.Text;
                urun.StokMiktari = Convert.ToInt32(txtStok.Text);
                urun.UrunFiyat = Convert.ToDecimal(txtFiyat.Text);
                urun.UrunBilgisi = txtAçıklama.Text;

                int kategoriId = Convert.ToInt32(ddlKategoriler.SelectedValue);
                int altkategoriId = Convert.ToInt32(ddlAltKategoriler.SelectedValue);

                urun.UrunKategoriNo = kategoriId;
                urun.UrunAltKategoriNo = altkategoriId;
                if(fuKucukResim.HasFile)
                {
                    fuKucukResim.SaveAs(Server.MapPath("/Content/urunimages/images/" + fuKucukResim.FileName));
                }
                if(fuBuyukResim.HasFile)
                {
                    fuBuyukResim.SaveAs(Server.MapPath("/Content/urunimages/images/Buyuk/" + fuBuyukResim.FileName));
                    
                }

                urun.UrunResimYolu1 = "/Content/urunimages/images/" + fuKucukResim.FileName;
                urun.UrunResimYolu2 = "/Content/urunimages/images/Buyuk/" + fuBuyukResim.FileName;

                try
                {
                    ent.SaveChanges();
                    UrunleriGetir();
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
                DataModel.Urunler urun = new DataModel.Urunler();
                urun.UrunKodu = "REF-" + txtUrunKodu.Text;
                urun.UrunAd = txtUrunAdi.Text;
                urun.StokMiktari = Convert.ToInt32(txtStok.Text);
                urun.UrunFiyat = Convert.ToDecimal(txtFiyat.Text);
                urun.UrunBilgisi = txtAçıklama.Text;

                int kategoriId = Convert.ToInt32(ddlKategoriler.SelectedValue);
                int altkategoriId = Convert.ToInt32(ddlAltKategoriler.SelectedValue);

                urun.UrunKategoriNo = kategoriId;
                urun.UrunAltKategoriNo = altkategoriId;
                if (fuKucukResim.HasFile)
                {
                    fuKucukResim.SaveAs(Server.MapPath("/Content/urunimages/images/" + fuKucukResim.FileName));
                }
                if (fuBuyukResim.HasFile)
                {
                    fuBuyukResim.SaveAs(Server.MapPath("/Content/urunimages/images/Buyuk/" + fuBuyukResim.FileName));

                }

                urun.UrunResimYolu1 = "/Content/urunimages/images/" + fuKucukResim.FileName;
                urun.UrunResimYolu2 = "/Content/urunimages/images/Buyuk/" + fuBuyukResim.FileName;

                ent.Urunler.Add(urun);
                try
                {
                    ent.SaveChanges();
                    UrunleriGetir();
                    Temizle();
                }
                catch (Exception ex)
                {
                    string hata = ex.Message;
                }
            }

            pnlekle.Visible = false;
            Session["urun"] = null;
        }

        private bool UrunVarmi()
        {
            int urunid = Convert.ToInt32(Session["urun"]);
            var urun = ent.Urunler.Where(u => u.UrunID==urunid ).Select(u => u).FirstOrDefault();
            if (urun != null) return true;
            return false;
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            int urunid = Convert.ToInt32(Session["urun"]);
            var urun = ent.Urunler.Where(u => u.UrunID == urunid).Select(u => u).FirstOrDefault();
            urun.Silindi = true;
            try
            {
                ent.SaveChanges();

                UrunleriGetir();
                pnlekle.Visible = false;
                Temizle();
                btnKaydet.Enabled = false;
                btnSil.Enabled = false;
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
            }
        }

        protected void lbtnYeniUrunEkle_Click(object sender, EventArgs e)
        {
            Temizle();
            btnKaydet.Enabled = true;
            btnSil.Enabled = false;
            pnlekle.Visible = true;

        }
    }
}