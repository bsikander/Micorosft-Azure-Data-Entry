using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConteoCiudadano
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
                {
                    plLogin.Visible = true;
                    plUsername.Visible = false;
                }
                else
                {
                    plLogin.Visible = false ;
                    plUsername.Visible = true ;
                    lblLoginName.Text = Convert.ToString(Session["UserName"]);  
                }
            }
        }
    }
}
