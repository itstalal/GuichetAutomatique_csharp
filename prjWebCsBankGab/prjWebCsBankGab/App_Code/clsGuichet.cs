using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace prjWebCsBankGab.App_Code
{
    public class clsGuichet
    {
        private string numero;
        private string compagnie;
        private string adresse;
        private clsListeClient clients;
        private string statut;
        private decimal solde;

        public string Numero
        { get => numero; set => numero = value; }
        public string Compagnie
        { get => compagnie; set => compagnie = value; }
        public string Adresse
        { get => adresse; set => adresse = value; }
        public clsListeClient Clients
        { get => clients; set => clients = value; }
        public string Statut
        { get => statut; set => statut = value; }
        public decimal Solde
        { get => solde; set => solde = value; }

        public clsGuichet()
        {
            numero = "Non defini";
            compagnie = "Non defini";
            adresse = "Non defini";
            clients = new clsListeClient();
            statut = "Non defini";
            solde = -1;
        }


        public clsGuichet(string numero, string compagnie, string adresse, string statut, decimal solde)
        {
            this.numero = numero;
            this.compagnie = compagnie;
            this.adresse = adresse;
            clients = new clsListeClient();
            this.statut = statut;
            this.solde = solde;
        }

        public clsGuichet(string numero, string compagnie, string adresse, clsListeClient clients, string statut, int solde)
        {
            this.numero = numero;
            this.compagnie = compagnie;
            this.adresse = adresse;
            this.clients = clients;
            this.statut = statut;
            this.solde = solde;
        }

        public void Ouvrir()
        {
            statut = "actif";

        }

        public void Remplir(decimal montant)
        {
            solde = montant;
            statut = "actif";
        }

        public void Fermer()
        {
            statut = " inactif";
        }
    }
}