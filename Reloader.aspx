<%@ Page MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="Reloader.aspx.cs" Inherits="Reloader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">
    <!-- адреса которые нужно загрузить наверх и вниз -->
    <asp:HiddenField ID="hdnTop" ClientIDMode="Static" runat="server" Value="" />
    <asp:HiddenField ID="hdnBottom" ClientIDMode="Static" runat="server" Value="" />

    <script>
        if (document.getElementById('hdnTop').value == '' && document.getElementById('hdnBottom').value == '') {
            // если адреса пустые то просто обновляем верх
            var url = window.parent.frames['list'].location.toString()
            if (url.indexOf('#noPrepare') > -1) url = url.replace('#noPrepare', '')
            window.parent.frames['list'].location = url
        } else {
            // если нет - то открываем оба адреса сверху и снизу
            window.parent.frames['list'].location = document.getElementById('hdnTop').value

            if (document.getElementById('hdnBottom').value != '')
                window.parent.frames['view'].location = document.getElementById('hdnBottom').value
        }
    </script>
</asp:Content>