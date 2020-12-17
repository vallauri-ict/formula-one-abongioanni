using System;
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
                cmb.DataSource = dbTools.ShowTables();
                cmbCountries_SelectedIndexChanged(cmb, new EventArgs());
            }
            cmb.DataBind();
        }

        protected void cmbCountries_SelectedIndexChanged(object sender, EventArgs e) {
            switch (((DropDownList)sender).SelectedValue) {
                case "Country": {
                        content.DataSource = dbTools.GetCountry();
                        break;
                    }
                case "Team": {
                        content.DataSource = dbTools.GetTeam();
                        break;
                    }
                case "Driver": {
                        content.DataSource = dbTools.GetDriver();
                        break;
                    }
                case "Circuit": {
                        content.DataSource = dbTools.GetCircuit();
                        break;
                    }
                case "Race": {
                        content.DataSource = dbTools.GetRace();
                        break;
                    }
                case "Result": {
                        content.DataSource = dbTools.GetResult();
                        break;
                    }
                default:
                    break;

            }
            content.DataBind();
        }
    }
}