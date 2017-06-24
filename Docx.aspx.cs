using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

public partial class Docx : System.Web.UI.Page
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

        if (string.IsNullOrEmpty(Request["ID"]))
            return;

        using (var db = new TDMSDataContext())
        {
            var doc = (from d in db.TDocuments
                       where d.ID == int.Parse(Request["ID"])
                       select d).Single();

            string template_file = ConfigurationManager.AppSettings["TDMSDir"] + "\\Templates\\";

            if (doc.TypeID == TDocumentType.TECH_REF || doc.TypeID == TDocumentType.PROJ_BUDGET || doc.TypeID == TDocumentType.PROJ_DOC)
            {
                if (doc.StatusID == TDocumentStatus.EXPERTED)
                {
                    template_file += doc.TypeID + "_examined.docx";
                }

                if (doc.StatusID == TDocumentStatus.FINISHED)
                {
                    template_file += doc.TypeID + "_finished.docx";
                }
            }
            else
            {
                template_file += doc.TypeID + ".docx";
            }

            var wordApp = new Word.Application();
            var wordDocument = wordApp.Documents.Open(template_file, Revert: true, ReadOnly: false);

            foreach (var attr in doc.TAttributes)
            {
                var range = wordDocument.Content;
                range.Find.ClearFormatting();
                range.Find.Execute(FindText: "{" + attr.Attribute + "}", ReplaceWith: attr.Value);
            }

            string generated_file = ConfigurationManager.AppSettings["TDMSDir"] + "\\Docs\\" + DateTime.Now.Ticks + ".doc";

            wordDocument.SaveAs(generated_file);
            wordDocument.Close();
            wordApp.Quit();

            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=\"" + HttpUtility.UrlEncode(Path.GetFileName(generated_file)) + "\";");

            Response.WriteFile(generated_file);
            Response.End();
        }
    }
}