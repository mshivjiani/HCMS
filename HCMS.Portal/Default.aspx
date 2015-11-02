<%@ Page Title="My Tracker" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Default.aspx.cs" Inherits="HCMS.Portal.Default" %>
<%@ Register src="~/Controls/defaultMain.ascx" tagprefix="custom" tagname="defaultMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server" >
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID ="mainContent" runat ="server" >

<custom:defaultMain id="defaultMain" runat="server" />
</asp:Content>
