using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsAdoOmnivox
{
    public partial class ecrireMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // connection a bd
            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Server.MapPath("~\\App_Data\\DB_Omnivox.mdf");
            mycon.Open();

            string sql = "SELECT Numero, Nom FROM Membres ORDER BY Nom";

            SqlCommand mycmd = new SqlCommand(sql, mycon);
            SqlDataReader myrder = mycmd.ExecuteReader();
            while (myrder.Read() == true)
            {
                ListItem elm = new ListItem();
                elm.Text = myrder["Nom"].ToString() + " (" +
                    myrder["Numero"].ToString() + ")";
                elm.Value = myrder["Numero"].ToString();
                cboDestinataires.Items.Add(elm);
            }
            myrder.Close();
            mycon.Close();
        }
    }
}