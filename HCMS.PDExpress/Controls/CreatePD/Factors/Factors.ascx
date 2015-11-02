<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="Factors.ascx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.Factors.Factors" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="Evaluation.ascx" TagName="Evaluation" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Message/Message.ascx" TagName="Message" TagPrefix="CreatePD" %>
<%@ Register Src="~/Controls/CreatePD/Factors/LadderProgressions.ascx" TagPrefix="uc"
    TagName="LadderProgressions" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="pde" %>
<%@ Register Src="~/Controls/CreatePD/CareerLadderBundle.ascx" TagName="CareerLadderBundle"
    TagPrefix="CL" %>

<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <%--<telerik:RadAjaxManager ID="RadAjaxManager1" runat ="server" ></telerik:RadAjaxManager>
<telerik:RadWindowManager ID="RadWindowManager1" runat ="server" ></telerik:RadWindowManager>
--%>

    <script type="text/javascript">
    
        function toggleOtherReferences(cbotherbox, otherrefid) {
            var vother = document.getElementById(otherrefid);
            var vcbotherbox = document.getElementById(cbotherbox);

            if (vcbotherbox.checked == 1) {
                vother.style.display = "block";
            }
            else {
                vother.style.display = "none";
                //vother.value = "";
            }
        }
        function ShowValidationMessage(message) {
            alert(message);
        }
        function ShowFactorLanguagePopup(positionFactorID, factorTitle) {
            var oWnd = $find("<%=rwFactorLanguagePopup.ClientID%>");
            oWnd.setUrl("../Controls/CreatePD/Factors/FactorLanguagePopup.aspx?PositionFactorID=" + positionFactorID + "&FactorTitle=" + factorTitle);
            oWnd.show();
        }
        function ShowNarrativeFactorLanguagePopup(positionFactorID, factorTitle) {
            var oWnd = $find("<%=rwNarrativeFactorLanguagePopup.ClientID%>");
            oWnd.setUrl("../Controls/CreatePD/Factors/NarrativeFactorLanguagePopup.aspx?PositionFactorID=" + positionFactorID + "&FactorTitle=" + factorTitle);
            oWnd.show();
        }
        function OnPopupWindowClose(oWnd, eventArgs) {
            if (eventArgs.get_argument() != null) {
                var arr = eventArgs.get_argument().split('|');
                //hdnRefreshGrid has the value indicating which grid to refresh 
                var hdnRefreshGrid = $get('<%=hdnRefreshGrid.ClientID%>');
                var hdnShowMessage = $get('<%=hdnShowMessage.ClientID%>');

                hdnRefreshGrid.value = arr[0];
                hdnShowMessage.value = arr[1];

                if (hdnRefreshGrid.value.length != 0 || hdnShowMessage.value.length != 0) {
                    // use button click event to rebind the grid (see btnRefresh_Click() event handler in code behind file)
                    document.getElementById("<%=btnRefresh.ClientID%>").click();
                }
            }
        }
//for issue 957 --show the message if user de-selects the pre-selected standard
        window.blockConfirm = function(text, mozEvent, oWidth, oHeight, callerObj, oTitle) {
            var ev = mozEvent ? mozEvent : window.event; //Moz support requires passing the event argument manually 
            //Cancel the event 
            ev.cancelBubble = true;
            ev.returnValue = false;
            if (ev.stopPropagation) ev.stopPropagation();
            if (ev.preventDefault) ev.preventDefault();

            //Determine who is the caller 
            var callerObj = ev.srcElement ? ev.srcElement : ev.target;

            //Call the original radconfirm and pass it all necessary parameters 
            if (callerObj) {
                //Show the confirm, then when it is closing, if returned value was true, automatically call the caller's click method again. 
                var callBackFn = function(arg) {
                    if (arg) {
                        callerObj["onclick"] = "";
                        if (callerObj.click) callerObj.click(); //Works fine every time in IE, but does not work for links in Moz 
                        else if (callerObj.tagName == "A") //We assume it is a link button! 
                        {
                            try {
                                eval(callerObj.href)
                            }
                            catch (e) { }
                        }
                    }
                }

                radconfirm(text, callBackFn, oWidth, oHeight, callerObj, oTitle);
            }
            return false;
        } 

    </script>

