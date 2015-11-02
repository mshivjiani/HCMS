<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="Timeout.aspx.cs" Inherits="HCMS.PDExpress.Common.Timeout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Your session has timed out.</h1>
<p>Please <asp:HyperLink ID="hyperlinkdefault" runat="server" 
        Text=" click here " NavigateUrl ="~/Default.aspx"></asp:HyperLink> to login again.</p>
        </asp:Content>
