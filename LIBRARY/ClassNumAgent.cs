using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebApplicationApisIshango.Models.CRUD
{
    public class ClassNumAgent
    {
        public partial class tNumCompteAgent
        {
            public int id { get; set; }
            public string designation { get; set; }
            public string numero { get; set; }
            public string description { get; set; }
        }

        public List<tNumCompteAgent> GetNumerosAgent(string index)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion))

                try
                {
                    Conn.Open();
                    List<tNumCompteAgent> _list = new List<tNumCompteAgent>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "select * from tNumCompteAgent";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        tNumCompteAgent objCust = new tNumCompteAgent();
                        objCust.id = Convert.ToInt32(_Reader["id"]);
                        objCust.designation = _Reader["designation"].ToString();
                        objCust.numero = _Reader["numero"].ToString();
                        objCust.description = _Reader["description"].ToString();
                        _list.Add(objCust);
                    }

                    return _list;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (Conn != null)
                    {
                        if (Conn.State == ConnectionState.Open)
                        {
                            Conn.Close();
                            Conn.Dispose();
                        }
                    }
                }
        }

    }
}