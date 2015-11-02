<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlSearchTaskStatement.ascx.cs" Inherits="HCMS.JNP.Controls.Search.ctrlSearchTaskStatement" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>--%>


<asp:Panel ID="pnlTSSearch" runat="server" CssClass="controlContentPanel" DefaultButton ="btnSearch">
    <span class="controlPartsWrapper">
        <span class="controlTSLeftPart">
            <asp:CheckBox ID="chkAllGrades" CssClass="align-top" AutoPostBack="true" OnCheckedChanged="chkAllGrades_OnCheckedChanged" 
                runat="server" Text="Search in all Grades" />&nbsp;
            <asp:ImageButton ID="imgsrchBttn" AlternateText="Show/hide keyword search" runat="server"
                SkinID="searchButton" OnClick="imgsrchBttn_Click" ToolTip ="Show/hide keyword search" />
        </span>&nbsp;
        <span id="spanright" runat="server" visible="false">
            <asp:TextBox ID="txtTSKeyword" CssClass="keywordSearch" runat="server" Width="180px"></asp:TextBox>&nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click"  />&nbsp; 
            <asp:Button ID="btnClear" runat ="server" Text="Clear" onclick="btnClear_Click" />&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text ="Cancel" onclick="btnCancel_Click" />
        </span>
    </span>    

</asp:Panel>

