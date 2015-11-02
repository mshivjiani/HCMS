<%@ Page Title="" Language="C#" MasterPageFile="~/JNPMaster.master" AutoEventWireup="false" CodeBehind="JAPositionInformation.aspx.cs" Inherits="HCMS.JNP.JA.JAPositionInformation" %>
<%@ Register Src="~/Controls/JNPWorkflowNotePopup/JNPWorkflowNotePopupLink.ascx" TagPrefix="JNP" TagName="JNPWorkflowNotePopupLink" %>
<%@ Register src="~/Controls/JA/ctrlPositionInfo.ascx" tagname="ctrlPositionInfo" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    

    <div><uc1:ctrlPositionInfo ID="ctrlPositionInfoData" runat="server" /></div>
</asp:Content>
