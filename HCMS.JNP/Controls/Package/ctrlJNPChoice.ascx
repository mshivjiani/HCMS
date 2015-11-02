<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlJNPChoice.ascx.cs"
    Inherits="HCMS.JNP.Controls.Package.ctrlJNPChoice" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="ToolTip" %>
<asp:ValidationSummary ID="jnpOptionsValidationSummary" runat="server" ValidationGroup="rblJNPOptions"
    CssClass="validationMessageBox" ShowSummary="true" DisplayMode="list" />
<table class="blueTable" width="100%">
    <%--<tr>
    <td class="leftImage">
        <asp:Label ID="jnpOptionsLabel" runat="server" Text="Please select from the following options <span class=required>*</span>"></asp:Label>
        <asp:RadioButtonList ID="rblJNPOptions" runat="server" width="100%"
            DataTextField="JNPOptionTypeName" DataValueField="JNPOptionTypeID" 
            ondatabinding="rblJNPOptions_DataBinding">
        </asp:RadioButtonList>
    </td>
    </tr>--%>
    <tr>
        <th class="blueGroupHeader">
            <asp:Literal ID="litFromExisting" runat="server" Text="Create From Existing "></asp:Literal>
        </th>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="leftImage">
            <asp:RadioButton ID="rbCreateUsingExisting" runat="server" GroupName="CreateJNPGroup"
                ValidationGroup="CreateJNPValGroup" Text="Create Job Announcement From Existing"
                Checked="true" />
            &nbsp;
            <ToolTip:ToolTip ID="ToolTip156" runat="server" ToolTipID="156" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <th class="blueGroupHeader">
            <asp:Literal ID="litCreateNew" runat="server" Text="Create New"></asp:Literal>
        </th>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="leftImage">
            <asp:RadioButton ID="rbCreateNewJANP" runat="server" GroupName="CreateJNPGroup" ValidationGroup="CreateJNPValGroup"
                Text="Create New Job Announcement" />
            &nbsp;
            <ToolTip:ToolTip ID="ToolTip155" runat="server" ToolTipID="155" />
        </td>
    </tr>
    <div runat="server" id="divCreateStandAloneDoc" visible="false">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <th class="blueGroupHeader">
                <asp:Literal ID="Literal1" runat="server" Text="Create Standard-Alone Job Announcement"></asp:Literal>
            </th>
        </tr>
        <tr>
            <td class="leftImage">
                <asp:RadioButton ID="rbCreateStandAloneDoc" runat="server" GroupName="CreateJNPGroup"
                    ValidationGroup="CreateJNPValGroup" Text="Create Stand-alone Document" />
                &nbsp;
                <ToolTip:ToolTip ID="ToolTip61" runat="server" ToolTipID="61" />
            </td>
        </tr>
    </div>
</table>
<%--<asp:RequiredFieldValidator ID="rblJNPOptionsReqVal" runat="server" ValidationGroup="jnpOptions"
    ControlToValidate="rblJNPOptions" InitialValue="" ErrorMessage="Please select an option"
    Display="None"></asp:RequiredFieldValidator>--%>
<br />
<span class="spanAction">
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
        ValidationGroup="jnpOptions" />
</span>