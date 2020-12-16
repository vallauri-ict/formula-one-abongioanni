using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormulaOneWebForm {
    public partial class Default : System.Web.UI.Page {
        public const string WORKINGPATH = @"C:\data\FormulaOne\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + "FormulaOne.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e) {
            Tools dbTools = new Tools();
            if (!Page.IsPostBack) {
                cmbCountries.DataSource = dbTools.GetCountries();
                cmbCountries.DataBind();
            }
        }
    }
}