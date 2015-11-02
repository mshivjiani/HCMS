<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="OrgChart.aspx.cs" Inherits="HCMS.Portal.Admin.OrgChart" %>

<%--<%@ Register Src="~/Controls/Admin/ctrlOrgChart.ascx" TagPrefix="hcms" TagName="OrgChart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
--%>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <script language="javascript" type="text/jscript">

        function GetDataFromWebService() {
                    alert('aaa');

                    $.ajax({
                        type: "POST",
                        url: 'OrgChart.aspx/GetOrgChartData',
                        data: {},
                        contentType: "application/json; charset=utf-8",
                        dataType: 'json',

                        success: function (data) {
                            var objdata = $.parseJSON(data.d);
                            // now iterate through this object's contents and load your gridview

                            alert(objdata);
                        }

                        
                    });


            //PageMethods.GetOrgChart(onSucceed, onError);
        }
        function onSucceed(result) {
            //alert('success');

            //        RadOrgChart1.DataFieldID = "PositionID";
            //        RadOrgChart1.DataFieldParentID = "ParentID";
            //        RadOrgChart1.DataTextField = "Name";


            //        RadOrgChart1.DataSource = dt;
            //        RadOrgChart1.DataBind();

        }
        function onError(result) {

            //alert(result);
        }

    </script>

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
                    <telerik:radajaxpanel runat="server" id="RadAjaxPanel1" loadingpanelid="RadLoadingPanel1">
                        <telerik:radorgchart id="RadOrgChart1" runat="server" enabledrilldown="true" loadondemand="NodesAndGroups"
                            skin="Forest" enabledraganddrop="True" />
                    </telerik:radajaxpanel>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
