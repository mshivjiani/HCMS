<%@ Page Title="" Language="C#" MasterPageFile="~/PDMaster.Master" AutoEventWireup="true" CodeBehind="ShowOccupationDiff.aspx.cs" Inherits="HCMS.PDExpress.CreatePD.ShowOccupationDiff" %>
<%@ Register Src="~/Controls/CreatePD/CreatePDMapStatusProgress.ascx" TagName="CreatePDMapStatusProgress" TagPrefix="CreatePD" %>
<%@ Register Src="~/Controls/CreatePD/Occupation/ShowOccupationDiff.ascx" TagName="ShowOccDiff" TagPrefix="CreatePD" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PDMasterMainContent" runat="server">
    <CreatePD:CreatePDMapStatusProgress ID="ctrlCreatePDMapStatusProgress" runat="server" PercentComplete="10.00" />
<CreatePD:ShowOccDiff ID="ctrlShowOccDiff" runat="server" />
   <script type="text/javascript">
        $(document).ready(function() {
        $('#content').css("width", "895px");
        $('.siteMapTable').css("width", "895px");
        });
    </script>
</asp:Content>
