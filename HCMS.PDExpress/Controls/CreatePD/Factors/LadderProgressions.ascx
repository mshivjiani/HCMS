<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="LadderProgressions.ascx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.Factors.LadderProgressions" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript" language="javascript">
        function progressionCheckboxClicked(idx)
        {
            var cont0 = $("span[name=checkBoxContainer0]");
            var cont1 = $("span[name=checkBoxContainer1]");

            var childrenToDisable;
            var childrenToEnable;
            //disable the grade range for the progression type that is not selected.
            if (idx == 0) //selected progression type is Trainee (1-grade interval)
            {
                childrenToDisable = cont1[0].children[0].children;
                childrenToEnable = cont0[0].children[0].children;
            }
            else
            {
                childrenToDisable = cont0[0].children[0].children;
                childrenToEnable = cont1[0].children[0].children;
            }

            for (var d = 0; d < childrenToDisable.length; d++)
            {
                var childToDisable = childrenToDisable[d];
                if (childToDisable.tagName == 'INPUT')
                {
                    childToDisable.disabled = true;
                    childToDisable.checked = false;
                }
            }

            for (var e = 0; e < childrenToEnable.length; e++)
            {
                var childToEnable = childrenToEnable[e];
                if (childToEnable.tagName == 'INPUT')
                {
                    childToEnable.disabled = false;
                }
            }
        }
    </script>
</telerik:RadCodeBlock>


<asp:UpdatePanel ID="updatePanelMain" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="buttonCreateLadderSteps" />
    </Triggers>
    <ContentTemplate>

    <asp:Panel ID="panelMain" runat="server">

        <asp:CustomValidator ID="customValPDTypeSelected" runat="server" ControlToValidate="textboxDummy" ErrorMessage="You must select a PD progression type before the associated Career Ladder position descriptions can be created." Display="None" />
        <asp:CustomValidator ID="customValGradeSelected" runat="server" ControlToValidate="textboxDummy" ErrorMessage="You must select at least one grade for the selected progression type." Display="None" />
        <asp:CustomValidator ID="customValProposedGrade" runat="server" ControlToValidate="textboxDummy" ErrorMessage="The maximum grade selected in the progression must be less than {0}." Display="None" />
        <asp:CustomValidator ID="customValGradeInSequence" runat="server" ControlToValidate="textboxDummy" ErrorMessage="Grades cannot be skipped within a Career Ladder.  Please ensure no grades have been skipped between the lowest grade and full performance grade." Display="None" />

        <asp:Panel ID="panelProgressionData" runat="server" GroupingText="Career Ladder Draft Position Descriptions">
        <br />
            <asp:Panel HorizontalAlign="Center" ID="panelComplete" runat="server" Visible="false">
                The Career Ladder position descriptions associated with this full performance PD have been successfully generated.
                <br /><br />
            </asp:Panel>

            <asp:Panel ID="panelInnerMain" runat="server">

                <asp:GridView ID="gridViewProgressions" runat="server" HorizontalAlign="Center" Width="600px" AutoGenerateColumns="false" SkinID="adminGridView" DataKeyNames="CareerLadderPDTypeID">
                    <HeaderStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="Select" HeaderStyle-Width="45px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Literal ID="literalRadio" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Progression Type" HeaderStyle-Width="125px">
                            <ItemTemplate>
                                <asp:literal id="literalTypeName" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Grades">
                            <ItemTemplate>
                                <span id="checkBoxContainer" runat="server">
                                    <asp:CheckBoxList ID="checkboxListCareerProgressions" runat="server" RepeatColumns="0" RepeatDirection="Horizontal" RepeatLayout="Flow" />
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />

                <div align="right" style="padding-right: 7px; padding-bottom: 10px;">
                <asp:Button ID="buttonCreateLadderSteps" runat="server" Text="Create Career Ladder Draft PD's" CausesValidation="true" />
                </div>

                <asp:TextBox ID="textboxDummy" runat="server" Text="1" Visible="false" />

            </asp:Panel>

        </asp:Panel>
        <br />
    </asp:Panel>

    <asp:UpdateProgress ID="progressCareer" runat="server">
<ProgressTemplate><br /><div align="center"><asp:Image ID="imageLoading" runat="server" SkinID="loadingIcon" /></div></ProgressTemplate>
</asp:UpdateProgress>


    </ContentTemplate>
</asp:UpdatePanel>

