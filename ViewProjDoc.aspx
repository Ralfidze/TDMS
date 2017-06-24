<%@ Page MasterPageFile="~/Site.master" Language="C#" AutoEventWireup="true" CodeFile="ViewProjDoc.aspx.cs" Inherits="ViewProjDoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">
    <!-- общие -->
    <asp:Panel ID="panAttrs" runat="server">
        <fieldset class="fld-view">
            <legend><asp:Literal ID="lblName" runat="server" /></legend>
            <asp:HyperLink ID="lnkDocx" runat="server" NavigateUrl="#" CssClass="fld-view-word">Скачать в формате Word</asp:HyperLink>
            
            <table border="0" cellspacing="0" cellpadding="5">
                <!-- описание ПСД -->
                <tbody id="tblProjDescr">
                    <tr>
                        <td><span>Описание</span></td>
                        <td><asp:TextBox ID="txtDescription" runat="server" Enabled="false" TextMode="MultiLine"></asp:TextBox></td>
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
                        <td><span>Место расположения объекта строительства</span></td>
                        <td><asp:TextBox ID="txtPlace" runat="server" Enabled="false" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><span>Экологические условия строительства</span></td>
                        <td><asp:TextBox ID="txtEcology" runat="server" Enabled="false" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                </tbody>
                <!-- смета -->
                <tbody id="tblProjBudget">
                    <tr>
                        <td><span>Общая стоимость строительства объекта</span></td>
                        <td><asp:TextBox ID="txtCost" runat="server" Enabled="false" CssClass="num"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><span>Стоимость работ</span></td>
                        <td><asp:TextBox ID="txtCostWork" runat="server" Enabled="false" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><span>Стоимость материалов</span></td>
                        <td><asp:TextBox ID="txtCostMats" runat="server" Enabled="false" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                </tbody>
                <!-- чертежи / записка / технические решения -->
                <tbody id="tblProjFile">
                    <tr>
                        <td><span>Наименование</span></td>
                        <td><asp:TextBox ID="txtName" runat="server" Enabled="false"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><span>Описание</span></td>
                        <td><asp:TextBox ID="txtKind" runat="server" Enabled="false"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><span>Файл</span></td>
                        <td>
                            <asp:FileUpload ID="uplFile" runat="server" Visible="false" />
                            <asp:HyperLink ID="lnkFile" runat="server" NavigateUrl="#">Скачать / Просмотреть</asp:HyperLink>
                        </td>
                    </tr>
                </tbody>
            </table>
        </fieldset>
    </asp:Panel>

    <p>Статус: <asp:Literal ID="lblStatus" runat="server" /></p>

    <!-- проектно-сметное бюро -->
    <asp:Panel ID="panActProjDoc" runat="server" Visible="false">
        <asp:Button ID="btnCreate" runat="server" Text="Отправить" onclick="btnCreate_Click" /> на экспертизу.
    </asp:Panel>

    <!-- экспертиза -->
    <asp:Panel ID="panActBuilder" runat="server" Visible="false">
        <asp:Button ID="btnAgree" runat="server" Text="Принять" onclick="btnAgree_Click" />
        <asp:Button ID="btnDisagree" runat="server" Text="Отклонить" onclick="btnDisagree_Click" />
    </asp:Panel>


    <asp:HiddenField ID="hdnProjDescr" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdnProjBudget" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdnProjFile" runat="server" ClientIDMode="Static" />
    <script>
        if (document.getElementById('hdnProjDescr').value != 1)
            document.getElementById('tblProjDescr').style.display = 'none'

        if (document.getElementById('hdnProjBudget').value != 1)
            document.getElementById('tblProjBudget').style.display = 'none'

        if (document.getElementById('hdnProjFile').value != 1)
            document.getElementById('tblProjFile').style.display = 'none'
    </script>

</asp:Content>