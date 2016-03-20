<%@ Page Title="SISFREQ - Autorizar Justificativa" Language="C#" MasterPageFile="~/Layouts/MPInterna.master" AutoEventWireup="true" CodeBehind="pgJustificativasDoSetor.aspx.cs" Inherits="Apresentacao.Pages.pgAutorizarJustificativa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    
        <div class="row">
            <asp:HiddenField ID="hfId" runat="server"></asp:HiddenField>
            <asp:Label ID="lblMensagem" CssClass="alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center" runat="server" Text="Preencha os dados corretamente!" Visible="false"></asp:Label>
        </div>

    <asp:Panel ID="panelJustificativasPendentes" GroupingText="Justificativas Pendentes" runat="server">
        <div class="container">
            <div class="row">
                <asp:GridView ID="gvJustificativas" HeaderStyle-BackColor="WhiteSmoke" CssClass="table table-condensed table-bordered col-lg-12" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvJustificativas_SelectedIndexChanged" OnRowCommand="gvJustificativas_RowCommand" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Motivo" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Motivo" />
                        <asp:BoundField DataField="InicioPeriodo" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Inicio" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="FimPeriodo" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Fim" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="Complemento" HeaderStyle-CssClass="text-center col-lg-3" ItemStyle-CssClass="text-center" HeaderText="Complemento" />
                        <asp:BoundField DataField="Funcionario.Nome" HeaderStyle-CssClass="text-center col-lg-2" ItemStyle-CssClass="text-center" HeaderText="Funcionário" />
                        <asp:CheckBoxField DataField="Aprovacao" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Autorizado?" />

                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn-xs btn-default" ItemStyle-CssClass="text-center" CommandName="comprovantePendente_click" Text="Comprovante" HeaderStyle-CssClass="text-center" HeaderText="Comprovante" />


                        <asp:CommandField ShowSelectButton="true" HeaderText="Aprovar" HeaderStyle-CssClass="text-center col-lg-1" SelectText="Aprovar" ItemStyle-CssClass="text-center" ControlStyle-CssClass="btn btn-xs btn-info" ButtonType="Button" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="panelJustificativasAutorizadas" GroupingText="Justificativas Autorizadas" runat="server">
        <div class="container">
            <div class="row">
                <asp:GridView ID="gvJustificativasRegional" HeaderStyle-BackColor="WhiteSmoke" CssClass="table table-condensed table-bordered col-lg-12" runat="server" AutoGenerateColumns="False" OnRowCommand="gvJustificativasRegional_RowCommand" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Motivo" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Motivo" />
                        <asp:BoundField DataField="InicioPeriodo" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Inicio" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="FimPeriodo" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Fim" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="Funcionario.Nome" HeaderStyle-CssClass="text-center col-lg-2" ItemStyle-CssClass="text-center" HeaderText="Funcionário" />
                        <asp:CheckBoxField DataField="Aprovacao" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Autorizado?" />
                        <asp:BoundField DataField="Responsavel.Nome" HeaderStyle-CssClass="text-center col-lg-2" ItemStyle-CssClass="text-center" HeaderText="Responsável" />
                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn-xs btn-default" ItemStyle-CssClass="text-center" CommandName="comprovanteAutorizado_click" Text="Comprovante" HeaderStyle-CssClass="text-center col-lg-2" HeaderText="Comprovante" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:Panel>

</asp:Content>
