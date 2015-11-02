<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCategoryRating.ascx.cs"
    Inherits="HCMS.JNP.Controls.CR.ctrlCategoryRating" %>
<%@ Register Src="../Workflow/ctrlWorkflowActionManager.ascx" TagName="ctrlWorkflowActionManager"
    TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="tooltip" %>
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <script type="text/javascript">

        function ShowMinimumQualificationsPopUp(SeriesId, TypeOfWorkID, GradeId, mode) {
            var omanager = GetRadWindowManager();
            var oWnd = $find("<%=rwMinimumQualifications.ClientID%>");
            if (mode == "Insert") {
                navigateurl = ("../CR/MinimumQualifications.aspx?Mode=Insert&SeriesId=" + SeriesId + "&TypeOfWorkID=" + TypeOfWorkID + "&GradeId=" + GradeId);
            }
            else if (mode == "Edit") {
                navigateurl = ("../CR/MinimumQualifications.aspx?Mode=Edit&SeriesId=" + SeriesId + "&TypeOfWorkID=" + TypeOfWorkID + "&GradeId=" + GradeId);
            }
            else {
                navigateurl = ("../CR/MinimumQualifications.aspx?Mode=View&SeriesId=" + SeriesId + "&TypeOfWorkID=" + TypeOfWorkID + "&GradeId=" + GradeId);
            }

            oWnd.set_title("Minimum Qualifications");
            oWnd.setUrl(navigateurl);
            oWnd.show();
        }

        function OnPopupWindowClose(oWnd, eventArgs) {
            var oWindow = GetRadWindow();
            if (oWindow != null)
                oWindow.close();
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            return oWindow;
        }
    </script>
</telerik:RadCodeBlock>
<br />
<table runat="server" width="100%" class="blueTable">
    <tr>
        <td>
            <b>Final KSAs</b>
        </td>
    </tr>
    <tr>
        <td style="width: 100%;">
            <telerik:RadTextBox ID="rtbFinalKSA" runat="server" Width="97%" TextMode="MultiLine"
                Rows="10" ReadOnly="true">
            </telerik:RadTextBox>
        </td>
    </tr>
</table>
<asp:HyperLink ID="hlCategoryRatingExample" runat="server" NavigateUrl="~/Common/CRExample.pdf"
    Target="_blank">Category Rating Example</asp:HyperLink>
<br />
<br />
<div id="bestQualified">
    <table runat="server" width="100%" class="blueTable">
        <tr>
            <td>
                <asp:RequiredFieldValidator ID="rfvBQGroupTypeName" runat="server" ControlToValidate="rtbBQGroupTypeName"
                    Display="None" EnableClientScript="false" ErrorMessage="Group Name is required"></asp:RequiredFieldValidator>
                Group Name <span class="required">*</span>
                <%-- needs a new ToolTip ID in the DB:  &nbsp;<tooltip:ToolTip ID="ToolTip2" runat="server" ToolTipID="99999" />
                --%>
                <telerik:RadTextBox ID="rtbBQGroupTypeName" runat="server" Width="320" Style="font-weight: bold;">
                </telerik:RadTextBox>
            </td>
            <td class="toolTipleft">
                <asp:RequiredFieldValidator ID="rfvBQRangeMin" runat="server" ControlToValidate="rtbBQRangeMin"
                    Display="None" EnableClientScript="false" ErrorMessage="Min is required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revBQRangeMin" runat="server" ControlToValidate="rtbBQRangeMin"
                    ValidationExpression="\d{2,2}" Display="None" EnableClientScript="false" ErrorMessage="Min should only contain 2 digits"></asp:RegularExpressionValidator>
                Min <span class="required">*</span> &nbsp;<tooltip:ToolTip ID="ToolTip3" runat="server"
                    ToolTipID="105" />
                <telerik:RadTextBox ID="rtbBQRangeMin" runat="server" Width="80" MaxLength="2">
                </telerik:RadTextBox>
            </td>
            <td class="toolTipleft">
                <asp:RequiredFieldValidator ID="rfvBQRangeMax" runat="server" ControlToValidate="rtbBQRangeMax"
                    Display="None" EnableClientScript="false" ErrorMessage="Max is required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revBQRangeMax" runat="server" ControlToValidate="rtbBQRangeMax"
                    ValidationExpression="\d{2,3}" Display="None" EnableClientScript="false" ErrorMessage="Min should only contain 2 or 3 digits"></asp:RegularExpressionValidator>
                Max <span class="required">*</span> &nbsp;<tooltip:ToolTip ID="ToolTip4" runat="server"
                    ToolTipID="105" />
                <telerik:RadTextBox ID="rtbBQRangeMax" runat="server" Width="80" MaxLength="3">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="toolTipleft">
                Qualifying Statements <span class="required">*</span> &nbsp;<tooltip:ToolTip ID="ToolTip5"
                    runat="server" ToolTipID="182" />
                <telerik:RadTextBox ID="rtbBQQualifyingStatements" runat="server" Width="97%" TextMode="MultiLine"
                    Rows="5">
                </telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rtbBQQualifyingStatements"
                    Display="None" EnableClientScript="false" ErrorMessage=" Category Qualifying Statement is required"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</div>
