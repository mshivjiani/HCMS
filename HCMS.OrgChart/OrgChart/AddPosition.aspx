<%@ Page Language="C#" MasterPageFile="~/OrgChartOther.Master"  AutoEventWireup="true" CodeBehind="AddPosition.aspx.cs" Inherits="HCMS.OrgChart.OrgChart.AddPosition" %>

<%@ Register src="../Controls/CreateOrgChart/ctrlAddWFPPosition.ascx" tagname="ctrlAddWFPPosition" tagprefix="uc1" %>
<%--
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/OrgChart_Default/main.css" rel="stylesheet" 
        type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    </div>
    
    <div id="controlcontainer" runat ="server" style="padding:10px;margin:10px;  " >
    <div id="divPgTitle" runat="server"  visible="true" class ="pageTitle">
                            <asp:Literal ID="literalPageTitle" runat="server" /></div>
    
    <uc1:ctrlAddWFPPosition ID="ctrlAddWFPPosition1" runat="server" />
    </div>
    </form>
</body>
</html>
--%>


<asp:content id="Content1" contentplaceholderid="headContent" runat="server">
 </asp:content>

<asp:content id="Content2" contentplaceholderid="mainContent" runat="server">
        <uc1:ctrlAddWFPPosition ID="ctrlAddWFPPosition1" runat="server" />
</asp:content>
