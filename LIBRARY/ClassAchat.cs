using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebApplicationApisIshango.Models.CRUD
{
    public class ClassAchat
    {
        public partial class tAchat
        {
            public int idAchat { get; set; }
            public string compte { get; set; }
            public string numero { get; set; }
            public double montant { get; set; }
            public int valider { get; set; }
            public string type { get; set; }
            public double interet { get; set; }
            public DateTime date { get; set; }
            public string motif { get; set; }
        }

        public int NouveauAchat(tAchat tbl)
        {
            using (SqlConnection con = new SqlConnection(ClassVaribleGolbal.seteconnexion))
            {
                con.Open();
                string query = "INSERT INTO tAchat(compte,numero,montant,valider,type,interet,date,motif) VALUES (@a,@b,@c,@d,@e,@f,@g,@h)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@a", tbl.compte);
                cmd.Parameters.AddWithValue("@b", tbl.numero);
                cmd.Parameters.AddWithValue("@c", tbl.montant);
                cmd.Parameters.AddWithValue("@d", tbl.valider);
                cmd.Parameters.AddWithValue("@e", tbl.type);
                cmd.Parameters.AddWithValue("@f", tbl.interet);
                cmd.Parameters.AddWithValue("@g", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@h", tbl.motif);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<tAchat> GetListeAchatNonValides(string index)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion))

                try
                {
                    Conn.Open();
                    List<tAchat> _list = new List<tAchat>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "select * from tAchat where valider = 0";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        tAchat objCust = new tAchat();
                        objCust.idAchat = Convert.ToInt32(_Reader["idAchat"]);
                        objCust.compte = _Reader["compte"].ToString();
                        objCust.numero = _Reader["numero"].ToString();
                        objCust.montant = Convert.ToDouble(_Reader["montant"]);
                        objCust.valider = Convert.ToInt32(_Reader["valider"]);
                        objCust.type = _Reader["type"].ToString();
                        objCust.interet = Convert.ToDouble(_Reader["interet"]);
                        objCust.date = Convert.ToDateTime(_Reader["date"]);
                        objCust.motif = _Reader["motif"].ToString();
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

        public List<tAchat> GetListeAchatValides(string index)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion))

                try
                {
                    Conn.Open();
                    List<tAchat> _list = new List<tAchat>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "select * from tAchat where valider = 1";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        tAchat objCust = new tAchat();
                        objCust.idAchat = Convert.ToInt32(_Reader["idAchat"]);
                        objCust.compte = _Reader["compte"].ToString();
                        objCust.numero = _Reader["numero"].ToString();
                        objCust.montant = Convert.ToDouble(_Reader["montant"]);
                        objCust.valider = Convert.ToInt32(_Reader["valider"]);
                        objCust.type = _Reader["type"].ToString();
                        objCust.interet = Convert.ToDouble(_Reader["interet"]);
                        objCust.date = Convert.ToDateTime(_Reader["date"]);
                        objCust.motif = _Reader["motif"].ToString();
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