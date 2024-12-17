<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="acceuilOmnivox.aspx.cs" Inherits="prjWebCsAdoOmnivox.acceuilOmnivox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Omnivox - Boîte de Réception</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f9f9f9;
        }

        h1 {
            color: #004d99;
            font-size: 36px;
            margin: 20px auto;
            text-align: center;
            font-weight: bold;
            line-height: 1.4;
        }

        hr {
            border: none;
            height: 2px;
            background: linear-gradient(to right, #33cc33, #004d99);
            margin-bottom: 20px;
        }

        .container {
            max-width: 90%;
            margin: 0 auto;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
        }

        #lblMessage {
            display: block;
            margin: 20px 0;
            padding: 10px 15px;
            color: #ffffff;
            background-color: #004d99;
            border-radius: 5px;
            font-size: 18px;
            text-align: center;
        }

        #tabMessages {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
            background-color: #ffffff;
            overflow-x: auto;
            text-align: left;
        }

        #tabMessages th, #tabMessages td {
            padding: 15px;
            text-align: center;
            font-size: 16px;
        }

        #tabMessages th {
            background-color: #33cc33;
            color: white;
            font-size: 18px;
        }

        #tabMessages tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        #tabMessages tr:hover {
            background-color: #e0f7e0;
        }

        #tabMessages td a {
            text-decoration: none;
            color: #004d99;
            font-weight: bold;
            transition: color 0.3s ease;
        }

        #tabMessages td a:hover {
            color: #33cc33;
        }

        @media screen and (max-width: 768px) {
            h1 {
                font-size: 28px;
            }

            #lblMessage {
                font-size: 16px;
            }

            #tabMessages th, #tabMessages td {
                font-size: 14px;
                padding: 10px;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>OMNIVOX - INSTITUT TECCART<br />Boîte des Messages Reçus</h1>
            <hr />
            <asp:Label ID="lblMessage" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
            <br />
            <asp:Table ID="tabMessages" GridLines="Both" runat="server" CellPadding="1" CellSpacing="1">
            </asp:Table>
        </div>
    </form>
</body>
</html>
