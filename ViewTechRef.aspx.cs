using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewTechRef : ViewBase
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
                    case TDocumentStatus.CREATED:
                        btnSign.Enabled = false;
                        break;

                    case TDocumentStatus.SIGNED:
                    case TDocumentStatus.CANCELED:
                        btnSign.Enabled = false;
                        btnCancel.Enabled = false;
                        break;
                }    
                break;

            case TRole.SUPERVISOR:
                panActSupervisor.Visible = true;
                foreach (var control in panAttrs.Controls)
                    if (control is TextBox)
                        ((TextBox)control).Enabled = true;
                switch (data.DocStatusID)
                {
                    case TDocumentStatus.AGREED:
                    case TDocumentStatus.SIGNED:
                        foreach (var control in panAttrs.Controls)
                            if (control is TextBox)
                                ((TextBox)control).Enabled = false;
                        btnSendToMain.Enabled = false;
                        break;
                }
                break;

            case TRole.BUILDER:
                panActBuilder.Visible = true;
                switch (data.DocStatusID)
                {
                    case TDocumentStatus.NEW:
                    case TDocumentStatus.AGREED:
                    case TDocumentStatus.CANCELED:
                        btnAgree.Enabled = false;
                        btnDisagree.Enabled = false;
                        break;

                    case TDocumentStatus.SIGNED:
                        btnAgree.Visible = false;
                        btnDisagree.Visible = false;
                        break;
                }
                break;

            case TRole.PROJECT_DOC:
                if (data.DocStatusID == TDocumentStatus.SIGNED)
                    panActProjDoc.Visible = true;
                break;
        }

        lnkDocx.NavigateUrl = "~/Docx.aspx?ID=" + data.DocID;
    }

    #region главный инженер

    protected void btnSign_Click(object sender, EventArgs e)
    {
        ChangeStatusAndRedirect(TDocumentStatus.SIGNED);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ChangeStatusAndRedirect(TDocumentStatus.CANCELED);
    }

    #endregion

    #region курирующий отдел

    protected void btnSendToMain_Click(object sender, EventArgs e)
    {
        FillSaveDocument(panAttrs);
    }

    #endregion

    #region подрядчик

    protected void btnAgree_Click(object sender, EventArgs e)
    {
        ChangeStatusAndRedirect(TDocumentStatus.AGREED);
    }

    protected void btnDisagree_Click(object sender, EventArgs e)
    {
        ChangeStatusAndRedirect(TDocumentStatus.CANCELED);
    }

    #endregion

    #region проектно-сметное бюро

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        List<TDocument> docs = new List<TDocument>();

        docs.Add(new TDocument
        {
            CreatorID = (int)Session["ID"],
            Label = "Запрос на формирование описания ПСД",
            StatusID = TDocumentStatus.NEW,
            TypeID = TDocumentType.PROJ_DOC,
            ParentDocunentID = int.Parse(Request["ID"]),
            Created = DateTime.Now,
        });

        docs.Add(new TDocument
        {
            CreatorID = (int)Session["ID"],
            Label = "Запрос на формирование сметы",
            StatusID = TDocumentStatus.NEW,
            TypeID = TDocumentType.PROJ_BUDGET ,
            ParentDocunentID = int.Parse(Request["ID"]),
            Created = DateTime.Now,
        });

        CreateAndSaveDocuments(docs);
    }

    #endregion
}