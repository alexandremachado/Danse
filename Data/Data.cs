using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    public class Data
    {
            public DataTable ExecuterRequete(string requete)
        {
            DataTable dtable = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString);
            SqlDataAdapter dadapter = new SqlDataAdapter(requete, conn);

            try
            {
                if (!String.IsNullOrEmpty(requete))
                {
                    conn.Open();
                    dadapter.Fill(dtable);
                }
            }
            catch (Exception ex)
            {
                dtable = new DataTable(ex.Message);
            }
            finally
            {
                conn.Close();
                conn = null;
            }
            return dtable;
        }
    }
}
