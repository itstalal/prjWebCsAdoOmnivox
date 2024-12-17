using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsAdoOmnivox
{
    public partial class acceuilOmnivox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int nbmsg = 0;

            lblMessage.Text = "Bienvenue " + Session["Nom"].ToString();

            TableRow maligne = new TableRow();
            maligne.Font.Size = FontUnit.Large;
            maligne.ForeColor = Color.White;
            maligne.BackColor = Color.DeepSkyBlue;

            TableCell macellule = new TableCell();
            macellule.Text = "Titres";
            maligne.Cells.Add(macellule);

            macellule = new TableCell();
            macellule.Text = "Envoyeurs";
            maligne.Cells.Add(macellule);

            macellule = new TableCell();
            macellule.Text = "Actions";
            maligne.Cells.Add(macellule);

            tabMessages.Rows.Add(maligne);

            // Charger DataSet
            DataSet ds = new DataSet();
            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Server.MapPath("~\\App_Data\\DB_Omnivox.mdf");
            mycon.Open();

            // Remplir le DataSet avec les tables 
            SqlDataAdapter adpMessages = new SqlDataAdapter("SELECT * FROM Messages", mycon);
            adpMessages.Fill(ds, "Messages");

            SqlDataAdapter adpMembres = new SqlDataAdapter("SELECT * FROM Membres", mycon);
            adpMembres.Fill(ds, "Membres");

            mycon.Close();

            DataTable tblMessages = ds.Tables["Messages"];
            DataTable tblMembres = ds.Tables["Membres"];

            DataRow[] userMessages = tblMessages.Select("Receveur = '" + Session["NumMembre"].ToString() + "'");

            foreach (DataRow messageRow in userMessages)
            {
                maligne = new TableRow();

                if (messageRow["Nouveau"].ToString() == "True")
                {
                    maligne.BackColor = Color.LightYellow;
                }

                macellule = new TableCell();
                macellule.Text = messageRow["Titre"].ToString();
                maligne.Cells.Add(macellule);

                DataRow[] envoyeurRow = tblMembres.Select("Numero = '" + messageRow["Envoyeur"].ToString() + "'");
                string nomEnvoyeur = envoyeurRow.Length > 0 ? envoyeurRow[0]["Nom"].ToString() : "Inconnu";

                macellule = new TableCell();
                macellule.Text = nomEnvoyeur;
                maligne.Cells.Add(macellule);

                macellule = new TableCell();
                int msgID = Convert.ToInt32(messageRow["RefMessage"]);
                macellule.Text = "<a href='lireMessage.aspx?refMes=" + msgID + "'>Lire</a>";
                macellule.Text += "&nbsp; &nbsp; &nbsp; <a href='effacerMessage.aspx?refMes=" + msgID + "'>Effacer</a>";
                maligne.Cells.Add(macellule);

                tabMessages.Rows.Add(maligne);
                nbmsg++;
            }

            lblMessage.Text += "<br />Vous avez " + nbmsg + " message(s).";
        }
    }
}
