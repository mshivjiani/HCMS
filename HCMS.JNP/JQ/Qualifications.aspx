<%@ Page Title="" Language="C#" MasterPageFile="~/JNPMaster.master" AutoEventWireup="true" CodeBehind="Qualifications.aspx.cs" Inherits="HCMS.JNP.JQ.Qualifications" %>
<%@ Register src="~/Controls/JQ/ctrlQualification.ascx" tagname="ctrlQualification" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <uc1:ctrlQualification ID="jqFactorQual" runat="server" />
</asp:Content>
