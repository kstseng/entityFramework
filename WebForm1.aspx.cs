using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace entityFramework
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //connection string
        private string PIS_Conn = ConfigurationManager.ConnectionStrings["PIS_Readonly"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            // initial
            PISLibrary.PISLibrary pis = new PISLibrary.PISLibrary();
            // open connection
            pis.SetConnectionString(PIS_Conn);
            pis.OpenConnection();

            //DataTable dt_result = pis.GetCategoryPIS("1-2JKKF3", "ENU");
            DataTable dt_result = pis.GetChildCategoriesPIS_V2("1-2JKKF3", "ACL", "ENU", 1);
            pis.CloseConnection();

            GridView1.DataSource = dt_result;
            GridView1.DataBind();

        }
    }
}