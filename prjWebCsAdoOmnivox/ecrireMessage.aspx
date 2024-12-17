<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ecrireMessage.aspx.cs" Inherits="prjWebCsAdoOmnivox.ecrireMessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align:center">OMNIVOX - INSTITUT TECCART<br />Composition De Nouveau Message</h1>
<hr />
            <table style="font-weight:bold;margin:auto;background-color:aquamarine;color:black">
                <tr>
                    <td>Destinataire :  </td>
                    <td>
                        <asp:DropDownList ID="cboDestinataires" Width="500px" runat="server"></asp:DropDownList>
                    </td>

                </tr>
                <tr>
                    <td>Sujet  :  </td>
                    <td>
                        <asp:TextBox ID="txtSujet" runat="server" Width="500px"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td style="vertical-align:top">Message  :  </td>
                    <td>
                        <asp:TextBox ID="txtMessage" TextMode="MultiLine" Height="500px" Width="500px" runat="server"></asp:TextBox>
                    </td>

                </tr>

                <tr>
                    <td>
                        <asp:Button ID="btnEnvoyer" Font-Bold="true" ForeColor="White" BackColor="Black" runat="server" Text="Envoyer" />
                    </td>
                    <td>
                       <asp:Button ID="btnAnnuler" Font-Bold="true" ForeColor="White" BackColor="Black" runat="server" Text="Annuler" />
                        <asp:Button ID="btnEffacer" Font-Bold="true" ForeColor="White" BackColor="Black" runat="server" Text="Effacer" />
                    </td>

                </tr>



            </table>
        </div>
    </form>
</body>
</html>
