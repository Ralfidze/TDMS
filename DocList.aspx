<%@ Page MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="DocList.aspx.cs" Inherits="DocList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">
        <script type="text/javascript">
            function endsWith(str, suffix) {
                return str.indexOf(suffix, str.length - suffix.length) !== -1
            }
            if (!endsWith(location.toString(), '#noPrepare')) {
                // если в адресе нет #noPrepare то открываем внизу страницу с просьбой выбрать документ
                window.parent.frames['view'].location = 'ViewEmpty.aspx'
                //window.parent.document.getElementsByTagName('frameset')[1].rows = '80%, 20%'
            }
        </script>

        <h1><asp:Literal ID="lblTitle" runat="server"></asp:Literal></h1>

        <asp:Table ID="tblList" runat="server" CssClass="tbl tbl-list" Visible="false">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell Width="1%">#</asp:TableHeaderCell>
                <asp:TableHeaderCell>Название<br /><i>Создатель</i></asp:TableHeaderCell>
                <asp:TableHeaderCell>Дата<br />создания</asp:TableHeaderCell>
                <asp:TableHeaderCell>Тип</asp:TableHeaderCell>
                <asp:TableHeaderCell>Статус</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>

        <asp:Literal ID="lblEmpty" runat="server"><p>Нет документов</p></asp:Literal>

</asp:Content>