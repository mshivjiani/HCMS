<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="Occupation.ascx.cs"
    Inherits="HCMS.PDExpress.Controls.CreatePD.Occupation.Occupation" %>
<%@ Register Assembly="Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet"
    Namespace="Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet"
    TagPrefix="EntLibVal" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/Message/Message.ascx" TagName="Message" TagPrefix="CreatePD" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="pde" %>
<%@ Register Src="~/Controls/CreatePD/CreatePDWorkflowNote.ascx" TagName="CreatePDWorkflowNote"
    TagPrefix="CreatePD" %>
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">

    <script type="text/javascript" language="javascript">
        var showconfirm = true;
        function clientClose(sender, args) {
            if (args.get_argument() != null) {
                //alert("'" + sender.get_name() + "'" + " was closed and returned the following argument: '" + args.get_argument() + "'");
                var val = args.get_argument();
                var hiddenfld = document.getElementById("<%=hiddenselection.ClientID %>");
                hiddenfld.value = val;
                if (val == 1) {
                    document.getElementById("<%=btnShowExistingPDs.ClientID%>").click();
                }
                else if (val == 2) {
                    document.getElementById("<%=btnContinue.ClientID%>").click();
                }
            }
        }


        function showmessage(sender, eventArgs) {

            if (showconfirm) {
                var originalval = sender.get_selectedItem().get_text();
                var newval = eventArgs.get_item().get_text();

                if (!radconfirm("Change "  + originalval + " to " + newval + "?"))
                    eventArgs.set_item() = newval;

            }

        }


        function ShowConfirmOrgCode(oldValue, combo) {
            if (!radconfirm('You have selected an Organization Code that the PD Creator does not have access. Proceeding with this change will result in the PD Creator no longer having access to this PD.\n\nDo you still want to continue?')) {
                var orgcombo = $get("<%= ddlOrgCode.ClientID %>");
                if (orgcombo != null && oldValue.length > 0) {
                    var $RCBP = Telerik.Web.UI.RadComboBox.prototype;
                    var postback = $RCBP.postback;
                    $RCBP.postback = function() { };
                    orgcombo.findItemByText(oldValue).select();
                    $RCBP.postback = postback;
                }
            }
            else {
                var $RCBP = Telerik.Web.UI.RadComboBox.prototype;
                var postback = $RCBP.postback;
                $RCBP.postback = function() { };
                $RCBP.postback = postback;
            }
        }


        //script to confirm the change to org code

        function OnOrgCodeChange(sender, eventArgs) {

            var orgcombo = sender;
            var originalorgcode = orgcombo.get_selectedItem().get_text();
            var neworgcode = eventArgs.get_item().get_value();

            if (radconfirm("Change " + originalorgcode + " to " + neworgcode + "?"))
                eventArgs.set_cancel(false)
            else
                eventArgs.set_cancel(true);

        }
        
       

    </script>

</telerik:RadCodeBlock>
<CreatePD:CreatePDWorkflowNote ID="ctrlCreatePDWorkflowNote" runat="server" Visible="false" />
<div style="position: relative; left: 100px; top: -31px;">
    <asp:HyperLink ID="hlShowDiffs" runat="server" Text="Show Changes(Draft-Review)"
        Visible="true" NavigateUrl="~/CreatePD/ShowOccupationDiff.aspx" />
</div>
<CreatePD:Message ID="ctrlCreatePDMessage" runat="server" />
<asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validationMessageBox"
    ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
    DisplayMode="BulletList" ValidationGroup="Group1" />