<asp:Button ID="btnWellQualified" runat="server" Text="Remove Well Qualified Section"
    CausesValidation="false" />
<br />
<br />
<div id="wellQualified" runat="server">
    <table runat="server" width="100%" class="blueTable">
        <tr>
            <td>
                <asp:RequiredFieldValidator ID="rfvWQGroupTypeName" runat="server" ControlToValidate="rtbWQGroupTypeName"
                    Display="None" EnableClientScript="false" ErrorMessage="Group Name is required"></asp:RequiredFieldValidator>
                Group Name <span class="required">*</span>
                <%-- needs a new ToolTip ID in the DB:  &nbsp;<tooltip:ToolTip ID="ToolTip6" runat="server" ToolTipID="99999" />
                --%>
                <telerik:RadTextBox ID="rtbWQGroupTypeName" runat="server" Width="320" Style="font-weight: bold;">
                </telerik:RadTextBox>
            </td>
            <td class="toolTipleft">
                <asp:RequiredFieldValidator ID="rfvWQRangeMin" runat="server" ControlToValidate="rtbWQRangeMin"
                    Display="None" EnableClientScript="false" ErrorMessage="Min is required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revWQRangeMin" runat="server" ControlToValidate="rtbWQRangeMin"
                    ValidationExpression="\d{2,2}" Display="None" EnableClientScript="false" ErrorMessage="Min should only contain 2 digits"></asp:RegularExpressionValidator>
                Min <span class="required">*</span> &nbsp;<tooltip:ToolTip ID="ToolTip7" runat="server"
                    ToolTipID="105" />
                <telerik:RadTextBox ID="rtbWQRangeMin" runat="server" Width="80" MaxLength="2">
                </telerik:RadTextBox>
            </td>
            <td class="toolTipleft">
                <asp:RequiredFieldValidator ID="rfvWQRangeMax" runat="server" ControlToValidate="rtbWQRangeMax"
                    Display="None" EnableClientScript="false" ErrorMessage="Max is required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revWQRangeMax" runat="server" ControlToValidate="rtbWQRangeMax"
                    ValidationExpression="\d{2,2}" Display="None" EnableClientScript="false" ErrorMessage="Min should only contain 2 digits"></asp:RegularExpressionValidator>
                Max <span class="required">*</span> &nbsp;<tooltip:ToolTip ID="ToolTip8" runat="server"
                    ToolTipID="105" />
                <telerik:RadTextBox ID="rtbWQRangeMax" runat="server" Width="80" MaxLength="2">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3"  class="toolTipleft">
                Qualifying Statements <span class="required">*</span> &nbsp;<tooltip:ToolTip ID="ToolTip9"
                    runat="server" ToolTipID="183" />
                <telerik:RadTextBox ID="rtbWQQualifyingStatements" runat="server" Width="97%" TextMode="MultiLine"
                    Rows="5">
                </telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rtbWQQualifyingStatements"
                    Display="None" EnableClientScript="false" ErrorMessage=" Category Qualifying Statement is required"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</div>
<asp:HyperLink ID="hlMinimumQualifications" runat="server" NavigateUrl="" Target="_blank">Minimum Qualifications</asp:HyperLink>&nbsp;<tooltip:ToolTip
    ID="ToolTip1" runat="server" ToolTipID="112" />
