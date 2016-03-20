using Negocio.BO;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apresentacao.Pages.Gerente
{
    public partial class pgRelatorioFrequencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] != null)
                {
                    if (((Funcionario)Session["Usuario"]).Administrador == true || ((Funcionario)Session["Usuario"]).Cargo.Nome == "Gerente")
                    {
                        if (Session["FuncionarioRelatorio"] != null)
                        {

                            Funcionario objFuncionario = (Funcionario)Session["FuncionarioRelatorio"];
                            DateTime dataInicial = (DateTime)Session["InicioRelatorio"];
                            DateTime dataFinal = (DateTime)Session["FimRelatorio"];

                            IList<Frequencia> listaFrequencia = new FrequenciaBO().BuscarPeriodo(objFuncionario, dataInicial, dataFinal);

                            RelatorioBO objRelatorioBO = new RelatorioBO();
                            Relatorio objRelatorio = objRelatorioBO.GerarRelatorio(objFuncionario, listaFrequencia);


                            lblInicioPeriodo.Text = String.Format("{0:d}", dataInicial);
                            lblFimPeriodo.Text = String.Format("{0:d}", dataFinal);
                            lblFuncionario.Text = objFuncionario.Nome.ToUpper();
                            lblDiasUteis.Text = objRelatorio.DiasUteis.ToString();
                            lblHorasTrabalhar.Text = objRelatorio.HorasTrabalhar.TotalHours.ToString() + " horas";


                            if (objRelatorio.HorasTrabalhadas == null)
                            {
                                lblHorasTrabalhadas.Text = "0";
                            }
                            else
                            {
                                lblHorasTrabalhadas.Text = Math.Truncate(objRelatorio.HorasTrabalhadas.Value.TotalHours).ToString() + " horas";
                            }

                            lblFaltas.Text = objRelatorio.Faltas.ToString();
                            lblFaltasJustificadas.Text = objRelatorio.FaltasJustificadas.ToString();
                            lblIncompletos.Text = objRelatorio.Incompletos.ToString();
                            lblIncompletosJustificado.Text = objRelatorio.IncompletosJustificadas.ToString();
                            if (objRelatorio.HorasTrabalhadasSabado == null)
                            {
                                lblHorasTrabalhadasSabado.Text = "0";
                            }
                            else
                            {
                                lblHorasTrabalhadasSabado.Text = Math.Truncate(objRelatorio.HorasTrabalhadasSabado.Value.TotalHours).ToString() + " horas";
                            }

                            if (objRelatorio.HorasTrabalhadasDomingo == null)
                            {
                                lblHorasTrabalhadasDomingo.Text = "0";
                            }
                            else
                            {
                                lblHorasTrabalhadasDomingo.Text = Math.Truncate(objRelatorio.HorasTrabalhadasDomingo.Value.TotalHours).ToString() + " horas";
                            }

                        }
                        else
                        {
                            Response.Redirect("../Pages/pgFrequenciaFuncionario.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("../Pages/pgInicial.aspx");
                    }
                }
                else
                {
                    Response.Redirect("../Pages/pgInicial.aspx");
                }
            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.Message;
                lblMensagem.Visible = true;
            }
        }
    }
}