<%@ Page Title="SISFREQ - Login" Language="C#" MasterPageFile="~/Layouts/MPExterna.Master" AutoEventWireup="true" CodeBehind="pgLogin.aspx.cs" Inherits="Apresentacao.Pages.pgLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <ul class="nav navbar-nav navbar-right">
            <li>
                <a>Efetue login a baixo, para acessar as ferramentas administrativa</a>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label ID="lblMensagem" CssClass="alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center" runat="server" Text="Preencha os dados corretamente!" Visible="false"></asp:Label>
        </div>
    </div>
    <div class="col-sm-4 col-xs-4 col-md-4 col-lg-4 col-sm-offset-4 col-xs-offset-4 col-md-offset-4 col-lg-offset-4">
        <fieldset>
            <legend>Área de Login</legend>
            <div class="form-group">
                <asp:TextBox CssClass="form-control" ID="txtMatricula" PlaceHolder="Matricula" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox CssClass="form-control" ID="txtSenha" TextMode="Password" PlaceHolder="Senha" runat="server"></asp:TextBox>
            </div>


            <div class=" input-group btn-group col-sm-10 col-md-10 col-lg-10 col-xs-10 col-sm-offset-1 col-md-offset-1 col-lg-offset-1 col-xs-offset-1">
                <asp:Button ID="btnLogar" OnClick="btnLogar_Click" CssClass="btn btn-primary col-sm-6 col-md-6 col-lg-6 col-xs-6" runat="server" Text="Logar" />
                <asp:Button ID="btnCancelar" CssClass="btn btn-danger col-sm-6 col-md-6 col-lg-6 col-xs-6" runat="server" Text="Cancelar" />
            </div>

        </fieldset>
    </div>
</asp:Content>
