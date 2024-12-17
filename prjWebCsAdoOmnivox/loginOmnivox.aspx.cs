using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace prjWebCsAdoOmnivox
{
    public partial class loginOmnivox : System.Web.UI.Page
    {
        static DataSet dsMembres;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ChargerDataSet();
            }
        }

        private void ChargerDataSet()
        {
            ///////////// Initiliser et remplir le DataSet
            dsMembres = new DataSet();

            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Server.MapPath("~\\App_Data\\DB_Omnivox.mdf");

            mycon.Open();

            string sql = "SELECT Numero, Nom, Nip FROM Membres";
            SqlCommand mycmd = new SqlCommand(sql, mycon);

            SqlDataAdapter adpMembres = new SqlDataAdapter(mycmd);

            adpMembres.Fill(dsMembres, "Membres");

            mycon.Close();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // recuperer input de le numero et le mot de passe
            string num = txtNumero.Text.Trim();
            string mdp = txtMot2passe.Text.Trim();

            // Rechercher l'utilisateur dans le DataSet
            DataTable tabMembres = dsMembres.Tables["Membres"];
            DataRow[] resultat = tabMembres.Select($"Numero = '{num}' AND Nip = '{mdp}'");

            if (resultat.Length == 0)
            {
                // Utilisateur introuvable
                lblErreur.Text = "Numero ou Mot de passe invalide, Essayez de nouveau";
            }
            else
            {
                // Utilisateur trouve
                DataRow membre = resultat[0];

                // save les informations dans les variables globales de session
                Session["NumMembre"] = membre["Numero"];
                Session["Nom"] = membre["Nom"];

                Response.Redirect("acceuilOmnivox.aspx");
            }
        }

        protected void btnInscrire_Click(object sender, EventArgs e)
        {
            Response.Redirect("inscrireOmnivox.aspx");
        }
    }
}
