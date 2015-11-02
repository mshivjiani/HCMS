<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FactorLanguagePopupCtrl.ascx.cs"
    Inherits="HCMS.PDExpress.Controls.CreatePD.Factors.FactorLanguagePopupCtrl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<script type="text/javascript">

    function onFactorLanguageChanged(positionfactorid) {

        var hdnFactorLangChanged = document.getElementById("<%=hdnFactorLanguageChanged.ClientID%>");
        hdnFactorLangChanged.value = "true";

    }

    function OnClientLoad(editor, args) {
        editor.removeShortCut("InsertTab");


    }
</script>

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

        function FactorLanguagePopupCtrlSaveAndClose() {


            var hdnFactorLanguageToCompareWith = $get("<%=hdnFactorLanguageToCompareWith.ClientID%>");
            var radEditorFactorLanguage = $get("<%=RadEditFactorLanguage.ClientID %>");

            var radeditfactorlanguagetext = "";
            var showMessageValue = "ShowMessage";
            var hdnRefreshGrid = $get("<%=hdnRefreshGrid.ClientID%>");
            //JA issue id 849: PDX: Save and Close button on Factor screen (for each factor) does nothing in Final Review
            // this was because the myIframe was returning null in final review because the tr - was disabled.
            //-- Radeditor text was collected using following to support firefox as well
            //but since in Final review it is returning null and throwing the error. So just commented and getting the text of radeditor by it's prop -innerText--
            //This also may have fixed issue JA issue 846:PDX: Similar to 743, HR Recommendation icon is not showing up until Factor screen is refreshed

            //Radeditor randers as IFrame and therefore getting its content 
            // via document.body.innerText (ie)/document.body.textContent (firefox)
//            var myIframe = $get("<%=RadEditFactorLanguage.ClientID %>" + "_contentIframe");
//            var iframeDocument = (myIframe.contentWindow || myIframe.contentDocument);
//            if (iframeDocument.document) {
//                iframeDocument = iframeDocument.document;
//                if (iframeDocument.body.innerText!='undefined') {
//                    radeditfactorlanguagetext = iframeDocument.body.innerText;
//                }
//                else if (iframeDocument.body.textContent!='undefined')
//                {
//                    radeditfactorlanguagetext = iframeDocument.body.textContent;
//                   
//                }

//                if (hdnFactorLanguageToCompareWith.value.toLowerCase() == radeditfactorlanguagetext.toLowerCase()) {
//                    showMessageValue = "";
//                }
//                        }

            if (radEditorFactorLanguage != null) {
                radeditfactorlanguagetext = radEditorFactorLanguage.innerText;
                if (hdnFactorLanguageToCompareWith.value.toLowerCase() == radeditfactorlanguagetext.toLowerCase()) {
                    showMessageValue = "";
                }
            }

            GetRadWindow().close(hdnRefreshGrid.value + '|' + showMessageValue);
        }

        //JA issue id 849: PDX: Save and Close button on Factor screen (for each factor) does nothing in Final Review
        //added this function to check the value of hidden field hdnShowMessage's value -- value is set in the code behind
        //on button click. Before this when save button was clicked js function- FactorLanguagePopupCtrlSaveAndClose was called
        //but that function was comparing the hidden field and current radeditor's value 
        //there was a problem with getting the content of radeditor (with/without formating) and comparision result was not faulty.
        //so now comparision is done in the code behind and if there is a need to show message that the langugage has changed then
        //in code behind the value of hdnShowMessage is set to "showMessage", otherwise it is set to ""
        function showMessage() {
            var hdnRefreshGrid = $get("<%=hdnRefreshGrid.ClientID%>");
            var hdnShowMessage = $get("<%=hdnShowMessage.ClientID %>");
            var showMessage = hdnShowMessage.value;
            GetRadWindow().close(hdnRefreshGrid.value + '|' + showMessage);
        }

        function FactorLanguagePopupCtrlCancel() {
            GetRadWindow().close();
        }
        function ShowFactorReviewPopup() {
            var oWnd = $find("<%=rwFactorLanguageReviewPopup.ClientID%>");
            var hdnPositionFactorID = $get("<%=hdnPositionFactorID.ClientID%>");
            var lblfactortitle = $get("<%=lblFactorTitle.ClientID %>");
            // var oBrowserWnd = GetRadWindow().BrowserWindow;
            // var url = "<%= Page.ResolveUrl("~/CreatePD/PositionFactorReviewPopup.aspx?PositionFactorID=")%>" + hdnPositionFactorID.value;
            // oBrowserWnd.open(url,"NewWindow");
            //  window.open (url);
            var url = String.format("~/CreatePD/PositionFactorReviewPopup.aspx?PositionFactorID={0}&FactorTitle={1}", hdnPositionFactorID.value, lblfactortitle.value);
            oWnd.setUrl("<%=Page.ResolveUrl(" + url + ")%>");
            oWnd.show();

        }
        function OnPopupWindowClose(oWnd, eventArgs) {
            //commented below line because we don't want to refresh the page when they just closed positionfactorreview window by clicking "X"
            //this page should only be reloaded when the closed the positionfactorreview window by clicking "accept" or "reject"
            //because the page load causes execution of the code to check reviewed flag and if not checked, it again pops the positionfactorreview window.
            //to avoid that, you should only reload when accept/reject button clicked and closed the window.
            //document.location.reload();
            if ((eventArgs.get_argument() != null) && (eventArgs.get_argument() == 'true')) {

                document.location.reload();
            }
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
        <tr id="trFactorLevel" runat="server">
            <td>
                <span class="highlight2">Factor Level - Points:</span>
            </td>
            <td>
                <telerik:RadComboBox ID="rcbFactorLevel" runat="server" AutoPostBack="true" />
            </td>
        </tr>
        <tr id="trFactorLanguage" runat="server">
            <td style="vertical-align: top;">
                <span class="highlight2">Factor Description:</span>
            </td>
            <td>
                <telerik:RadEditor ID="RadEditFactorLanguage" runat="server">
                </telerik:RadEditor>
                <%--                <asp:TextBox ID="txtFactorLanguage" runat="server" TextMode="MultiLine" CssClass="factorLanguageInput" Style="width: 99%" Rows="10" />
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
                <telerik:RadEditor ID="RadEditFactorJustification" runat="server" SkinID ="shortRadEditor" >
                </telerik:RadEditor>
                <%-- <asp:TextBox ID="txtFactorJustification" runat="server" TextMode="MultiLine" CssClass="factorLanguageInput"
                    Style="width: 99%" Rows="3" />--%>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="btnReview" runat="server" Text="Review" ToolTip="Review Changes"
                    OnClientClick="ShowFactorReviewPopup(); return false;" Visible="False" />
                &nbsp;&nbsp;
                <asp:Button ID="btnSave" runat="server" Text="&nbsp;Save and Close&nbsp;" ToolTip="Save and Close"  />&nbsp;
                <asp:Button ID="btnClose" runat="server" Text="&nbsp;Close&nbsp;" ToolTip="Close"
                    OnClientClick="FactorLanguagePopupCtrlCancel(); return false;" />
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hdnFactorLanguageToCompareWith" runat="server" Value="" />
<asp:HiddenField ID="hdnShowMessage" runat ="server" />
<asp:HiddenField ID="hdnRefreshGrid" runat="server" Value="" />
<asp:HiddenField ID="hdnFactorLanguageChanged" runat="server" Value="" />
<asp:HiddenField ID="hdnPositionFactorID" runat="server" Value="" />
<asp:HiddenField ID="hdnAcceptedRejectedClicked" runat="server" Value="" />
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
