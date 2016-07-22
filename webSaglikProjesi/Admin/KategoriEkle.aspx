<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="webSaglikProjesi.Admin.KategoriEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var baslik = this.document.getElementById("UstBaslik");
        baslik.innerText = "Kategori Ekleme Güncelleme";        
    </script>
    <div style="width:700px">
        <div style="width:330px;float:left; height: 191px;">
            <table style="width:329px; height: 189px;">
            <tr>
                <td style="width:100px;font-size:16px">
                    <asp:Label ID="Label1" runat="server" Text="Kategori Adı"></asp:Label>
                </td>                
                <td  colspan="2">
                    <asp:TextBox ID="txtKategoriAd" runat="server" Width="163px" Font-Size="16px"></asp:TextBox>
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
            <asp:GridView ID="gvKategoriler" runat="server" DataKeyNames="ID" Height="194px" Width="350px" AutoGenerateColumns="False" OnSelectedIndexChanged="gvKategoriler_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Seç" />
                <asp:BoundField DataField="KategoriAd" HeaderText="Kategori" />
                <asp:BoundField DataField="Aciklama" HeaderText="Açıklama" />
            </Columns>
        </asp:GridView>
        </div>
        
        
    </div>
</asp:Content>
