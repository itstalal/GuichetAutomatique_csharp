using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjWebCsBankGab.App_Code
{
    public class clsDate2
    {
        //champs prives pour stoquer les valeur des proprietes
        private int jour;
        private int mois;
        private int annee;

        //Declaration de constructeur
        public clsDate2(int jour, int mois, int annee)
        {
            Jour = jour;
            Mois = mois;
            Annee = annee;
        }

        public clsDate2()
        {
            Jour = 1;
            Mois = 1;
            Annee = 1;
        }

        //declaration des proprietes publiques
        public int Jour
        {
            get => jour;
            set => jour = (value<=31 && value>=1) ? value : 1; }
        public int Mois
        { 
            get => mois;
            set => mois = (value <= 12 && value >= 1) ? value : 1;
        }
        public int Annee 
        { 
            get => annee;
            set => annee = (value > 0) ? value : 1;
        }

        // declaration des methodes
        public void Ajuster(int jour , int mois, int annee )
        {
            Jour = jour;
            Mois = mois;
            Annee = annee;
        }

        public string Enchiffre()
        {
            return jour +"/"+ Mois +"/" +annee;
        }

    }
}