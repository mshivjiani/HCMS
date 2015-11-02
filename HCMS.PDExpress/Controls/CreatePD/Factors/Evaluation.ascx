<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Evaluation.ascx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.Factors.Evaluation" %>

<br />
<table id="tableEval" runat="server" width="100%" class="blueTable">
    <tr>
        <td align="right">
            <asp:Button ID="btnAddEval" runat="server" Text="Evaluation Statement" Enabled="false" CausesValidation="false" />
        </td>
    </tr>
</table>
<br />

<asp:UpdatePanel ID="updtpnlEvalCrit" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAddEval" />
        <asp:AsyncPostBackTrigger ControlID="btnSubmitEvalCrit" />
    </Triggers>
    <ContentTemplate>
        <asp:Panel ID="pnlEvalCrit" runat="server" GroupingText="Evaluation Statement Criteria" Visible="false" Width="99%">
            <table width="100%">
                <tr>
                    <td>
                        <asp:CheckBoxList ID="chkEvalCriteria" runat="server" RepeatDirection="Vertical" DataTextField="EvalCriteriaDescription" DataValueField="EvalCriteriaID">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="btnSubmitEvalCrit" runat="server" Text="Submit Evaluation Statement Criteria" ValidationGroup="EvalCritGroup" OnClientClick="SetValidationGroup('EvalCritGroup');" />
                    </td>
                </tr>
               <tr><td ><asp:Literal ID="litEvalCritmsg" runat ="server"></asp:Literal></td></tr>

            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<br />

<asp:UpdatePanel ID="updtpnlEval" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSubmitEvalCrit" />
        <asp:AsyncPostBackTrigger ControlID="btnSaveEval" />
    </Triggers>
    <ContentTemplate>
        <asp:Panel ID="pnlEval" runat="server" Visible="false" Width="100%" GroupingText="Evaluation Statement">
            <table width="100%" class="blueTable">
            <tr><td  colspan ="2" align="right" >
                <telerik:RadSpell ID="RadSpellEval" runat="server" AllowAddCustom="false"
                ControlsToCheck="txtSeriesJustification,txtTitleJustification,txtGradeJustification,txtAdditionalJustification"
                ButtonType="ImageButton" ButtonText="" ToolTip="Spell Check"    /></td></tr>
                <tr>
                    <td style="vertical-align:top;">
                        <asp:Label ID="lblSeries" runat="server" Text="Series Justification:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSeriesJustification" runat="server" TextMode="MultiLine" Width="99%" Rows="4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">
                        <asp:Label ID="lblTitle" runat="server" Text="Title Justification:"></asp:Label>
                    </td>
                    <td style="width:82%">
                        <asp:TextBox ID="txtTitleJustification" runat="server" TextMode="MultiLine" Width="99%" Rows="4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">
                        <asp:Label ID="lblGrade" runat="server" Text="Grade Justification:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtGradeJustification" runat="server" TextMode="MultiLine" Width="99%" Rows="4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">
                        <asp:Label ID="lblAdditional" runat="server" Text="Additional Justification:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdditionalJustification" runat="server" TextMode="MultiLine" Width="99%" Rows="4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
  
                        <asp:Button ID="btnSaveEval" runat="server" Text="Save Evaluation Statement" OnClick="btnSaveEval_Click" />
                    </td>
                </tr>
                <tr><td colspan ="2"><asp:Literal ID="litEvalmsg" runat ="server"></asp:Literal></td></tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>