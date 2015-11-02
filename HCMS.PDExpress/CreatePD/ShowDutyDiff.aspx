<%@ Page Title="Duty Differences" Language="C#" MasterPageFile="~/PDMaster.Master" AutoEventWireup="true" CodeBehind="ShowDutyDiff.aspx.cs" Inherits="HCMS.PDExpress.CreatePD.ShowDutyDiff" %>
<%@ Register src="../Controls/CreatePD/Duties/ShowDutyDiff.ascx" tagname="ShowDutyDiff" tagprefix="uc1" %>
<%@ Register Src="~/Controls/CreatePD/CreatePDMapStatusProgress.ascx" TagName="CreatePDMapStatusProgress" TagPrefix="CreatePD" %>


<asp:Content ID="Content2" ContentPlaceHolderID="PDMasterMainContent" runat="server">
    <CreatePD:CreatePDMapStatusProgress ID="ctrlCreatePDMapStatusProgress" runat="server" PercentComplete="40.00" />
    <uc1:ShowDutyDiff ID="ucShowDutyDiff" runat="server" />
    
    <script type="text/javascript">
        $(document).ready(function() {
        $('#content').css("width", "895px");
        $('.siteMapTable').css("width", "900px");
        });
    </script>
</asp:Content>
