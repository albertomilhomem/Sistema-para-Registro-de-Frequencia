<%@ Page Title="SISFREQ - Funcionario" Language="C#" MasterPageFile="~/Layouts/MPInterna.master" AutoEventWireup="true" CodeBehind="pgFuncionario.aspx.cs" Inherits="Apresentacao.Pages.pgFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <asp:Panel ID="panelFuncionario" runat="server" GroupingText="Novo Funcionário">
        <div class="container">
            <div class="row">
                <asp:HiddenField ID="hfId" runat="server"></asp:HiddenField>
                <asp:Label ID="lblMensagem" CssClass="alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center" runat="server" Text="Preencha os dados corretamente!" Visible="true"></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2">Nome</label>
            <div class="col-sm-8 col-md-8 col-lg-8 col-xs-8">
                <asp:TextBox CssClass="form-control" ID="txtNome" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2">E-mail</label>
            <div class="col-sm-8 col-md-8 col-lg-8 col-xs-8">
                <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group form-horizontal">
            <div>
                <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2">CPF</label>
                <div class="col-sm-3 col-md-3 col-lg-3 col-xs-3">
                    <asp:TextBox CssClass="form-control" ID="txtCpf" runat="server"></asp:TextBox>
                </div>
            </div>

            <div>
                <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2">Data de Nascimento</label>
                <div class="col-sm-3 col-md-3 col-lg-3 col-xs-3">
                    <asp:TextBox CssClass="form-control" ID="txtDataNascimento" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="form-group form-horizontal">
            <div>
                <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2">Matricula</label>
                <div class="col-sm-3 col-md-3 col-lg-3 col-xs-3">
                    <asp:TextBox CssClass="form-control" ID="txtMatricula" runat="server"></asp:TextBox>
                </div>
            </div>
            <div>
                <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2">Data de Admissão</label>
                <div class="col-sm-3 col-md-3 col-lg-3 col-xs-3">
                    <asp:TextBox CssClass="form-control" ID="txtDataAdmissao" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="form-group form-horizontal">
            <div>
                <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2">Cargo</label>
                <div class="col-sm-3 col-md-3 col-lg-3 col-xs-3">
                    <asp:DropDownList ID="ddlCargo" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>

            <div>
                <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2">Setor</label>
                <div class="col-sm-3 col-md-3 col-lg-3 col-xs-3">
                    <asp:DropDownList ID="ddlSetor" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>


        <div class="form-group form-horizontal">
            <div>
                <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2">Senha</label>
                <div class="col-sm-3 col-md-3 col-lg-3 col-xs-3">
                    <asp:TextBox CssClass="form-control" TextMode="Password" ID="txtSenha" runat="server"></asp:TextBox>
                </div>
            </div>
            <div>
                <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2">Confirmar senha</label>
                <div class="col-sm-3 col-md-3 col-lg-3 col-xs-3">
                    <asp:TextBox CssClass="form-control" TextMode="Password" ID="txtConfimarSenha" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>

        <div runat="server" id="divAdministrador" visible="false" class="form-group form-horizontal">
            <div>
                <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 col-lg-offset-2">Administrador</label>
                <div class="col-sm-5 col-md-5 col-lg-5 col-xs-5">
                    <asp:DropDownList ID="ddlAdministrador" CssClass="form-control" runat="server">
                        <asp:ListItem Value="false">Não</asp:ListItem>
                        <asp:ListItem Value="true">Sim</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>


        <div class=" input-group btn-group col-sm-6 col-md-6 col-lg-6 col-xs-6 col-sm-offset-3 col-md-offset-3 col-lg-offset-3 col-xs-offset-3">
            <asp:Button ID="btnSalvar" OnClick="btnSalvar_Click" CssClass="btn btn-success col-sm-6 col-md-6 col-lg-6 col-xs-6" runat="server" Text="Salvar" />
            <asp:Button ID="btnCancelar" CssClass="btn btn-danger col-sm-6 col-md-6 col-lg-6 col-xs-6" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
        </div>

    </asp:Panel>

    <asp:Panel ID="panelListaFuncionarios" GroupingText="Lista de Funcionários" runat="server">

        <div class="container">
            <div class="row">
                <div class="col-sm-10 col-md-10 col-xs-10 col-lg-10 col-lg-offset-10 col-sm-offset-1 col-md-offset-1 col-xs-offset-1 col-lg-offset-1">
                    <div class="form-group">
                        <div class="col-sm-3 col-md-3 col-lg-3 col-xs-3">
                            <asp:DropDownList ID="ddlFiltro" CssClass="form-control" runat="server">
                                <asp:ListItem Value="nome">Nome</asp:ListItem>
                                <asp:ListItem Value="email">E-mail</asp:ListItem>
                                <asp:ListItem Value="CPF">CPF</asp:ListItem>
                                <asp:ListItem Value="Matricula">Matrícula</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col-sm-7 col-md-7 col-lg-7 col-xs-7">
                            <asp:TextBox ID="txtFiltrar" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnFiltrar" OnClick="btnFiltrar_Click" CssClass="btn btn-primary" runat="server" Text="Filtrar" />
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <asp:GridView ID="gvFuncionarios" CssClass="tablex table-condensed table-bordered table-striped col-sm-12 col-xs-12 col-md-12 col-lg-12" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvFuncionarios_SelectedIndexChanged" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="Id" Visible="false" />
                        <asp:BoundField DataField="Nome" HeaderStyle-CssClass="text-center col-lg-4" ItemStyle-CssClass="text-center" HeaderText="Nome" />
                        <asp:BoundField DataField="Cpf" HeaderStyle-CssClass="text-center col-lg-2" ItemStyle-CssClass="text-center" HeaderText="CPF" />
                        <asp:BoundField DataField="Email" HeaderStyle-CssClass="text-center col-lg-2" ItemStyle-CssClass="text-center" HeaderText="E-mail" />
                        <asp:BoundField DataField="Matricula" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Matrícula" />
                        <asp:BoundField DataField="Setor.Nome" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Setor" />
                        <asp:BoundField DataField="Cargo.Nome" HeaderStyle-CssClass="text-center col-lg-2" ItemStyle-CssClass="text-center" HeaderText="Cargo" />
                        <asp:CommandField ShowSelectButton="true" HeaderText="Selecionar" HeaderStyle-CssClass="text-center col-lg-1" SelectText="Selecionar" ItemStyle-CssClass="text-center" ControlStyle-CssClass="btn btn-xs btn-info" ButtonType="Button" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:Panel>

    <script type="text/javascript">
        jQuery(function ($) {
            $("#ContentPlaceHolder3_ContentPlaceHolder4_txtDataNascimento").inputmask("99/99/9999")
            $("#ContentPlaceHolder3_ContentPlaceHolder4_txtDataAdmissao").inputmask("99/99/9999")
            $("#ContentPlaceHolder3_ContentPlaceHolder4_txtCpf").inputmask("999.999.999-99")
        })
    </script>
</asp:Content>