<br />
<br />
<div id="qualified">
    <table runat="server" width="100%" class="blueTable">
        <tr>
            <td>
                <asp:RequiredFieldValidator ID="rfvQGroupTypeName" runat="server" ControlToValidate="rtbQGroupTypeName"
                    Display="None" EnableClientScript="false" ErrorMessage="Group Name is required"></asp:RequiredFieldValidator>
                Group Name <span class="required">*</span>
                <%-- needs a new ToolTip ID in the DB:  &nbsp;<tooltip:ToolTip ID="ToolTip6" runat="server" ToolTipID="99999" />
                --%>
                <telerik:RadTextBox ID="rtbQGroupTypeName" runat="server" Width="320" Style="font-weight: bold;">
                </telerik:RadTextBox>
            </td>
            <td class="toolTipleft">
                <asp:RequiredFieldValidator ID="rfvQRangeMin" runat="server" ControlToValidate="rtbQRangeMin"
                    Display="None" EnableClientScript="false" ErrorMessage="Min is required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revQRangeMin" runat="server" ControlToValidate="rtbQRangeMin"
                    ValidationExpression="\d{2,2}" Display="None" EnableClientScript="false" ErrorMessage="Min should only contain 2 digits"></asp:RegularExpressionValidator>
                Min <span class="required">*</span> &nbsp;<tooltip:ToolTip ID="ToolTip2" runat="server"
                    ToolTipID="105" />
                <telerik:RadTextBox ID="rtbQRangeMin" runat="server" Width="80" MaxLength="2">
                </telerik:RadTextBox>
            </td>
            <td class="toolTipleft">
                <asp:RequiredFieldValidator ID="rfvQRangeMax" runat="server" ControlToValidate="rtbQRangeMax"
                    Display="None" EnableClientScript="false" ErrorMessage="Max is required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revQRangeMax" runat="server" ControlToValidate="rtbQRangeMax"
                    ValidationExpression="\d{2,2}" Display="None" EnableClientScript="false" ErrorMessage="Min should only contain 2 digits"></asp:RegularExpressionValidator>
                Max <span class="required">*</span> &nbsp;<tooltip:ToolTip ID="ToolTip6" runat="server"
                    ToolTipID="105" />
                <telerik:RadTextBox ID="rtbQRangeMax" runat="server" Width="80" MaxLength="2">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3"  class="toolTipleft">
                Qualifying Statements <span class="required">*</span> &nbsp;<tooltip:ToolTip ID="ToolTip10"
                    runat="server" ToolTipID="106" />
                <telerik:RadTextBox ID="rtbQQualifyingStatements" runat="server" Width="97%" TextMode="MultiLine"
                    Rows="5">
                </telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rtbQQualifyingStatements"
                    Display="None" EnableClientScript="false" ErrorMessage=" Category Qualifying Statement is required"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</div>

<div style="float: right;">
    <table>
        <tr>
            <td colspan="3">
                <telerik:RadSpell ID="RadSpellQualifyingStatements" runat="server" AllowAddCustom="false"
                    ControlsToCheck="rtbBQQualifyingStatements,rtbWQQualifyingStatements,rtbQQualifyingStatements"
                    ButtonType="PushButton" ButtonText="Spell Check" ToolTip="Spell Check"  />
            </td>
        </tr>
    </table>
</div>
<br /><br /><br />
<div style="float: right;">
    <table>
        <tr>
            <td>
                <asp:Button ID="btnDelete" CssClass="formBtn" runat="server" CausesValidation="false" Text="Delete" OnClick="btnDelete_Click"
                    Width="100px" />&nbsp;&nbsp;
            </td>
            <td>
                <asp:Button ID="btnSave" CssClass="formBtn" runat="server" Text="Save" OnClick="btnSave_Click" 
                    Width="100px" />&nbsp;&nbsp;
                <asp:CustomValidator CssClass="formBtn" ID="customValCR" runat="server" Display="None"
                    OnServerValidate="customValCR_ServerValidate" />
            </td>
            <td>
                <asp:Button ID="btnContinue" CssClass="formBtn" runat="server" Text="Continue" CausesValidation="false"
                    Visible="false" OnClick="btnContinue_Click" Width="100px" />
            </td>
        </tr>
    </table>
</div>
<br />
<span class="spanAction" id="spanNextActions" runat="server">
    <uc1:ctrlWorkflowActionManager ID="ctrlWActManager" runat="server" />
</span>
<br />
<%--
//Issue Id: 35
//Author: Deepali Anuje
//Date Fixed: 1/23/2012
//Description: In CR: The Min Qual pop-up box should be bigger  --%>
<telerik:RadWindow ID="rwMinimumQualifications" runat="server" RegisterWithScriptManager="true"
    Skin="WebBlue" Height="300px" Width="560px" Behaviors="Close" VisibleStatusbar="false"
    Modal="true" ReloadOnShow="true" OnClientClose="OnPopupWindowClose">
</telerik:RadWindow>
<div>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Skin="WebBlue">
    </telerik:RadWindowManager>
</div>
<style type="text/css">
    .confirmBeforeDelete
    {
        display: block;
        background-color: White;
        text-align: left;
        width: 400px;
        height: 150px;
        padding: 10px 10px 10px 10px;
    }
</style>
<telerik:RadWindow ID="rwConfirmBeforeDelete" Skin="WebBlue" runat="server" VisibleTitlebar="false"
    VisibleStatusbar="false" Modal="true" Width="440" Height="190" Left="100" Top="100">
    <ContentTemplate>
        <div runat="server" id="divConfirmBeforeDelete">
            Are you sure you want to delete this Category Rating? Doing so will update the Recruitment Option to Merit Postion (MP).<br />
            <br />
            Select OK to delete this document or Cancel to continue editing the Category Rating.<br />
            <br />
            <div style="text-align: center;">
                <asp:Button ID="btnConfirmDelete_OK" OnClick="btnConfirmDelete_OK_Click" runat="server"
                    Text="OK" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnConfirmDelete_Cancel" OnClick="btnConfirmDelete_Cancel_Click"
                    runat="server" Text="Cancel" />
            </div>
        </div>
    </ContentTemplate>
</telerik:RadWindow>
