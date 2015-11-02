<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="tester.aspx.cs" Inherits="HCMS.OrgChart.PubOrgChart.tester" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>Enter Organization Chart Log ID:</div><br />
    <div>
    <asp:TextBox ID="textboxChartLogID" runat="server" MaxLength="50" Width="95px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiredChartLogID" runat="server" ControlToValidate="textboxChartLogID" 
                ErrorMessage="The 'Chart Log ID' is a required field."  />
            <asp:CompareValidator ID="compareChartLogID" runat="server" ErrorMessage="The value is not a valid integer." 
                ControlToValidate="textboxChartLogID" Type="Integer" Operator="DataTypeCheck" />
    </div>
    <br />
    <div>
                <asp:Button id="buttonSubmit" runat="server" CssClass="button" Text="Set Value" />
    </div>
    </div>
    </form>
</body>
</html>
