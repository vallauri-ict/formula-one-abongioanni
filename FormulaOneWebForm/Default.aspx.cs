using System;
using System.Collections;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormulaOneDll;
namespace FormulaOneWebForm {
    public partial class Default : System.Web.UI.Page {
        Tools dbTools;
        HttpUtils http;

        protected void Page_Load(object sender, EventArgs e) {
            dbTools = new Tools(Paths.CONNECTION_STRING);
            http = new HttpUtils();
            if (!Page.IsPostBack) {
                content.DataSource = http.GetDriverCards();
                content.DataBind();
            }
            content.DataBound += Content_DataBound;
        }

        private void Content_DataBound(object sender, EventArgs e) {
        }
    }
}