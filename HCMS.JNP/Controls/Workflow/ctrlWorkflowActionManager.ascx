<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlWorkflowActionManager.ascx.cs" Inherits="HCMS.JNP.Controls.Workflow.ctrlWorkflowActionManager" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Label ID="lblmsg" runat ="server" style="font-weight:bold"></asp:Label>

<telerik:RadComboBox ID="radComboActions" runat ="server" 
    Text="Select Action" 
    ToolTip="Select Action" 
    width="400px"
    DataTextField ="ActionTypeName" 
    DataValueField="ActionTypeID">
</telerik:RadComboBox>&nbsp;

<asp:Button ID="btnSubmit" runat ="server" 
    Text ="Go" 
    ToolTip ="Go" 
    onclick="btnSubmit_Click" 
    ValidationGroup="StaffingObjectValidator"
    OnClientClick="SetValidationGroup('StaffingObjectValidator');" />

<asp:CustomValidator ID="customValidator" runat ="server" 
    Display ="None" 
    OnServerValidate ="customValidator_ServerValidate">
</asp:CustomValidator>

<style type="text/css">
    .confirmBeforeRevise 
    {
        display: block;
        background-color: White;
        text-align: left;
        width: 450px;
        height: 225px;
        padding: 10px 10px 10px 10px;
    }
</style>

<telerik:RadWindowManager ID="rwManager" runat="server" EnableViewState="false"></telerik:RadWindowManager>

<telerik:RadWindow ID="rwConfirmBeforeRevise" runat="server" 
                   VisibleTitlebar="true"
                   Title="Confirm Job Questionnaire is in finalized format"  
                   VisibleStatusbar="false"
                   Behaviors="Close"  
                   Skin="WebBlue"  
                   Modal="true" 
                   Width="490" 
                   Height="285"  
                   Left="100" 
                   Top="100">
    <ContentTemplate>
        <div runat="server" class="confirmBeforeRevise" id="divConfirmBeforeRevise">
            Before submitting this package to the manager, please confirm that you have taken the following actions so 
            that the Job Questionnaire is in a finalized format for the Manager to  review.<br />
            <br />
            <ul>
            <li>Reviewed the Questionnaire Instructions</li>
            <li>Reviewed the Questionnaire response type and response instructions</li>
            <li>Previewed the Questionnaire in a UTF-8 (USA Staffing) format</li>
            </ul>
            <br />
            Click OK to send the package to Revise, click Cancel to continue editing the package in HR Review.<br />
            <div style="text-align:center;">
                <asp:Button ID="btnConfirmReviseReady_OK" OnClick="btnConfirmReviseReady_OK_Click" runat="server" Text="OK" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnConfirmReviseReady_Cancel" OnClick="btnConfirmReviseReady_Cancel_Click" runat="server" Text="Cancel" />
            </div>
        </div>
    </ContentTemplate>
</telerik:RadWindow> 


