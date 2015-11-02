<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowOccupationDiff.ascx.cs"
    Inherits="HCMS.PDExpress.Controls.CreatePD.Occupation.ShowOccupationDiff" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">

 p.MsoNormal
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:0in;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
    .style1
    {
        border-collapse: collapse;
        font-size: 11.0pt;
        font-family: Calibri, sans-serif;
        border: 1.0pt solid windowtext;
    }
</style>
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">

    <script type="text/javascript">
        function onRadComboActionTopSelectedIndexChanged(sender, eventArgs) {
            var selectedItem = eventArgs.get_item();
            var selectedItemText = selectedItem != null ? selectedItem.get_text() : sender.get_text();



            //Enable/Disable grid combo boxes based on selection            
            //SetAction(selectedItemText);
        }

        function onRadComboActionBottomSelectedIndexChanged(sender, eventArgs) {
            var selectedItem = eventArgs.get_item();
            var selectedItemText = selectedItem != null ? selectedItem.get_text() : sender.get_text();
        }
        window.blockConfirm = function(text, mozEvent, oWidth, oHeight, callerObj, oTitle) {
            var ev = mozEvent ? mozEvent : window.event; //Moz support requires passing the event argument manually
            //Cancel the event
            ev.cancelBubble = true;
            ev.returnValue = false;
            if (ev.stopPropagation) ev.stopPropagation();
            if (ev.preventDefault) ev.preventDefault();

            var callerObj = ev.srcElement ? ev.srcElement : ev.target;
            text = 'Are you sure you want to save the changes?';

            //Call the original radconfirm and pass it all necessary parameters
            if (callerObj) {
                //Show the confirm, then when it is closing, if returned value was true, automatically call the caller's click method again.
                var callBackFn = function(arg) {
                    if (arg) {
                        callerObj["onclick"] = "";
                        if (callerObj.click) callerObj.click();
                        else if (callerObj.tagName == "A") {
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
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnableAJAX="true">
    <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radComboActionTop">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="radlstviewOccChanges" LoadingPanelID="rlpDefault" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="rlpDefault" runat="server" Skin="Web20" />
<div id="divSubmitActionTop" runat="server" class="blueTable"  style=" width: 98%; padding: 4px;
    margin-top: 10px; margin-bottom: 10px;">
    <asp:Button ID="btnGoBackTop" runat="server" Text="Go Back" align="right" CssClass="formBtn" OnClick="GoBack" ToolTip="Go Back" /><br />
    <br />
    <div align="right" >
    
        <asp:Literal ID="litAccRej" runat ="server" Text ="Review HR recommended changes and 'Accept All' or 'Reject All' the changes.<br/> You can selectively Accept/Reject each change by selecting the option 'Select Changes'."></asp:Literal>

  
       <telerik:RadComboBox ID="radComboActionTop" runat="server" Width="105px" ShowMoreResultsBox="false"
            Skin="WebBlue" EnableLoadOnDemand="false" 
        OnClientSelectedIndexChanging="onRadComboActionTopSelectedIndexChanged" 
        onselectedindexchanged="radComboActionTop_SelectedIndexChanged" AutoPostBack="true">
            <Items>
                <telerik:RadComboBoxItem Text="Accept All" Selected="true" Value="acceptall" />
                <telerik:RadComboBoxItem Text="Reject All" Selected="true" Value="rejectall" />
                <telerik:RadComboBoxItem Text="Select Changes" Selected="true" Value="select" />
            </Items>
        </telerik:RadComboBox>
  
   </div>
</div>
<asp:Panel ID="pnlOccupationChanges" runat="server" Width="100%">
    <telerik:RadListView ID="radlstviewOccChanges" runat="server" Width="100%" SkinID="Web20"
        ItemPlaceholderID="OccupationContainer" OnItemDataBound="radlstviewOccChanges_ItemDataBound"
        OnNeedDataSource="radlstviewOccChanges_NeedDataSource">
        <LayoutTemplate >
            <fieldset style="width:97%">
                <legend>Occupation Changes From HR Review</legend>
                <asp:PlaceHolder ID="OccupationContainer" runat="server"  />
            </fieldset>
        </LayoutTemplate>
        <ItemTemplate>
            
                <table class="blueTableListView" border="0">
                    <tr>
                        <td style="width: 30%">
                            Job Series:
                        </td>
                        <td>
                            <asp:Label ID="lblJobSeries" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlJobSeriesSel" runat="server" Visible="false" >
                                <asp:ListItem Text="Accept" Value="1" Selected="True" />
                                <asp:ListItem Text="Reject" Value ="0" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr >
                        <td style="background-color: #e4ebf1 ;border-bottom-style: none">
                            Proposed Grade:
                        </td>
                        <td style="background-color: #e4ebf1 ;border-bottom-style: none">
                            <asp:Label ID="lblProposedGrade" runat="server"></asp:Label>
                        </td>
                        <td rowspan="2" style="background-color: #e4ebf1;">
                         <asp:DropDownList ID="ddlGradeSel" runat="server" Visible="false">
                                <asp:ListItem Text="Accept" Value="1" Selected="True" />
                                <asp:ListItem Text="Reject" Value ="0" />
                            </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <td style="background-color: #e4ebf1">
                            Proposed Full Performance Grade:
                        </td>
                        <td style="background-color: #e4ebf1">
                            <asp:Label ID="lblFPGrade" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            OPM Job Title:
                        </td>
                        <td >
                            <asp:Label ID="lblOPMJobTitle" runat="server"></asp:Label>
                        </td>
                        <td >
                         <asp:DropDownList ID="ddlOPMJobTitleSel" runat="server" Visible="false">
                                <asp:ListItem Text="Accept" Value="1" Selected="True" />
                                <asp:ListItem Text="Reject" Value ="0" />
                            </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <td style="background-color: #e4ebf1">
                            FWS Position Title:
                        </td>
                        <td style="background-color: #e4ebf1">
                            <asp:Label ID="lblFWSPositionTitle" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #e4ebf1" >
                         <asp:DropDownList ID="ddlFWSPositionTitleSel" runat="server" Visible="false">
                                <asp:ListItem Text="Accept" Value="1" Selected="True" />
                                <asp:ListItem Text="Reject" Value ="0" />
                            </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <td >
                            Position Type:
                        </td>
                        <td >
                            <asp:Label ID="lblPositionType" runat="server"></asp:Label>
                        </td>
                        <td >
                         <asp:DropDownList ID="ddlPositionTypeSel" runat="server" Visible="false">
                                <asp:ListItem Text="Accept" Value="1" Selected="True" />
                                <asp:ListItem Text="Reject" Value ="0" />
                            </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <td style="background-color: #e4ebf1">
                            Organization Code:
                        </td>
                        <td style="background-color: #e4ebf1">
                            <asp:Label ID="lblOrganizationCode" runat="server"></asp:Label>
                        </td>
                        <td style="background-color: #e4ebf1">
                         <asp:DropDownList ID="ddlOrganizationCodeSel" runat="server" Visible="false" >
                                <asp:ListItem Text="Accept" Value="1" Selected="True" />
                                <asp:ListItem Text="Reject" Value ="0" />
                            </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <td style ="border-bottom-style: none">
                            Interdisciplinary?
                        </td>
                        <td style ="border-bottom-style: none">
                            <asp:Label ID="lblIsInterdisciplinary" runat="server"></asp:Label>
                        </td>
                        <td rowspan="2" style ="border-bottom-style: none" >
                         <asp:DropDownList ID="ddlIsInterdisciplinarySel" runat="server" Visible="false">
                                <asp:ListItem Text="Accept" Value="1" Selected="True" />
                                <asp:ListItem Text="Reject" Value ="0" />
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td >
                            Additional Series:
                        </td>
                        <td >
                            <asp:Label ID="lblAdditionalSeries" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
        
        </ItemTemplate>
        <EmptyDataTemplate>
            <fieldset>
                <legend>Occupation</legend>No Changes to Occupation.
            </fieldset>
        </EmptyDataTemplate>
    </telerik:RadListView>
</asp:Panel>

<span class="spanAction">
       
        <asp:Button ID="btnSaveTop" runat="server" CssClass="formBtn" OnClick="btnSaveTop_Click"
            Text="Save and Continue" ToolTip="Save and Continue" OnClientClick="return blockConfirm('Occupation Changes?', event, 330, 150,'','Confirm Occupation Changes');" />
</span>
<%--This is for radconfirm--%>
<div>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Skin="WebBlue">
    </telerik:RadWindowManager>
</div>
		

		
