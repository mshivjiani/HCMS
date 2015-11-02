<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NarrativeFactorLanguagePopupCtrl.ascx.cs"
    Inherits="HCMS.PDExpress.Controls.CreatePD.Factors.NarrativeFactorLanguagePopupCtrl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

    <script type="text/javascript">
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function NarrativeFactorLanguagePopupCtrlClose() {
            var hdnFactorLanguageToCompareWith = $get("<%=hdnFactorLanguageToCompareWith.ClientID%>");
            var radEditorFactorLanguage = $get("<%=RadEditFactorLanguage.ClientID %>");
            //Radeditor randers as IFrame and therefore getting its content 
            // via document.body.innerText (ie)/document.body.textContent (firefox)
            var myIframe = $get("<%=RadEditFactorLanguage.ClientID %>" + "_contentIframe");
            var iframeDocument = (myIframe.contentWindow || myIframe.contentDocument);
            var radeditfactorlanguagetext="";
            var hdnRefreshGrid = $get("<%=hdnRefreshGrid.ClientID%>");
            var showMessageValue = "ShowMessage";
            if (iframeDocument.document) {
                iframeDocument = iframeDocument.document;
                if (iframeDocument.body.innerText != 'undefined') {
                    radeditfactorlanguagetext = iframeDocument.body.innerText;
                }
                else if (iframeDocument.body.textContent != 'undefined') {
                    radeditfactorlanguagetext = iframeDocument.body.textContent;

                }

                if (hdnFactorLanguageToCompareWith.value.toLowerCase() == radeditfactorlanguagetext.toLowerCase()) {
                    showMessageValue = "";
                }
            }

            GetRadWindow().close(hdnRefreshGrid.value + '|' + showMessageValue);
        }
        function ShowFactorReviewPopup() {
            var oWnd = $find("<%=rwFactorLanguageReviewPopup.ClientID%>");
            var hdnPositionFactorID = $get("<%=hdnPositionFactorID.ClientID%>");
            oWnd.setUrl('<%= Page.ResolveUrl("~/CreatePD/PositionFactorReviewPopup.aspx?PositionFactorID=")%>' + hdnPositionFactorID.value);
            oWnd.show();

        }
        function OnPopupWindowClose(oWnd, eventArgs) {
            if ((eventArgs.get_argument() != null) && (eventArgs.get_argument() == 'true')) {

                document.location.reload();
            }
        }
        function OnClientLoad(editor, args) {
            editor.removeShortCut("InsertTab");
        }
        function FactorLanguagePopupCtrlCancel() {
            GetRadWindow().close();
        }
    </script>

</telerik:RadCodeBlock>
<telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
<div style="border-bottom: solid 1px #9cb6c5;">
    <table class="popupTable" width="100%">
        <col width="16%" />
        <tr>
            <td>
                <span class="highlight2">Factor Title:</span>
            </td>
            <td>
                <asp:Label ID="lblFactorTitle" runat="server" />
            </td>
        </tr>
        <tr id="trFactorLanguage" runat="server">
            <td style="vertical-align: top;">
                <span class="highlight2">Factor Description:</span>
            </td>
            <td>
                <telerik:RadEditor ID="RadEditFactorLanguage" runat="server">
                </telerik:RadEditor>
                <%--                <asp:TextBox ID="txtFactorLanguage" runat="server" TextMode="MultiLine"  Style="width: 99%" Rows="10" />
--%>
            </td>
        </tr>
        <tr id="trFactorRecommendation" runat="server">
            <td style="vertical-align: top;">
                <span class="highlight2">HR Factor Recommendation:</span>
            </td>
            <td>
                <asp:TextBox ID="txtFactorRecommendation" runat="server" TextMode="MultiLine" Style="width: 99%"
                    Rows="3" />
            </td>
        </tr>
        <tr id="trReviewed" runat="server">
            <td>
                <span class="highlight2">Reviewed?</span>
            </td>
            <td>
                <asp:CheckBox ID="chkReviewed" runat="server" />
            </td>
        </tr>
        <tr id="trFactorJustification" runat="server">
            <td style="vertical-align: top;">
                <span class="highlight2">Factor Justification:</span>
            </td>
            <td>
                <telerik:RadEditor ID="RadEditFactorJustification" runat="server" SkinID ="shortRadEditor">
                </telerik:RadEditor>
                <%--                <asp:TextBox ID="txtFactorJustification" runat="server" TextMode="MultiLine" Style="width: 99%" Rows="3" />
--%>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="btnSave" runat="server" Text="&nbsp;Save and Close&nbsp;" ToolTip="Save and Close"
                    OnClientClick="NarrativeFactorLanguagePopupCtrlClose();" />&nbsp;
                <asp:Button ID="btnClose" runat="server" Text="&nbsp;Close&nbsp;" ToolTip="Close"
                    OnClientClick="FactorLanguagePopupCtrlCancel(); return false;" />
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hdnFactorLanguageToCompareWith" runat="server" Value="" />
<asp:HiddenField ID="hdnRefreshGrid" runat="server" Value="" />
<asp:HiddenField ID="hdnPositionFactorID" runat="server" Value="" />
<div>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Skin="WebBlue">
        <Windows>
            <telerik:RadWindow ID="rwFactorLanguageReviewPopup" runat="server" ReloadOnShow="true"
                Skin="WebBlue" Modal="true" Width="700px" Height="400px" Style="display: none;"
                Title="Review Factor Language" VisibleOnPageLoad="false" Behaviors="Close" InitialBehaviors="None"
                VisibleStatusbar="false" VisibleTitlebar="true" OnClientClose="OnPopupWindowClose">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</div>
