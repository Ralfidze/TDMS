<%@ Page MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="ViewPlan.aspx.cs" Inherits="ViewPlan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">
    <!-- общие -->
    <asp:Panel ID="panAttrs" runat="server">
        <fieldset class="fld-view">
            <legend><asp:Literal ID="lblName" runat="server" /></legend>
            <asp:HyperLink ID="lnkDocx" runat="server" NavigateUrl="#" CssClass="fld-view-word">Скачать в формате Word</asp:HyperLink>
            
            <table border="0" cellspacing="0" cellpadding="5">
                <tr>
                    <td><span>Название проекта</span></td>
                    <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><span>Место расположения<br />объекта строительства</span></td>
                    <td><asp:TextBox ID="txtPlace" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><span>Год</span></td>
                    <td><asp:TextBox ID="txtYear" runat="server" CssClass="num"></asp:TextBox></td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>

    <p>Статус: <asp:Literal ID="lblStatus" runat="server" /></p>

    <!-- главный -->
    <asp:Panel ID="panActMain" runat="server" Visible="false">
        <asp:Button ID="btnSign" runat="server" Text="Подписать" onclick="btnSign_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Отклонить" onclick="btnCancel_Click" />
    </asp:Panel>

    <!-- отдел планирования ПИР -->
    <asp:Panel ID="panActProjPlan" runat="server" Visible="false">
        <asp:Button ID="btnSendToMain" runat="server" Text="Отправить" onclick="btnSendToMain_Click" /> на согласование и подпись.
    </asp:Panel>

    <!-- курирующие отделы -->
    <asp:Panel ID="panActSupervisor" runat="server" Visible="false">
        <asp:Button ID="btnAgree" runat="server" Text="Согласовать" onclick="btnAgree_Click" />
        <asp:Button ID="btnDisagree" runat="server" Text="Отклонить" onclick="btnDisagree_Click" />
        <!-- если согласовано всеми то -->
        <asp:Button ID="btnCreateTechRef" runat="server" Text="Сформировать ТЗ" onclick="btnCreateTechRef_Click" />
    </asp:Panel>

</asp:Content>