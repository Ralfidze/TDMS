<%@ Page MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="Sidebar.aspx.cs" Inherits="Sidebar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">
    <h1>Technical Data Managment System</h1>
    <div class="pan-login">
        <a href="Logout.aspx">Выйти</a>
        <asp:Literal ID="lblName" runat="server"></asp:Literal><br />
        <i><asp:Literal ID="lblRole" runat="server"></asp:Literal></i>
    </div>

    <div class="ls-menu">
        <ul>
            <li><a href="DocList.aspx?Type=0" target="list">Все документы</a></li>
            <li><a href="Search.aspx" target="list">Поиск документов</a></li>
            <li><a href="DocList.aspx?Type=1" target="list">План ПИР</a></li>
            <li><span>Проект</span>
                <ul>
                    <!-- <li><a href="DocList.aspx?Type=2" target="list">Договоры</a></li> -->
                    <li><a href="DocList.aspx?Type=3" target="list">Техническое задание</a></li>
                    <li><span>ПСД</span>
                        <ul>
                            <li><a href="DocList.aspx?Type=4" target="list">Описание</a></li>
                            <li><a href="DocList.aspx?Type=5" target="list">Смета</a></li>
                            <li><a href="DocList.aspx?Type=6" target="list">Доп. документация</a></li>
                        </ul>
                    </li>
                    <li><a href="DocList.aspx?Type=7" target="list">Экспертиза</a></li>
                </ul>
            </li>
        </ul>
    </div>
</asp:Content>