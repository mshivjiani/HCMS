<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Message.ascx.cs" Inherits="HCMS.Portal.Controls.Message.Message" %>

<style type="text/css">
.hiddenMessage
{
    display:none;
}
/* was background-color:#FBFF8B; */
.visibleMessage
{
    display:block; 
    margin:5px 0px; 
    padding:10px; 
    width:97%; 
    border:solid 1px black; 
    background-color:#FFF3A8;
    color:Red;
    font-size:larger;
    font-weight:bolder;        
}
</style>

<asp:UpdatePanel ID="updtpnlMessage" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
        <div id="divMessage" runat="server" class="hiddenMessage">
            <b><asp:Label ID="lblTitle" runat="server" style="color:Black;"/></b>
            <br />
            <asp:Label ID="lblMessage" runat="server" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
