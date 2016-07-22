<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="UrunEkle.aspx.cs" Inherits="webSaglikProjesi.Admin.UrunEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 131px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var baslik = this.document.getElementById("UstBaslik");
        baslik.innerText = "Ürün Ekleme Güncelleme";        
    </script>
    <div style="width:700px;text-align:center">             
        <div style="clear:both">
            <asp:GridView ID="gvUrunler" runat="server" AutoGenerateColumns="False" Height="183px" OnSelectedIndexChanged="gvUrunler_SelectedIndexChanged" Width="682px" DataKeyNames="UrunID">
                <Columns>
                    <asp:CommandField SelectText="Seç" ShowSelectButton="True" />
                    <asp:BoundField DataField="UrunKodu" HeaderText="Ürün Kodu" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UrunAd" HeaderText="Ürün Adı" />
                    <asp:BoundField DataField="StokMiktari" HeaderText="Stok Miktarı">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UrunFiyat" HeaderText="Fiyat">
                    <ItemStyle HorizontalAlign="Right" Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UrunBilgisi" HeaderText="Ürün Bilgisi">
                    <ItemStyle Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UrunResimYolu1" HeaderText="küçük resim" Visible="False">
                    <ItemStyle Width="0px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UrunResimYolu2" HeaderText="büyükresim" Visible="False">
                    <ItemStyle Width="0px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UrunID" HeaderText="ID" Visible="False" />
                </Columns>
            </asp:GridView>
        </div>
        <div style="text-align:left">
            <br />
        <asp:LinkButton ID="lbtnYeniUrunEkle" runat="server" OnClick="lbtnYeniUrunEkle_Click">Yeni Ürün Ekle</asp:LinkButton>
            <br />
        </div>
        <asp:Panel ID="pnlekle" runat="server" Visible="false">
        <div style="width:330px;float:left; height: 200px;">
            <table style="width:329px; height: 195px;">
            <tr>
                <td style="width:110px;font-size:16px">
                    <asp:Label ID="Label4" runat="server" Text="Kategori Adı"></asp:Label>
                </td>                
                <td  colspan="2" style="text-align:left">
                    <asp:DropDownList ID="ddlKategoriler" runat="server" Height="16px" OnSelectedIndexChanged="ddlKategoriler_SelectedIndexChanged" Width="163px" DataTextField="KategoriAd" DataValueField="ID" AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:130px;font-size:16px">
                    <asp:Label ID="Label5" runat="server" Text="Altkategori Adı"></asp:Label>
                </td>                
                <td style="text-align:left" >
                    <asp:DropDownList ID="ddlAltKategoriler" runat="server" Height="16px"  Width="163px" DataTextField="KategoriAd" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="ddlAltKategoriler_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:100px;font-size:16px;">
                    <asp:Label ID="Label6" runat="server" Text="Ürün Kodu"></asp:Label>
                </td>
                <td style="text-align:left">
                    <asp:Label ID="Label7" runat="server" Text="REF-" Font-Size="16px"></asp:Label>
                    <asp:TextBox ID="txtUrunKodu" runat="server" Font-Size="16px" Height="18px" TextMode="Number" Width="115px"></asp:TextBox>
                </td>
            </tr>
            <tr >
                <td style="width:100px;font-size:16px;">
                    <asp:Label ID="Label8" runat="server" Text="Ürün Adı"></asp:Label>
                </td>
                <td style="text-align:left">
                    <asp:TextBox ID="txtUrunAdi" runat="server" Font-Size="16px" Height="18px" Width="156px"></asp:TextBox>
                </td>
            </tr>
            <tr >
                <td style="width:100px;font-size:16px">
                    <asp:Label ID="Label9" runat="server" Text="Fiyat"></asp:Label>
                </td>
                <td style="text-align:left">
                    <asp:TextBox ID="txtFiyat" runat="server" Font-Size="16px" Height="18px" Width="110px"></asp:TextBox>
                </td>
            </tr>
                <tr>
                    <td style="width:100px;font-size:16px">
                        <asp:Label ID="Label10" runat="server" Text="Stok Miktarı"></asp:Label>
                </td>
                <td style="text-align:left">                    
                    <asp:TextBox ID="txtStok" runat="server" Font-Size="16px" Height="18px" Width="110px"></asp:TextBox>
                </td>
                </tr>                
        </table>
        </div>
        <div style="float:left;margin-left:5px;">
            <table style="width:347px; height: 195px;">
            <tr>
                <td style="font-size:16px" class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="Küçük Resim"></asp:Label>
                </td>                
                <td >
                    <asp:FileUpload ID="fuKucukResim" runat="server" Width="230px" />
                </td>
            </tr>
            <tr>
                <td style="font-size:16px" class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Büyük Resim"></asp:Label>
                </td>                
                <td >
                    <asp:FileUpload ID="fuBuyukResim" runat="server" Width="230px" />
                </td>
            </tr>
            <tr>
                <td style="font-size:16px;" class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Ürün Bilgisi"></asp:Label>
                </td>
                <td rowspan="2" style="text-align:left">
                    <asp:TextBox ID="txtAçıklama" runat="server" TextMode="MultiLine" Height="67px" Width="163px"></asp:TextBox>
                </td>
            </tr>
            <tr style="height:60px">
                <td style="font-size:16px" class="auto-style1">
                </td>
            </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" CssClass="bluebutton" Width="114px" Enabled="False" OnClick="btnKaydet_Click" />
                    </td>
                    <td style="text-align:right">
                        <asp:Button ID="btnSil" runat="server" Text="Sil" CssClass="bluebutton" Width="114px" Enabled="False" OnClick="btnSil_Click" OnClientClick="return confirm('Silmek İstiyor musunuz?')" />
                    </td>
                </tr>                
        </table>
        </div> 
        </asp:Panel>
    </div>
</asp:Content>
