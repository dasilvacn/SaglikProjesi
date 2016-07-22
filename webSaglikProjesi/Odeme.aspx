<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Odeme.aspx.cs" Inherits="webSaglikProjesi.Odeme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 175px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var baslik = this.document.getElementById("ortaBaslik");
        baslik.innerText = "Ödeme İşlemleri";
    </script>
    <div style="text-align:center">
        <img src="Content/style/images/odeme2.jpg" />
        <br /><br />
        <table style="text-align:left;width:400px">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Adı"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAdi" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Soyadı"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSoyadi" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="Alışveriş Tutarı"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTutar" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnHavaleEFT" runat="server" Text="Havale/EFT" Width="105px" CssClass="bluebutton" OnClick="btnHavaleEFT_Click" />
                </td>
                <td style="text-align:right">
                    <asp:Button ID="btnKrediKarti" runat="server" Text="Kredi Kartı" Width="105px" CssClass="bluebutton" OnClick="btnKrediKarti_Click" />
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlHavaleEFT" runat="server" Visible="false">
            <table style="text-align:left;width:400px">
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Firma Ünvan"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="MS-Yaz_08 Sağlık Ürünleri Ltd. Şti"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Banka"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Garanti Bankası"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Şube"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Barbaros Şb."></asp:Label>
                </td>
            </tr>
                <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Hesap No"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="35235323"></asp:Label>
                </td>
            </tr>
                <tr>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="IBAN NO"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="TR49 1223 5352 5746 3423 2452 89"></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAlisveriseDevam" runat="server" Text="Alışverişe Devam" Width="170px" CssClass="bluebutton" OnClick="btnAlisveriseDevam_Click" />
                </td>
                <td style="text-align:right">
                    <asp:Button ID="btnGuvenliCikis" runat="server" Text="Güvenli Çıkış" Width="105px" CssClass="bluebutton" OnClick="btnGuvenliCikis_Click" />
                </td>
            </tr>
        </table>
        </asp:Panel>
    </div>

</asp:Content>
