﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Hoja.Master" AutoEventWireup="true" CodeBehind="wTecnicos.aspx.cs" Inherits="Ex2R.wTecnicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1>Tecnicos</h1>
        <p>&nbsp;</p>
    </div>
    <div>
        <br />
        <br />
        <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True" />

        <br />
        <br />
        <br />

    </div>
    <div class="container text-center">
       IDtecnico: <asp:TextBox ID="txtID" class="form-control" runat="server"></asp:TextBox>
       Nombre: <asp:TextBox ID="txtNombre" class="form-control" runat="server"></asp:TextBox>
       Especialidad: <asp:TextBox ID="txtEspecialidad" class="form-control" runat="server"></asp:TextBox>

    </div>
    <div class="container text-center">

        <asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Agregar" />
        <asp:Button ID="Button2" class="btn btn-outline-secondary" runat="server" Text="Borrar"/>
        <asp:Button ID="Button3" runat="server" class="btn btn-outline-danger" Text="Modificar" />
        <asp:Button ID="Bconsulta" runat="server" class="btn btn-outline-danger" Text="Consultar"/>
        

    </div>

</asp:Content>