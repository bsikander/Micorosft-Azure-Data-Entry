using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConteoCiudadano.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            //FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

            //string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            //if (String.IsNullOrEmpty(continueUrl))
            //{
            //    continueUrl = "~/";
            //}
            //Response.Redirect(continueUrl);
        }

        protected void CreateUserButton_Click(object sender, EventArgs e)
        {
            ConteoCiudadanoDBDataContext db = new ConteoCiudadanoDBDataContext();
            Usuario _Usuario = new Usuario();
            _Usuario.email = Email.Text;
            _Usuario.Nick = UserName.Text;
            _Usuario.Password = Password.Text;
            db.Usuarios.InsertOnSubmit(_Usuario);
            db.SubmitChanges();

            Session["UserID"] = _Usuario.ID;
            Session["UserName"] = _Usuario.email;
            Response.Redirect("../default.aspx");
  
        }

    }
}
