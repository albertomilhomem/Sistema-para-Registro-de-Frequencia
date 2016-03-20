<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgRelatorioFrequencia.aspx.cs" Inherits="Apresentacao.Pages.Gerente.pgRelatorioFrequencia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Relatorio de Frequência</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap-theme.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <asp:HiddenField ID="hfId" runat="server"></asp:HiddenField>
            <asp:Label ID="lblMensagem" CssClass="alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center" runat="server" Text="Preencha os dados corretamente!" Visible="false"></asp:Label>
        </div>
        <div class="col-xs-8 col-sm-8 col-md-8 col-lg-8 col-xs-offset-2 col-sm-offset-2 col-md-offset-2 col-lg-offset-2">
            <h1 class="text-center">Relatorio de Frequência</h1>
            <br />
            <h4><b>Funcionário:
                <asp:Label ID="lblFuncionario" runat="server" Text=""></asp:Label></b></h4>
            <h4><b>Período:
                <asp:Label ID="lblInicioPeriodo" runat="server" Text=""></asp:Label>
                à
                <asp:Label ID="lblFimPeriodo" runat="server" Text=""></asp:Label></b></h4>
            <br />
            <h3 class="text-center">Informações referente ao periodo</h3>
            <p>Dias uteis no periodo:
                <asp:Label ID="lblDiasUteis" runat="server" Text=""></asp:Label></p>
            <p>Horas à trabalhar:
                <asp:Label ID="lblHorasTrabalhar" runat="server" Text=""></asp:Label></p>
            <p>Horas trabalhadas:
                <asp:Label ID="lblHorasTrabalhadas" runat="server" Text=""></asp:Label></p>
            <h3 class="text-center">Horas no sábado e domingo</h3>
            <p>Horas trabalhadas no sábado:
                <asp:Label ID="lblHorasTrabalhadasSabado" runat="server" Text=""></asp:Label></p>
            <p>Horas trabalhadas no domingo:
                <asp:Label ID="lblHorasTrabalhadasDomingo" runat="server" Text=""></asp:Label></p>

            <h3 class="text-center">Faltas e Incompletas</h3>
            <p>Faltas:
                <asp:Label ID="lblFaltas" runat="server" Text=""></asp:Label></p>
            <p>Faltas justificadas:
                <asp:Label ID="lblFaltasJustificadas" runat="server" Text=""></asp:Label></p>
            <p>Incompletos:
                <asp:Label ID="lblIncompletos" runat="server" Text=""></asp:Label></p>
            <p>Incompletos justificado:
                <asp:Label ID="lblIncompletosJustificado" runat="server" Text=""></asp:Label></p>

            <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" OnClientClick="window.print()" CssClass="hidden-print" />
        </div>
    </form>
</body>
</html>
