<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">
    <h1>Поиск документов</h1>

    <div class="pan-login">
        <table border="0" cellspacing="0" cellpadding="5">
            <tr>
                <td>
                    <span>Текст документа</span>
                    <asp:TextBox ID="txtData" runat="server"></asp:TextBox>
                </td>
                <td>
                    <span>Создатель</span>
                    <asp:DropDownList ID="ddlCreator" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Создан начиная с</span>
                    <asp:TextBox ID="txtDateFrom" runat="server"></asp:TextBox>
                </td>
                <td>
                    <span>по</span>
                    <asp:TextBox ID="txtDateTo" runat="server"></asp:TextBox>
                    <asp:Button ID="btnFind" runat="server" Text="Найти" onclick="btnFind_Click" />
                </td>
            </tr>
        </table>
    </div>

    <asp:Table ID="tblList" runat="server" CssClass="tbl tbl-list" Visible="false">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell Width="1%">#</asp:TableHeaderCell>
            <asp:TableHeaderCell>Название<br /><i>Создатель</i></asp:TableHeaderCell>
            <asp:TableHeaderCell>Дата<br />создания</asp:TableHeaderCell>
            <asp:TableHeaderCell>Тип</asp:TableHeaderCell>
            <asp:TableHeaderCell>Статус</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>

    <asp:Literal ID="lblEmpty" runat="server" Visible="false"><p>Нет документов</p></asp:Literal>

</asp:Content>

