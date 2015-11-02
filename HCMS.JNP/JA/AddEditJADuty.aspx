<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/JNPMaster.master" CodeBehind="AddEditJADuty.aspx.cs" Inherits="HCMS.JNP.JA.AddEditJADuty" %>
<%@ Register src="~/Controls/JA/ctrlAddEditJADuty.ascx" tagname="ctrlAddEditJADuty" tagprefix="uc1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div>
        <uc1:ctrlAddEditJADuty ID="ctrlAddEditJADuty1" runat="server" />
    </div>

</asp:Content>