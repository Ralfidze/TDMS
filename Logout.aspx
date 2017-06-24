<%@ Page Title="Выход" MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="Logout.aspx.cs" Inherits="Logout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">
    <script>
        function endsWith(str, suffix) {
            return str.indexOf(suffix, str.length - suffix.length) !== -1
        }
        if (!endsWith(window.parent.location.toString(), 'Logout.aspx')) {
            window.parent.location = 'Logout.aspx'
        }
    </script>
    <div>
        <h1>Вы выполнили выход</h1>

        <p><a href="Login.aspx">Войдите снова</a></p>
    </div>
</asp:Content>
