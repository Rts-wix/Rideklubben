﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// billeder
using System.Drawing;
using System.IO;

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
                try
                {
                    // slet billedet
                    File.Delete(Server.MapPath("~/" + hesten.BilledeSti));
                    // slet entiteten
                    ctx.DeleteObject(hesten);
                    // gem ændringerne
                    ctx.SaveChanges();
                }
                catch (System.IO.DirectoryNotFoundException de)
                {
                    // nada
                }
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

            GemHesteBillede(hesten);

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

            GemHesteBillede(hesten);

            // her er magien
            ctx.Heste.AddObject(hesten);
            ctx.SaveChanges();
        }
        PanelEdit.Visible = false;
        ButtonOpret.Visible = false;
        RepeaterHeste.DataBind();
    }

    private void GemHesteBillede(Hest hesten)
    {
        if (FileUploadBillede.HasFile)
        {
            String guid = Guid.NewGuid().ToString();
            String path = "images/heste/";
            String realPath = Server.MapPath("~/" + path);

            ImageNet.FluentImage img = ImageNet.FluentImage.FromStream(FileUploadBillede.FileContent);

            Rectangle crop;
            if (img.Current.Height > img.Current.Width)  // højformat
            {
                int width = img.Current.Width;
                int offset = (img.Current.Height - width) / 2;
                crop = new Rectangle(0, offset, width, width);
            }
            else                                         // tværformat
            {
                int height = img.Current.Height;
                int offset = (img.Current.Width - height) / 2;
                crop = new Rectangle(offset, 0, height, height);
            }
            img = img.Resize.Crop(crop).Resize.Scale(800);

            img.Save(realPath + guid + ".png", ImageNet.OutputFormat.Png);
            hesten.BilledeSti = path + guid + ".png";
        }
        else
        {
            hesten.BilledeSti = "";
        }
    }
}