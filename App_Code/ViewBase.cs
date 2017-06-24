using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class ViewBase : System.Web.UI.Page
{
    protected override void OnPreLoad(EventArgs e)
    {
        base.OnPreLoad(e);

        // проверка авторизации

        if (Session["ID"] == null)
        {
            Response.Redirect("~/Logout.aspx");
            Response.End();
        }
    }

    /// <summary>
    /// заполнить страницу документа и вернуть ID пользователя и ID документа
    /// </summary>
    public UserAndDoc LoadContentAndGetIDs(ITextControl lblName, ITextControl lblStatus, Control panAttrs)
    {
        using (var db = new TDMSDataContext())
        {
            var doc = (from d in db.TDocuments
                       where d.ID == int.Parse(Request["ID"])
                       select d).Single();

            // заполняем заголовок, статус
            lblName.Text = HttpUtility.HtmlEncode(doc.Label) + " от " + doc.Created;
            lblStatus.Text = HttpUtility.HtmlEncode(doc.TDocumentStatus.Label);

            // и данные из таблицы TAttributes
            foreach (var attr in doc.TAttributes)
                ((ITextControl)panAttrs.FindControl(attr.Attribute)).Text = HttpUtility.HtmlEncode(attr.Value);

            // в зависимости от роли пользователя просматривающего эту страницу
            // и текущего статуса документа
            // показываем/скрываем или включаем кнопки и поля для ввода            
            var user = (from u in db.TUsers
                        where u.ID == (int)Session["ID"]
                        select u).Single();

            return new UserAndDoc 
            { 
                UserID = user.ID, 
                UserRoleID = user.RoleID,
                DocID = doc.ID,
                DocTypeID = doc.TypeID,
                DocStatusID = doc.StatusID,
            };
        }
    }

    /// <summary>
    /// изменить статус документа, сохранить это в базе
    /// </summary>
    public void ChangeStatusAndRedirect(int status)
    {
        if (!IsValid)
            return;

        using (var db = new TDMSDataContext())
        {
            // находим
            var doc = (from d in db.TDocuments
                       where d.ID == int.Parse(Request["ID"])
                       select d).Single();

            // ставим статус
            doc.StatusID = status;

            db.SubmitChanges();

            // перезагрузить страницы во фреймах
            Redirect();
        }
    }

    /// <summary>
    /// сохранить данные документа из формы в базу 
    /// </summary>
    public void FillSaveDocument(Control panAttrs)
    {
        if (!IsValid)
            return;

        using (var db = new TDMSDataContext())
        {
            // находим
            var doc = (from d in db.TDocuments
                       where d.ID == int.Parse(Request["ID"])
                       select d).Single();

            // сохраняем все введенные пользователем данные
            foreach (Control control in panAttrs.Controls)
            {
                if (control is ITextControl && control.ID != null && control.ID.StartsWith("txt"))
                {
                    // проверяем существует ли такой атрибут у этого документа
                    var attr = (from a in doc.TAttributes
                                where a.Attribute == control.ID
                                select a).SingleOrDefault();

                    // если не нашли то создаем и добавляем в базу
                    if (attr == null)
                    {
                        attr = new TAttribute();
                        attr.Attribute = control.ID;

                        doc.TAttributes.Add(attr);
                    }

                    // записываем новое значение
                    attr.Value = ((ITextControl)control).Text;
                }
            }

            // изменяем статус документа 
            doc.StatusID = TDocumentStatus.CREATED;

            db.SubmitChanges();
        }

        Redirect();
    }

    /// <summary>
    /// сохранить документ в базе
    /// </summary>
    public void CreateAndSaveDocument(string label, int type)
    {
        List<TDocument> docs = new List<TDocument>();

        TDocument doc = new TDocument
        {
            CreatorID = (int)Session["ID"],
            Label = label,
            StatusID = TDocumentStatus.NEW,
            TypeID = type,
            Created = DateTime.Now,
        };

        if (!string.IsNullOrEmpty(Request["ID"]))
            doc.ParentDocunentID = int.Parse(Request["ID"]);

        docs.Add(doc);
        CreateAndSaveDocuments(docs);
    }
    
    /// <summary>
    /// сохранить документы в базе
    /// </summary>
    public void CreateAndSaveDocuments(List<TDocument> docs)
    {
        if (!IsValid)
            return;

        using (var db = new TDMSDataContext())
        {
            db.TDocuments.InsertAllOnSubmit(docs);
            db.SubmitChanges();

            // перезагружаем страницы
            Response.Redirect("~/Reloader.aspx?Top=" + docs[0].TypeID + (docs.Count > 1 ? "" : "&Bottom=" + docs[0].ID));
            Response.End();
        }
    }

    /// <summary>
    /// перезагрузить страницу во фрейме
    /// </summary>
    public void Redirect()
    {
        Response.Redirect("~/Reloader.aspx");
        Response.End();
    }
}