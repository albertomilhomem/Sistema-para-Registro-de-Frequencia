<%@ Page Title="SISFREQ - Feriado" Language="C#" MasterPageFile="~/Layouts/MPInterna.master" AutoEventWireup="true" CodeBehind="pgFeriado.aspx.cs" Inherits="Apresentacao.Pages.pgFeriado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">

    <asp:Panel ID="panelFeriado" runat="server" GroupingText="Feriado">
        <div class="container">
            <div class="row">
                <asp:HiddenField ID="hfId" runat="server"></asp:HiddenField>
                <asp:Label ID="lblMensagem" CssClass="alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center" runat="server" Text="Preencha os dados corretamente!" Visible="true"></asp:Label>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div>
                    <div class="form-group form-horizontal">
                        <div>
                            <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2">Nome</label>
                            <div class="col-sm-5 col-md-5 col-lg-5 col-xs-5">
                                <asp:TextBox CssClass="form-control" ID="txtNome" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div>
                            <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2">Data</label>
                            <div class="col-sm-2 col-md-2 col-lg-2 col-xs-2">
                                <asp:TextBox CssClass="form-control" ID="txtData" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=" input-group btn-group col-sm-6 col-md-6 col-lg-6 col-xs-6 col-sm-offset-3 col-md-offset-3 col-lg-offset-3 col-xs-offset-3">
            <asp:Button ID="btnSalvar" OnClick="btnSalvar_Click" CssClass="btn btn-success col-sm-6 col-md-6 col-lg-6 col-xs-6" runat="server" Text="Salvar" />
            <asp:Button ID="btnCancelar" CssClass="btn btn-danger col-sm-6 col-md-6 col-lg-6 col-xs-6" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
        </div>
    </asp:Panel>
    <asp:Panel ID="panelListaFeriado" GroupingText="Lista de Feriados" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2">
                    <div class="form-group">
                        <div class="col-sm-4 col-md-4 col-lg-4 col-xs-4">
                            <asp:DropDownList ID="ddlFiltro" CssClass="form-control" runat="server">
                                <asp:ListItem Value="nome">Nome</asp:ListItem>
                                <asp:ListItem Value="data">Data</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col-sm-6 col-md-6 col-lg-6 col-xs-6">
                            <asp:TextBox ID="txtFiltrar" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnFiltrar" OnClick="btnFiltrar_Click" CssClass="btn btn-primary" runat="server" Text="Filtrar" />
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2">
                    <asp:GridView ID="gvFeriados" CssClass="tablex table-condensed table-bordered table-striped col-sm-12 col-xs-12 col-md-12 col-lg-12" OnSelectedIndexChanged="gvFeriados_SelectedIndexChanged" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
                        <Columns>
                            <asp:BoundField DataField="Nome" HeaderStyle-CssClass="text-center col-lg-7" ItemStyle-CssClass="text-center" HeaderText="Nome" />
                            <asp:BoundField DataField="Dia" HeaderStyle-CssClass="text-center col-lg-2" ItemStyle-CssClass="text-center" HeaderText="Data" DataFormatString="{0:d}" />
                            <asp:CommandField ShowSelectButton="true" HeaderText="Selecionar" HeaderStyle-CssClass="text-center col-lg-1" SelectText="Selecionar" ItemStyle-CssClass="text-center" ControlStyle-CssClass="btn btn-xs btn-info" ButtonType="Button" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </div>
    </asp:Panel>
    <script type="text/javascript">
        jQuery(function ($) {
            $("#ContentPlaceHolder3_ContentPlaceHolder4_txtData").inputmask("99/99/9999")
        })
    </script>
</asp:Content>
