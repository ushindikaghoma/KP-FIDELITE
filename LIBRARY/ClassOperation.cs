using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebApplicationApisIshango.Models.CRUD
{
    public class ClassOperation
    {
        public partial class tOperation
        {
            public int NumOperation { get; set; }
            public DateTime DateOp { get; set; }
            public string Libelle { get; set; }
            public string Reference { get; set; }
            public int status_result { get; set; }
            public string status_response { get; set; }
        }

        public int GetDernierID()
        {
            int ID = 1;
            using (SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion))

                try
                {
                    Conn.Open();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "SELECT MAX(NumOperation) + 1 AS NumOperation FROM tOperation";
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

        //modification de l'api enregistrement nouvelle operation, changement type de donnee a retourner

        public List<tOperation> NouvelleOperation(tOperation tbl)
        {
            using (SqlConnection con = new SqlConnection(ClassVaribleGolbal.seteconnexion))
            {
                List<tOperation> _list = new List<tOperation>();
                con.Open();
                string query = "INSERT INTO tOperation(DateOp,Libelle,Reference) VALUES (@a,@b,@c)";

                int reference = GetDernierID();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@a", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@b", tbl.Libelle);
                cmd.Parameters.AddWithValue("@c", (reference));

                int result = cmd.ExecuteNonQuery();

                //rrecuperation de la reponse a retourne  lors de l'insertion d'une operations
                tOperation objectResult = new tOperation();
                
                if(result == 1)
                {
                    objectResult.DateOp = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    objectResult.Libelle = tbl.Libelle;
                    objectResult.Reference = Convert.ToString(reference);
                    objectResult.status_result = result;
                    objectResult.status_response = "Insertion réussie avec succès";
                }
                else
                {
                    objectResult.DateOp = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    objectResult.Libelle = "";
                    objectResult.Reference = "";
                    objectResult.status_result = result;
                    objectResult.status_response = "Echec Insertion";
                }
               
                _list.Add(objectResult);
                return _list;
            }
        }

        public List<tOperation> GetListeOperarion(string index)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion))

                try
                {
                    Conn.Open();
                    List<tOperation> _list = new List<tOperation>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "select * from tOperation order by NumOperation desc";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        tOperation objCust = new tOperation();

                        objCust.NumOperation = Convert.ToInt32(_Reader["NumOperation"]);
                        objCust.DateOp = Convert.ToDateTime(_Reader["DateOp"]);
                        objCust.Libelle = _Reader["Libelle"].ToString();
                        objCust.Reference = _Reader["Reference"].ToString();
                        
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

        public List<tOperation> GetOperationParReference(string reference)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion))

                try
                {
                    Conn.Open();
                    List<tOperation> _list = new List<tOperation>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "select * from tOperation where Reference = @a";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.Parameters.AddWithValue("@a", reference);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        tOperation objCust = new tOperation();

                        objCust.NumOperation = Convert.ToInt32(_Reader["NumOperation"]);
                        objCust.DateOp = Convert.ToDateTime(_Reader["DateOp"]);
                        objCust.Libelle = _Reader["Libelle"].ToString();
                        objCust.Reference = _Reader["Reference"].ToString();

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

        public Int32 DeleteOperation(string NumOperation)
        {
            SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion);
            Conn.Open();

            int result = 0;

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open)
                    Conn.Open();
                string s = "DELETE FROM tOperation WHERE  NumOperation=@NumOperation";
                SqlCommand objCommand = new SqlCommand(s, Conn);
                objCommand.CommandType = CommandType.Text;
                objCommand.Parameters.AddWithValue("@NumOperation", NumOperation);

                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result; 
                }
                else
                {
                    return 0;
                }
                
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

        public Int32 DeleteMvtCompte(string NumOperation)
        {
            SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion);
            Conn.Open();

            int result = 0;

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open)
                    Conn.Open();
                string s = "DELETE FROM tMvtCompte WHERE  NumOperation=@NumOperation";
                SqlCommand objCommand = new SqlCommand(s, Conn);
                objCommand.CommandType = CommandType.Text;
                objCommand.Parameters.AddWithValue("@NumOperation", NumOperation);

                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
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