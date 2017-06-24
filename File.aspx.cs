using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

public partial class File_ : System.Web.UI.Page
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

        string[] files = Directory.GetFiles(ConfigurationManager.AppSettings["TDMSDir"] + "\\Upload\\", int.Parse(Request["ID"]) + ".*");

        if (files.Length > 0)
        {
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=\"" + HttpUtility.UrlEncode(Path.GetFileName(files[0])) + "\";");

            Response.WriteFile(files[0]);
            Response.End();
        }
    }
}