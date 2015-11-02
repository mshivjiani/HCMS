<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditPDQual.ascx.cs"
    Inherits="HCMS.PDExpress.Controls.CreatePD.Duties.AddEditPDQual" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="pde" %>
<%@ Register Src="~/Controls/Search/ctrlSearchKSA.ascx" TagPrefix="uc1" TagName="ctrlSearchKSA" %>

<script type="text/javascript">

    function OnClientLoad(editor, args) {
        editor.removeShortCut("InsertTab");
    }

    
    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.radWindow;
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow;
        return oWindow;
    }
    function CloseWindow() {
        GetRadWindow().close();
    }       
</script>

<asp:ObjectDataSource ID="odsQualification" runat="server" SelectMethod="GetObjects"
    TypeName="HCMS.Business.Lookups.QualificationDataSourceBusinessObject">
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsQualificationType" runat="server" SelectMethod="GetObjects"
    TypeName="HCMS.Business.Lookups.QualificationTypeDataSourceBusinessObject">
</asp:ObjectDataSource>
<table class="blueTable" width="100%">
    <tr>
        <td colspan="2">
            <asp:ValidationSummary ValidationGroup="KSAValGroup" ID="valSummary" runat="server" DisplayMode="BulletList" CssClass="validationMessageBox" />
           
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="literalSearchmsg" runat="server"></asp:Label>
        </td>
        </tr>
    <tr>
        <td colspan="2" style="text-align:left;">
            <div style="width:60px;">
                KSA:<span class="required">*</span>&nbsp;<pde:ToolTip ID="ToolTip1" runat="server" ToolTipID="91" />
            </div>
        </td>
        </tr>
    <tr>
        <td class="style1" colspan="2">
            <telerik:RadComboBox ID="radcomboKSA" runat="server" CssClass="float-left" AutoPostBack="true" DataTextField="KSAText"
                DataValueField="KSAID" MarkFirstMatch="True"  DropDownWidth="677px" Width="325px" 
                    onselectedindexchanged="radcomboKSA_SelectedIndexChanged" CausesValidation="false">
                </telerik:RadComboBox>&nbsp;<uc1:ctrlSearchKSA ID="SearchKSA" runat="server" />
                <asp:RequiredFieldValidator ValidationGroup="KSAValGroup" runat ="server" ID="radcomboKSAReqVal" ControlToValidate ="radcomboKSA"
                Display="None" ErrorMessage="Select KSA First" InitialValue ="<<--Select KSA-->>"></asp:RequiredFieldValidator>
        </td>
        </tr>
    <tr>
        <td colspan="2" style="text-align:left;">
            <div style="width:100px;">
                Description: <span class="required">*</span>&nbsp;
                <pde:ToolTip ID="ToolTip58" runat="server" ToolTipID="58" />
            </div>
        </td>
        </tr>
    <tr>
        <td class="style1" colspan="2">
            <telerik:RadEditor ID="radEditorQualDescription" runat="server" SkinID="limitedTextRadEditor"  OnClientLoad="OnClientLoad"></telerik:RadEditor>
            <asp:RequiredFieldValidator ValidationGroup="KSAValGroup" ID="radEditorQualDescriptionReqVal" runat="server" ControlToValidate="radEditorQualDescription"
                Display="Dynamic" InitialValue="" ErrorMessage="KSA Description is required." />
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align:left;vertical-align:middle">
            <div style="width:100px;float:left;">
                Qualification: &nbsp;
                <pde:ToolTip ID="ToolTip17" runat="server" ToolTipID="17" />
            </div>&nbsp;&nbsp;
            <telerik:RadComboBox ID="radComboQualID" runat="server" DataSourceID="odsQualification"
                DataValueField="QualificationID" DataTextField="QualificationName" Width="200px">
            </telerik:RadComboBox>
        </td>
        </tr>
    <tr>
        <td colspan="2" style="text-align:left;vertical-align:middle">
            <div style="width:128px;float:left;">
                Qualification Type: &nbsp;
                <pde:ToolTip ID="ToolTip59" runat="server" ToolTipID="59" />
            </div>&nbsp;&nbsp;
            <telerik:RadComboBox ID="radcomboQualificationTypeID" runat="server" DataSourceID="odsQualificationType"
                Width="200px" DataValueField="QualificationTypeID" 
                DataTextField="QualificationTypeName" 
                onitemdatabound="radcomboQualificationTypeID_ItemDataBound">
            </telerik:RadComboBox>
        </td>
    </tr>
</table>
<br />

<table width="100%">
    <tr align="right">
        <td>
         <asp:Label ID="lblmsg" runat="server" Font-Bold ="true" ></asp:Label>
            <asp:Button ID="btnUpdate" Text="Save and Close" runat="server" OnClick="btnUpdate_Click" ValidationGroup="KSAValGroup">
            </asp:Button>&nbsp;
            <asp:Button ID="btnCancel" Text="Close" runat="server" CausesValidation="False" ToolTip="Close"
                OnClientClick="window.close();"></asp:Button>
        </td>
    </tr>
</table>
