<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="orgChartValidations.ascx.cs" Inherits="HCMS.OrgChart.Controls.OrgChart.Common.orgChartValidations" %>
<%@ Register TagPrefix="custom" TagName="NoteBox" Src="~/Controls/Common/noteBox.ascx" %>

<div style="display: block; padding-top: 10px;">
<custom:NoteBox id="customNoteRootNotAcknowledged" runat="server" LabelText="Validation Error: The Top Level Position information is incomplete. Please complete all required fields for the Top Level Position." NoteType="3" visible="false" />
<custom:NoteBox id="customNoteMissingRootNode" runat="server" LabelText="Validation Error: This organization chart is missing the Top Level Position. Please resolve this issue." NoteType="3" visible="false" />
<custom:NoteBox id="customNoteAbolishedPositions" runat="server" LabelText="Validation Error: This organization chart has at least one abolished position. Please resolve this issue." NoteType="3" visible="false" />
<custom:NoteBox id="customNoteBrokenHierarchy" runat="server" LabelText="Validation Error: This organization chart appears to have a broken hierarchy. Please resolve this issue." NoteType="3" visible="false" />
<custom:NoteBox id="customNoteNewFPPSPositions" runat="server" LabelText="Warning: There are new FPPS positions in your Organization. To view these positions, click the New FPPS Positions link on the top right corner of your screen." NoteType="2" visible="false" />
</div>