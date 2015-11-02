<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="defaultMain.ascx.cs"
    Inherits="HCMS.Portal.Controls.defaultMain" %>
<%@ Register Src="~/Controls/Login.ascx" TagName="Login" TagPrefix="uc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register src="ModuleSelector.ascx" tagname="ModuleSelector" tagprefix="uc2" %>


<asp:LoginView ID="LoginView1" runat="server">
    <LoggedInTemplate>
        
        
        <uc2:ModuleSelector ID="ModuleSelector1" runat="server" />
        
        
    </LoggedInTemplate>
    <AnonymousTemplate>
        <uc1:Login ID="Login1" runat="server" />
    </AnonymousTemplate>
</asp:LoginView>
