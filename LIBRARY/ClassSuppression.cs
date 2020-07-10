using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebApplicationApisIshango.Models.CRUD
{
    public class ClassSuppression
    {
        public partial class tSuppression
        {
            public int id { get; set; }
            public string operation { get; set; }
            public string libelle { get; set; }
            public string par { get; set; }
            public DateTime date_suppression { get; set; }
        }

        public int EnregistrerSuppression(tSuppression tbl)
        {
            using (SqlConnection con = new SqlConnection(ClassVaribleGolbal.seteconnexion))
            {
                con.Open();

                string query = "INSERT INTO tSuppression(operation,libelle,par,date_suppression) VALUES (@a,@b,@c,@d)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@a", tbl.operation);
                cmd.Parameters.AddWithValue("@b", tbl.libelle);
                cmd.Parameters.AddWithValue("@c", tbl.par);
                cmd.Parameters.AddWithValue("@d", DateTime.Now.ToString("yyyy-MM-dd"));
                return cmd.ExecuteNonQuery();
            }
        }


    }
}