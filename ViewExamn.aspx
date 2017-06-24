<%@ Page MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="ViewExamn.aspx.cs" Inherits="ViewExamn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">
    <!-- общие -->
    <asp:Panel ID="panAttrs" runat="server">
        <fieldset class="fld-view">
            <legend><asp:Literal ID="lblName" runat="server" /></legend>
            <asp:HyperLink ID="lnkDocx" runat="server" NavigateUrl="#" CssClass="fld-view-word">Скачать в формате Word</asp:HyperLink>

            <table border="0" cellspacing="0" cellpadding="5">
                <tr>
                    <td><span>Наименование<br />объекта строительства</span></td>
                    <td><asp:TextBox ID="txtName" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><span>Текст замечаний</span></td>
                    <td><asp:TextBox ID="txtComment" runat="server" Enabled="false" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>

    <p>Статус: <asp:Literal ID="lblStatus" runat="server" /></p>

    <!-- главный -->
    <asp:Panel ID="panActMain" runat="server" Visible="false">
        <asp:Button ID="btnSign" runat="server" Text="Подписать" onclick="btnSign_Click"  />
        <asp:Button ID="btnCancel" runat="server" Text="Отклонить" onclick="btnCancel_Click"  />
    </asp:Panel>

    <!-- экспертиза -->
    <asp:Panel ID="panActExp" runat="server" Visible="false">
        <asp:Button ID="btnSendToMain" runat="server" Text="Отправить" onclick="btnSendToMain_Click" /> на подпись.
    </asp:Panel>

</asp:Content>