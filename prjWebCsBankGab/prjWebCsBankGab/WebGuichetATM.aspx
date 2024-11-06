<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebGuichetATM.aspx.cs" Inherits="prjWebCsBankGab.WebGuichetATM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        h1{
            text-align:center;
            background-color:forestgreen;
            color:white;
        }
        #grandtableau{
            margin:auto;
        }
        .bordureRonde{
            border-radius:10px;
        }
        .boite{
            border-radius:5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <hr />
            <h1>BANQUE TALAL</h1>
            <h1>Guichet Automatique</h1>

            <hr />

            <table id="grandtableau" >
                <tr>
                    <td>
                        <asp:Panel ID="panClientNumero" runat="server" Width="500px" CssClass="bordureRonde" GroupingText="Client Identification" BackColor="#ccffff" BorderColor="Green" BorderWidth="4px" Font-Bold="True" Font-Size="Large">
                            <table>
                                <tr>
                                    <td>Entrez votre numero de client : </td>
                                    <td>
                                        <asp:TextBox ID="txtNumero" Width="200px" Font-Bold="true" CssClass="boite" Font-Size="Large" runat="server" ForeColor="Navy"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAnnulerNumero" runat="server" Width="150px" BackColor="Green" Font-Bold="true" CssClass="boite" Font-Size="Large" ForeColor="White" Text="Annuler " />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnValiderNumero" OnClick="btnValiderNumero_Click" runat="server" Width="150px" BackColor="Green" Font-Bold="true" CssClass="boite" Font-Size="Large" ForeColor="White" Text=" Suivant >> " />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblErreurNumero" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>

                            </table>
                        </asp:Panel>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Panel ID="panClientNip" runat="server" Width="500px" CssClass="bordureRonde" GroupingText="Verification Nip Client" BackColor="#ccffcc" BorderColor="Green" BorderWidth="4px" Font-Bold="True" Font-Size="Large">
                            <table>
                                 <tr>
                                    <td>Entrez votre nip de client : </td>
                                    <td>
                                        <asp:TextBox ID="txtNip" TextMode="Password" Width="200px" Font-Bold="true" Font-Size="Large" runat="server" ForeColor="Navy"></asp:TextBox>
                                    </td>
                                 </tr>
                                 <tr>
                                    <td>
                                        <asp:Button ID="btnAnnulerNip" runat="server" Width="150px" BackColor="Green" Font-Bold="true" CssClass="boite" Font-Size="Large" ForeColor="White" Text="Annuler " />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSuivantNip" OnClick="btnSuivantNip_Click" runat="server" Width="150px" BackColor="Green" Font-Bold="true" CssClass="boite" Font-Size="Large" ForeColor="White" Text=" Suivant >> " />
                                    </td>
                                 </tr>
                                 <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblErreurNip" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                    </td>
                                  </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Panel ID="panComptes" runat="server" Width="500px" CssClass="bordureRonde" GroupingText="Selection Compte Client" BackColor="#ccffff" BorderColor="Green" BorderWidth="4px" Font-Bold="True" Font-Size="Large">
                            <table>
                                <tr>
                                    <td>Choisir le type de compte : </td>
                                    <td>
                                          <asp:DropDownList ID="cboComptes" Width="200px" Font-Bold="true" CssClass="boite" Font-Size="Large" runat="server" ForeColor="Navy"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAnnulerCompte" runat="server" Width="150px" BackColor="Green" Font-Bold="true" CssClass="boite" Font-Size="Large" ForeColor="White" Text="Annuler " />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSuivantCompte" OnClick ="btnSuivantCompte_Click" runat="server" Width="150px" BackColor="Green" Font-Bold="true" CssClass="boite" Font-Size="Large" ForeColor="White" Text=" Suivant >> " />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblErreurCompte" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Panel ID="panTransaction" runat="server" Width="500px" CssClass="bordureRonde" GroupingText="Choix Transactions Client " BackColor="#ccffcc" BorderColor="Green" BorderWidth="4px" Font-Bold="True" Font-Size="Large">
                            <table>
                                <tr>
                                    <td colspan="2">Choisissez votre Transaction et Entrez le Montant </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButton ID="radDeposer" OnCheckedChanged="radDeposer_CheckedChanged" GroupName="transac" AutoPostBack="true"  runat="server" Font-Bold="True" />
                                        Transaction Deposer
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDeposer" Width="50px" Font-Bold="true" Font-Size="Large" runat="server" ForeColor="Navy"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButton ID="radRetirer" OnCheckedChanged ="radRetirer_CheckedChanged" GroupName="transac" AutoPostBack="true"  runat="server" Font-Bold="True" />
                                        Transaction Retirer
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRetirer" Width="50px" Font-Bold="true" Font-Size="Large" runat="server" ForeColor="Navy"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButton ID="radConsulter" OnCheckedChanged="radConsulter_CheckedChanged" Checked="true" AutoPostBack="true"  GroupName="transac" runat="server" Font-Bold="True" />
                                        Transaction Consulter
                                    </td>
                                    <td>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAnnulerTransaction" runat="server" Width="150px" BackColor="Green" Font-Bold="true" CssClass="boite" Font-Size="Large" ForeColor="White" Text="Annuler " />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnExecuterTransaction" OnClick="btnExecuterTransaction_Click" runat="server" Width="150px" BackColor="Green" Font-Bold="true" CssClass="boite" Font-Size="Large" ForeColor="White" Text=" Suivant >> " />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblErreurTransaction" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                </td>
               </tr>

                <tr>
                    <td>
                        <asp:Panel ID="panInfoCompte" runat="server" Width="500px" CssClass="bordureRonde" GroupingText="Information Du Compte" BackColor="#ccffff" BorderColor="Green" BorderWidth="4px" Font-Bold="True" Font-Size="Large">
                            <table>
                               <tr>
                                  <td colspan="2">
                                        <asp:Label ID="lblCompteInfos" runat="server" ForeColor="#3333CC" Font-Bold="True" BorderStyle="Solid" BorderWidth="2px" Height="105px" Width="400px" ></asp:Label>
                                  </td>
                              </tr>
                              <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnTerminer" OnClick="btnTerminer_Click" runat="server" Width="250px" BackColor="Green" Font-Bold="true" CssClass="boite" Font-Size="Large" ForeColor="White" Text=" ^^ TERMINER ^^ " />
                                </td>
                              </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
