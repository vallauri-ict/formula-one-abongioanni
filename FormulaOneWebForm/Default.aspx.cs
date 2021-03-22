using System;
using System.Collections;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormulaOneDll;
namespace FormulaOneWebForm {
    public partial class Default : System.Web.UI.Page {
        Tools dbTools;

        protected void Page_Load(object sender, EventArgs e) {
            dbTools = new Tools(Paths.CONNECTION_STRING);
            if (!Page.IsPostBack) {
                string[] elem = dbTools.ShowTables();
                Array.Sort(elem);
                cmb.DataSource = elem;
            }
            cmb.DataBind();
            content.DataBound += Content_DataBound;
            CmbCountries_SelectedIndexChanged(cmb, new EventArgs());
        }

        private void Content_DataBound(object sender, EventArgs e) {
            if (cmb.SelectedValue == "Team") {
                foreach (GridViewRow row in content.Rows) {
                    string color = row.Cells[row.Cells.Count - 1].Text;
                    row.Cells[row.Cells.Count - 1].Text = "";
                    row.Cells[row.Cells.Count - 1].BackColor = ColorTranslator.FromHtml(color);
                }
            }
            noResults.InnerText = cmb.SelectedValue + "'s table is empty!";
            noResults.Visible = content.Rows.Count == 0;
        }

        protected void CmbCountries_SelectedIndexChanged(object sender, EventArgs e) {
            content.DataSource = dbTools.GetTable(((DropDownList)sender).SelectedValue);
            content.DataBind();
        }
    }
}