</telerik:RadCodeBlock>
<asp:UpdatePanel ID="updateValidationMessage" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSubmitClassStdSource" />
        <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
        <asp:AsyncPostBackTrigger ControlID="btnRefresh" />
    </Triggers>
    <ContentTemplate>
        <asp:Panel ID="pnlValidationMessage" runat="server" Visible="false">
            <div style="width: 100%; background-color: #FFF3A8; border: solid 1px black; margin-bottom: 10px;">
                <div style="margin: 10px;">
                    <div style="font-size: larger; font-weight: bolder;">
                        Validation Message</div>
                    <br />
                    <br />
                    <ul style="color: Red;">
                        <li>
                            <asp:Label ID="lblValidationMessage" runat="server" Style="color: Red; font-weight: bolder;" />
                        </li>
                    </ul>
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="rlpDefault">
    <asp:Panel ID="pnlClassificationStandardSource" runat="server" GroupingText="Select Evaluation Guide - Factor Format To Classify a Position. <span class='required'>*&nbsp;</span> ">
        <table id="tblClassStdSource" runat="server" width="100%">
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblJFSMsg" runat="server" Font-Bold="true" ForeColor="Red" Visible="false"
                        Text="If a guide was not auto-selected, choose “OPM Job Family Standard for the given series – FES” unless otherwise instructed."></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
             
                            <asp:Repeater ID="repeaterClassStdSource" runat="server">
                                <HeaderTemplate>
                                    <table width="100%">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="cbClassStdSource" runat="server" Text='<%# Eval("ClassificationSourceTitle")+ "-" + Eval("FactorFormatType") %>' />
                                            <asp:HiddenField ID="hiddenClassSourceTitle" runat="server" Value='<%#Eval("ClassificationSourceTitle") %>' />
                                            <asp:HiddenField ID="hiddenClassStdSourceID" runat="server" Value='<%#Eval("ClassificationSourceID") %>' />
                                            <asp:HiddenField ID="hiddenFactorFormatTypeID" runat="server" Value='<%#Eval("FactorFormatTypeID") %>' />
                                            <pde:ToolTip ID="toolTip" runat="server" ToolTipID="-1" />
                                            <div id="divOther" runat="server" style="display: none">
                                                <asp:TextBox ID="txtOtherReferences" runat="server" TextMode="MultiLine" Width="99%"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                 
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="btnSubmitClassStdSource" runat="server" Text="Submit" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</telerik:RadAjaxPanel>
<telerik:RadAjaxLoadingPanel ID="rlpDefault" runat="server" Skin="Web20" />
<br />
<asp:UpdatePanel ID="updatePanelCLProgression" runat="server">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSubmitClassStdSource" />
    </Triggers>
    <ContentTemplate>
        <uc:LadderProgressions ID="ucCareerLadderProgressions" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="updatePanel1" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSubmitClassStdSource" />
        <asp:AsyncPostBackTrigger ControlID="btnRefresh" />
    </Triggers>
    <ContentTemplate>
        <asp:Label ID="lblFactorlangWarning" runat="server" class="requiredField" Visible="false"
            Text="NOTE: Verify and Save factor language by accessing each factor below. FES factor levels and corresponding criteria are pre-populated based on typical factor level pattern for the Job Series and Grade selected."></asp:Label>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="updatePanelFESFactor" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSubmitClassStdSource" />
        <asp:AsyncPostBackTrigger ControlID="btnRefresh" />
    </Triggers>
    <ContentTemplate>
        <asp:Panel ID="pnlFESFactor" runat="server" GroupingText="FES Factor Format" Visible="false">
            <asp:GridView ID="gvFesFactor" runat="server" AllowSorting="false" AllowPaging="true"
                PageSize="5" AutoGenerateColumns="false" SkinID="adminGridView" DataKeyNames="FactorLevel"
                Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Action">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEditFESFactor" runat="server" CommandName="Edit" CommandArgument='<%# Container.DisplayIndex  %>'
                                 SkinID ="editButton"  AlternateText="Edit" />
                            <asp:ImageButton ID="imgDeleteFESFactor" runat="server" CommandName="Delete"  SkinID ="deleteButton" 
                                AlternateText="Delete" Visible="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Factor Title" HeaderStyle-Width="75%">
                        <ItemTemplate>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblFesFactorTitle" runat="server" Text='<%#Eval("FactorTitle") %>' />
                                        </td>
                                        <td>
                                            <asp:Image ID="imgFactorLangAdded" runat="server" ToolTip="Factor Language Added"
                                                 SkinID="notesIcon"  Visible="false" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Level/Points">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblFESFactorLevel" runat="server" Text='<%# Eval("LevelID") %>'></asp:Label>-
                                            <asp:Label ID="lblFESFactorLevelPoint" runat="server" Text='<%# Eval("Point") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Image ID="imgRecommendationNote" runat="server" ToolTip="Recommendation Notes"
                                                 SkinID ="detailsIcon" Visible="false" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Factor ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblFactorID" runat="server" Text='<%# Bind("FactorID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFactorID" runat="server" Text='<%# Bind("FactorID") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FactorlLevelID" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblFactorLevelID" runat="server" Text='<%# Bind("FactorLevel") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFactorLevelID" runat="server" Text='<%# Bind("FactorLevel") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Factor Language" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblFactorLanguage" runat="server" Text='<%# Bind("Language") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <table id="tblFesGradeConversion" runat="server" width="100%" class="blueTable">
                <tr>
                    <td align="right" width="85%">
                        <asp:Label ID="lblFesTotalPoints" runat="server" Text="Total Points:"></asp:Label>
                    </td>
                    <td align="justify">
                        <asp:Label ID="lblFesTotalPointsVal" runat="server" Font-Bold="true" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="vertical-align: top;">
                        <asp:Label ID="lblFesGradeRange" runat="server" Text="Grade Conversion Range:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblFesMinPoint" runat="server" Font-Bold="true" Text=""></asp:Label>-
                        <asp:Label ID="lblFesMaxPoint" runat="server" Font-Bold="true" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblFesGradeRangeVal" runat="server" Font-Bold="true" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblFesGradeRangeMessage" ForeColor="Red" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="updatePanelGSSGFactor" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSubmitClassStdSource" />
        <asp:AsyncPostBackTrigger ControlID="btnRefresh" />
    </Triggers>
    <ContentTemplate>
        <asp:Panel ID="pnlGSSGFactor" runat="server" GroupingText="GSSG Factor Format" Visible="false">
            <asp:GridView ID="gvGSSGFactor" runat="server" AllowSorting="false" AllowPaging="true"
                PageSize="5" AutoGenerateColumns="false" SkinID="adminGridView" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Action">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEditGSSGFactor" runat="server" CommandName="Edit" CommandArgument='<%# Container.DisplayIndex %>'
                                 SkinID ="editButton"  AlternateText="Edit" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Factor Title" HeaderStyle-Width="75%">
                        <ItemTemplate>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblFactorTitle" runat="server" Text='<%#Eval("FactorTitle") %>' />
                                        </td>
                                        <td>
                                            <asp:Image ID="imgFactorLangAdded" runat="server" ToolTip="Factor Language Added"
                                                 SkinID ="notesIcon"  Visible="false" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Level/Points">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblFactorLevel" runat="server" Text='<%#Eval("LevelID") %>'></asp:Label>-
                                            <asp:Label ID="lblFactorLevelPoint" runat="server" Text='<%#Eval("Point") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Image ID="imgRecommendationNote" runat="server" ToolTip="Recommendation Notes"
                                                SkinID="detailsIcon"  Visible="false" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Factor ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblFactorID" runat="server" Text='<%# Bind("FactorID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FactorlLevelID" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblFactorLevelID" runat="server" Text='<%# Bind("FactorLevel") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Factor Language" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblFactorLanguage" runat="server" Text='<%# Bind("Language") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <table id="tblGssgGradeConversion" runat="server" width="100%" class="blueTable">
                <tr>
                    <td align="right" width="85%">
                        <asp:Label ID="lblGssgTotalPoints" runat="server" Text="Total Points:"></asp:Label>
                    </td>
                    <td align="justify">
                        <asp:Label ID="lblGssgTotalPointsVal" runat="server" Font-Bold="true" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="vertical-align: top;">
                        <asp:Label ID="lblGssgGradeRange" runat="server" Text="Grade Conversion Range:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGssgMinPoint" runat="server" Font-Bold="true" Text=""></asp:Label>-
                        <asp:Label ID="lblGssgMaxPoint" runat="server" Font-Bold="true" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblGssgGradeRangeVal" runat="server" Font-Bold="true" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblGssgGradeRangeMessage" ForeColor="Red" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="updatePanelNarrativeFactor" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSubmitClassStdSource" />
        <asp:AsyncPostBackTrigger ControlID="btnRefresh" />
    </Triggers>
    <ContentTemplate>
        <asp:Panel ID="pnlNarrativeFactor" runat="server" GroupingText="Narrative Factor Format"
            Visible="false">
            <asp:GridView ID="gvNarrativeFactor" runat="server" DataKeyNames="PositionFactorID"
                AllowSorting="false" AllowPaging="true" PageSize="5" AutoGenerateColumns="false"
                SkinID="adminGridView" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Action" HeaderStyle-Width="8%">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEditNarrativeFactor" runat="server" CommandName="Edit" CommandArgument='<%# Container.DisplayIndex  %>'
                                SkinID="editButton"  AlternateText="Edit" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Factor Title" HeaderStyle-Width="92%">
                        <ItemTemplate>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblNarrativeFactorTitle" runat="server" Text='<%#Eval("FactorTitle") %>' />
                                        </td>
                                        <td>
                                            <asp:Image ID="imgFactorLangAdded" runat="server" ToolTip="Factor Language Added"
                                                SkinID="notesIcon"  Visible="false" />
                                        </td>
                                        <td>
                                            <asp:Image ID="imgRecommendationNote" runat="server" ToolTip="Recommendation Notes"
                                                SkinID="detailsIcon"  Visible="false" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Factor ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblFactorID" runat="server" Text='<%# Bind("FactorID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFactorID" runat="server" Text='<%# Bind("FactorID") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Factor Language" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblFactorLanguage" runat="server" Text='<%# Bind("Language") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="updatePanelNarrativeSupFactor" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSubmitClassStdSource" />
        <asp:AsyncPostBackTrigger ControlID="btnRefresh" />
    </Triggers>
    <ContentTemplate>
        <asp:Panel ID="pnlNarrativeSupFactor" runat="server" GroupingText="Narrative Supervisory Factor Format"
            Visible="false">
            <asp:GridView ID="gvNarrativeSupFactor" runat="server" DataKeyNames="PositionFactorID"
                AllowSorting="false" AllowPaging="true" PageSize="5" AutoGenerateColumns="false"
                SkinID="adminGridView" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Action" HeaderStyle-Width="8%">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEditNarrativeFactor" runat="server" CommandName="Edit" CommandArgument='<%# Container.DisplayIndex  %>'
                                SkinID="editButton"  AlternateText="Edit" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Factor Title" HeaderStyle-Width="92%">
                        <ItemTemplate>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblNarrativeFactorTitle" runat="server" Text='<%#Eval("FactorTitle") %>' />
                                        </td>
                                        <td>
                                            <asp:Image ID="imgFactorLangAdded" runat="server" ToolTip="Factor Language Added"
                                                SkinID="notesIcon"  Visible="false" />
                                        </td>
                                        <td>
                                            <asp:Image ID="imgRecommendationNote" runat="server" ToolTip="Recommendation Notes"
                                               SkinID="detailsIcon"  Visible="false" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Factor ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblFactorID" runat="server" Text='<%# Bind("FactorID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFactorID" runat="server" Text='<%# Bind("FactorID") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Factor Language" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblFactorLanguage" runat="server" Text='<%# Bind("Language") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<uc:Evaluation ID="ucEvaluation" runat="server" />
