<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PDMaster.Master" CodeBehind="AddEditDuty.aspx.cs" Inherits="HCMS.PDExpress.CreatePD.AddEditDuty" %>
<%@ Register Src="~/Controls/CreatePD/CreatePDMapStatusProgress.ascx" TagName="CreatePDMapStatusProgress" TagPrefix="CreatePD" %>
<%@ Register Src="~/Controls/CreatePD/CreatePDWorkflowNote.ascx" TagName="CreatePDWorkflowNote" TagPrefix="CreatePD" %>
<%@ Register src="../Controls/CreatePD/Duties/EditDuty.ascx" tagname="EditDuty" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PDMasterMainContent" runat="server">
  <CreatePD:CreatePDMapStatusProgress ID="ctrlCreatePDMapStatusProgress" runat="server" PercentComplete="40.00" />
  <CreatePD:CreatePDWorkflowNote ID="ctrlCreatePDWorkflowNote" runat="server" />
  <uc1:EditDuty ID="EditDuty1" runat="server" /> 
 </asp:Content>
