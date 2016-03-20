using Negocio.BO;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apresentacao.Pages.Gerente
{
    public partial class pgFrequenciaFuncionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"] == null)
            {
                Response.Redirect("../Pages/pgLogin.aspx");
            }
            else if (((Funcionario)Session["Usuario"]).Administrador == true || ((Funcionario)Session["Usuario"]).Cargo.Nome == "Gerente")
            {
                lblMensagem.Visible = false;
                if (!IsPostBack)
                {
                    CarregarDDL();
                }
            }
            else
            {
                Response.Redirect("../Pages/pgInicial.aspx");
            }

        }

        private void CarregarDDL()
        {
            ddlFuncionarios.DataSource = new FuncionarioBO().BuscarTodosRegional((Funcionario)Session["Usuario"]);
            ddlFuncionarios.DataValueField = "Id";
            ddlFuncionarios.DataTextField = "Nome";
            ddlFuncionarios.DataBind();
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Funcionario)Session["Usuario"] != null)
                {
                    DateTime dataInicial, dataFinal;
                    
                    dataInicial = Convert.ToDateTime(txtDataInicial.Text);
                    dataFinal = Convert.ToDateTime(txtDataFinal.Text);

                    Funcionario objFuncionario = new FuncionarioBO().BuscarID(Convert.ToInt16(ddlFuncionarios.SelectedValue));
                    FrequenciaBO objFrequenciaBO = new FrequenciaBO();
                    objFrequenciaBO.ValidarData(dataInicial, dataFinal);

                    gvFrequencia.DataSource = objFrequenciaBO.BuscarPeriodo(objFuncionario, dataInicial, dataFinal);
                    gvFrequencia.DataBind();
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

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dataInicial, dataFinal;


                dataInicial = Convert.ToDateTime(txtDataInicial.Text);
                dataFinal = Convert.ToDateTime(txtDataFinal.Text);

                Funcionario objFuncionario = new FuncionarioBO().BuscarID(Convert.ToInt16(ddlFuncionarios.SelectedValue));

                RelatorioBO objRelatorioBO = new RelatorioBO();

                objRelatorioBO.ValidarData(dataInicial, dataFinal);

                Session["FuncionarioRelatorio"] = objFuncionario;
                Session["InicioRelatorio"] = dataInicial;
                Session["FimRelatorio"] = dataFinal;

                //Response.Redirect("../Pages/pgRelatorioFrequencia.aspx");

                string abrir = "window.open('../Pages/pgRelatorioFrequencia.aspx');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), abrir, true);

            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.Message;
                lblMensagem.Visible = true;
                lblMensagem.CssClass = "alert alert-danger col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
            }

        }
    }
}