﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="webSaglikProjesi.Admin.Admin" %>

<%@ Register Src="~/Admin/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlKullaniciGirisi" runat="server">
        <center>
        <uc1:WebUserControl1 runat="server" id="WebUserControl1" />
        </center>
    </asp:Panel>
</asp:Content>
