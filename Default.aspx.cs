using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (var ctx = new RideklubbenContext())
        {
            // hent alle Heste fra context'en, og put dem i repeaterens datasource.
            // Databind(), så kører resten :-)
            RepeaterTopBar.DataSource = ctx.Heste;
            RepeaterTopBar.DataBind();
        }
    }

    /// <summary>
    /// Når man klikker på en hest i topbaren
    /// </summary>
    /// <param name="source">topbar repeateren</param>
    /// <param name="e">Alt muligt info om eventet.
    /// Bl.a. e.CommandArgument, hvor vi har ID'et på hesten brugeren trykkede på.</param>
    protected void RepeaterTopBar_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        // asert Heste
        // TODO hvad hvis ikke heste? Men Ryttere eller ejere...

        // den hest der er klikket på
        int hesteId = Convert.ToInt32(e.CommandArgument);
        using (var ctx = new RideklubbenContext())
        {
            // hent den hest der er klikket på
            Hest hesten = ctx.Heste.Single(heste => heste.HesteId == hesteId);

            // Udskriv info om hesten (der er kun en, så jeg gider ikke en repeater).
            CenterImageNavn.Text = hesten.Navn;
            // udregn alder i år
            CenterImageAlder.Text = Math.Floor(((DateTime.Now - hesten.FødeDato).TotalDays / 365)).ToString() + " år";
            CenterIamgeOprindelse.Text = hesten.Fødestald;
            CenterImageImg.ImageUrl = hesten.BilledeSti;

            // HER BLIR DET SMART!
            // vi binder alle hestens ryttere til repeateren i venstre side.
            RepeaterLeftColumn.DataSource = hesten.Ryttere;
            RepeaterLeftColumn.DataBind();

        }
    }
}