<asp:Table ID="tableOccupation" runat="server" CssClass="blueTable" Width="100%">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblPDNumber" runat="server" Text="PD No.:" />
            &nbsp;
            <pde:ToolTip ID="ToolTip11" runat="server" ToolTipID="11" />
        </asp:TableCell><asp:TableCell>
            <asp:Label ID="lblPDNumberValue" runat="server" />
        </asp:TableCell><asp:TableCell>
            <asp:Label ID="lblFPPSID" runat="server" Text="FPPS PD No.:" />
            &nbsp;
            <pde:ToolTip ID="ToolTip12" runat="server" ToolTipID="12" />
        </asp:TableCell><asp:TableCell>
            <asp:TextBox ID="txtFPPSID" Width="150px" MaxLength="15" runat="server" CssClass="TelerikTextFont" />
        </asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblPayPlan" runat="server" Text="Pay Plan:" />
            &nbsp; <span class="required">*</span> &nbsp;
            <pde:ToolTip ID="ToolTip2" runat="server" ToolTipID="2" />
        </asp:TableCell><asp:TableCell Width="20%">
            <telerik:RadComboBox ID="ddlPayPlan" AutoPostBack="true" Width="300px" runat="server"
                MarkFirstMatch="true" />
            <asp:RequiredFieldValidator ID="ddlPayPlanreqval" runat="server" Display="None" ErrorMessage="Pay Plan is required."
                ControlToValidate="ddlPayPlan" InitialValue="<<- Select Pay Plan ->>" ValidationGroup="Group1"></asp:RequiredFieldValidator>
        </asp:TableCell><asp:TableCell>
            <asp:Label ID="lblInterdisc" runat="server" Text="Interdisciplinary?" Width="130px"></asp:Label>&nbsp;<pde:ToolTip
                ID="ToolTip67" runat="server" ToolTipID="67" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:CheckBox ID="chkInterdisc" runat="server" TextAlign="Left" AutoPostBack="true"
                Text="" />
        </asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblJobSeries" runat="server" Text="Job Series:" />
            &nbsp; <span class="required">*</span> &nbsp;
            <pde:ToolTip ID="ToolTip4" runat="server" ToolTipID="4" />
        </asp:TableCell><asp:TableCell>
            <asp:UpdatePanel ID="updatePanelJobSeries" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlPayPlan" />
                </Triggers>
                <ContentTemplate>
                    <telerik:RadComboBox ID="ddlJobSeries" Width="300px" AutoPostBack="true" runat="server"
                        DropDownWidth="400px" Height="200px" MarkFirstMatch="true" />
                    <asp:RequiredFieldValidator ID="ddlJobSeriesreqval" runat="server" InitialValue="<<- Select Job Series ->>"
                        Display="None" ErrorMessage="Job Series is required." ControlToValidate="ddlJobSeries"
                        ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:TableCell><asp:TableCell>
            <asp:UpdatePanel ID="updatePanelAddSeries" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="chkInterdisc" />
                </Triggers>
                <ContentTemplate>
                    <asp:Label ID="lblAdditionalSeries" runat="server" Text="Additional Series:"></asp:Label>&nbsp;
                    <span class="required" id="spn68" runat="server">*</span> &nbsp;
                    <pde:ToolTip ID="ToolTip68" runat="server" ToolTipID="68" Visible="false" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:TableCell>
        <asp:TableCell>
            <asp:UpdatePanel ID="updatePanelAddSeries1" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="chkInterdisc" />
                </Triggers>
                <ContentTemplate>
                    <asp:TextBox ID="txtAdditionalSeries" runat="server" Width="150px" Visible="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="txtAdditionalSeriesreqval" runat="server" Display="None"
                        ErrorMessage="Additional Series is required." ControlToValidate="txtAdditionalSeries"
                        ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:TableCell></asp:TableRow>
    <asp:TableRow>
    </asp:TableRow>
    <asp:TableRow ID="rowProposedGrade" runat="server">
        <asp:TableCell Width="20%">
            <asp:Label ID="lblProposedGrade" runat="server" Text="Proposed Grade:" />
            &nbsp; <span class="required">*</span> &nbsp;
            <pde:ToolTip ID="ToolTip5" runat="server" ToolTipID="5" />
        </asp:TableCell><asp:TableCell Width="20%">
            <asp:UpdatePanel ID="updatePanelProposedGrade" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlPayPlan" />
                    <asp:AsyncPostBackTrigger ControlID="ddlJobSeries" />
                </Triggers>
                <ContentTemplate>
                    <telerik:RadComboBox ID="ddlProposedGrade" AutoPostBack="true" Width="300px" runat="server"
                        MarkFirstMatch="true" />
                    <asp:RequiredFieldValidator ID="ddlProposedGradereqval" runat="server" Display="None"
                        ErrorMessage="Proposed Grade is required." ControlToValidate="ddlProposedGrade"
                        InitialValue="<<- Select Proposed Grade ->>" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:TableCell><asp:TableCell Width="20%">
            <asp:UpdatePanel ID="updatePanellblOtherProposed" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlPayPlan" />
                    <asp:AsyncPostBackTrigger ControlID="ddlJobSeries" />
                    <asp:AsyncPostBackTrigger ControlID="ddlProposedGrade" />
                </Triggers>
                <ContentTemplate>
                    <asp:Panel ID="panellblOtherProposed" runat="server" Visible="false">
                        <asp:Label ID="lblOtherProposed" runat="server" Style="font-weight: normal;" Text="If Other, specify<br /> Non-Standard Grade:" />
                        &nbsp; <span class="required">*</span>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:TableCell><asp:TableCell Width="20%">
            <asp:UpdatePanel ID="updatePanelddlOtherProposed" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlPayPlan" />
                    <asp:AsyncPostBackTrigger ControlID="ddlJobSeries" />
                    <asp:AsyncPostBackTrigger ControlID="ddlProposedGrade" />
                </Triggers>
                <ContentTemplate>
                    <asp:Panel ID="panelddlOtherProposed" runat="server" Visible="false">
                        <telerik:RadComboBox ID="ddlOtherProposed" AutoPostBack="true" Width="140px" runat="server"
                            MarkFirstMatch="true" />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell Width="20%">
            <asp:Label ID="lblFullGrade" runat="server" Text="Proposed Full Performance Grade:" />
            &nbsp; <span class="required">*</span> &nbsp;
            <pde:ToolTip ID="ToolTip6" runat="server" ToolTipID="6" />
        </asp:TableCell><asp:TableCell Width="20%">
            <asp:UpdatePanel ID="updatePanelFullGrade" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlPayPlan" />
                    <asp:AsyncPostBackTrigger ControlID="ddlJobSeries" />
                    <asp:AsyncPostBackTrigger ControlID="ddlProposedGrade" />
                </Triggers>
                <ContentTemplate>
                    <telerik:RadComboBox ID="ddlFullGrade" AutoPostBack="true" Width="300px" runat="server"
                        MarkFirstMatch="true" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:TableCell><asp:TableCell Width="20%">
            <asp:UpdatePanel ID="updatePanellblOtherFull" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlPayPlan" />
                    <asp:AsyncPostBackTrigger ControlID="ddlJobSeries" />
                    <asp:AsyncPostBackTrigger ControlID="ddlProposedGrade" />
                </Triggers>
                <ContentTemplate>
                    <asp:Panel ID="panellblOtherFull" runat="server" Visible="false">
                        <asp:Label ID="lblOtherFull" runat="server" Style="font-weight: normal;" Text="If Other, specify<br /> Non-Standard Grade:" />
                        &nbsp; <span class="required">*</span>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:TableCell><asp:TableCell Width="20%">
            <asp:UpdatePanel ID="updatePanelddlOtherFull" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlPayPlan" />
                    <asp:AsyncPostBackTrigger ControlID="ddlJobSeries" />
                    <asp:AsyncPostBackTrigger ControlID="ddlProposedGrade" />
                </Triggers>
                <ContentTemplate>
                    <asp:Panel ID="panelddlOtherFull" runat="server" Visible="false">
                        <telerik:RadComboBox ID="ddlOtherFull" Width="140px" runat="server" />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblOPMJobTitle" runat="server" Text="OPM Job Title:" />
            &nbsp; <span class="required">*</span> &nbsp;
            <pde:ToolTip ID="ToolTip7" runat="server" ToolTipID="7" />
        </asp:TableCell><asp:TableCell>
            <asp:UpdatePanel ID="updatePanelOPMJobTitle" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlPayPlan" />
                    <asp:AsyncPostBackTrigger ControlID="ddlJobSeries" />
                </Triggers>
                <ContentTemplate>
                    <telerik:RadComboBox ID="ddlOPMJobTitle" runat="server" AutoPostBack="true" Width="300px"
                        MarkFirstMatch="true" />
                    <asp:RequiredFieldValidator ID="ddlOPMJobTitlereqval" runat="server" Display="None"
                        ErrorMessage="OPM Job Title is required." ControlToValidate="ddlOPMJobTitle"
                        InitialValue="<<- Select OPM Title ->>" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:TableCell><asp:TableCell ColumnSpan="2">
        </asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblFWSPositionTitle" runat="server" Text="FWS Position Title:" />
            &nbsp; <span class="required">*</span> &nbsp;
            <pde:ToolTip ID="ToolTip8" runat="server" ToolTipID="8" />
        </asp:TableCell><asp:TableCell>
            <asp:UpdatePanel ID="updatePanelFWSPositionTitle" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlPayPlan" />
                    <asp:AsyncPostBackTrigger ControlID="ddlJobSeries" />
                    <asp:AsyncPostBackTrigger ControlID="ddlOPMJobTitle" />
                </Triggers>
                <ContentTemplate>
                    <asp:TextBox ID="txtFWSPositionTitle" Width="295px" MaxLength="200" runat="server"
                        CssClass="TelerikTextFont" />
                    <asp:RequiredFieldValidator ID="txtFWSPositionTitlereqval" runat="server" ControlToValidate="txtFWSPositionTitle"
                        Display="None" ErrorMessage="FWS Position Title is required." ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:TableCell><asp:TableCell ColumnSpan="2">
        </asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblPositionType" runat="server" Text="Position Type:" />
            &nbsp; <span class="required">*</span> &nbsp;
            <pde:ToolTip ID="ToolTip9" runat="server" ToolTipID="9" />
        </asp:TableCell><asp:TableCell>
            <telerik:RadComboBox ID="ddlPositionType" Width="300px" AutoPostBack="true" runat="server" />
            <asp:Literal ID="literalPositionType" runat="server" Visible="false">Neither</asp:Literal>
            <asp:RequiredFieldValidator ID="ddlPositionTypereqval" runat="server" ControlToValidate="ddlPositionType"
                Display="None" ErrorMessage="Position Type is required." InitialValue="<<- Select Position Type ->>"
                ValidationGroup="Group1"></asp:RequiredFieldValidator>
        </asp:TableCell><asp:TableCell ColumnSpan="2">
        </asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell >
            <asp:Label ID="lblOrgCode" runat="server" Text="Organization Code:" />
            &nbsp; <span id="spnOrgCodeReqVal" runat="server" />
            <pde:ToolTip ID="ToolTip57" runat="server" ToolTipID="57" />
        </asp:TableCell>
        <asp:TableCell ColumnSpan="3">
            <asp:UpdatePanel ID="updatePanelOrgCode" runat="server">
                <ContentTemplate>
                    <telerik:RadComboBox ID="ddlOrgCode" Width="95%" runat="server" AutoPostBack="true"
                        Height="100px" DropDownWidth="570px" MarkFirstMatch="true" EnableLoadOnDemand="false"
                        OnSelectedIndexChanged="ddlOrgCode_SelectedIndexChanged"
                         />
                    <asp:RequiredFieldValidator ID="ddlOrgCodereqval" Enabled="true" runat="server" ControlToValidate="ddlOrgCode"
                        Display="None" InitialValue="<<- Select Organization Code ->>" ErrorMessage="Organization code is required."
                        ValidationGroup="Group1"></asp:RequiredFieldValidator>
                    <asp:HiddenField ID="hiddenOrgCode" runat="server" />
                    <asp:HiddenField ID="hiddenHasAccess" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblIntroduction" runat="server" Text="Introduction" ToolTip="Introduction" />
            <pde:ToolTip ID="ToolTip15" runat="server" ToolTipID="15" />
        </asp:TableCell>
        <asp:TableCell ColumnSpan="3">
            <asp:UpdatePanel ID="updatePanelIntro" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlOrgCode" />
                </Triggers>
                <ContentTemplate>
                    <asp:TextBox ID="txtIntroduction" runat="server" CssClass="TelerikTextFont" TextMode="MultiLine"
                        Rows="8" Width="95%" MaxLength="8000"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
       
         </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:UpdatePanel ID="updatePanelEOS" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlPositionType" />
    </Triggers>
    <ContentTemplate>
        <div id="divEOS" runat="server" style="display: none;">
            <asp:Table ID="tableEOS" runat="server" CssClass="blueTable" Width="100%">
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="4">
                        <asp:Label ID="lblEqualEmploymentStatement" runat="server" Text="Equal Employment Opportunity/Diversity Statement" />
                    </asp:TableCell></asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="4">
                        <asp:TextBox ID="txtEqualEmploymentStatement" Width="99%" Rows="4" TextMode="MultiLine"
                            CssClass="TelerikTextFont" Text="" MaxLength="8000" runat="server" />
                    </asp:TableCell></asp:TableRow>
            </asp:Table>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:Table ID="tblAction" runat="server" Width="100%">
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:UpdatePanel ID="updatePanelShowExistingPDs" runat="server" UpdateMode="Conditional"
                RenderMode="Inline">
                <ContentTemplate>
                    <span id="snpShowExistingPDs" runat="server" style="display: none;">
                        <asp:Button ID="btnShowExistingPDs" runat="server" Text="Show Existing PDs" />
                        &nbsp; </span>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:TableCell></asp:TableRow>
</asp:Table>
<span class="spanAction">
    <asp:Button ID="btnContinue" runat="server" Text="Save and Continue" ToolTip="Save and Continue"
        CssClass="formBtn" ValidationGroup="Group1" />
    &nbsp;
    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="formBtn" ToolTip="Reset" />
</span>
<div>
    <telerik:RadWindow runat="server" ID="ShowExistingMsgWin" ReloadOnShow="true" Skin="WebBlue"
        Modal="true" Width="800px" Height="300px" Style="display: none;" VisibleOnPageLoad="false"
        Behaviors="None" InitialBehaviors="None" VisibleStatusbar="False" OnClientClose="clientClose">
    </telerik:RadWindow>
    <div>
        <asp:HiddenField ID="hiddenselection" runat="server" />
    </div>
</div>
<div>
    <!-- for radconfirm -->
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Skin="WebBlue">
    </telerik:RadWindowManager>
</div>
