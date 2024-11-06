using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using prjWebCsBankGab.App_Code;

namespace prjWebCsBankGab.App_Code
{
    public class clsCompte
    {
        private string numero;
        private string type;
        private clsDate2 dateOuverture;
        private decimal solde;
        private string statut;

        public clsCompte(string numero, string type, int jour, int mois, int annee, decimal solde, string statut)
        {
            this.numero = numero;
            this.type = type;
            this.dateOuverture = new clsDate2(jour,mois,annee);
            this.solde = solde;
            this.statut = statut;

             
        }

        public clsCompte()
        {
            numero = type = statut = "Non definie";
            dateOuverture = new clsDate2();
            solde = -1;

        }

        public string Numero
        {
            get => numero;
           
        }

        public string Type
        {
            get => type;
            set
            {
                type = value;
            }
        }

        public clsDate2 DateOuverture
        {
            get => dateOuverture;
           
        }

        public decimal Solde
        {
            get => solde;
            
        }

        public string Statut
        {
            get => statut;
            set
            {
                statut = value;
            }
        }

        public void Ouvrir(string numero, string type)
        {
            this.numero = numero;
            this.type = type;
            dateOuverture = new clsDate2(DateTime.Today.Day,
                DateTime.Today.Month,DateTime.Today.Year);
            solde = 0;
            statut = "actif";
        }

        public bool Deposer(decimal montant)
        {
           if(montant >= 2 && montant <= 20000)
            {
                solde = solde + montant;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Retourne 0:pour succes , -1:pour minimum, -2:pour maximum,
        /// 1:pour fonds insuffisants, 2:pour multiple de 20
        /// </summary>
        
        public int Retirer(decimal montant)
        {
           if(montant < 20) { return -1; }
           else if(montant > 500) {  return -2; }
           else if((montant % 20) != 0) {  return 2;}
           else if(montant >solde) { return 1; }
            else
            {
                solde = solde - montant;
                return 0;
            }

        }

        public string Consulter()
        {
            string info = "Numero : " + numero + "<br />Type : " +
                type + "<br />Date Ouverture : " + dateOuverture.Enchiffre() +
                "<br />Solde : " + solde + "<br />Statut : " + statut;
            return info;
        }

        public void Fermer()
        {
            statut = "Fermer";
        }
    }
}