using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apresentacao.Pages
{
    public partial class pgLogoff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Pages/pgLogin.aspx");
        }
    }
}