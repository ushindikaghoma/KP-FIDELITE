using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebApplicationApisIshango.Models.CRUD
{
    public class ClassParametreGeneraux
    {
        public partial class tParametreGeneraux
        {
            public int IdPara { get; set; }
            public String DateActuelle { get; set; }
            public double TauxFc { get; set; }
        }

        public List<tParametreGeneraux> GetParametre(string index)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion))

                try
                {
                    Conn.Open();
                    List<tParametreGeneraux> _list = new List<tParametreGeneraux>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "SELECT * FROM tParametreGeneraux WHERE IdPara = 1";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        tParametreGeneraux objCust = new tParametreGeneraux();
                        objCust.IdPara = Convert.ToInt32(_Reader["IdPara"]);
                        objCust.DateActuelle = Convert.ToDateTime(_Reader["DateActuelle"]).ToString("yyyy-MM-dd");
                        objCust.TauxFc = Convert.ToDouble(_Reader["TauxFc"]);
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