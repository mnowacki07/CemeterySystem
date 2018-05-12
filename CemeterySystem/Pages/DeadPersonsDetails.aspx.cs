using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CemeterySystem.Pages
{
    public partial class DeadPersonsDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }




        //button powrotu do listy ze szczegółów
        protected void lbtnGoBack_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/DeadPersonsList");
        }
    }
}