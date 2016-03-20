<%@ Page Title="SISFREQ - Registro de Frequência" Language="C#" MasterPageFile="~/Layouts/MPExterna.Master" AutoEventWireup="true" CodeBehind="pgFrequencia.aspx.cs" Inherits="Apresentacao.pgFrequencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <ul class="nav navbar-nav navbar-right">
            <li>
                <a href="Pages/pgLogin.aspx">Página Administrativa
                </a>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <div class="row">
            <asp:HiddenField ID="hfId" runat="server"></asp:HiddenField>
            <asp:Label ID="lblMensagem" CssClass="alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center" runat="server" Visible="false"></asp:Label>
        </div>
    </div>
    <asp:Panel ID="panelMatricula" runat="server">
        <div class="col-sm-4 col-md-4 col-lg-4 col-xs-4 col-sm-offset-4 col-md-offset-4 col-lg-offset-4 col-xs-offset-4">
            <div class="form-group">
                <h2 class="text-center">Digite a sua matrícula</h2>
                <asp:TextBox ID="txtMatricula" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="btn-group-lg col-sm-4 col-md-4 col-lg-4 col-xs-4 col-sm-offset-4 col-md-offset-4 col-lg-offset-4 col-xs-offset-4">
                <asp:Button ID="btnVerificar" runat="server" OnClick="btnVerificar_Click" Text="Verificar" CssClass="btn btn-default" />
            </div>
        </div>
    </asp:Panel>


    <asp:Panel ID="panelVerificar" Visible="false" runat="server">
        <div class="paddingC">
            <h2 class="text-center">Verifique os dados e informe a senha</h2>
        </div>

        <div class="col-sm-10 col-md-10 col-lg-10 col-xs-10 col-sm-offset-1 col-md-offset-1 col-lg-offset-1 col-xs-offset-1">

            <div class="form-group">
                <div class="form-group form-horizontal padding">
                    <label class="control-label col-sm-3 col-md-3 col-lg-3 col-xs-3">Nome:</label>
                    <div class="col-sm-8 col-md-8 col-lg-8 col-xs-8">
                        <asp:TextBox CssClass="form-control" ReadOnly="true" ID="txtVerificacaoNome" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group form-horizontal">
                    <label class="control-label col-sm-3 col-md-3 col-lg-3 col-xs-3">CPF:</label>
                    <div class="col-sm-8 col-md-8 col-lg-8 col-xs-8">
                        <asp:TextBox CssClass="form-control" ReadOnly="true" ID="txtVerificacaoCPF" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group form-horizontal">
                    <label class="control-label col-sm-3 col-md-3 col-lg-3 col-xs-3">Matrícula:</label>
                    <div class="col-sm-8 col-md-8 col-lg-8 col-xs-8">
                        <asp:TextBox CssClass="form-control" ReadOnly="true" ID="txtVerificacaoMatricula" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group form-horizontal">
                    <label class="control-label col-sm-3 col-md-3 col-lg-3 col-xs-3">Data de Nascimento:</label>
                    <div class="col-sm-8 col-md-8 col-lg-8 col-xs-8">
                        <asp:TextBox CssClass="form-control" ReadOnly="true" ID="txtVerificacaoNascimento" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group form-horizontal">
                    <label class="control-label col-sm-3 col-md-3 col-lg-3 col-xs-3">E-mail:</label>
                    <div class="col-sm-8 col-md-8 col-lg-8 col-xs-8">
                        <asp:TextBox CssClass="form-control" ReadOnly="true" ID="txtVerificacaoEmail" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group form-horizontal">
                    <label class="control-label col-sm-3 col-md-3 col-lg-3 col-xs-3">Senha:</label>
                    <div class="col-sm-8 col-md-8 col-lg-8 col-xs-8">
                        <asp:TextBox CssClass="form-control" TextMode="Password" ID="txtSenhaConfirmacao" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class=" input-group btn-group col-sm-6 col-md-6 col-lg-6 col-xs-6 col-sm-offset-3 col-md-offset-3 col-lg-offset-3 col-xs-offset-3">
                    <asp:Button ID="btnAutenticar" OnClick="btnAutenticar_Click" CssClass="btn btn-success col-sm-6 col-md-6 col-lg-6 col-xs-6" runat="server" Text="Autenticar" />
                    <asp:Button ID="btnCancelarAutenticacao" OnClick="btnCancelar_Click" CssClass="btn btn-danger col-sm-6 col-md-6 col-lg-6 col-xs-6" runat="server" Text="Cancelar" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="panelConfirmarFrequencia" runat="server" Visible="false">
        <div class="container">
            <div class="form-group">
                <div class="col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2">
                    <asp:GridView ID="gvFrequencia" HeaderStyle-BackColor="WhiteSmoke" CssClass="table table-condensed table-bordered col-sm-12 col-xs-12 col-md-12 col-lg-12" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowDataBound="gvFrequencia_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Dia" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" DataFormatString="{0:dddd}" />
                            <asp:BoundField DataField="Dia" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Dia" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="ListaPonto[0].Hora" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Entrada" DataFormatString="{0:t}" />
                            <asp:BoundField DataField="ListaPonto[1].Hora" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Saída" DataFormatString="{0:t}" />
                            <asp:BoundField DataField="ListaPonto[2].Hora" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Entrada" DataFormatString="{0:t}" />
                            <asp:BoundField DataField="ListaPonto[3].Hora" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Saída" DataFormatString="{0:t}" />
                            <asp:BoundField DataField="HorasTrabalhadas" HeaderStyle-CssClass="text-center col-lg-2" ItemStyle-CssClass="text-center" HeaderText="Horas Trabalhadas" DataFormatString="{0:hh\:mm\:ss}" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        <div class="container">
            <div class=" input-group btn-group col-sm-6 col-md-6 col-lg-6 col-xs-6 col-sm-offset-3 col-md-offset-3 col-lg-offset-3 col-xs-offset-3">
                <asp:Button ID="btnRegistrarFrequencia" OnClick="btnRegistrarFrequencia_Click" CssClass="btn btn-success col-sm-6 col-md-6 col-lg-6 col-xs-6" runat="server" Text="Registrar Frequência" />
                <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger col-sm-6 col-md-6 col-lg-6 col-xs-6" runat="server" Text="Cancelar" />
            </div>
        </div>
        </div>
    </asp:Panel>
</asp:Content>
