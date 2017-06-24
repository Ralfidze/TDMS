using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DocView : ViewBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        using (var db = new TDMSDataContext())
        {
            var user = (from u in db.TUsers
                        where u.ID == (int)Session["ID"]
                        select u).Single();

            switch (user.RoleID)
            {
                case TRole.MAIN:
                    panActMain.Visible = true;
                    break;
            
                case TRole.PROJECT_DOC:
                    panProjDoc.Visible = true;
                    break;

                case TRole.EXAMINATOR:
                    panExp.Visible = true;

                    var any = (from d in db.TDocuments
                                where (d.TypeID == TDocumentType.PROJ_ADDITIONAL
                                    || d.TypeID == TDocumentType.PROJ_BUDGET
                                    || d.TypeID == TDocumentType.PROJ_DOC
                                    ) && d.StatusID != TDocumentStatus.EXPERTED
                                select d).Any();
                    if (!any)
                    {
                        lblExpNotAll.Visible = false;
                        btnCreateExp.Visible = true;
                    }
                    break;
            }
        }
    }

    #region главный инженер

    /// <summary>
    /// создайте план
    /// </summary>
    protected void btnCreatePlan_Click(object sender, EventArgs e)
    {
        CreateAndSaveDocument("Заявка на формирование плана ПИР", TDocumentType.PLAN);
    }

    #endregion

    #region проектно-сметное бюро
    
    protected void btnCreateDoc_Click(object sender, EventArgs e)
    {
        CreateAndSaveDocument("Описание ПСД", TDocumentType.PROJ_DOC);
    }

    protected void btnCreateBudget_Click(object sender, EventArgs e)
    {
        CreateAndSaveDocument("Смета", TDocumentType.PROJ_BUDGET);
    }

    protected void btnCreateFile_Click(object sender, EventArgs e)
    {
        CreateAndSaveDocument("Дополнительная ПСД", TDocumentType.PROJ_ADDITIONAL);
    }

    #endregion

    #region экспертиза
    
    protected void btnCreateExp_Click(object sender, EventArgs e)
    {
        CreateAndSaveDocument("Экспертное заключение", TDocumentType.EXAMINATION);
    }

    #endregion
}