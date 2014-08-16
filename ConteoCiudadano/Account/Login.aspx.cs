using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConteoCiudadano.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            ConteoCiudadanoDBDataContext db = new ConteoCiudadanoDBDataContext();
            db.ObjectTrackingEnabled = false;
            Usuario _Usuarios = (from u in db.Usuarios 
                                where u.email == txtUserName.Text  &&
                                u.Password == txtPassword.Text 
                                   select u 
                                   ).FirstOrDefault() ;
            if (_Usuarios != null )
            {
                Session["UserID"] = _Usuarios.ID;
                Session["UserName"] = _Usuarios.email;
                Response.Redirect("../default.aspx");
            }
            else
            {
                FailureText.Text = "Username and Password does not match";
            }
  
        }
    }
}
