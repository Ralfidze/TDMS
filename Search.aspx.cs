using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
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
            var users = from u in db.TUsers
                        orderby u.Name
                        select u;

            ddlCreator.Items.Clear();
            ddlCreator.Items.Add(new ListItem("Любой", "0"));
            foreach (var u in users)
                ddlCreator.Items.Add(new ListItem(u.Name, u.ID.ToString()));
        }

    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        if (!IsValid)
            return;

        using (var db = new TDMSDataContext())
        {
            DateTime date_from = DateTime.Today.AddYears(-10);
            if (!string.IsNullOrEmpty(txtDateFrom.Text))
                DateTime.TryParse(txtDateFrom.Text, out date_from);

            DateTime date_to = DateTime.Today.AddYears(10);
            if (!string.IsNullOrEmpty(txtDateTo.Text))
                DateTime.TryParse(txtDateTo.Text, out date_to);

            // ищем документы

            var docs = from d in db.TDocuments
                       where 
                            d.Created > date_from && d.Created < date_to && 
                           (d.CreatorID == int.Parse(ddlCreator.SelectedValue) || int.Parse(ddlCreator.SelectedValue) == 0)
                       orderby d.TypeID, d.Created descending
                       select d;

            // если нужно ищем по словам в документе 

            if (!string.IsNullOrEmpty(txtData.Text))
            {
                docs = from d in docs
                       where d.TAttributes.Any(a => a.Value.Contains(txtData.Text))
                       orderby d.TypeID, d.Created descending
                       select d;
            }

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