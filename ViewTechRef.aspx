<%@ Page MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="ViewTechRef.aspx.cs" Inherits="ViewTechRef" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">
    <!-- общие -->
    <asp:Panel ID="panAttrs" runat="server">
        <fieldset class="fld-view">
            <legend><asp:Literal ID="lblName" runat="server" /></legend>
            <asp:HyperLink ID="lnkDocx" runat="server" NavigateUrl="#" CssClass="fld-view-word">Скачать в формате Word</asp:HyperLink>
            
            <table border="0" cellspacing="0" cellpadding="5">
                <tr>
                    <td><span>Наименование объекта строительства</span></td>
                    <td><asp:TextBox ID="txtName" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><span>Вид строительства</span></td>
                    <td><asp:TextBox ID="txtKind" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><span>Срок начала строительства</span></td>
                    <td><asp:TextBox ID="txtDateBegin" runat="server" Enabled="false" CssClass="num"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><span>Срок окончания строительства</span></td>
                    <td><asp:TextBox ID="txtDateEnd" runat="server" Enabled="false" CssClass="num"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><span>Экологические условия строительства</span></td>
                    <td><asp:TextBox ID="txtEcology" runat="server" Enabled="false" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><span>Требования к подрядчику</span></td>
                    <td><asp:TextBox ID="txtBuilderCond" runat="server" Enabled="false" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><span>Условия ввода в эксплуатацию</span></td>
                    <td><asp:TextBox ID="txtUseCond" runat="server" Enabled="false" TextMode="MultiLine"></asp:TextBox></td>
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

    <!-- курирующие отделы -->
    <asp:Panel ID="panActSupervisor" runat="server" Visible="false">
        <asp:Button ID="btnSendToMain" runat="server" Text="Отправить" onclick="btnSendToMain_Click" /> на согласование и подпись.
    </asp:Panel>
        
    <!-- подрядчик -->
    <asp:Panel ID="panActBuilder" runat="server" Visible="false">
        <asp:Button ID="btnAgree" runat="server" Text="Согласовать" onclick="btnAgree_Click" />
        <asp:Button ID="btnDisagree" runat="server" Text="Отклонить" onclick="btnDisagree_Click" />
    </asp:Panel>

    <!-- проектно-сметное бюро -->
    <asp:Panel ID="panActProjDoc" runat="server" Visible="false">
        <!-- если согласовано всеми то -->
        <asp:Button ID="btnCreate" runat="server" Text="Сформировать ПСД" onclick="btnCreate_Click" />
    </asp:Panel>

</asp:Content>