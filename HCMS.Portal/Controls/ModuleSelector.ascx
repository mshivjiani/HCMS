<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModuleSelector.ascx.cs"
    Inherits="HCMS.Portal.Controls.ModuleSelector" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


 <!--Make sure that Workforce Planning and Administration tab are the last two tabs as they are displayed based on role-->
<telerik:RadTabStrip ID="RadTabStripModSel" runat="server" MultiPageID="RadMultipageModSel"
    SelectedIndex="0" Orientation="HorizontalTop" Skin="WebBlue">
    <Tabs>
   
        <telerik:RadTab Text="PD Express" Value="PDExpress" AccessKey="P" TabIndex="0"> </telerik:RadTab>
        <telerik:RadTab Text="Job Announcement Express" Value="JNP" AccessKey="J"></telerik:RadTab>
        <telerik:RadTab Text="Organization Chart" Value="oc" AccessKey="o"></telerik:RadTab>
        <telerik:RadTab Text="Workforce Planning" Value="wf" AccessKey="W"></telerik:RadTab>
        <telerik:RadTab Text="Administration" Value="Admin" AccessKey="A">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<!--UNIVERSAL BUTTON-->
<asp:Button ID="btnEnter" runat="server" CssClass="button float-center bt_launch"
    ToolTip="Enter" Text="Enter" OnClick="btnEnter_Click" />
<!--CONTENT PANES-->
<div class="introCont">
    <telerik:RadMultiPage ID="RadMultipageModSel" runat="server" SelectedIndex="0">
        <telerik:RadPageView ID="RadPageViewPDExpress" runat="server">
            <!--LEFT COLUMN-->
            <div class="left">
                <img src="App_Themes/HCMS_Default/Images/screenshot_PDExpress.png"></div>
            <!--RIGHT COLUMN-->
            <div class="right">
                <h1>
                    PD Express</h1>
                <p>
                    PD Express is an automated, web-based tool that managers can use to create and store
                    position descriptions and job analysis components (such as knowledge required by
                    the position and selective factors). The tool puts managers and supervisors in the
                    Driver's Seat for establishing critical positions and hiring the right people for
                    their organizations by providing them with an automated suite of relevant and reliable
                    reference materials that pre-populate PDs and job analysis components based on their
                    input. PD Express also has a workflow component to streamline the PD certification
                    and classification process, thereby dramatically improving the hiring process for
                    FWS.</p>
                <p>
                    For example, PD Express features a data repository which houses approved, existing
                    position descriptions and standard position descriptions for each organization and
                    allows managers to utilize those documents to generate PDs and job analysis components.</p>
                <p>
                    To access online training course modules on DOI Learn,
                    <asp:HyperLink ID="DOITrainingLink" runat="server" Text="click here " NavigateUrl="https://gm2.geolearning.com/geonext/doi/login.geo"
                        Target="_blank"></asp:HyperLink>
                    and search the catalog for 'PD Express'.</p>
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageViewJNP" runat="server">
            <div class="left">
                <img src="App_Themes/HCMS_Default/Images/screenshot_JNP.png"></div>
            <div class="right">
                <h1>
                    Job Announcement Express</h1>
                <p>
                    Job Announcement Express (JAX) is an automated, web-based tool that managers can
                    use to create and store job announcement components (such as Job Analyses, Job Questionnaires
                    and Category Ratings). The tool puts managers and supervisors in the Driver's Seat
                    for staffing critical positions and hiring the right people for their organizations
                    by providing them with an automated suite of relevant and reliable reference materials
                    that pre-populate job analysis, category rating and job questionnaire components
                    based on their input. JAX also has a workflow component to streamline the staffing
                    process, thereby dramatically improving the hiring process for FWS.
                    <br />
                    <br />
                    For example, JAX features a data repository which houses approved, existing job
                    analyses, job questionnaires and category ratings for each organization and allows
                    managers to utilize those documents to generate job announcement packages.
                </p>
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageViewOrgChart" runat="server">
            <div class="left">
                <img src="App_Themes/HCMS_Default/Images/screenshot_OrgExpress.png"></div>
            <div class="right">
                <h1>
                   Organization Chart Express
                </h1>
                <p>
                    Organization Chart Express (OCX) is an automated, web-based tool that was developed for the Service’s managers to automate and streamline the process of developing and maintaining Organization Charts.  This tool also enables managers to generate customized Excel reports of all encumbered and vacant positions in their Organization, Program and/or Region.<br />
                    <br />Standard easily accessible Organizational Charts and information help to provide accurate information about the current organization as well as enables managers to forecast future scenarios by creating workforce planning positions.
                </p>
            </div>
        </telerik:RadPageView>
		<telerik:RadPageView ID="RadPageViewWorkflow" runat="server">
            <div class="left">
                <img src="App_Themes/HCMS_Default/Images/screenshot_workforce.png"></div>
            <div class="right">
                <h1>
                    Workforce Planning Dashboards
                </h1>
                <p>
                    The Workforce Planning Dashboard provides managers with instant access to their workforce demographics, projected retirements, and workforce changes in their organization.</p>
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageViewAdmin" runat="server">
            <div class="left">
                <img src="App_Themes/HCMS_Default/Images/screenshot_HCMS.png"></div>
            <div class="right">
                <h1>
                    Human Capital Management System Administration</h1>
                <p>
                    The Human Capital Management System (HCMS) Administration module is a web-based
                    tool that enables FWS Regional and System Administrators to administer access to
                    both PD Express and the JAX system. This includes administration of user accounts
                    (assigning / modifying roles, etc.), activating and delegating ownership of documents,
                    and Organization Code administration.</p>
            </div>
        </telerik:RadPageView>

    </telerik:RadMultiPage>
</div>
