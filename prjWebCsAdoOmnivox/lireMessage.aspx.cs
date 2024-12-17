using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace prjWebCsAdoOmnivox
{
    public partial class lireMessage : System.Web.UI.Page
    {
        static DataSet dsOmnivox;
        static SqlDataAdapter adpMessages;
        static SqlDataAdapter adpMembres;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dsOmnivox = ChargerDataset();
            }

            // get le refMessage du message choisi
            int refMsgALire = Convert.ToInt32(Request.QueryString["refMes"]);

            
            LireMessage(refMsgALire);

            
            MarquerCommeLu(refMsgALire);

            
            SauvegarderModifications();
        }

        private DataSet ChargerDataset()
        {
            DataSet mySet = new DataSet();

            // Connexion à la base de données
            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Server.MapPath("~\\App_Data\\DB_Omnivox.mdf");
            mycon.Open();

            // Charger la table Messages
            string sqlMessages = "SELECT * FROM Messages";
            adpMessages = new SqlDataAdapter(sqlMessages, mycon);
            adpMessages.Fill(mySet, "Messages");

            // Charger la table Membres
            string sqlMembres = "SELECT * FROM Membres";
            adpMembres = new SqlDataAdapter(sqlMembres, mycon);
            adpMembres.Fill(mySet, "Membres");

            // Définir les clés primaires pour faciliter les recherches
            mySet.Tables["Messages"].PrimaryKey = new DataColumn[] { mySet.Tables["Messages"].Columns["RefMessage"] };
            mySet.Tables["Membres"].PrimaryKey = new DataColumn[] { mySet.Tables["Membres"].Columns["Numero"] };

            mycon.Close();
            return mySet;
        }

        private void LireMessage(int refMessage)
        {
            // Rechercher le message dans la table Messages
            DataRow messageRow = dsOmnivox.Tables["Messages"].Rows.Find(refMessage);

            if (messageRow != null)
            {
                // Rechercher l'envoyeur dans la table Membres
                string envoyeurId = messageRow["Envoyeur"].ToString();
                DataRow membreRow = dsOmnivox.Tables["Membres"].Rows.Find(envoyeurId);

                // Construire les informations du message
                string info = "<table>";
                info += "<tr><td>Titre : </td><td>" + messageRow["Titre"].ToString() + "</td></tr>";
                info += "<tr><td>Envoyeur : </td><td>" + (membreRow != null ? membreRow["Nom"].ToString() : "Inconnu") + "</td></tr>";
                info += "<tr><td>Date : </td><td>" + messageRow["Date"].ToString() + "</td></tr>";
                info += "<tr><td>Contenu : </td><td>" + messageRow["Contenu"].ToString() + "</td></tr>";
                info += "</table>";

                lblMessage.Text = info;
            }
        }

        private void MarquerCommeLu(int refMessage)
        {
            // Rechercher le message dans la table Messages
            DataRow messageRow = dsOmnivox.Tables["Messages"].Rows.Find(refMessage);

            if (messageRow != null)
            {
                // Modifier la valeur de la colonne Nouveau
                messageRow["Nouveau"] = false;
            }
        }

        private void SauvegarderModifications()
        {
            SqlCommandBuilder cmdBuilderMessages = new SqlCommandBuilder(adpMessages);

            adpMessages.Update(dsOmnivox, "Messages");
        }

        protected void btnRetourner_Click(object sender, EventArgs e)
        {
            Response.Redirect("acceuilOmnivox.aspx");
        }
    }
}
