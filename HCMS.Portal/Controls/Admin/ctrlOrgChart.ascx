<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlOrgChart.ascx.cs"
    Inherits="HCMS.Portal.Controls.Admin.ctrlOrgChart" %>
<telerik:radajaxloadingpanel id="ajaxLoadingPanelSave" runat="server" />
<%--<telerik:RadScriptManager runat="server" ID="RadScriptManager1" />--%>
<telerik:radskinmanager id="QsfSkinManager" runat="server" showchooser="false" />
<%--<telerik:radscriptmanager runat="server" id="RadScriptManager1" />--%>
<telerik:radformdecorator id="QsfFromDecorator" runat="server" decoratedcontrols="All"
    enableroundedcorners="false" />
<table>
    <tr>
        <td align="center">
            <h1>
                Organization Chart</h1>
        </td>
    </tr>
    <tr>
        <td>
            <div class="qsf-demo-canvas">
                <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel1" LoadingPanelID="RadLoadingPanel1">
                    <telerik:RadOrgChart ID="RadOrgChart1" runat="server" EnableDrillDown="true"  loadondemand="NodesAndGroups" 
                        Skin="Forest" EnableDragAndDrop="True"  />
                </telerik:RadAjaxPanel>
            </div>
           <%-- <div class="qsf-demo-canvas">
                <telerik:radajaxpanel runat="server" id="RadAjaxPanel">
                    <telerik:radorgchart id="RadOrgChart1" runat="server" skin="Forest" loadondemand="NodesAndGroups" />
                </telerik:radajaxpanel>
            </div>--%>
        </td>
    </tr>
</table>
