using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webSaglikProjesi
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        DataModel.SaglikUrunleriEntities1 ent = new DataModel.SaglikUrunleriEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var categories = (from category in ent.Kategoriler
                                  where category.Silindi == false
                                  select category).ToList();
                foreach (var kategori in categories)
                {
                    MenuItem mitm = new MenuItem();
                    mitm.Text = kategori.KategoriAd;
                    mitm.Value = kategori.ID.ToString();
                    mnuKategoriler.Items.Add(mitm);
                    var subcategories = (from subcategory in ent.AltKategoriler
                                      where subcategory.Silindi == false && subcategory.KategoriId == kategori.ID
                                      select subcategory).ToList();
                    foreach (var altkategori in subcategories)
                    {
                        MenuItem citm = new MenuItem();
                        citm.Text = altkategori.AltKategoriAd;
                        citm.Value = altkategori.ID.ToString();
                        mitm.ChildItems.Add(citm);
                    }
                }   
            }
        }

        protected void mnuKategoriler_MenuItemClick(object sender, MenuEventArgs e)
        {
            //Response.Write("Kategori : " + e.Item.Text + ", ID : " + e.Item.Value);

            //Response.Write("Yol : " + e.Item.ValuePath);
            string[] Degerler = e.Item.ValuePath.Split('/');
            int altkno = 0;
            if(Degerler.Length > 1)
            {
                altkno = Convert.ToInt16(Degerler[1]);
            }
            Response.Redirect("Products.aspx?kno=" + Degerler[0] + "&akno=" + altkno);
        }

        protected void gvSepetOzeti_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)Session["sepet"];
            dt.Rows.RemoveAt(e.RowIndex);
            Session["sepet"] = dt;
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

        protected void lbtnSepeteGit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sepet.aspx");
        }

        protected void gvSepetOzeti_DataBound(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["sepet"];

            if (dt.Rows.Count <1)
            {
                lbtnSepeteGit.Visible = false;
            }
            else
            {
                lbtnSepeteGit.Visible = true;
            }
        }

        protected void gvSepetOzeti_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            DataTable dt = (DataTable)Session["sepet"];

            if (dt.Rows.Count < 1)
            {
                lbtnSepeteGit.Visible = false;
            }
            else
            {
                lbtnSepeteGit.Visible = true;
            }
        }
    }
}