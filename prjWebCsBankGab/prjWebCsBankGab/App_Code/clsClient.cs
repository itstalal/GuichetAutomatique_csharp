using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace prjWebCsBankGab.App_Code
{
    public class clsClient
    {
        private string numero;
        private string nom;
        private string nip;
        private clsListCompte comptes;
        private string statut;

        public clsClient()
        {
            numero = nom = nip = statut = "Non definie";
            comptes = new clsListCompte();
        }

        public clsClient(string numero, string nom, string nip, clsListCompte comptes, string statut)
        {
            this.numero = numero;
            this.nom = nom;
            this.nip = nip;
            this.comptes = comptes;
            this.statut = statut;
        }

        public clsClient(string numero, string nom, string nip, string statut)
        {
            this.numero = numero;
            this.nom = nom;
            this.nip = nip;
            this.comptes = new clsListCompte();
            this.statut = statut;
        }
        //rr
        public string Numero
        {
            get => numero;

        }

        public string Nom
        {
            get => nom;
            set
            {
                nom = value;
            }
        }

        public string Nip
        {
            get => nip;
            set
            {
                nip = value;
            }
        }

        public clsListCompte Comptes
        {
            get => comptes;
            set
            {
                comptes = value;
            }
        }

        public string Statut
        {
            get => statut;
            set
            {
                statut = value;
            }
        }

        public void Inscrire(string numero, string nom, string nip)
        {
            this.numero = numero;
            this.nom = nom;
            this.nip = nip;
            this.comptes = new clsListCompte();
            this.statut = "actif";
        }

        public void Annuler()
        {
            statut = "inactif";
        }

        public string Afficher()
        {
            string info = "Numero: " + numero + "<br />Nom: " + nom +
                "<br />" + nip + "<br />Statut: " + Statut +
                "<br /> ses comptes: " + comptes.Afficher();
            return info;
        }
    }
}