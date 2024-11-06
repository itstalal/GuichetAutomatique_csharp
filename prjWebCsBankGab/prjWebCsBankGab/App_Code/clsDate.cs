using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjWebCsBankGab.App_Code
{
    public class clsDate
    { 
        // proprietes
        private int vJour;
        private int vMois;
        private int vAnnee;

        // getter et setter
        public int Jour
        {
            get
            {
                return vJour;
            }
            set
            {
                if(value >0 && value <= 31)
                {
                vJour = value;
                }
                else
                {
                    vJour = 1;
                }
            }
        }

        public int Mois
        {
            get
            {
                return vMois;
            }
            set
            {
                if(value >0 && value <= 12)
                {
                vMois = value;
                }
                else
                {
                    vMois = 1;
                }
            }
        }

        public int Annee
        {
            get
            {
                return vAnnee;
            }
            set
            {
                if(value>1900 && value <= 2024)
                {
                    vAnnee = value;
                }
                else
                {
                    vAnnee = 2024;
                }
            }
        }

        // constructeurs
        public clsDate()
        {
            vJour = DateTime.Now.Day;
            vMois = DateTime.Now.Month;
            vAnnee = DateTime.Now.Year;
        }
        public clsDate(int jour , int mois , int annee)
        {
            Jour = DateTime.Now.Day;
            Mois = DateTime.Now.Month;
             Annee = DateTime.Now.Year;
        }
         // methodes
        public void Ajuster(int jour , int mois , int annee)
        {
            Jour = jour;
            Mois = mois;
            Annee = annee;
        }
         
        public string EnChiffre()
        {
            return Jour + "/" + Mois + "/" + Annee;
        }

        public string Enlettre()
        {
            string moisenlettre;
            string jourenlettre = "";

            
            DateTime date = new DateTime(Annee, Mois, Jour);
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    jourenlettre = "Lundi";
                    break;
                case DayOfWeek.Tuesday:
                    jourenlettre = "Mardi";
                    break;
                case DayOfWeek.Wednesday:
                    jourenlettre = "Mercredi";
                    break;
                case DayOfWeek.Thursday:
                    jourenlettre = "Jeudi";
                    break;
                case DayOfWeek.Friday:
                    jourenlettre = "Vendredi";
                    break;
                case DayOfWeek.Saturday:
                    jourenlettre = "Samedi";
                    break;
                case DayOfWeek.Sunday:
                    jourenlettre = "Dimanche";
                    break;
            }

            switch (Mois)
            {
                case 1:
                    moisenlettre = "Janvier";
                    break;
                case 2:
                    moisenlettre = "Fevrier";
                    break;
                case 3:
                    moisenlettre = "Mars";
                    break;
                case 4:
                    moisenlettre = "Avril";
                    break;
                case 5:
                    moisenlettre = "Mai";
                    break;
                case 6:
                    moisenlettre = "Juin";
                    break;
                case 7:
                    moisenlettre = "Juillet";
                    break;
                case 8:
                    moisenlettre = "Aout";
                    break;
                case 9:
                    moisenlettre = "Septembre";
                    break;
                case 10:
                    moisenlettre = "Octobre";
                    break;
                case 11:
                    moisenlettre = "Novembre";
                    break;
                case 12:
                    moisenlettre = "Decembre";
                    break;
                default:
                    moisenlettre = "invalide";
                    break;
            }
            return jourenlettre + " le " + Jour + moisenlettre + " " + Annee;
        }


    }
}