<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="AUG_ADO_NET_DEMO.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" AllowPaging="true" PageSize="4" AutoGenerateColumns="false" DataKeyNames="studentId"
        runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" 
        OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

        <Columns>
            <asp:BoundField DataField="studentId" HeaderText="STUDENT ID" SortExpression="studentId" />
            <asp:BoundField DataField="studentName" HeaderText="STUDENT NAME" SortExpression="studentName" />

            <asp:TemplateField HeaderText="STREAM"  SortExpression="stream">
                <ItemTemplate><%# Eval("stream") %></ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="streamTB" runat="server" Text='<%# Bind("stream") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="MARKS"  SortExpression="marks">
                 <ItemTemplate><%# Eval("marks") %></ItemTemplate>
                 <EditItemTemplate>
                     <asp:TextBox ID="marksTB" runat="server" Text='<%# Bind("marks") %>'></asp:TextBox>
                 </EditItemTemplate>
             </asp:TemplateField>
            <asp:CommandField  HeaderText="ACTIONS" ShowDeleteButton="true" ShowEditButton="true" ShowSelectButton="true" ShowInsertButton="true"/>

        </Columns>

    </asp:GridView>
</asp:Content>
