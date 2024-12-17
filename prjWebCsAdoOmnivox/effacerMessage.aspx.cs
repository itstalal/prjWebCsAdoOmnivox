using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace prjWebCsAdoOmnivox
{
    public partial class effacerMessage : System.Web.UI.Page
    {
        static DataSet dsOmnivox;
        static SqlDataAdapter adpMessages;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dsOmnivox = ChargerDataset();
            }

            int refMsgALire = Convert.ToInt32(Request.QueryString["refMes"]);

            SupprimerMessage(refMsgALire);

            SauvegarderModifications();

            Response.Redirect("acceuilOmnivox.aspx");
        }

        private DataSet ChargerDataset()
        {
            DataSet mySet = new DataSet();

            // Connexion à la bd
            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Server.MapPath("~\\App_Data\\DB_Omnivox.mdf");
            mycon.Open();

            string sql = "SELECT RefMessage, Contenu, Envoyeur, Receveur FROM Messages";
            SqlCommand mycmd = new SqlCommand(sql, mycon);

            //  DataAdapter et remplir le DataSet
            adpMessages = new SqlDataAdapter(mycmd);
            adpMessages.Fill(mySet, "Messages");

            // definir la cle primaire pour faciliter les recherches
            DataColumn[] primaryKey = new DataColumn[1];
            primaryKey[0] = mySet.Tables["Messages"].Columns["RefMessage"];
            mySet.Tables["Messages"].PrimaryKey = primaryKey;

            mycon.Close();
            return mySet;
        }

        private void SupprimerMessage(int refMessage)
        {
            DataRow messageRow = dsOmnivox.Tables["Messages"].Rows.Find(refMessage);

            if (messageRow != null)
            {
                messageRow.Delete();
            }
        }

        private void SauvegarderModifications()
        {
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adpMessages);

            adpMessages.Update(dsOmnivox, "Messages");
        }
    }
}
