using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reloader : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // заполняем невидимые поля адресами если в GET запросе есть ID 

        if (!string.IsNullOrEmpty(Request["Top"]))
        {
            hdnTop.Value = "DocList.aspx?Type=" + int.Parse(Request["Top"]);
        }
        
        if (!string.IsNullOrEmpty(Request["Bottom"]))
        {
            using (var db = new TDMSDataContext())
            {
                var view = (from d in db.TDocuments
                            where d.ID == int.Parse(Request["Bottom"])
                            select d.TDocumentType.View).Single();

                hdnTop.Value += "#noPrepare";
                hdnBottom.Value = view + ".aspx?ID=" + int.Parse(Request["Bottom"]);
            }
        }
    }
}