using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sidebar : System.Web.UI.Page
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
            var user = (from u in db.TUsers
                        where u.ID == (int)Session["ID"]
                        select u).Single();
            
            // название отдела
            lblRole.Text = HttpUtility.HtmlEncode(user.TRole.Label);

            // имя текущего пользователя
            lblName.Text = HttpUtility.HtmlEncode(user.Name);
        }
    }
}