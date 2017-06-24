using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewPlan : ViewBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        var data = LoadContentAndGetIDs(lblName, lblStatus, panAttrs);

        switch (data.UserRoleID)
        {
            #region главный инженер

            case TRole.MAIN:
                panActMain.Visible = true;
                txtName.Enabled = false;
                txtPlace.Enabled = false;
                txtYear.Enabled = false;
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

            #endregion

            #region группа планирования пир

            case TRole.PROJECT_PLAN:
                panActProjPlan.Visible = true;
                switch (data.DocStatusID)
                {
                    case TDocumentStatus.AGREED:
                    case TDocumentStatus.SIGNED:
                        txtName.Enabled = false;
                        txtPlace.Enabled = false;
                        txtYear.Enabled = false;
                        btnSendToMain.Enabled = false;
                        break;
                }
                break;

            #endregion

            #region курирующие отделы

            case TRole.SUPERVISOR:
                panActSupervisor.Visible = true;
                txtName.Enabled = false;
                txtPlace.Enabled = false;
                txtYear.Enabled = false;
                btnCreateTechRef.Visible = false;
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
                        btnCreateTechRef.Visible = true;
                        break;
                }
                break;

            #endregion

            #region остальные

            default:
                txtName.Enabled = false;
                txtPlace.Enabled = false;
                txtYear.Enabled = false;
                break;

            #endregion
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

    #region планирование пир

    protected void btnSendToMain_Click(object sender, EventArgs e)
    {
        FillSaveDocument(panAttrs);
    }

    #endregion

    #region курирующие отделы

    protected void btnAgree_Click(object sender, EventArgs e)
    {
        ChangeStatusAndRedirect(TDocumentStatus.AGREED);
    }

    protected void btnDisagree_Click(object sender, EventArgs e)
    {
        ChangeStatusAndRedirect(TDocumentStatus.CANCELED);
    }

    protected void btnCreateTechRef_Click(object sender, EventArgs e)
    {
        CreateAndSaveDocument("Заявка на формирование ТЗ", TDocumentType.TECH_REF);
    }

    #endregion
}