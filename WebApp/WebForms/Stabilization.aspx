<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Master.Master" AutoEventWireup="true" CodeBehind="Stabilization.aspx.cs" Inherits="WebApp.WebForms.Stabilization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h2>Stabilization -- WebForms</h2>
    <h5>Buttons and checkbox cause UpdatePanel updates.</h5>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset>
                <legend>Terms and Conditions</legend>
                <span ID="ConditionsType" runat="server" Text=""></span><br />
                <div ID="Conditions" runat="server"></div><br />
                <asp:Button ID="Previous" runat="server" OnClick="Previous_Click" Text="Previous" />
                <asp:Button ID="Next" runat="server" OnClick="Next_Click" Text="Next" /><br />
                <asp:Panel runat="server" ID="AcceptPanel" CssClass="top-shim">
                    <asp:CheckBox ID="AgreeCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="AgreeCheckBox_OnCheckedChanged" Text="I agree to it all"/><br />
                    <asp:Button ID="Accept" runat="server" OnClick="Accept_Click" Text="Accept" />
                </asp:Panel>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>