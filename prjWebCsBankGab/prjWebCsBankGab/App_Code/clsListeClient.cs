using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using prjWebCsBankGab.App_Code;

namespace prjWebCsBankGab.App_Code
{

    public class clsListeClient
    {
        // cacher ou encapsuler une collection dictionnary 
        // et utiliser ses methodes necessaires
        private Dictionary<string, clsClient> ListeCachee;

        public clsListeClient()
        {
            ListeCachee = new Dictionary<string, clsClient>();

        }

        public int Nombre
        {
            get { return ListeCachee.Count; }
        }

        public Dictionary<string, clsClient>.ValueCollection Elements
        {
            get => ListeCachee.Values;
        }

        public bool Ajouter(clsClient unClient)
        {
            if (ListeCachee.ContainsKey(unClient.Numero) == false)
            {
                ListeCachee.Add(unClient.Numero, unClient);
                return true;
            }
            else { return false; }
        }

        public bool Supprimer(string numero)
        {
            return ListeCachee.Remove(numero);
        }

        public clsClient Trouver(string numero)
        {
            if (ListeCachee.ContainsKey(numero) == true)
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
            string info = "<br />Liste de clients <br /> ";
            foreach (clsClient unCpt in ListeCachee.Values)
            {
                info += unCpt.Afficher() + "<br />-----------<br />";
            }
            return info;
        }
    }
}