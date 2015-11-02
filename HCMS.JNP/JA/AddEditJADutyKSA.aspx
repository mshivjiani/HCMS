<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditJADutyKSA.aspx.cs" Inherits="HCMS.JNP.JA.AddEditDutyKSA" %>

<%@ Register src="~/Controls/JA/ctrlAddEditDutyKSA.ascx" tagname="ctrlAddEditDutyKSA" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body class="bodyWhite">
    <form id="form1" runat="server">
    <div>
      <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
        <uc1:ctrlAddEditDutyKSA ID="ctrlAddEditDutyKSA1" runat="server" />
    
    </div>
    </form>
</body>
</html>
