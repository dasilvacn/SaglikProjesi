<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UyeKayit.aspx.cs" Inherits="webSaglikProjesi.UyeKayit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var baslik = this.document.getElementById("ortaBaslik");
        baslik.innerText = "Üyelik İşlemleri";
    </script>
    <div style="float:left;width:330px;">
        <table style="margin-top:5px; width:330px">
            <tr>
                    <td style="text-align:left;font-size:small;width:100px">
                        E-Mail
                    </td>
                    <td style="margin-left:15px" class="auto-style1">
                        &nbsp; <asp:TextBox ID="txtEmail" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="E-Mail boş geçilemez!" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revMail" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Mail Dogru Girilmelidir" ForeColor="Red" ControlToValidate="txtEmail">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
            <tr>
                    <td style="text-align:left;font-size:small">
                        Şifre
                    </td>
                    <td style="margin-left:15px" class="auto-style1">
                        &nbsp; <asp:TextBox ID="txtSifre" runat="server" Width="190px" Height="20px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvfSifre" runat="server" ControlToValidate="txtSifre" ErrorMessage="Şifre boş geçilemez!" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            <tr>
                    <td style="text-align:left;font-size:small">
                        Şifre Tekrar
                    </td>
                    <td style="margin-left:15px" class="auto-style1">
                        &nbsp; <asp:TextBox ID="txtSifreTekrar" runat="server" Width="190px" Height="20px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSifreTekrar" runat="server" ControlToValidate="txtSifreTekrar" ErrorMessage="Şifre boş geçilemez!" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvRePassword" runat="server" ControlToCompare="txtSifre" ControlToValidate="txtSifreTekrar" ErrorMessage="Şifre eşleşmiyor!" ForeColor="Red">*</asp:CompareValidator>
                    </td>
                </tr>
            <tr>
                    <td style="text-align:left;font-size:small">
                        Ad
                    </td>
                    <td style="margin-left:15px" class="auto-style1">
                        &nbsp; <asp:TextBox ID="txtAd" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAd" runat="server" ControlToValidate="txtAd" ErrorMessage="Ad boş geçilemez!" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            <tr>
                    <td style="text-align:left;font-size:small">
                        Soyad
                    </td>
                    <td style="margin-left:15px" class="auto-style1">
                        &nbsp; <asp:TextBox ID="txtSoyad" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSoyad" runat="server" ControlToValidate="txtSoyad" ErrorMessage="Soyad boş geçilemez!" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            <tr>
                    <td style="text-align:left;font-size:small">
                        TC Kimlik No
                    </td>
                    <td style="margin-left:15px" class="auto-style1">
                        &nbsp; <asp:TextBox ID="txtTcNo" runat="server" Width="190px" Height="20px" MaxLength="11" TextMode="Number" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTcNo" runat="server" ControlToValidate="txtTcNo" ErrorMessage="TC Kimlik No boş geçilemez!" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revTcNo" runat="server" ControlToValidate="txtTcNo" ErrorMessage="11 karakter girilmelidir" ValidationExpression="\d{11}" ForeColor="Red">*</asp:RegularExpressionValidator>
                    </td>
                
                </tr>
                <tr>
                    <td style="text-align:left;font-size:small">
                        Adres
                    </td>
                    <td style="margin-left:15px" class="auto-style1">
                        &nbsp; <asp:TextBox ID="txtTeslimAdresi" runat="server" Width="190px" TextMode="multiline"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left;font-size:small">
                        İlçe
                    </td>
                    <td style="margin-left:15px" class="auto-style1">
                        &nbsp; <asp:TextBox ID="txtIlce" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left;font-size:small">
                        İl
                    </td>
                    <td style="margin-left:15px" class="auto-style1">
                        &nbsp; <asp:TextBox ID="txtIl" runat="server" Width="190px" Height="20px" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left;font-size:small">
                        Telefon
                    </td>
                    <td style="margin-left:15px" class="auto-style1">
                        &nbsp; <asp:TextBox ID="txtTelefon" runat="server" Width="190px" Height="20px" MaxLength="11" TextMode="Number" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTelefon" runat="server" ControlToValidate="txtTelefon" ErrorMessage="Telefon boş geçilemez!" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            <tr>
                <td></td>
                    <td  style="margin-left:15px;text-align:left">
                        &nbsp;<asp:CheckBox ID="cbxOkudum" runat="server" Text="Gizlilik Sözleşmesini Okudum" Font-Size="15px" OnCheckedChanged="cbxOkudum_CheckedChanged" />
                    </td>
                </tr>
               <tr>
                    <td  colspan="2" style="margin-left:15px;text-align:center">
                        <asp:Button ID="btnKaydet" runat="server" Text="Kayıt Ol" CssClass="bluebutton" Width="117px" OnClick="btnKaydet_Click"></asp:Button>
                    </td>
                </tr>
            <tr>
                    <td  colspan="2" style="margin-left:15px;text-align:left">
                        <asp:Label ID="lblMesaj" runat="server" Text="" ForeColor="Red" Font-Size="15px"></asp:Label>
                    </td>
                </tr>
            </table>
    </div>
    <div style="float:left;width:150px;margin-left:20px;">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <br /><br /><br /><br />
        <asp:TextBox ID="TextBox1" runat="server" Width="141px" TextMode="MultiLine" Height="170px" Font-Size="12px" Enabled="false" Text="Gizlilik Sözleşmesi : Girmiş olduğunuz kişisel bilgileriniz, 3. Şahıs ve kurumlarla kesinlikle paylaşılmayacaktır. Her türlü özel bilgi ve ödeme işlemleriniz 128 bit SSL güvenlik sertifikalarıyla şifrelenmektedir."></asp:TextBox>
    </div>
</asp:Content>
