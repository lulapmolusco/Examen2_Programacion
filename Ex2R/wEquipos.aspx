<%@ Page Title="" Language="C#" MasterPageFile="~/Hoja.Master" AutoEventWireup="true" CodeBehind="wEquipos.aspx.cs" Inherits="Ex2R.wEquipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1>Equipos</h1>
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
        IDequipo: <asp:TextBox ID="txtID" class="form-control" runat="server"></asp:TextBox>
        TipoEquipo: <asp:TextBox ID="txtTipoE" class="form-control" runat="server"></asp:TextBox>
       Modelo: <asp:TextBox ID="txtModelo" class="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="container text-center">

        <asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Agregar" />
        <asp:Button ID="Button2" class="btn btn-outline-secondary" runat="server" Text="Borrar"/>
        <asp:Button ID="Button3" runat="server" class="btn btn-outline-danger" Text="Modificar" />
        <asp:Button ID="Bconsulta" runat="server" class="btn btn-outline-danger" Text="Consultar"/>
        

    </div>

</asp:Content>
