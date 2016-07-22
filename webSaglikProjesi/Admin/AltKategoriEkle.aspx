<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="AltKategoriEkle.aspx.cs" Inherits="webSaglikProjesi.Admin.AltKategoriEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script type="text/javascript">
        var baslik = this.document.getElementById("UstBaslik");
        baslik.innerText = "Altkategori Ekleme Güncelleme";        
    </script>
    <div style="width:700px">
        <div style="width:330px;float:left; height: 191px;">
            <table style="width:329px; height: 189px;">
            <tr>
                <td style="width:110px;font-size:16px">
                    <asp:Label ID="Label3" runat="server" Text="Kategori Adı"></asp:Label>
                </td>                
                <td  colspan="2">
                    <asp:DropDownList ID="ddlKategoriler" runat="server" Height="16px" OnSelectedIndexChanged="ddlKategoriler_SelectedIndexChanged" Width="163px" DataTextField="KategoriAd" DataValueField="ID" AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:110px;font-size:16px">
                    <asp:Label ID="Label1" runat="server" Text="Altkategori Adı"></asp:Label>
                </td>                
                <td  colspan="2">
                    <asp:TextBox ID="txtAltkategoriAd" runat="server" Width="163px" Font-Size="16px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:100px;font-size:16px;">
                    <asp:Label ID="Label2" runat="server" Text="Açıklaması"></asp:Label>
                </td>
                <td rowspan="2" colspan="2">
                    <asp:TextBox ID="txtAçıklama" runat="server" TextMode="MultiLine" Height="67px" Width="163px"></asp:TextBox>
                </td>
            </tr>
            <tr style="height:60px">
                <td style="width:100px;font-size:16px">
                </td>
            </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:Button ID="btnEkle" runat="server" Text="Ekle" CssClass="bluebutton" Width="63px" OnClick="btnEkle_Click" />
                    </td>
                    <td style="text-align:center">
                        <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" CssClass="bluebutton" Width="63px" Enabled="False" OnClick="btnKaydet_Click" />
                    </td>
                    <td style="text-align:center">
                        <asp:Button ID="btnSil" runat="server" Text="Sil" CssClass="bluebutton" Width="63px" Enabled="False" OnClick="btnSil_Click" OnClientClick="return confirm('Silmek İstiyor musunuz?')" />
                    </td>
                </tr>                
        </table>
        </div>
        <div style="float:left;margin-left:5px;">
            <asp:GridView ID="gvAltKategoriler" runat="server" AutoGenerateColumns="False" Height="183px" OnSelectedIndexChanged="gvKategoriler_SelectedIndexChanged" Width="355px" DataKeyNames="ID">
                <Columns>
                    <asp:CommandField SelectText="Seç" ShowSelectButton="True" />
                    <asp:BoundField DataField="AltKategoriAd" HeaderText="Alt Kategori" />
                    <asp:BoundField DataField="Aciklama" HeaderText="Açıklama" />
                </Columns>
            </asp:GridView>
        </div>      
        
    </div>
</asp:Content>