<asp:UpdatePanel ID="updateValidationMessagebottom" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSubmitClassStdSource" />
        <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
        <asp:AsyncPostBackTrigger ControlID="btnRefresh" />
    </Triggers>
    <ContentTemplate>
        <asp:Panel ID="pnlValidationMessagebottom" runat="server" Visible="false">
            <div style="width: 100%; background-color: #FFF3A8; border: solid 1px black; margin-bottom: 10px;">
                <div style="margin: 10px;">
                    <div style="font-size: larger; font-weight: bolder;">
                        Validation Message</div>
                    <br />
                    <br />
                    <ul style="color: Red;">
                        <li>
                            <asp:Label ID="lblValidationMessagebottom" runat="server" Style="color: Red; font-weight: bolder;" />
                        </li>
                    </ul>
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
        
<asp:UpdatePanel ID="updatePanelActionValidate" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
        <asp:AsyncPostBackTrigger ControlID="gvNarrativeSupFactor" />
        <asp:AsyncPostBackTrigger ControlID="gvNarrativeFactor" />
        <asp:AsyncPostBackTrigger ControlID="gvGSSGFactor" />
        <asp:AsyncPostBackTrigger ControlID="gvFesFactor" />
    </Triggers>
    <ContentTemplate>
        <CL:CareerLadderBundle id="ctrlCareerLadderBundle" runat="server"></CL:CareerLadderBundle>
    </ContentTemplate>
