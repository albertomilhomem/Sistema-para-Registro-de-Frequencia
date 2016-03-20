using Negocio.BO;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Text;

namespace Apresentacao.Pages
{
    public partial class pgFrequencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("pgLogin.aspx");
            }

            if (!IsPostBack)
            {
                CarregarGV();
            }
        }
        private void CarregarGV()
        {
            if ((Funcionario)Session["Usuario"] != null)
            {
                DateTime dataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime dataFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

                Funcionario objFuncionario = (Funcionario)Session["Usuario"];

                FrequenciaBO objFrequenciaBO = new FrequenciaBO();

                gvFrequencia.DataSource = objFrequenciaBO.BuscarPeriodo(objFuncionario, dataInicial, dataFinal);
                gvFrequencia.DataBind();
            }
        }
        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Funcionario)Session["Usuario"] != null)
                {
                    DateTime dataInicial, dataFinal;

                    if (String.IsNullOrEmpty(txtDataFinal.Text) == false || String.IsNullOrEmpty(txtDataInicial.Text) == false)
                    {

                        dataInicial = Convert.ToDateTime(txtDataInicial.Text);
                        dataFinal = Convert.ToDateTime(txtDataFinal.Text);

                        Funcionario objFuncionario = (Funcionario)Session["Usuario"];
                        FrequenciaBO objFrequenciaBO = new FrequenciaBO();

                        gvFrequencia.DataSource = objFrequenciaBO.BuscarPeriodo(objFuncionario, dataInicial, dataFinal);
                        gvFrequencia.DataBind();
                    }
                    else
                    {
                        throw new Exception("Você não informou as datas!");
                    }
                }
            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.Message;
                lblMensagem.CssClass = "alert alert-danger col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
                lblMensagem.Visible = true;
            }
        }
        protected void gvFrequencia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "Dia.DayOfWeek").ToString() == "Saturday")
                {
                    e.Row.BackColor = Color.LightGreen;
                }
                else if (DataBinder.Eval(e.Row.DataItem, "Dia.DayOfWeek").ToString() == "Sunday")
                {
                    e.Row.BackColor = Color.LightBlue;
                }
                else if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EnumEstado")) == "Faltou")
                {
                    e.Row.BackColor = Color.Bisque;
                }
                else if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EnumEstado")) == "Incompleto")
                {
                    e.Row.BackColor = Color.Cornsilk;
                }
                else if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EnumEstado")) == "Justificado")
                {
                    e.Row.BackColor = Color.Lavender;
                }
                else if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Feriado.Dia")) == Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dia")))
                {
                    e.Row.BackColor = Color.PaleGoldenrod;
                }
            }
        }

        protected void gvFrequencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(gvFrequencia.SelectedDataKey.Value);
            FrequenciaBO objFrequenciaBO = new FrequenciaBO();
            Frequencia objFrequencia = objFrequenciaBO.BuscarId(id);

            if (objFrequencia.ListaPonto != null)
            {
                gvListaPontos.DataSource = objFrequencia.ListaPonto;
                gvListaPontos.DataBind();

                lblMensagemPonto.Text = "Lista de pontos referente ao dia " + Convert.ToString(objFrequencia.Dia.ToShortDateString());
                lblMensagemPonto.CssClass = "alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
            }
            else
            {
                lblMensagemPonto.Text = "Você não possui pontos no dia " + Convert.ToString(objFrequencia.Dia.ToShortDateString());
                lblMensagemPonto.CssClass = "alert alert-danger col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";

            }
            panelListaPontos.Visible = true;
            panelListaFrequencia.Visible = false;
        }
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            panelListaPontos.Visible = false;
            panelListaFrequencia.Visible = true;

        }
        protected void gvListaPontos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "Entrada").ToString() == "True")
                {
                    e.Row.BackColor = Color.MediumSeaGreen;
                }
                else if (DataBinder.Eval(e.Row.DataItem, "Entrada").ToString() == "False")
                {
                    e.Row.BackColor = Color.IndianRed;
                }
            }
        }
    }
}