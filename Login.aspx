<%@ Page Title="Вход" MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">
    <h1>Авторизируйтесь в системе</h1>
    
    <fieldset>
        <legend>Вход</legend>

        <asp:Literal ID="lblError" runat="server" Visible="false"><p style="color:red">Неверный логин и пароль</p></asp:Literal>

        <table border="0" cellspacing="0" cellpadding="5">
            <tr>
                <td>Логин</td>
                <td><asp:TextBox ID="txtLogin" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Пароль</td>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnLogin" runat="server" Text="Войти" onclick="btnLogin_Click" /></td>
            </tr>
        </table>            

    </fieldset>

    <pre style="color: silver;">
    main    Владимир Главинженер
    plan    Иван Планиренко
    supr    Руслан Кураторев
    expr    Ольга Экспертникова
    proj    Айдар Проектосметник
    budg    Петр Сметокреатив
    cust    Эльвира Подрядочница
    </pre>

</asp:Content>