<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="webSaglikProjesi.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="dlisturundetay" RepeatColumns="1" runat="server" Width="510px" OnItemCommand="dlisturundetay_ItemCommand">
        <ItemTemplate>
            <div style="text-align:center">
                <asp:Label ID="lblUrunAdi" runat="server" Text='<%#Eval("UrunAd") %>' Font-Size="15px"></asp:Label><br /><br />
                <asp:Image ID="imgBuyukResim" runat="server" width="220px" Height="240px" ImageUrl='<%#Eval("UrunResimYolu2") %>' /><br />
                <asp:Label ID="lblFiyat" runat="server" Text='<%#Eval("UrunFiyat", "{0:C}") %>' Font-Size="15px"></asp:Label>                
                <asp:TextBox ID="txtAdet" runat="server" TextMode="Number" Width="26px" Text="1" ></asp:TextBox><br />                
                <asp:ImageButton ID="btnSepeteAt" ImageUrl="~/Content/style/images/btnSepeteAt.png" runat="server" CommandName="sepet" CommandArgument='<%#Eval("UrunID") %>' /><br />
                <asp:Label ID="lblUrunBilgisi" runat="server" Text='<%#Eval("UrunBilgisi") %>'></asp:Label>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
