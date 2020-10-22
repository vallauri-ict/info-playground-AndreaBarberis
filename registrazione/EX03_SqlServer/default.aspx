<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="EX03_SqlServer._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>REGISTRAZIONE</h1>
            <asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>
            <asp:TextBox ID="txtNome" runat="server" OnTextChanged="txtNome_TextChanged"></asp:TextBox>
            <asp:Label ID="Cognome" runat="server" Text="Cognome"></asp:Label>
            <asp:TextBox ID="txtCognome" runat="server" OnTextChanged="txtCognome_TextChanged"></asp:TextBox> 
            <br />
            <asp:Label ID="Label3" runat="server" Text="Data_nascita (solo anno)"></asp:Label>
            <asp:TextBox ID="TxtData" runat="server" OnTextChanged="TxtData_TextChanged" TextMode="Date"></asp:TextBox>
            <%--<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>--%>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
            <asp:TextBox  ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="lblRegioni" runat="server" Text="Regioni"></asp:Label>
            <asp:DropDownList ID="cmbRegioni" runat="server" OnSelectedIndexChanged="cmbRegioni_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <asp:Label ID="lblProvince" runat="server" Text="Province" ></asp:Label>
            <asp:DropDownList ID="cmbProvince" runat="server" OnSelectedIndexChanged="cmbProvince_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <asp:Label ID="lblComuni" runat="server" Text="Comune" ></asp:Label>
            <asp:DropDownList ID="cmbComuni" runat="server"></asp:DropDownList>
            <br />
            <asp:Button ID="btnInvia" runat="server" Text="Invia" OnClick="btnInvia_Click" />
            <br />
            <asp:label id="messaggio" runat="server" Text="..."></asp:label>
            <br />
            <br />
            <h1 id="H1Saluto" runat="server"></h1>
        </div>
    </form>
</body>
</html>
