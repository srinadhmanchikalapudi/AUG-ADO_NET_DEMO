﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CommandBuilderDemo.aspx.cs" Inherits="AUG_ADO_NET_DEMO.CommandBuilderDemo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="border:2px solid blue">
        <tr>
            <td>Student ID</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Load" OnClick="Button1_Click" />
            </td>
        </tr>

        <tr>
            <td>Name</td>
            <td colspan="2">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Stream</td>
            <td colspan="2">
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Total Marks</td>
            <td colspan="2">
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" /></td>
            <td><asp:Button ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" /></td>
            <td><asp:Button ID="Button4" runat="server" Text="Insert" OnClick="Button4_Click" /></td>
            <td><asp:Label ID="Label1" runat="server" ForeColor="Green" Text=""></asp:Label></td>
        </tr>
    </table>
    <asp:Label ID="Label2" runat="server" Text="" BorderStyle="Solid"></asp:Label>
    <asp:Label ID="Label3" runat="server" Text="" BorderStyle="Solid"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="" BorderStyle="Solid"></asp:Label>

    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
