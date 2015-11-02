<%@ Page Title="Show Difference" Language="C#" MasterPageFile="~/PDMaster.Master" AutoEventWireup="true" CodeBehind="ShowDiff.aspx.cs" Inherits="HCMS.PDExpress.CreatePD.ShowDiff" %>
<%@ Register src="../Controls/CreatePD/ShowPositionFactorDiff.ascx" tagname="ShowPositionFactorDiff" tagprefix="uc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="PDMasterMainContent" runat="server">
    <uc1:ShowPositionFactorDiff ID="ShowPositionFactorDiff1" runat="server" />
</asp:Content>
