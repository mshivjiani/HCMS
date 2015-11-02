<%@ Page Title="" Language="C#" MasterPageFile="~/JNPMaster.master" AutoEventWireup="false"
    CodeBehind="FinalJQ.aspx.cs" Inherits="HCMS.JNP.JQ.FinalJQ" %>

<%@ Register Src="~/Controls/JQ/ctrlJQFinal.ascx" TagName="ctrlJQFinal" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/JQ/ctrlJQFinalDetails.ascx" TagName="ctrlJQFinalDetails"
    TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="headContent" runat="server">
    <script type="text/javascript" src="../Src/JsRelatedtoCSS/JQ/FinalJQ.js"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <telerik:RadAjaxManager ID="mainAJAXManager" runat="server" UpdatePanelsRenderMode="Inline">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ctrlJQFinalInfo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ctrlJQFinalInfo" />
                    <telerik:AjaxUpdatedControl ControlID="ctrlJQFinalDetailsInfo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ctrlJQFinalDetailsInfo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ctrlJQFinalInfo" />
                    <telerik:AjaxUpdatedControl ControlID="ctrlJQFinalDetailsInfo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <uc1:ctrlJQFinal ID="ctrlJQFinalInfo" runat="server" />
    <uc1:ctrlJQFinalDetails ID="ctrlJQFinalDetailsInfo" runat="server" Visible="false" />
</asp:Content>
