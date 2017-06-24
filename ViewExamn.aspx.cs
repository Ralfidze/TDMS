using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewExamn : ViewBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        var data = LoadContentAndGetIDs(lblName, lblStatus, panAttrs);

        switch (data.UserRoleID)
        {
            case TRole.MAIN:
                panActMain.Visible = true;
                switch (data.DocStatusID)
                {
                    case TDocumentStatus.NEW:
                    case TDocumentStatus.SIGNED:
                        btnCancel.Enabled = false;
                        btnSign.Enabled = false;
                        break;
                }
                break;

            case TRole.EXAMINATOR:
                panActExp.Visible = true;
                switch (data.DocStatusID)
                {
                    case TDocumentStatus.NEW:
                    case TDocumentStatus.CREATED:
                    case TDocumentStatus.CANCELED:
                        txtComment.Enabled = true;
                        txtName.Enabled = true;
                        break;

                    case TDocumentStatus.SIGNED:
                        btnSendToMain.Enabled = false;
                        break;
                }
                break;
        }

        lnkDocx.NavigateUrl = "~/Docx.aspx?ID=" + data.DocID;
    }

    #region главный инженер

    protected void btnSign_Click(object sender, EventArgs e)
    {
        using (var db = new TDMSDataContext())
        {
            var docs = from d in db.TDocuments
                       where d.TypeID == TDocumentType.TECH_REF || d.TypeID == TDocumentType.PROJ_BUDGET || d.TypeID == TDocumentType.PROJ_DOC
                       select d;

            foreach (var d in docs)
            {
                d.StatusID = TDocumentStatus.FINISHED;
            }

            db.SubmitChanges();
        }

        ChangeStatusAndRedirect(TDocumentStatus.SIGNED);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ChangeStatusAndRedirect(TDocumentStatus.CANCELED);
    }

    #endregion

    #region экспертиза

    protected void btnSendToMain_Click(object sender, EventArgs e)
    {
        FillSaveDocument(panAttrs);
    }

    #endregion
}