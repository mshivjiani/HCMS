<%@ Page Title="Help" Language="C#" MasterPageFile="~/PDMaster.Master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="HCMS.PDExpress.Help" %>
<%@ Register Assembly="HCMS.WebFramework" Namespace="HCMS.WebFramework.CustomControls" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="PDMasterMainContent" runat="server">
    <table  class="helpLinkTable" >
    <tr><td><asp:Image id="img3"  runat="server" SkinID="pdfIcon" />&nbsp;<a href="~/Common/QuickReferenceCard.pdf" id="A3" runat ="server" target="_blank" title="Quick Reference Guide">Quick Reference Guide</a>
        </td></tr>
        <tr>
            <td>
            <asp:Image id="img4"  runat="server" SkinID="pdfIcon"  />&nbsp;<a href="~/Common/Hiring Manager Manual.pdf" id="hiringmangagerdoclink" runat ="server" target="_blank" title="Hiring Manager Manual">Hiring Manager Manual</a>
            </td>
        </tr>
        <tr>
      
            <td>
            <asp:Image id="img1" runat="server" SkinID="pdfIcon"  />&nbsp;<a href="~/Common/Human Resources Manual.pdf" id="A1" runat ="server" target="_blank" title="Human Resources Manual">Human Resources Manual</a>
            </td>
        </tr>
       
          <tr id="trAdminHelpLink" runat ="server" visible="false">
            <td>
            <asp:Image  id="img2" AlternateText ="pdficon" runat="server" SkinID="pdfIcon" />&nbsp;<a href="~/Common/Administrator Manual.pdf" id="A2" runat ="server" target="_blank" title="Administrator Manual.pdf">Administrator Manual</a>
            </td>
        </tr>
    </table>
    <p></p>
    <div style="font-weight:bold; ">To access online training course modules on DOI Learn, <asp:HyperLink ID="DOITrainingLink" runat="server" 
        Text="click here "
        NavigateUrl="https://gm2.geolearning.com/geonext/doi/login.geo" Target="_blank" ></asp:HyperLink> and search the catalog for 'PD Express'</div>

</asp:Content>