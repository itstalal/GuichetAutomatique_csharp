using prjWebCsBankGab.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsBankGab
{
    public partial class WebGuichetATM : System.Web.UI.Page
    {
        //declaration des variables globales
        static clsGuichet monGuichet;
        static clsClient clientourant;
        static clsCompte comptecourant;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false) //ce code s'execute une seule fois
            {
                // creation et instanciation du clsGuichet
                monGuichet = new clsGuichet("gui001","TD","Teccart","actif",200000);
                monGuichet.Clients = clsSourceDeDonnees.RecupererTousLesClients();

                panClientNumero.Visible = true;
                panClientNip.Visible = false;
                panComptes.Visible = false;
                panTransaction.Visible = false;
                panInfoCompte.Visible = false;
                txtNumero.Focus();
            }
        }

        protected void btnValiderNumero_Click(object sender, EventArgs e)
        {
            // recuperer le numero de client saisi
            string numeroClient = txtNumero.Text.Trim();
            // trouver le client dans la liste des clients du guichet
            clientourant = monGuichet.Clients.Trouver(numeroClient);
            // tester le resultat de la recherche
            if (clientourant == null)
            {
                lblErreurNumero.Text = "Numero de client introuvable. Essayer de nouveau";
                txtNumero.Focus();
            }
            else
            {              
                  panClientNumero.Visible = false;
                // affichage de panel du nip
                  panClientNip.Visible = true;
                  txtNip.Focus();
                //afichage d'erreur
                lblErreurNip.Text = "Bienvenue" + clientourant.Nom;
            }
        }

        protected void btnSuivantNip_Click(object sender, EventArgs e)
        {
            // recuperer le nip saisi
            string nipsaisi = txtNip.Text.Trim();
            // verifier nip
            if(clientourant.Nip != nipsaisi)
            {
                lblErreurNip.Text = "Nip invalide! Essayer de nouveau";
                txtNip.Text = " ";
                txtNip.Focus();
            }
            else
            {
                // client trouve et verifie (par nip) maintenant
                // il faut ramener les comptes de ce client
                clientourant.Comptes = clsSourceDeDonnees.RecupererLesComptesDuClient(clientourant.Numero);
                panClientNip.Visible = false;
                panComptes.Visible = true;
                // remplir le combox avec les comptes de client(type et numero)
                foreach(clsCompte unCpt in clientourant.Comptes.Elements)
                {
                    ListItem elmt = new ListItem();
                    elmt.Text = unCpt.Type;
                    elmt.Value = unCpt.Numero;
                    cboComptes.Items.Add(elmt);
                }
            }
        }

        protected void btnSuivantCompte_Click(object sender, EventArgs e)
        {
            string numCompteChoisi = cboComptes.SelectedItem.Value;
            comptecourant = clientourant.Comptes.Trouver(numCompteChoisi);

            panComptes.Visible = false;
            panTransaction.Visible = true;
            txtDeposer.Visible = false;
            txtRetirer.Visible = false;
            radConsulter.Checked = true;
        }

        protected void btnExecuterTransaction_Click(object sender, EventArgs e)
        {
            if(radDeposer.Checked == true)
            {
                decimal montant =Convert.ToDecimal(txtDeposer.Text);
                if( comptecourant.Deposer(montant) == false)
                {
                    lblErreurTransaction.Text = "Erreur Depot : Montant doit etre entre 2 et 20000.";
                    txtDeposer.Focus();
                    return;
                }
                
                
            }
            if (radRetirer.Checked == true)
            {
                decimal montant = Convert.ToDecimal(txtRetirer.Text);
                int result = comptecourant.Retirer(montant);
                switch (result)
                {
                    case -1:
                        lblErreurTransaction.Text = "Erreur retrait: le montant minimum est 20";
                        return;
                    case -2:
                        lblErreurTransaction.Text = "Erreur retrait: le montant maximum est 500";
                        return;
                    case 2:
                        lblErreurTransaction.Text = "Erreur retrait: le montant doit etre un multiple de 20";
                        return;
                    case 1:
                        lblErreurTransaction.Text = "Erreur retrait: Fonds insufisants, solde disponible est"+comptecourant.Solde;
                        return;


                }
            }
            lblCompteInfos.Text = comptecourant.Consulter();
            panTransaction.Visible = false;
            panInfoCompte.Visible = true;
        }

        protected void btnTerminer_Click(object sender, EventArgs e)
        {
            panClientNumero.Visible = true;
            panClientNip.Visible = false;
            panComptes.Visible = false;
            panTransaction.Visible = false;
            panInfoCompte.Visible = false;
            txtNumero.Focus();
            //nottoyer tous les affichages
            lblCompteInfos.Text = "";
            lblCompteInfos.Text = "";
            lblErreurNip.Text = "";
            lblErreurNumero.Text = lblErreurTransaction.Text = "";
            txtDeposer.Text = txtNip.Text = txtNumero.Text = txtDeposer.Text = txtRetirer.Text = "";
        }

        protected void radDeposer_CheckedChanged(object sender, EventArgs e)
        {
            txtDeposer.Text = "";
            txtDeposer.Visible = true;
            txtRetirer.Text = "";
            txtRetirer.Visible = false;
            txtDeposer.Focus();
        }

        protected void radRetirer_CheckedChanged(object sender, EventArgs e)
        {
            txtRetirer.Text = "";
            txtRetirer.Visible = true;
            txtDeposer.Text = "";
            txtDeposer.Visible = false;
            txtRetirer.Focus();
        }

        protected void radConsulter_CheckedChanged(object sender, EventArgs e)
        {
            txtRetirer.Text = "";
            txtRetirer.Visible = false;
            txtDeposer.Text = "";
            txtDeposer.Visible = false;
            txtRetirer.Focus();
        }
    }
}

