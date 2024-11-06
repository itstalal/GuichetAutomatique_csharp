using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjWebCsBankGab.App_Code
{
    public class clsTime
    {
        // declaration des champs prives qui vont stocker les valeurs de nos proprietes
        private int vHeure;
        private int vMinute;
        private int vSeconde;

        // declaration des proprietes public ou les getters et setters
        public int Heure
        {
            get //access en lecture au champ vHeure
            {
                return vHeure;
            }
            set //access en ecriture au champ vHeure
            {
               vHeure = (value >=0 && value<=23)? value : 0;
            }
        }

        public int Minute
        {
            get //access en lecture au champ vMinute
            {
                return vMinute;
            }
            set //access en ecriture au champ vMinute
            {
                vMinute = (value >= 0 && value <= 59) ? value : 0;
            }
        }

        public int Seconde
        {
            get //access en lecture au champ vSeconde
            {
                return vSeconde;
            }
            set //access en ecriture au champ vSeconde
            {
                vSeconde = (value >= 0 && value <= 59) ? value : 0;
            }
        }
        // declaration des constructeurs
        public clsTime()
        {
            vHeure = DateTime.Now.Hour;
            vMinute = DateTime.Now.Minute;
            vSeconde= DateTime.Now.Second;
        }
        public clsTime(int heure , int minute , int seconde)
        {
            Heure = heure;
            Minute = minute;
            Seconde= seconde;
        } 



        // declaration des methodes publiques
        public void Regler(int heure, int minute, int seconde)
        {
            Heure = heure;
            Minute = minute;
            Seconde = seconde;
        }

        public string EnUniversel()
        {
            return Heure + ":" + Minute + ":" + Seconde;
        }
    }
}