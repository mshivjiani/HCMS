<%@ Page Title="User Administration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="default.aspx.cs" Inherits="HCMS.Portal.Admin._default" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

<asp:UpdatePanel ID="panelUpdate" runat="server" UpdateMode="Conditional">
<ContentTemplate>

<br />


<asp:Panel ID ="pnlSearch1" DefaultButton ="buttonSearch" runat="server"  
    class="sectionContainer"   >
<div  title ="User Search">
    <table width="100%">
    <col width="110px" />
    <col width="310px" />

    <tr>
        <td>Region:</td>
        <td><telerik:RadComboBox ID="radComboRegions" CausesValidation="false" runat="server" AutoPostBack="true" Width="300px" />
        <span class="highlight1"><asp:Literal ID="literalRegionName" runat="server" /></span>&nbsp;
        <asp:RequiredFieldValidator ID="requiredRegion" runat="server" ControlToValidate="radComboRegions"
         ErrorMessage="You must select a region for the new account." ValidationGroup="RegValGroup">*</asp:RequiredFieldValidator></td>
        <td><asp:button ID="buttonSearch" runat="server" Text="Search" CausesValidation="true"  ValidationGroup="RegValGroup" />&nbsp;<asp:button ID="buttonViewAll" runat="server" Text="View All" CausesValidation="false"  /></td>
    <tr>
        <td>Organization Code:</td>
        <td colspan="2"><telerik:RadComboBox ID="radComboOrgCodes" runat="server" AutoPostBack="false" Width="450px" MarkFirstMatch="true" /></td>
    </tr>  
    <tr>
        <td></td>
        <td colspan="2"><asp:button ID="buttonShowAdvanced" runat="server" Text="Advanced Search Features" CausesValidation="false"  /></td>
    </tr>
    </table>
</div>
</asp:Panel>
<asp:Panel ID="panelMoreFields" runat="server" DefaultButton="buttonSearch2">
<br /><hr class="separator" /><div class="sectionTitle">Additional Search Critieria</div>
<div class="sectionContainer">
    <table width="100%">
    <col width="65px" />
    <col width="120px" />
    <col width="" />
    <col width="95px" />
    <col width="110px" />
    <tr>
        <td>Last Name:</td>
        <td><asp:TextBox ID="textboxLastName" runat="server" Width="180" /></td>
        <td></td>
        <td align='right'>First Name:</td>
        <td><asp:TextBox ID="textboxFirstName" runat="server" Width="180" /></td>
        <td align="right"><asp:button ID="buttonSearch2" ValidationGroup="Search" runat="server" Text="Search" CausesValidation="true"  /></td>
    </tr>  
    </table>
</div>
</asp:Panel>

<asp:UpdateProgress ID="progressSearch" runat="server">
<ProgressTemplate><br /><div align="center"><asp:Image ID="imageLoading" runat="server" SkinID="loadingIcon" /></div></ProgressTemplate>
</asp:UpdateProgress>

<asp:Panel ID="panelSystemMessage" runat="server" Visible="false">
<br /><hr class="separator" /><div align="center" class="systemMessage"><asp:Literal ID="literalSystem" runat="server" /></div>
</asp:Panel>

<asp:Panel ID="panelData" runat="server">
    <br />
    <hr class="separator" />
    <div class="sectionTitle">User Accounts</div>
    
    <telerik:RadGrid ID="rgUsers" runat="server"
                     SkinID="customRADGridView"
                     Width="100%"
                     AllowPaging="true" PageSize="10" PagerStyle-AlwaysVisible="false" 
                     AllowSorting="true"
                     OnNeedDataSource="rgUsers_NeedDataSource"
                     OnItemDataBound="rgUsers_ItemDataBound">
        <MasterTableView DataKeyNames="userID">
            <Columns>
                <telerik:GridHyperLinkColumn Visible="false" HeaderText="Edit User" DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="~/Admin/editUser.aspx?userID={0}" Text="Edit User" ItemStyle-Width="75px" ItemStyle-HorizontalAlign="Center" />
                <telerik:GridHyperLinkColumn Visible="false" HeaderText="Delegate PD" DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="~/Admin/delegatePD.aspx?userID={0}" Text="Delegate PD" ItemStyle-Width="75px" ItemStyle-HorizontalAlign="Center" />
                <telerik:GridHyperLinkColumn Visible="false" HeaderText="Delegate JNP" DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="~/Admin/DelegateJNP.aspx?userID={0}" Text="Delegate JNP" ItemStyle-Width="75px" ItemStyle-HorizontalAlign="Center" />

                <telerik:GridTemplateColumn HeaderText="Action" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink ID="linkDelegatePD" runat="server">
                            <asp:Image ID="imageDelegatePD" runat="server" SkinID="delegatePDIcon" AlternateText="Delegate PD" ToolTip ="Delegate PD" />
                        </asp:HyperLink>
                        &nbsp;&nbsp;
                        <asp:HyperLink ID="linkDelegateJNP" runat="server">
                            <asp:Image ID="imageDelegateJNP" runat="server" SkinID="delegatePDIcon" AlternateText="Delegate JNP" ToolTip ="Delegate JNP" />
                        </asp:HyperLink>
                        &nbsp;&nbsp;
                        <asp:HyperLink ID="linkDelegateOrgChart" runat="server">
                            <asp:Image ID="imageDelegateOrgChart" runat="server" SkinID="delegateOrgChartIcon" AlternateText="Delegate OrgChart"  />
                        </asp:HyperLink>
                        &nbsp;&nbsp;
                        <asp:HyperLink ID="linkEditUser" runat="server">
                            <asp:Image ID="imageEditUser" runat="server" SkinID="editUserIcon" AlternateText="Edit this User Account" ToolTip ="Edit this User Account" />
                        </asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="LastName" AllowSorting="true" SortExpression="LastName" HeaderText="Last Name"/>
                <telerik:GridBoundColumn DataField="FirstName" AllowSorting="true" SortExpression="FirstName" HeaderText="First Name" />
                <telerik:GridBoundColumn DataField="RoleName" AllowSorting="true" SortExpression="RoleName" HeaderText="Role" ItemStyle-Width="165px" ItemStyle-HorizontalAlign="Center" />
                <telerik:GridImageColumn      AllowSorting="true" SortExpression="Enabled" DataType="System.Boolean" HeaderText="Active" UniqueName="Active" ItemStyle-HorizontalAlign="Center"/>
            </Columns>        
        </MasterTableView>                     
    </telerik:RadGrid>
    
</asp:Panel>

<%--<hr />


<asp:Panel ID="panelAddNew" runat="server"><br /><div align="left" class="sectionContainer">
<asp:Button ID="buttonAddUser" runat="server" Text="Add New User" CausesValidation="false" Width="250px"  /></div></asp:Panel>    --%>

</ContentTemplate>
</asp:UpdatePanel>
<%--<br />

<div id="divActivateDeactivate" runat="server" class="sectionContainer" align="left">
<asp:button ID="buttonActivateDeactivate" runat="server" Text="Activate / Inactivate Position Description" CausesValidation="false" Width="250px"  />
</div>
<br />
<div id="divOrgCodeAdmin" runat ="server" class ="sectionContainer " align="left"  >
<asp:Button ID="btnOrgCodeAdmin" runat ="server" Text ="Organization Code Administration" CausesValidation ="false"  Width="250px" />
</div>
<br />        --%>

</asp:Content>
