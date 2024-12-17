using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsAdoOmnivox
{
    public partial class inscrireOmnivox : System.Web.UI.Page
    {
        // Déclaration des objets globaux pour le DataSet
        private static DataSet dsOmnivox;
        private static SqlDataAdapter adpEtudiants;
        private static SqlDataAdapter adpMembres;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ChargerDataSet();
            }
        }

        private void ChargerDataSet()
        {
            // Initialisation du DataSet
            dsOmnivox = new DataSet();

            // Connexion a la bd
            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Server.MapPath("~\\App_Data\\DB_Omnivox.mdf");
            mycon.Open();

            // Remplir les tables Etudiants et Membres dans le DataSet
            string sqlEtudiants = "SELECT Numero, Nom, Email, YEAR(Naissance) AS AnneeNaissance FROM Etudiants";
            string sqlMembres = "SELECT Numero, Nom, Nip, Statut FROM Membres";

            adpEtudiants = new SqlDataAdapter(sqlEtudiants, mycon);
            adpMembres = new SqlDataAdapter(sqlMembres, mycon);

            adpEtudiants.Fill(dsOmnivox, "Etudiants");
            adpMembres.Fill(dsOmnivox, "Membres");

            mycon.Close();
        }

        protected void bntInscrire_Click(object sender, EventArgs e)
        {
            // select les valeurs entrees par l'utilisateur
            string num = txtNumero.Text.Trim();
            string eml = txtEmail.Text.Trim();
            int anNaisance = Convert.ToDateTime(txtNaissance.Text).Year;
            string mdp = txtMotdepasse.Text.Trim();
            string nom = "";

            // verify si l'utilisateur est un étudiant
            DataTable tabEtudiants = dsOmnivox.Tables["Etudiants"];
            DataRow[] etudiantRows = tabEtudiants.Select($"Numero = '{num}' AND Email = '{eml}' AND AnneeNaissance = {anNaisance}");

            if (etudiantRows.Length == 0)
            {
                lblErreur.Text = "Échec inscription : Il faut être étudiant(e).";
                return;
            }

            // Récupérer le nom de l'etudiant
            nom = etudiantRows[0]["Nom"].ToString();

            // verify si l'étudiant est deja membre
            DataTable tabMembres = dsOmnivox.Tables["Membres"];
            DataRow[] membreRows = tabMembres.Select($"Numero = '{num}'");

            if (membreRows.Length > 0)
            {
                lblErreur.Text = "Échec Inscription : Vous êtes déjà membre, contactez l'admin.";
                return;
            }

            // Ajouter l'étudiant en tant que membre
            DataRow newMembre = tabMembres.NewRow();
            newMembre["Numero"] = num;
            newMembre["Nom"] = nom;
            newMembre["Nip"] = mdp;
            newMembre["Statut"] = "actif";
            tabMembres.Rows.Add(newMembre);

            // Synchroniser les modifications avec la bd
            SqlCommandBuilder builderMembres = new SqlCommandBuilder(adpMembres);
            adpMembres.Update(dsOmnivox, "Membres");

            // Redirection vers la page de connexion
            Response.Redirect("loginOmnivox.aspx");
        }
    }
}
