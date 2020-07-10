using System;

namespace WebApplicationApisIshango.Models.CRUD
{
    public static class ClassVaribleGolbal
    {
        //public static string seteconnexion = "Data Source=127.0.0.1;Initial Catalog=AfriProjetDepense;Integrated Security=True";

        //public static string seteconnexion = "Data Source=127.0.0.1;Initial Catalog=CompteVirtuel; User Id=Afriprodep;Password=111222333";
        public static string seteconnexion = "Data Source=SQL5033.site4now.net;Initial Catalog=DB_A54EFD_Fidelity;User Id=DB_A54EFD_Fidelity_admin;Password=Freedum099;";

        public static string CodeEntreprise = "ECOL";
        public static String OPinit = "INITIAL";
        public static String GroupeService = "706";
        public static String CompteDestokqge = "601000";
        public static String CompteVente = "701000";
        public static String CompteStock = "311000";
        public static String CompteAchat = "601001"; 
        public static String CompteFacturation = "702000";
        public static String CompteclientOccasionne = "41101";
        public static String UTILISATEUR = "INITIAL";
        public static DateTime  DateDuJOUR;
        public static DateTime DateCloturer;
        public static String AutreInfo = "706";
        public static Boolean ETATbd;
        public static Double TauxFc;
        public static Double TauxTrans;
        public static Double FraisdeTransProduit;
        public static Double FraisdeTransEmbllage;

        public static string CompteEmbale = "310101";

        public static string RefAchercher;
    }

    public static class verifierNumbe
    {
        public static bool IsNumeric(this string s)
        {
            float output;
            return float.TryParse(s, out output);
        }
    }
}
