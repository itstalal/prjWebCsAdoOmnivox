<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inscrireOmnivox.aspx.cs" Inherits="prjWebCsAdoOmnivox.inscrireOmnivox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        table{
            width:500px;
            background-color:aquamarine;
            border:2px solid;
            border-radius:5px;
            font-weight:bold;
            margin:auto;
            padding:4px;
            border-spacing:2px;
        }
        body{
            background-color:dodgerblue;
        }
        .boite{
            width:250px;
            color:blue;
            font-weight:bold;
            border-radius:3px;
        }
        .bouton{
            width:200px;
            color:white;
            background-color:orange;
            font-weight:bold;
            border-radius:6px;
            height:25px;
        }


    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align:center">
                TECCART - OMNIVOX<br /> Inscription du Nouveau Membre
            </h1>
            <hr style="width:800px" />
            <table>
                <tr>
                    <td>   Numero Etudiant :  </td>
                    <td>
                        <asp:TextBox ID="txtNumero" CssClass="boite" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>   Date de Naissance :  </td>
                    <td>
                        <asp:TextBox ID="txtNaissance" TextMode="Date"  CssClass="boite" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>   Email Etudiant :  </td>
                    <td>
                        <asp:TextBox ID="txtEmail" TextMode="Email"  CssClass="boite" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>   Mot de passe :  </td>
                    <td>
                        <asp:TextBox ID="txtMotdepasse" TextMode="Password"  CssClass="boite" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>Confirmer Mot de passe:  </td>
                    <td>
                        <asp:TextBox ID="txtMotdepasse2" TextMode="Password"  CssClass="boite" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>

                <tr>
                    <td style="text-align:center">
                        <asp:Button ID="bntInscrire" OnClick="bntInscrire_Click" CssClass="bouton" runat="server" Text="Inscrire Membre" />
                    </td>
                    <td style="text-align:center" colspan="2">
                         <asp:Button ID="btnRecommencer" CssClass="bouton" runat="server" Text="Effacer Recommencer" />
                    </td>
                </tr>

                <tr>
                    <td colspan="3" style="text-align:center">
                        <asp:Label ID="lblErreur" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>  
                    </td>
                </tr>
                 <tr>
                    <td colspan="3" style="text-align:center">
                        <asp:ValidationSummary ID="ValidationSummary1" Font-Bold="true" ForeColor="Red" runat="server" />
                    </td>
                </tr>



            </table>
        </div>
    </form>
</body>
</html>