</asp:UpdatePanel>

<span class="spanAction">
    <asp:UpdatePanel ID="updatePanelSubmit" runat="server" RenderMode="Inline" UpdateMode="Always">
        <ContentTemplate>
            <asp:Button ID="btnViewPD" runat="server" Text="View PD" />&nbsp;
            <asp:Button ID="btnShowDiff" runat="server" Text="Show Difference" />&nbsp;
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Enabled="false"    />
        </ContentTemplate>
    </asp:UpdatePanel>
</span>
<telerik:RadWindow ID="rwFactorLanguagePopup" runat="server" ReloadOnShow="true"
    Skin="WebBlue" Modal="true" Width="800px" Height="480px" Style="display: none;"
    VisibleOnPageLoad="false" Behaviors="None" InitialBehaviors="None" VisibleStatusbar="False"
    OnClientClose="OnPopupWindowClose">
</telerik:RadWindow>
<telerik:RadWindow ID="rwNarrativeFactorLanguagePopup" runat="server" ReloadOnShow="true"
    Skin="WebBlue" Modal="true" Width="800px" Height="480px" Style="display: none;"
    VisibleOnPageLoad="false" Behaviors="None" InitialBehaviors="None" VisibleStatusbar="False"
    OnClientClose="OnPopupWindowClose">
</telerik:RadWindow>


<div style="display: none">
    <asp:Button ID="btnRefresh" runat="server" Visible="True" />
</div>
<asp:HiddenField ID="hdnRefreshGrid" runat="server" Value="none" />
<asp:HiddenField ID="hdnShowMessage" runat="server" Value="no" />
<%--This is for radconfirm--%>
<div>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Skin="WebBlue">
    </telerik:RadWindowManager>
</div>