using System;
using System.Collections;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormulaOneDllProject;

namespace FormulaOneWebForm {
    public partial class Default : System.Web.UI.Page {
        public const string WORKINGPATH = @"C:\data\FormulaOne\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + "FormulaOne.mdf;Integrated Security=True;Connect Timeout=30";
        Tools dbTools;

        protected void Page_Load(object sender, EventArgs e) {
            dbTools = new Tools(CONNECTION_STRING);
            if (!Page.IsPostBack) {
                string[] elem = dbTools.ShowTables();
                Array.Sort(elem);
                cmb.DataSource = elem;
            }
            cmb.DataBind();
            cmbCountries_SelectedIndexChanged(cmb, new EventArgs());
            content.DataBound += Content_DataBound;
        }

        private void Content_DataBound(object sender, EventArgs e) {
            if (cmb.SelectedValue == "Team") {
                foreach (GridViewRow row in content.Rows) {
                    string color = row.Cells[row.Cells.Count - 1].Text;
                    row.Cells[row.Cells.Count - 1].Text = "";
                    row.Cells[row.Cells.Count - 1].BackColor = ColorTranslator.FromHtml(color);
                }
            }
        }

        protected void cmbCountries_SelectedIndexChanged(object sender, EventArgs e) {
            switch (((DropDownList)sender).SelectedValue) {
                case "Country": {
                        content.DataSource = dbTools.GetCountryTable();
                        break;
                    }
                case "Team": {
                        content.DataSource = dbTools.GetTeamTable();
                        break;
                    }
                case "Driver": {
                        content.DataSource = dbTools.GetDriverTable();
                        break;
                    }
                case "Circuit": {
                        content.DataSource = dbTools.GetCircuitTable();
                        break;
                    }
                case "Race": {
                        content.DataSource = dbTools.GetRaceTable();
                        break;
                    }
                case "Result": {
                        content.DataSource = dbTools.GetResultTable();
                        break;
                    }
                default:
                    break;

            }
            content.DataBind();
        }
    }
}