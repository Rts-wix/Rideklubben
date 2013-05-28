using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class images_hesteBillede : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            
            Response.ContentType = "image/png";

            byte[] imgBuffer = null;
            using (var ctx = new RideklubbenContext())
            {
                Hest hesten = ctx.Heste.Single(h => h.HesteId == id);
                String size = Request.QueryString["size"];
                if (size == "large")
                {
                    imgBuffer = hesten.Billede.large;
                }
                else if (size == "small")
                {
                    imgBuffer = hesten.Billede.small;
                }
                else if (size == "tiny")
                {
                    imgBuffer = hesten.Billede.tiny;
                }
            }

            //stream it back in the HTTP response
            Response.BinaryWrite(imgBuffer);
            Response.Flush();
            Response.Close();
        }
    }
}