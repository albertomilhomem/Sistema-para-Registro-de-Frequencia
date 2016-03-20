<%@ Page Title="SISFREQ - Alterar Senha" Language="C#" MasterPageFile="~/Layouts/MPInterna.master" AutoEventWireup="true" CodeBehind="pgAlterarSenha.aspx.cs" Inherits="Apresentacao.Pages.pgAlterarSenha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">

    <asp:Panel ID="panelAlterarSenha" runat="server" GroupingText="Alterar Senha">
        <div class="container">
            <div class="row">
                <asp:Label ID="lblMensagem" CssClass="alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center" runat="server" Text="Preencha os dados corretamente!" Visible="false"></asp:Label>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div>
                    <div class="form-group">
                        <div>
                            <label class="control-label col-sm-3 col-md-3 col-lg-3 col-xs-3">Senha Antiga</label>
                            <div class="col-sm-6 col-md-6 col-lg-6 col-xs-6">
                                <asp:TextBox CssClass="form-control" ID="txtSenhaAntiga" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div>
                            <label class="control-label col-sm-3 col-md-3 col-lg-3 col-xs-3">Nova Senha</label>
                            <div class="col-sm-6 col-md-6 col-lg-6 col-xs-6">
                                <asp:TextBox CssClass="form-control" ID="txtSenhaNova" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div>
                            <label class="control-label col-sm-3 col-md-3 col-lg-3 col-xs-3">Confirmação da Nova Senha</label>
                            <div class="col-sm-6 col-md-6 col-lg-6 col-xs-6">
                                <asp:TextBox CssClass="form-control" ID="txtConfirmacaoNovaSenha" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=" input-group btn-group col-sm-6 col-md-6 col-lg-6 col-xs-6 col-sm-offset-3 col-md-offset-3 col-lg-offset-3 col-xs-offset-3">
            <asp:Button ID="btnAlterar" CssClass="btn btn-success col-sm-6 col-md-6 col-lg-6 col-xs-6" OnClick="btnAlterar_Click" runat="server" Text="Salvar" />
            <asp:Button ID="btnCancelar" CssClass="btn btn-danger col-sm-6 col-md-6 col-lg-6 col-xs-6" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
        </div>
    </asp:Panel>
</asp:Content>
