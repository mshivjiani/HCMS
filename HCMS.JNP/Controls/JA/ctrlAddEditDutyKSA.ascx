<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlAddEditDutyKSA.ascx.cs" Inherits="HCMS.JNP.Controls.JA.ctrlAddEditDutyKSA" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="tooltip" %>
<%@ Register src="~/Controls/Search/ctrlSearchKSA.ascx" tagname="ctrlSearchKSA" tagprefix="uc1" %>

<script type="text/javascript" language="javascript">
    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.radWindow;
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow;
        return oWindow;
    }
    function EditDutyKSAClose() {
        GetRadWindow().close(); 
    }
    function OnClientLoad(editor, args) {
        editor.removeShortCut("InsertTab");
    }
</script>
<asp:ObjectDataSource ID="odsQualification" runat="server" SelectMethod="GetObjects"
    TypeName="HCMS.Business.Lookups.QualificationDataSourceBusinessObject">
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsQualificationType" runat="server" SelectMethod="GetObjects"
    TypeName="HCMS.Business.Lookups.QualificationTypeDataSourceBusinessObject">
</asp:ObjectDataSource>
<asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" CssClass="validationMessageBox" ValidationGroup="AddKSAValGroup" />
<asp:Label ID="lblError" runat ="server" CssClass="validationMessage"></asp:Label>
<table class="blueTable" width="100%">
  
   <tr id="trKSASearch" ><td colspan ="2">
        <uc1:ctrlSearchKSA ID="SearchKSA" runat="server" />
        </td></tr>
    <tr><td colspan="2"><asp:Literal ID="literalSearchmsg" runat="server"></asp:Literal></td></tr>
    <tr><td class="toolTipleft">KSA:<span class="required">*</span> <span style="vertical-align: top;">&nbsp;
            </span>&nbsp;<tooltip:ToolTip ID="ToolTip1" runat="server" ToolTipID="91" /></td> 
            <td>
            <telerik:RadComboBox ID="radcomboKSA" runat="server" AutoPostBack="true" DataTextField="KSAText"
             DataValueField="KSAID" MarkFirstMatch="True" Width="350px" 
                    onselectedindexchanged="radcomboKSA_SelectedIndexChanged" CausesValidation="false">
              </telerik:RadComboBox>
              <asp:RequiredFieldValidator runat ="server" ID="radcomboKSAReqVal" ControlToValidate ="radcomboKSA" ValidationGroup="AddKSAValGroup"
               Display="Dynamic" ErrorMessage="Select KSA First" InitialValue ="<<--Select KSA First-->>"></asp:RequiredFieldValidator>
              </td>
     </tr>
      <tr>
        <td class="toolTipleft" colspan="2">
            KSA Description: <span class="required">*</span> <span style="vertical-align: top;">&nbsp;&nbsp;<tooltip:ToolTip ID="ToolTip2" runat="server" ToolTipID="94" />

            </span>
            <telerik:RadEditor ID="radEditorJAKSADescription" runat="server"  SkinID="limitedTextRadEditor"  OnClientLoad="OnClientLoad"></telerik:RadEditor>
            <asp:RequiredFieldValidator ID="radEditorJAKSADescriptionReqVal" runat="server" ControlToValidate="radEditorJAKSADescription"
                Display="Dynamic" InitialValue="" ErrorMessage="KSA Description is required." ValidationGroup="AddKSAValGroup" />
        </td>
     </tr>
         <tr>
        <td class="toolTipleft">
            Qualification: <span style="vertical-align: top;">&nbsp;<tooltip:ToolTip ID="ToolTip3" runat="server" ToolTipID="17" />
     
            </span>
        </td>
        <td>
            <telerik:RadComboBox ID="radComboDutyQualID" runat="server" DataSourceID="odsQualification"
                DataValueField="QualificationID" DataTextField="QualificationName" Width="200px">
            </telerik:RadComboBox>
        </td>
    </tr>
        <tr>
        <td class="toolTipleft"><!--JA issue id 424: On Duty KSA Screen, use tool tip 59 for Qualification Type defintion -->
            Qualification Type: <span style="vertical-align: top;">&nbsp;<tooltip:ToolTip ID="ToolTip4" runat="server" ToolTipID="59" />

            </span>
        </td>
        <td>
            <telerik:RadComboBox ID="radcomboQualificationTypeID" runat="server" DataSourceID="odsQualificationType"
                Width="200px" DataValueField="QualificationTypeID" DataTextField="QualificationTypeName">
            </telerik:RadComboBox>
        </td>
    </tr>
</table>

<table width="100%">
    <tr align="right">
        <td>
        <asp:Label ID="lblmsg" runat="server" Font-Bold ="true" ></asp:Label>
            <asp:Button ID="btnUpdate" Text="Save" runat="server" OnClick="btnUpdate_Click" ValidationGroup="AddKSAValGroup">
            </asp:Button>&nbsp;
            <asp:Button ID="btnCancel" Text="Close" runat="server" CausesValidation="False" ToolTip="Close"
                                onclick="btnCancel_Click"></asp:Button>
        </td>
    </tr>
</table>
   
<asp:HiddenField ID="hiddenMode" runat="server" Value="Update" />
<asp:HiddenField ID="hiddenID" runat="server" />