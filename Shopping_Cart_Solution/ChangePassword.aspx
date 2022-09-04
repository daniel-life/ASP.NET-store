<%@ Page Title="" Language="C#" MasterPageFile="~/Afterlogin.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="OldPassword" runat="server" PlaceHolder="Current Password" CssClass="inputtxt"></asp:TextBox>
    <asp:TextBox ID="NewPassword" runat="server" PlaceHolder="New Password" CssClass="inputtxt"></asp:TextBox> 
    <asp:TextBox ID="CfmPassword" runat="server" PlaceHolder="Confirm Password" CssClass="inputtxt"></asp:TextBox>
    <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
    <asp:Button ID="Submit" Class="btnsignin" runat="server" Text="Update" OnClick="Submit_Click" />
</asp:Content>

