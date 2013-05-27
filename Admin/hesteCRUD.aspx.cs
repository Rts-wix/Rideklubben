using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_hesteCRUD : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void RepeaterHeste_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "hentHest")
        {
            int hesteID = Convert.ToInt32(e.CommandArgument);
            Hest hesten;

            using (var ctx = new RideklubbenContext())
            {
                hesten = ctx.Heste.Single(h => h.HesteId == hesteID);

                TextBoxNavn.Text = hesten.Navn;
                TextBoxVægt.Text = hesten.Vægt.ToString();
                TextBoxHøjde.Text = hesten.Højde.ToString();
                ViewState["hesteID"] = hesteID;
            }

            PanelEdit.Visible = true;
            ButtonOpdater.Visible = true;
            ButtonOpret.Visible = false;
        }
        else if (e.CommandName == "sletHest")
        {
            int hesteID = Convert.ToInt32(e.CommandArgument);
            Hest hesten;

            using (var ctx = new RideklubbenContext())
            {
                // indlæs entiteten
                hesten = ctx.Heste.Single(h => h.HesteId == hesteID);
                // slet entiteten
                ctx.DeleteObject(hesten);
                // gem ændringerne
                ctx.SaveChanges();
            }
            RepeaterHeste.DataBind();
        }
    }

    protected void ButtonOpdater_Click(object sender, EventArgs e)
    {
        int hesteID = Convert.ToInt32(ViewState["hesteID"]);
        Hest hesten;
        using (var ctx = new RideklubbenContext())
        {
            // vi henter den entitet der skal redigeres
            hesten = ctx.Heste.Single(h => h.HesteId == hesteID);

            // nye værdier puttes ind i objektet
            hesten.Navn = TextBoxNavn.Text;
            hesten.Vægt = Convert.ToDouble( TextBoxVægt.Text );
            hesten.Højde = Convert.ToDouble( TextBoxHøjde.Text );
            
            // her er magien
            ctx.SaveChanges();
        }
        PanelEdit.Visible = false;
        ButtonOpdater.Visible = false;
        RepeaterHeste.DataBind();
    }

    protected void ButtonNy_Click(object sender, EventArgs e)
    {
        TextBoxNavn.Text = "";
        TextBoxVægt.Text = "";
        TextBoxHøjde.Text = "";

        PanelEdit.Visible = true;
        ButtonOpret.Visible = true;
        ButtonOpdater.Visible = false;
    }

    // ny hest
    protected void ButtonOpret_Click(object sender, EventArgs e)
    {
        // hesten oprettes, erklæres som variabel og instantieres med default constructor
        Hest hesten = new Hest();
        using (var ctx = new RideklubbenContext())
        {
            // værdier puttes ind i objektet
            hesten.Navn = TextBoxNavn.Text;
            hesten.Vægt = Convert.ToDouble(TextBoxVægt.Text);
            hesten.Højde = Convert.ToDouble(TextBoxHøjde.Text);

            // Åh suk. Jeg har lavet disse felter "not null" i databasen, så der skal være en værdi i.
            hesten.Forælder_HesteId = ctx.Heste.Single(f => f.Navn == "Stamfar").HesteId;
            hesten.Fødestald = "";
            hesten.FødeDato = DateTime.Now;
            hesten.BilledeSti = "";

            // her er magien
            ctx.Heste.AddObject(hesten);
            ctx.SaveChanges();
        }
        PanelEdit.Visible = false;
        ButtonOpret.Visible = false;
        RepeaterHeste.DataBind();
    }
}