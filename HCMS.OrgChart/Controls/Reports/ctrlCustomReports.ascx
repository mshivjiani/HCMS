<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCustomReports.ascx.cs"
    Inherits="HCMS.OrgChart.Controls.Reports.ctrlCustomReports" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="tooltip" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <script type="text/javascript">
        //using pageLoad instead of document.ready() because it needs to attach click event to chkAll box
        //even after partial postback
        function pageLoad() {
            var chkall = document.getElementById('<%=chkAll.ClientID%>');
            var chkallid = chkall.getAttribute('id');
            $('#' + chkallid).click(
             function () {
                 var $ctrls = $("[id*=chkDataElements] input:checkbox");
                 $("[id*=chkDataElements] input:checkbox").each(
                 function () {
                     var curindex = $ctrls.index($(this));
                     if ($.inArray(curindex, [0, 1, 2]) == -1) {
                         $(this).prop("checked", $('#' + chkallid).is(':checked'));
                     }
                 });
             });
        };
        
    </script>
</telerik:RadCodeBlock>
<cc1:Accordion ID="accReports" runat="server" AutoSize="None" RequireOpenedPane="false"
    HeaderCssClass="blueAccordionHeader" HeaderSelectedCssClass="blueAccordionHeaderSelected">
    <Panes>
        <cc1:AccordionPane ID="accPanelCannedReports" runat="server">
            <Header>
                Canned Reports</Header>
            <Content>
                <table width="100%" class="blueTable">
                    <tr>
                        <td>
                            <asp:Image ID="imgQrg3" runat="server" SkinID="pdfIcon" />&nbsp;<a href="~/Common/Executive_Organizational_Chart_Report_without_Phone_Numbers.pdf"
                                id="report3" runat="server" target="_blank" title="Executive Organizational Chart Report without Phone Numbers">Executive
                                Organizational Chart Report</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="imgQrg6" runat="server" SkinID="pdfIcon" />&nbsp;<a href="~/Common/Regional_Organizational_Chart_Report_without_Phone_Numbers.pdf"
                                id="A1" runat="server" target="_blank" title="Regional Organizational Chart Report without Phone Numbers">Regional
                                Organizational Chart Report</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="imgQrg4" runat="server" SkinID="pdfIcon" />&nbsp;<a href="~/Common/Enterprise_Organizational_Chart_Report.pdf"
                                id="report4" runat="server" target="_blank" title="Enterprise Organizational Chart Report">Enterprise
                                Organizational Chart Report</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="imgQrg1" runat="server" SkinID="pdfIcon" />&nbsp;<a href="~/Common/Green_Book_Organizational_Chart_Report.pdf"
                                id="report1" runat="server" target="_blank" title="Green Book Organizational Chart Report">Green
                                Book Organizational Chart Report</a>
                        </td>
                    </tr>
                    <tr runat="server" id="trExecPh">
                        <td>
                            <asp:Image ID="imgQrg2" runat="server" SkinID="pdfIcon" />&nbsp;<a href="~/Common/Executive_Organizational_Chart_Report_with_Phone_Numbers.pdf"
                                id="report2" runat="server" target="_blank" title="Executive Organizational Chart Report with Phone Numbers">Executive
                                Organizational Chart Report(Phone Numbers)</a>
                        </td>
                    </tr>
                    <tr runat="server" id="trRegionalPh">
                        <td>
                            <asp:Image ID="imgQrg5" runat="server" SkinID="pdfIcon" />&nbsp;<a href="~/Common/Regional_Organizational_Chart_Report_with_Phone_Numbers.pdf"
                                id="report5" runat="server" target="_blank" title="Regional Organizational Chart Report with Phone Numbers">Regional
                                Organizational Chart Report(Phone Numbers)</a>
                        </td>
                    </tr>
                </table>
            </Content>
        </cc1:AccordionPane>
        <cc1:AccordionPane ID="accPanelCustomExports" runat="server">
            <Header>
                Custom Exports</Header>
            <Content>
                <table width="100%" class="blueTable">
                    <tr>
                        <td>
                            <asp:Label ID="lblOrganizationCode" runat="server" Text="Organization Code:"></asp:Label>
                             
                            <span class="required">*</span> &nbsp;<tooltip:ToolTip ID="ToolTip1" runat="server"
                                ToolTipID="216" />
                        </td>
                        <td>
                         <asp:RadioButtonList ID="rdOrgCode" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                        OnSelectedIndexChanged="rdOrgCode_Changed">
                                        <asp:ListItem Text="Old Org Code" Value="Old" Selected="True" />
                                        <asp:ListItem Text="New Org Code" Value="New" />
                                    </asp:RadioButtonList>
                            <telerik:RadComboBox ID="rcbOrganizationCode" runat="server" AutoPostBack="true"
                                Width="400px" DataTextField="OrganizationCode" DataValueField="OrganizationCodeID"
                                OnSelectedIndexChanged="rcbOrganizationCode_SelectedIndexChanged" />
                            <asp:RequiredFieldValidator ID="reqOrgCode" runat="server" ValidationGroup="rep1"
                                ControlToValidate="rcbOrganizationCode" ErrorMessage="Organization Code is required"
                                Display="None" InitialValue="<<--Select Organization Code-->>" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkChilldOrgCode" runat="server" Text="Include children Org Code"
                                AutoPostBack="true" Enabled='false' />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblIncludeVacant" runat="server" Text="Include Vacant Positions:"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:CheckBox ID="chkIncludeVacant" runat="server" Text="Include Vacant Positions" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSelect" runat="server" Text="Select elements to include"></asp:Label>
                            <span class="required">*</span> &nbsp;<tooltip:ToolTip ID="ToolTip2" runat="server"
                                ToolTipID="217" />
                        </td>
                        <td colspan="2">
                            <asp:CheckBox ID="chkAll" runat="server" Text="Select All" />
                            <asp:CheckBoxList ID="chkDataElements" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                                <asp:ListItem Value="FirstName" Selected="True" Enabled="false">First Name</asp:ListItem>
                                <asp:ListItem Value="LastName" Selected="True" Enabled="false">Last Name</asp:ListItem>
                                <asp:ListItem Value="OrganizationCode" Selected="True" Enabled="false">FBMS Org Code</asp:ListItem>
                                <asp:ListItem Value="OrganizationName">FBMS Org Code Description</asp:ListItem>
                                <asp:ListItem Value="PositionNumberBase">Position Number Base</asp:ListItem>
                                <asp:ListItem Value="PositionNumberSuffix">Position Number Suffix</asp:ListItem>
                                <asp:ListItem Value="PayPlanAbbreviation">Pay Plan</asp:ListItem>
                                <asp:ListItem Value="SeriesID">Series</asp:ListItem>
                                <asp:ListItem Value="Grade">Grade</asp:ListItem>
                                <asp:ListItem Value="FPLGrade">FPL Grade</asp:ListItem>
                                <asp:ListItem Value="PositionTitle">Position Title</asp:ListItem>
                                <asp:ListItem Value="SupervisoryStatus">Position Type (Supervisory/Non-Supervisory)</asp:ListItem>
                                <asp:ListItem Value="DutyStationStateName">Duty Station State</asp:ListItem>
                                <asp:ListItem Value="DutyStationDescription">Duty Station Description</asp:ListItem>
                                <asp:ListItem Value="PhoneNumber">Phone Number</asp:ListItem>
                                <asp:ListItem Value="EmailAddress">Email Address</asp:ListItem>
                                <asp:ListItem Value="WorkScheduleTypeDesc">WorkSchedule Type</asp:ListItem>
                                <asp:ListItem Value="AppointmentType">Appointment Type</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="right">
                            <asp:Button ID="btnExport" runat="server" Text="Export Report" OnClick="btnExport_Click"
                                ValidationGroup="rep1" OnClientClick="SetValidationGroup('rep1');" />
                            <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </Content>
        </cc1:AccordionPane>
    </Panes>
</cc1:Accordion>
