<%@ Page Title="SISFREQ - Justificativa" Language="C#" MasterPageFile="~/Layouts/MPInterna.master" AutoEventWireup="true" CodeBehind="pgJustificativa.aspx.cs" Inherits="Apresentacao.Pages.pgJustificativa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <asp:Panel ID="panelListaFrequencia" runat="server" GroupingText="Justificativa">

        <div class="container">
            <div class="row">
                <asp:HiddenField ID="hfId" runat="server"></asp:HiddenField>
                <asp:Label ID="lblMensagem" CssClass="alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center" runat="server" Text="Preencha os dados corretamente!" Visible="true"></asp:Label>
            </div>
        </div>
        <div class="form-group form-horizontal">
            <div>
                <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2">Data Inicial</label>
                <div class="col-sm-2 col-md-2 col-lg-2 col-xs-2">
                    <asp:TextBox CssClass="form-control" ID="txtDataInicial" runat="server"></asp:TextBox>
                </div>
            </div>
            <div>
                <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2">Data Final</label>
                <div class="col-sm-2 col-md-2 col-lg-2 col-xs-2">
                    <asp:TextBox CssClass="form-control" ID="txtDataFinal" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2">Motivo</label>
            <div class="col-sm-5 col-md-5 col-lg-5 col-xs-5">
                <asp:DropDownList ID="ddlMotivo" CssClass="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2">Comprovante</label>
            <div class="col-sm-9 col-md-9 col-lg-9 col-xs-9">
                <asp:FileUpload ID="fileComprovante" runat="server" />
            </div>
        </div>


        <div class="form-group">
            <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2">Complemento</label>
            <div class="col-sm-8 col-md-8 col-lg-8 col-xs-8">
                <asp:TextBox ID="txtDescricao" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>




        <div class=" input-group btn-group col-sm-6 col-md-6 col-lg-6 col-xs-6 col-sm-offset-3 col-md-offset-3 col-lg-offset-3 col-xs-offset-3">
            <asp:Button ID="btnSalvar" CssClass="btn btn-success col-sm-6 col-md-6 col-lg-6 col-xs-6" runat="server" OnClick="btnSalvar_Click" Text="Salvar" />
            <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger col-sm-6 col-md-6 col-lg-6 col-xs-6" runat="server" Text="Cancelar" />
        </div>
    </asp:Panel>

    <asp:Panel ID="panelListaFuncionarios" GroupingText="Lista de Justificativa" runat="server">
        <div class="container">
            <div class="row">
                <asp:GridView ID="gvJustificativas" CssClass="tablex table-condensed table-bordered table-striped col-sm-12 col-xs-12 col-md-12 col-lg-12" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvJustificativas_SelectedIndexChanged" OnRowCommand="gvJustificativas_RowCommand" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Motivo" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Motivo" />
                        <asp:BoundField DataField="InicioPeriodo" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Início" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="FimPeriodo" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Fim" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="Complemento" HeaderStyle-CssClass="text-center col-lg-3" ItemStyle-CssClass="text-center" HeaderText="Complemento" />
                        <asp:CheckBoxField DataField="Aprovacao" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Autorizado?" />
                        <asp:BoundField DataField="Responsavel.Nome" HeaderStyle-CssClass="text-center col-lg-2" ItemStyle-CssClass="text-center" HeaderText="Responsável" />
                        <asp:CommandField ShowSelectButton="true" HeaderText="Selecionar" HeaderStyle-CssClass="text-center col-lg-1" SelectText="Selecionar" ItemStyle-CssClass="text-center" ControlStyle-CssClass="btn btn-xs btn-info" ButtonType="Button" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:Panel>
    
    <script type="text/javascript">
        jQuery(function ($) {
            $("#ContentPlaceHolder3_ContentPlaceHolder4_txtDataInicial").inputmask("99/99/9999")
            $("#ContentPlaceHolder3_ContentPlaceHolder4_txtDataFinal").inputmask("99/99/9999")
        })
    </script>
</asp:Content>
