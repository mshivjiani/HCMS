<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CLBundleActionsPopup.aspx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.CLBundleActionsPopup" %>

<%@ Register src="../CreatePD/CareerLadderErrors.ascx" tagname="CLBundleActions" tagprefix="UC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <UC:CLBundleActions ID="ctrlCLBundleErrors" runat="server" />
        </div>
    </form>
</body>
</html>
