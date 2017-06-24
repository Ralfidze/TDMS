using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

public partial class ViewProjDoc : ViewBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        var data = LoadContentAndGetIDs(lblName, lblStatus, panAttrs);

        switch (data.DocTypeID)
        {
            case TDocumentType.PROJ_DOC:
                hdnProjDescr.Value = "1";
                break;

            case TDocumentType.PROJ_BUDGET:
                hdnProjBudget.Value = "1";
                break;

            case TDocumentType.PROJ_ADDITIONAL:
                hdnProjFile.Value = "1";
                lnkDocx.Visible = false;
                break;
        }

        switch (data.UserRoleID)
        {
            case TRole.PROJECT_DOC:
                panActProjDoc.Visible = true;
                uplFile.Visible = true;
                lnkFile.Visible = false;
                foreach (var control in panAttrs.Controls)
                    if (control is TextBox)
                        ((TextBox)control).Enabled = true;
                switch (data.DocStatusID)
                {
                    case TDocumentStatus.EXPERTED:
                        foreach (var control in panAttrs.Controls)
                            if (control is TextBox)
                                ((TextBox)control).Enabled = false;
                        btnCreate.Enabled = false;
                        uplFile.Visible = false;
                        lnkFile.Visible = true;
                        break;
                }
                break;
                
            case TRole.EXAMINATOR:
                panActBuilder.Visible = true;
                btnAgree.Enabled = false;
                btnDisagree.Enabled = false;
                switch (data.DocStatusID)
                {
                    case TDocumentStatus.CREATED:
                        btnAgree.Enabled = true;
                        btnDisagree.Enabled = true;
                        break;
                }
                break;
        }

        lnkDocx.NavigateUrl = "~/Docx.aspx?ID=" + data.DocID;
        lnkFile.NavigateUrl = "~/File.aspx?ID=" + data.DocID;
    }

    #region проектно-сметное бюро

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        // сохраняем файл на сервер
        if (uplFile.HasFile)
        {
            string name = uplFile.FileName;

            if (name.LastIndexOf('.') > -1)
                name = int.Parse(Request["ID"]) + name.Substring(name.LastIndexOf('.'));
            else
                name = int.Parse(Request["ID"]).ToString();

            name = ConfigurationManager.AppSettings["TDMSDir"] + "\\Upload\\" + name;

            if (File.Exists(name))
                File.Delete(name);

            uplFile.PostedFile.SaveAs(name);
        }

        FillSaveDocument(panAttrs);
    }

    #endregion

    #region экспертиза

    protected void btnAgree_Click(object sender, EventArgs e)
    {
        ChangeStatusAndRedirect(TDocumentStatus.EXPERTED);
    }

    protected void btnDisagree_Click(object sender, EventArgs e)
    {
        ChangeStatusAndRedirect(TDocumentStatus.CANCELED);
    }

    #endregion
}