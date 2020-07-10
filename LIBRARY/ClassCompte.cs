using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace WebApplicationApisIshango.Models.CRUD
{
    public class ClassCompte
    {
        public partial class tCompte
        {
            public int RefCompte { get; set; }
            public string NumCompte { get; set; }
            public string Telephone { get; set; }
            public string Pseudo { get; set; }
            public string CodePin { get; set; }
            public int Niveau { get; set; }
            public string Token { get; set; }
            public int GroupeCompte { get; set; }
            public string Photo { get; set; }
            public int Etat { get; set; }
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

                    string s = "SELECT MAX(RefCompte) + 1 AS RefCompte FROM tCompte";
                    SqlCommand objCommand = new SqlCommand(s, Conn);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        ID = Convert.ToInt32(_Reader["RefCompte"]); ;
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

        // enregistre la photo(donc ce string) dans le dossier des images sur le site
        public static string SaveImage(string ImgStr, string ImgName)
        {
            //String path = HttpContext.Current.Server.MapPath("~/ImageUpload"); //Path Images  // ImageUpload
            String path = ""; //Path Images  // ImageUpload


            //Check if directory exist
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }

            string imageName = ImgName + ".png";

            //set the image path
            string imgPath = Path.Combine(path, imageName);

            byte[] imageBytes = Convert.FromBase64String(ImgStr); // String en byte

            File.WriteAllBytes(imgPath, imageBytes);

            return imageName;
        }

        public int NouveauCompte(tCompte tbl)
        {
            using (SqlConnection con = new SqlConnection(ClassVaribleGolbal.seteconnexion))
            {
                con.Open();
                string query = "INSERT INTO tCompte(NumCompte,Telephone,Pseudo,CodePin,Niveau,Token,GroupeCompte,Etat) VALUES (@a,@b,@c,@d,@e,@f,@g,@h)";

                if(tbl.Photo.Length > 2)
                {
                    String enregistrer_image = SaveImage(tbl.Photo, tbl.Telephone);
                }

                SqlCommand cmd = new SqlCommand(query, con);

                int dernier_compte = GetDernierID();

                String nombre_zero = "";

                if (dernier_compte > 0 && dernier_compte < 10) nombre_zero = "00000";
                if (dernier_compte > 9 && dernier_compte < 100) nombre_zero = "0000";
                if (dernier_compte > 99 && dernier_compte < 1000) nombre_zero = "000";
                if (dernier_compte > 999 && dernier_compte < 10000) nombre_zero = "00";
                if (dernier_compte > 9999 && dernier_compte < 100000) nombre_zero = "0";
                if (dernier_compte > 99999 && dernier_compte < 1000000) nombre_zero = "";

                if (tbl.GroupeCompte == 410)
                {
                    cmd.Parameters.AddWithValue("@a", "410" + nombre_zero + dernier_compte);
                }
                if (tbl.GroupeCompte == 411)
                {
                    cmd.Parameters.AddWithValue("@a", "411" + nombre_zero + dernier_compte);
                }
                if (tbl.GroupeCompte == 412)
                {
                    cmd.Parameters.AddWithValue("@a", "411" + nombre_zero + dernier_compte);
                }
                if (tbl.GroupeCompte == 101)
                {
                    cmd.Parameters.AddWithValue("@a", "101" + nombre_zero + dernier_compte);
                }
                if (tbl.GroupeCompte == 413)
                {
                    cmd.Parameters.AddWithValue("@a", "413" + nombre_zero + dernier_compte);
                }
                if (tbl.GroupeCompte == 601)
                {
                    cmd.Parameters.AddWithValue("@a", "601" + nombre_zero + dernier_compte);
                }
                if (tbl.GroupeCompte == 701)
                {
                    cmd.Parameters.AddWithValue("@a", "701" + nombre_zero + dernier_compte);
                }

                cmd.Parameters.AddWithValue("@b", tbl.Telephone);
                cmd.Parameters.AddWithValue("@c", tbl.Pseudo);
                cmd.Parameters.AddWithValue("@d", tbl.CodePin);
                cmd.Parameters.AddWithValue("@e", tbl.Niveau);
                cmd.Parameters.AddWithValue("@f", tbl.Token);
                cmd.Parameters.AddWithValue("@g", tbl.GroupeCompte);
                cmd.Parameters.AddWithValue("@h", 1);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<tCompte> GetCompteParTelephone(string Telephone)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion))

                try
                {
                    Conn.Open();
                    List<tCompte> _list = new List<tCompte>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "select * from tCompte where Telephone = @a";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.Parameters.AddWithValue("@a", Telephone);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        tCompte objCust = new tCompte();
                        objCust.RefCompte = Convert.ToInt32(_Reader["RefCompte"]);
                        objCust.NumCompte = _Reader["NumCompte"].ToString();
                        objCust.Telephone = _Reader["Telephone"].ToString();
                        objCust.Pseudo = _Reader["Pseudo"].ToString();
                        objCust.CodePin = _Reader["CodePin"].ToString();
                        objCust.Niveau = Convert.ToInt32(_Reader["Niveau"]);
                        objCust.Token = _Reader["Token"].ToString();
                        objCust.GroupeCompte = Convert.ToInt32(_Reader["GroupeCompte"]);
                        objCust.Etat = Convert.ToInt32(_Reader["Etat"]);
                        objCust.Photo = _Reader["Telephone"].ToString()+".png";
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

        public List<tCompte> GetCompteParNumeroCompte(string NumCompte)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion))

                try
                {
                    Conn.Open();
                    List<tCompte> _list = new List<tCompte>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "select * from tCompte where NumCompte = @a";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.Parameters.AddWithValue("@a", NumCompte);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        tCompte objCust = new tCompte();
                        objCust.RefCompte = Convert.ToInt32(_Reader["RefCompte"]);
                        objCust.NumCompte = _Reader["NumCompte"].ToString();
                        objCust.Telephone = _Reader["Telephone"].ToString();
                        objCust.Pseudo = _Reader["Pseudo"].ToString();
                        objCust.CodePin = _Reader["CodePin"].ToString();
                        objCust.Niveau = Convert.ToInt32(_Reader["Niveau"]);
                        objCust.Token = _Reader["Token"].ToString();
                        objCust.GroupeCompte = Convert.ToInt32(_Reader["GroupeCompte"]);
                        objCust.Etat = Convert.ToInt32(_Reader["Etat"]);
                        objCust.Photo = _Reader["Telephone"].ToString() + ".png";
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

        public IEnumerable<tCompte> GetCompteParTelephoneEtPin(string Telephone, string CodePin)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion))

                try
                {
                    Conn.Open();
                    List<tCompte> _list = new List<tCompte>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "select * from tCompte where (Telephone = @a OR NumCompte = @a) and CodePin = @b";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.Parameters.AddWithValue("@a", Telephone);
                    objCommand.Parameters.AddWithValue("@b", CodePin);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        tCompte objCust = new tCompte();
                        objCust.RefCompte = Convert.ToInt32(_Reader["RefCompte"]);
                        objCust.NumCompte = _Reader["NumCompte"].ToString();
                        objCust.Telephone = _Reader["Telephone"].ToString();
                        objCust.Pseudo = _Reader["Pseudo"].ToString();
                        objCust.CodePin = _Reader["CodePin"].ToString();
                        objCust.Niveau = Convert.ToInt32(_Reader["Niveau"]);
                        objCust.Token = _Reader["Token"].ToString();
                        objCust.GroupeCompte = Convert.ToInt32(_Reader["GroupeCompte"]);
                        objCust.Etat = Convert.ToInt32(_Reader["Etat"]);
                        objCust.Photo = _Reader["Telephone"].ToString() + ".png";
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

        public List<tCompte> GetTousLesAutresCompte(string NumCompte)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion))

                try
                {
                    Conn.Open();
                    List<tCompte> _list = new List<tCompte>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "select * from tCompte where NumCompte != @a order by RefCompte DESC";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.Parameters.AddWithValue("@a", NumCompte);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        tCompte objCust = new tCompte();
                        objCust.RefCompte = Convert.ToInt32(_Reader["RefCompte"]);
                        objCust.NumCompte = _Reader["NumCompte"].ToString();
                        objCust.Telephone = _Reader["Telephone"].ToString();
                        objCust.Pseudo = _Reader["Pseudo"].ToString();
                        objCust.CodePin = _Reader["CodePin"].ToString();
                        objCust.Niveau = Convert.ToInt32(_Reader["Niveau"]);
                        objCust.Token = _Reader["Token"].ToString();
                        objCust.GroupeCompte = Convert.ToInt32(_Reader["GroupeCompte"]);
                        objCust.Etat = Convert.ToInt32(_Reader["Etat"]);
                        objCust.Photo = _Reader["Telephone"].ToString() + ".png";
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

        public int ModifierEtatCompte(int Etat, string NumCompte)
        {
            // dbConnector objConn = new dbConnector();
            SqlConnection Conn = new SqlConnection(ClassVaribleGolbal.seteconnexion);
            Conn.Open();

            int result = 0;

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open)
                    Conn.Open();
                string s = " UPDATE tCompte SET Etat=@Etat WHERE NumCompte=@NumCompte";
                SqlCommand objCommand = new SqlCommand(s, Conn);
                objCommand.CommandType = CommandType.Text;
                objCommand.Parameters.AddWithValue("@Etat", Etat);
                objCommand.Parameters.AddWithValue("@NumCompte", NumCompte);

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