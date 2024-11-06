using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prjWebCsBankGab.App_Code
{
    public static class clsSourceDeDonnees
    {
        public static clsListeClient RecupererTousLesClients()
        {
            clsListeClient tousClient = new clsListeClient();
            // se connecter a la BD pour recuperer la table client 

            // etape 1 : se connecter a la BD
            SqlConnection mycon = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BanqueDB;Integrated Security=True");
            mycon.Open();

            // etape 2 : creer la commande 
            string sql = "SELECT * FROM Clients";
            SqlCommand mycmd = new SqlCommand(sql, mycon);

            //etape 3 : creer le datareader
            SqlDataReader myRder = mycmd.ExecuteReader();

            //Boucle de copie de datareader vers clsListClient
            while (myRder.Read()==true) 
            {
                string num = myRder["Numero"].ToString();
                string nom = myRder["Nom"].ToString();
                string nip = myRder["Nip"].ToString();
                string stat = myRder["Statut"].ToString();
                clsClient clientTmp = new clsClient(num,nom,nip,stat);
                tousClient.Ajouter(clientTmp);
            }
            myRder.Close();
            mycon.Close();

            return tousClient;
        }


        public static clsListCompte RecupererLesComptesDuClient(string ClientNum)
        {
            clsListCompte LesComptesDuClient = new clsListCompte();

            // se connecter a la BD pour recuperer la table client 

            // etape 1 : se connecter a la BD
            SqlConnection mycon = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BanqueDB;Integrated Security=True");
            mycon.Open();

            // etape 2 : creer la commande 
            string sql = "SELECT * FROM Comptes WHERE NumeroClient='" + ClientNum +"'";
            SqlCommand mycmd = new SqlCommand(sql, mycon);

            //etape 3 : creer le datareader
            SqlDataReader myRder = mycmd.ExecuteReader();

            //Boucle de copie de datareader vers clsListClient
            while (myRder.Read() == true)
            {
                string num = myRder["Numero"].ToString();
                string type = myRder["Type"].ToString();
                int jour = Convert.ToDateTime(myRder["DateOuverture"]).Day;
                int moi = Convert.ToDateTime(myRder["DateOuverture"]).Month;
                int an = Convert.ToDateTime(myRder["DateOuverture"]).Year;
                decimal sold = Convert.ToDecimal(myRder["Solde"]);
                string stat = myRder["Statut"].ToString();

                clsCompte comptetmp = new clsCompte(num,type,jour,moi,an,sold,stat);
                LesComptesDuClient.Ajouter(comptetmp);

            }
            myRder.Close();
            mycon.Close();












            return LesComptesDuClient;
        }
    }
}