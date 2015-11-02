<%@ Page Title="" Language="C#" MasterPageFile="~/JNPMaster.master" AutoEventWireup="true" CodeBehind="JADuties.aspx.cs" Inherits="HCMS.JNP.JA.JADuties" %>
<%@ Register src="~/Controls/JA/ctrlDutyKSA.ascx" tagname="ctrlDutyKSA" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
 <uc1:ctrlDutyKSA ID="ctrlDutyKSA1" runat="server" />

</asp:Content>
