using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebApplicationApisIshango.Models.CRUD
{
    public class ClassMvtCompte
    {
        public partial class tMvtCompte
        {
            public int NumRef { get; set; }
            public int NumOperation { get; set; }
            public string NumCompte { get; set; }
            public double Entree { get; set; }
            public double Sortie { get; set; }
            public DateTime DateMvt { get; set; }
            public double Interet { get; set; }
        }

        public partial class tMvtGroupeCompte
        {
            public int GroupeCompte { get; set; }
            public string DesignationGroupe { get; set; }
            public double SEntree { get; set; }
            public double SSortie { get; set; }
            public double Solde { get; set; }
        }

        public partial class tJournalCompte
        {
            public int NumOperation { get; set; }
            public DateTime DateOp { get; set; }
            public string Libelle { get; set; }
            public string NumCompte { get; set; }
            public string Pseudo { get; set; }
            public string Telephone { get; set; }
            public double Entree { get; set; }
            public double Sortie { get; set; }
            public int Reference { get; set; }
        }

        public partial class tSolde
        {
            public double Solde { get; set; }
        }

        public int GetDerniereOperation()
        {
            int ID = 1;
            using (SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion))

                try
                {
                    Conn.Open();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "SELECT MAX(NumOperation) AS NumOperation FROM tOperation";
                    SqlCommand objCommand = new SqlCommand(s, Conn);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        ID = Convert.ToInt32(_Reader["NumOperation"]);
                    }

                    return ID;
                }
                catch
                {
                    //throw;
                    return 1;
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

        public int EnregistrerMouvement(tMvtCompte tbl)
        {
            using (SqlConnection con = new SqlConnection(ClassVaribleGolbal.seteconnexion))
            {
                con.Open();

                string query = "INSERT INTO tMvtCompte(NumOperation,NumCompte,Entree,Sortie,DateMvt,Interet) VALUES (@a,@b,@c,@d,@e,@f)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@a", GetDerniereOperation());
                cmd.Parameters.AddWithValue("@b", tbl.NumCompte);
                cmd.Parameters.AddWithValue("@c", tbl.Entree);
                cmd.Parameters.AddWithValue("@d", tbl.Sortie);
                cmd.Parameters.AddWithValue("@e", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@f", tbl.Interet);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<tMvtCompte> GetListeNvt(string index)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion))

                try
                {
                    Conn.Open();
                    List<tMvtCompte> _list = new List<tMvtCompte>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "select * from tMvtCompte";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        tMvtCompte objCust = new tMvtCompte();

                        objCust.NumRef = Convert.ToInt32(_Reader["NumRef"]);
                        objCust.NumOperation = Convert.ToInt32(_Reader["NumOperation"]);
                        objCust.NumCompte = _Reader["NumCompte"].ToString();
                        objCust.Entree = Convert.ToDouble(_Reader["Entree"]);
                        objCust.Sortie = Convert.ToDouble(_Reader["Sortie"]);
                        objCust.DateMvt = Convert.ToDateTime(_Reader["DateMvt"]);
                        objCust.Interet = Convert.ToDouble(_Reader["Interet"]);


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

        public List<tMvtCompte> GetListeNvtParCompte(string NumCompte)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion))

                try
                {
                    Conn.Open();
                    List<tMvtCompte> _list = new List<tMvtCompte>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "select * from tMvtCompte where NumCompte = @a";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.Parameters.AddWithValue("@a", NumCompte);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        tMvtCompte objCust = new tMvtCompte();

                        objCust.NumRef = Convert.ToInt32(_Reader["NumRef"]);
                        objCust.NumOperation = Convert.ToInt32(_Reader["NumOperation"]);
                        objCust.NumCompte = _Reader["NumCompte"].ToString();
                        objCust.Entree = Convert.ToDouble(_Reader["Entree"]);
                        objCust.Sortie = Convert.ToDouble(_Reader["Sortie"]);
                        objCust.DateMvt = Convert.ToDateTime(_Reader["DateMvt"]);
                        objCust.Interet = Convert.ToDouble(_Reader["Interet"]);

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

        public List<tMvtGroupeCompte> GetMouvementGroupeCompte(string index)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion))

                try
                {
                    Conn.Open();
                    List<tMvtGroupeCompte> _list = new List<tMvtGroupeCompte>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "SELECT tGroupeCompte.GroupeCompte, tGroupeCompte.DesignationGroupe, SUM(tMvtCompte.Entree) AS SEntree, SUM(tMvtCompte.Sortie)"+
                        " AS SSortie,SUM(tMvtCompte.Entree) -SUM(tMvtCompte.Sortie) AS Solde FROM tCompte INNER JOIN tGroupeCompte ON tCompte.GroupeCompte"+
                        " = tGroupeCompte.GroupeCompte INNER JOIN tMvtCompte ON tCompte.NumCompte = tMvtCompte.NumCompte INNER JOIN tOperation ON"+
                        " tMvtCompte.NumOperation = tOperation.NumOperation GROUP BY tGroupeCompte.GroupeCompte, tGroupeCompte.DesignationGroupe";

                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        tMvtGroupeCompte objCust = new tMvtGroupeCompte();


                        objCust.GroupeCompte = Convert.ToInt32(_Reader["GroupeCompte"]);
                        objCust.DesignationGroupe = _Reader["DesignationGroupe"].ToString();
                        objCust.SEntree = Convert.ToDouble(_Reader["SEntree"]);
                        objCust.SSortie = Convert.ToDouble(_Reader["SSortie"]);
                        objCust.Solde = Convert.ToDouble(_Reader["Solde"]);

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

        public List<tJournalCompte> GetJournalCompte(string date_debut, string date_fin)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion))

                try
                {
                    Conn.Open();
                    List<tJournalCompte> _list = new List<tJournalCompte>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "SELECT tOperation.NumOperation, tOperation.DateOp, tOperation.Libelle, tCompte.NumCompte, tCompte.Pseudo, tCompte.Telephone, "+
                        "tMvtCompte.Entree, tMvtCompte.Sortie, tOperation.Reference FROM tCompte INNER JOIN tMvtCompte ON tCompte.NumCompte = tMvtCompte.NumCompte"+
                        " INNER JOIN tOperation ON tMvtCompte.NumOperation = tOperation.NumOperation WHERE(tOperation.DateOp BETWEEN "+
                        "CONVERT(DATETIME, @a, 102) AND CONVERT(DATETIME, @b, 102))";

                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.Parameters.AddWithValue("@a", date_debut);
                    objCommand.Parameters.AddWithValue("@b", date_fin);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        tJournalCompte objCust = new tJournalCompte();

                        objCust.NumOperation = Convert.ToInt32(_Reader["NumOperation"]);
                        objCust.DateOp = Convert.ToDateTime(_Reader["DateOp"]);
                        objCust.Libelle = _Reader["Libelle"].ToString();
                        objCust.NumCompte = _Reader["NumCompte"].ToString();
                        objCust.Pseudo = _Reader["Pseudo"].ToString();
                        objCust.Telephone = _Reader["Telephone"].ToString();
                        objCust.Entree = Convert.ToDouble(_Reader["Entree"]);
                        objCust.Sortie = Convert.ToDouble(_Reader["Sortie"]);
                        objCust.Reference = Convert.ToInt32(_Reader["Reference"]);

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

        public List<tJournalCompte> GetReleveDuCompte(string date_debut, string date_fin, string num_compte)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion))

                try
                {
                    Conn.Open();
                    List<tJournalCompte> _list = new List<tJournalCompte>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "SELECT tOperation.NumOperation, tOperation.DateOp, tOperation.Libelle, tCompte.NumCompte, tCompte.Pseudo, tCompte.Telephone, " +
                        "tMvtCompte.Entree, tMvtCompte.Sortie, tOperation.Reference FROM tCompte INNER JOIN tMvtCompte ON tCompte.NumCompte = tMvtCompte.NumCompte" +
                        " INNER JOIN tOperation ON tMvtCompte.NumOperation = tOperation.NumOperation WHERE(tOperation.DateOp BETWEEN " +
                        "CONVERT(DATETIME, @a, 102) AND CONVERT(DATETIME, @b, 102)) AND tMvtCompte.NumCompte = @c";

                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.Parameters.AddWithValue("@a", date_debut);
                    objCommand.Parameters.AddWithValue("@b", date_fin);
                    objCommand.Parameters.AddWithValue("@c", num_compte);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        tJournalCompte objCust = new tJournalCompte();

                        objCust.NumOperation = Convert.ToInt32(_Reader["NumOperation"]);
                        objCust.DateOp = Convert.ToDateTime(_Reader["DateOp"]);
                        objCust.Libelle = _Reader["Libelle"].ToString();
                        objCust.NumCompte = _Reader["NumCompte"].ToString();
                        objCust.Pseudo = _Reader["Pseudo"].ToString();
                        objCust.Telephone = _Reader["Telephone"].ToString();
                        objCust.Entree = Convert.ToDouble(_Reader["Entree"]);
                        objCust.Sortie = Convert.ToDouble(_Reader["Sortie"]);
                        objCust.Reference = Convert.ToInt32(_Reader["Reference"]);

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

        public tSolde GetSolde(string NumCompte)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion))

                try
                {
                    Conn.Open();
                    tSolde _list = new tSolde();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "select (SUM(Entree)-SUM(Sortie)) AS Solde from tMvtCompte where NumCompte = @a";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.Parameters.AddWithValue("@a", NumCompte);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        tSolde objCust = new tSolde();

                        objCust.Solde = Convert.ToDouble(_Reader["Solde"]);

                       // _list.Add(objCust);
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