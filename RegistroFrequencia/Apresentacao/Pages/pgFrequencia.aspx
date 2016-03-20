<%@ Page Title="SISFREQ - Frequencia" Language="C#" MasterPageFile="~/Layouts/MPInterna.master" AutoEventWireup="true" CodeBehind="pgFrequencia.aspx.cs" Inherits="Apresentacao.Pages.pgFrequencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <div>
        <asp:Panel runat="server" ID="panelListaPontos" GroupingText="Pontos" Visible="false">
            <div class="row">
                <asp:Label runat="server" ID="lblMensagemPonto" CssClass="alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center"></asp:Label>
            </div>
            <div class="row">
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 col-lg-offset-5 col-md-offset-5 col-sm-offset-5 col-xs-offset-5">
                    <asp:GridView ID="gvListaPontos" HeaderStyle-BackColor="WhiteSmoke" CssClass="tablex table-condensed table-bordered col-sm-12 col-xs-12 col-md-12 col-lg-12" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowDataBound="gvListaPontos_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Hora" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" DataFormatString="{0:t}" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row paddingP">
                <div class="btn-group col-sm-2 col-md-2 col-lg-2 col-xs-2 col-sm-offset-5 col-md-offset-5 col-lg-offset-5 col-xs-offset-5">
                    <asp:Button ID="btnVoltar" OnClick="btnVoltar_Click" CssClass="btn btn-default col-sm-12 col-md-12 col-lg-12 col-xs-12" runat="server" Text="Voltar" />
                </div>
            </div>
        </asp:Panel>
    </div>
    <asp:Panel ID="panelListaFrequencia" runat="server" GroupingText="Lista de Frequencia">
        <div class="container">
            <div class="row">
                <asp:HiddenField ID="hfId" runat="server"></asp:HiddenField>
                <asp:Label ID="lblMensagem" CssClass="alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center" runat="server" Text="Preencha os dados corretamente!" Visible="false"></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2 col-md-2 col-lg-2 col-xs-2 col-sm-offset-2 col-md-offset-2 col-lg-offset-2 col-xs-offset-2 col-lg-offset-2">Período</label>
            <div class="col-sm-2 col-md-2 col-lg-2 col-xs-2">
                <asp:TextBox ID="txtDataInicial" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-2 col-md-2 col-lg-2 col-xs-2">
                <asp:TextBox ID="txtDataFinal" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnMostrar" CssClass="btn btn-primary" OnClick="btnMostrar_Click" runat="server" Text="Mostrar" />
        </div>

        <div class="container">
            <div class="row">
                <div class="col-sm-12 col-xs-12 col-md-12 col-lg-12">
                    <asp:GridView ID="gvFrequencia" HeaderStyle-BackColor="WhiteSmoke" CssClass="table table-condensed table-bordered col-sm-12 col-xs-12 col-md-12 col-lg-12" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnSelectedIndexChanged="gvFrequencia_SelectedIndexChanged" OnRowDataBound="gvFrequencia_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Dia" HeaderText="Dia" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" DataFormatString="{0:dddd}" />
                            <asp:BoundField DataField="Dia" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Data" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="ListaPonto[0].Hora" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Entrada" DataFormatString="{0:t}" />
                            <asp:BoundField DataField="ListaPonto[1].Hora" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Saída" DataFormatString="{0:t}" />
                            <asp:BoundField DataField="ListaPonto[2].Hora" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Entrada" DataFormatString="{0:t}" />
                            <asp:BoundField DataField="ListaPonto[3].Hora" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Saída" DataFormatString="{0:t}" />
                            <asp:CommandField ShowSelectButton="true" HeaderText="Detalhes" HeaderStyle-CssClass="text-center col-lg-1" SelectText="Detalhes" ItemStyle-CssClass="text-center" ControlStyle-CssClass="btn btn-xs btn-info" ButtonType="Button" />
                            <asp:BoundField DataField="HorasTrabalhadas" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Horas Trabalhadas" DataFormatString="{0:hh\:mm\:ss}" />

                            <asp:BoundField DataField="EnumEstado" HeaderText="Estado" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" />
                            <asp:BoundField DataField="Justificativa.Motivo" HeaderStyle-CssClass="text-center col-lg-1" ItemStyle-CssClass="text-center" HeaderText="Justificativa" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </div>

        <div class="control-label col-sm-4 col-md-4 col-lg-4 col-xs-4 col-sm-offset-4 col-md-offset-4 col-lg-offset-4 col-xs-offset-4 col-lg-offset-4">
            <img src="../Imagens/legenda.png" alt="Legenda" />
        </div>
    </asp:Panel>
    <script type="text/javascript">
        jQuery(function ($) {
            $("#ContentPlaceHolder3_ContentPlaceHolder4_txtDataInicial").inputmask("99/99/9999")
            $("#ContentPlaceHolder3_ContentPlaceHolder4_txtDataFinal").inputmask("99/99/9999")
        })
    </script>
</asp:Content>
