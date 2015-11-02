<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserMaintenace.ascx.cs" Inherits="HCMS.Portal.Controls.Admin.UserMaintenance" %>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="UserID" DataSourceID="SqlDataSource1" 
    EmptyDataText="There are no data records to display.">
    <Columns>
        <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" 
            SortExpression="UserID" />
        <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
            SortExpression="FirstName" />
        <asp:BoundField DataField="LastName" HeaderText="LastName" 
            SortExpression="LastName" />
        <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" 
            SortExpression="MiddleName" />
        <asp:BoundField DataField="Suffix" HeaderText="Suffix" 
            SortExpression="Suffix" />
        <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" 
            SortExpression="EmailAddress" />
        <asp:BoundField DataField="SupervisorStatusID" HeaderText="SupervisoryStatus" 
            SortExpression="SupervisorStatusID" />
        <asp:BoundField DataField="FPPSPdID" HeaderText="FPPSPdID" 
            SortExpression="FPPSPdID" />
        <asp:BoundField DataField="EmployeeCommonID" HeaderText="EmployeeCommonID" 
            SortExpression="EmployeeCommonID" />
        <asp:BoundField DataField="CreatedByID" HeaderText="CreatedByID" 
            SortExpression="CreatedByID" />
        <asp:BoundField DataField="CreateDate" HeaderText="CreateDate" 
            SortExpression="CreateDate" />
        <asp:BoundField DataField="UpdatedByID" HeaderText="UpdatedByID" 
            SortExpression="UpdatedByID" />
        <asp:BoundField DataField="UpdateDate" HeaderText="UpdateDate" 
            SortExpression="UpdateDate" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:PDExpressConnectionString1 %>" 
    DeleteCommand="spr_DeleteUser" DeleteCommandType="StoredProcedure" 
    InsertCommand="spr_AddUser" InsertCommandType="StoredProcedure" 
    ProviderName="<%$ ConnectionStrings:PDExpressConnectionString1.ProviderName %>" 
    SelectCommand="SELECT [UserID], [FirstName], [LastName], [MiddleName], [Suffix], [EmailAddress], [SupervisorStatusID], [FPPSPdID], [EmployeeCommonID], [CreatedByID], [CreateDate], [UpdatedByID], [UpdateDate] FROM [tbl_User]" 
    UpdateCommand="spr_UpdateUser" UpdateCommandType="StoredProcedure">
    <DeleteParameters>
        <asp:Parameter Name="UserID" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Direction="InputOutput" Name="newUserID" Type="Int32" />
        <asp:Parameter Name="FirstName" Type="String" />
        <asp:Parameter Name="LastName" Type="String" />
        <asp:Parameter Name="MiddleName" Type="String" />
        <asp:Parameter Name="Suffix" Type="String" />
        <asp:Parameter Name="EmailAddress" Type="String" />
        <asp:Parameter Name="SupervisorStatusID" Type="Int32" />
        <asp:Parameter Name="FPPSPdID" Type="String" />
        <asp:Parameter Name="EmployeeCommonID" Type="Int32" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="UserID" Type="Int32" />
        <asp:Parameter Name="FirstName" Type="String" />
        <asp:Parameter Name="LastName" Type="String" />
        <asp:Parameter Name="MiddleName" Type="String" />
        <asp:Parameter Name="Suffix" Type="String" />
        <asp:Parameter Name="EmailAddress" Type="String" />
        <asp:Parameter Name="SupervisoryStatus" Type="Int32" />
        <asp:Parameter Name="FPPSPdID" Type="String" />
        <asp:Parameter Name="EmployeeCommonID" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>
