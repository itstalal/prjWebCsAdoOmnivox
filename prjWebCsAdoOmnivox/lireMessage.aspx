<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lireMessage.aspx.cs" Inherits="prjWebCsAdoOmnivox.lireMessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Omnivox - Lecture du Message</title>
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
            max-width: 60%;
            margin: 0 auto;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
            text-align: center;
        }

        #lblMessage {
            display: block;
            margin: 20px 0;
            padding: 15px 20px;
            color: #333333;
            background-color: #e0f7fa;
            border-radius: 5px;
            font-size: 18px;
            line-height: 1.5;
            text-align: left;
            white-space: pre-wrap;
        }

        #btnRetourner {
            padding: 10px 20px;
            background-color: #33cc33;
            color: #ffffff;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            font-weight: bold;
            cursor: pointer;
            transition: background-color 0.3s ease;
            text-decoration: none;
            display: inline-block;
        }

        #btnRetourner:hover {
            background-color: #28a745;
        }

        @media screen and (max-width: 768px) {
            h1 {
                font-size: 28px;
            }

            .container {
                max-width: 90%;
            }

            #lblMessage {
                font-size: 16px;
                padding: 10px 15px;
            }

            #btnRetourner {
                font-size: 14px;
                padding: 8px 15px;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>OMNIVOX - INSTITUT TECCART<br />Lecture du Message</h1>
            <hr />
            <asp:Label ID="lblMessage" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
            <br />
            <asp:Button ID="btnRetourner" OnClick="btnRetourner_Click" runat="server" Text="Retourner à la boîte de messages" />
        </div>
    </form>
</body>
</html>
