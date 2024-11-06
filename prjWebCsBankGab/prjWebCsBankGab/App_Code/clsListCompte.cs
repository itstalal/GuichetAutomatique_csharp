using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

namespace prjWebCsBankGab.App_Code
{
    public class clsListCompte
    {
        // cacher ou encapsuler une collection dictionnary 
        // et utiliser ses methodes necessaires
        private Dictionary<string, clsCompte> ListeCachee;

        public clsListCompte()
        {
            ListeCachee = new Dictionary<string, clsCompte>();

        }

        public int Nombre
        {
            get { return ListeCachee.Count; }
        }

        public Dictionary<string, clsCompte>.ValueCollection Elements
        {
            get => ListeCachee.Values;
        }

        public bool Ajouter(clsCompte unCompte)
        {
            if(ListeCachee.ContainsKey(unCompte.Numero) == false)
            {
                ListeCachee.Add(unCompte.Numero, unCompte);
                return true;
            }
            else { return false; }
        }

        public bool Supprimer(string numero)
        {
           return ListeCachee.Remove(numero);
        }

        public clsCompte Trouver(string numero)
        {
            if(ListeCachee.ContainsKey(numero) == true) 
            {
                return ListeCachee[numero];
            }
            else { return null; }
        }

        public bool Existe(string numero)
        {
            return ListeCachee.ContainsKey(numero);
        }

        public string Afficher()
        {
            string info = "<br />Liste de comptes <br /> ";
            foreach(clsCompte unCpt in ListeCachee.Values)
            {
                info += unCpt.Consulter() + "<br />-----------<br />";
            }
            return info;
        }
    }
}