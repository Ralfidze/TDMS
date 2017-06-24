<%@ Page MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="ViewEmpty.aspx.cs" Inherits="DocView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">

    <asp:Literal ID="lblEmpty" runat="server"><p>Выберите документ</p></asp:Literal>

    <!-- главный инженер -->
    <asp:Panel ID="panActMain" runat="server" Visible="false">
        или <asp:Button ID="btnCreatePlan" runat="server" Text="Создайте заявку" onclick="btnCreatePlan_Click" />  
        на план ПИР.
    </asp:Panel>
    
    <!-- проектно-сметное бюро -->
    <asp:Panel ID="panProjDoc" runat="server" Visible="false">
        или создайте <asp:Button ID="btnCreateDoc" runat="server" Text="описание" onclick="btnCreateDoc_Click" />
        <asp:Button ID="btnCreateBudget" runat="server" Text="смету" onclick="btnCreateBudget_Click" />
        <asp:Button ID="btnCreateFile" runat="server" Text="доп. документацию" onclick="btnCreateFile_Click" /> ПСД.
    </asp:Panel>

    <!-- экспертиза -->
    <asp:Panel ID="panExp" runat="server" Visible="false">
        или
        <asp:Literal ID="lblExpNotAll" runat="server">проведите экспертизу всех документов ПСД чтобы сформировать заключение.</asp:Literal>
        <asp:Button ID="btnCreateExp" runat="server" Text="Сформируйте заключение" Visible="false" onclick="btnCreateExp_Click" />
    </asp:Panel>

</asp:Content>