using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DocList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region проверка авторизации.
        if (Session["ID"] == null)
        {
            Response.Redirect("~/Logout.aspx");
            Response.End();
            return;
        }
        #endregion

        if (IsPostBack)
            return;

        using (var db = new TDMSDataContext())
        {
            int type = 0;

            if (string.IsNullOrEmpty(Request["Type"]))
            {
                // если тип не указан то берем из базы по умолчанию для роли пользователя

                type = (from u in db.TUsers
                        where u.ID == (int)Session["ID"]
                        select u.TRole.DefaultDocumentType).Single();
            }
            else
            {
                type = int.Parse(Request["Type"]);
            }

            // заголовок списка документов

            lblTitle.Text = (from t in db.TDocumentTypes
                             where t.ID == type
                             select t.Label).Single();

            // документы показываемые в списке

            var docs = from d in db.TDocuments
                       where (d.TypeID == type || type == 0)
                       orderby d.TypeID, d.Created descending
                       select d;

            foreach (var d in docs)
            {
                TableRow tr = new TableRow();

                tr.Cells.Add(new TableCell { Text = d.ID.ToString() });
                tr.Cells.Add(new TableCell 
                { 
                    Text = string.Format(
                        "<a href=\"{0}.aspx?ID={1}\" target=\"view\">{2}</a><br /><i>{3}</i>",
                        HttpUtility.HtmlEncode(d.TDocumentType.View),
                        d.ID, 
                        HttpUtility.HtmlEncode(d.Label), 
                        HttpUtility.HtmlEncode(d.TUser.Name))
                });
                tr.Cells.Add(new TableCell { Text = d.Created.ToString() });
                tr.Cells.Add(new TableCell { Text = d.TDocumentType.Label });
                tr.Cells.Add(new TableCell { Text = d.TDocumentStatus.Label });

                tblList.Rows.Add(tr);
            }

            // если документы есть то убираем надпись что их нет и показываем таблицу

            if (tblList.Rows.Count > 1)
            {
                tblList.Visible = true;
                lblEmpty.Visible = false;
            }
        }

        
    }
}