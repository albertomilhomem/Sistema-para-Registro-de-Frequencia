using Negocio.BO;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apresentacao.Pages
{
    public partial class pgFeriado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["Usuario"] == null)
                {
                    Response.Redirect("../Pages/pgLogin.aspx");
                }
                else if (((Funcionario)Session["Usuario"]).Administrador != true)
                {

                    Response.Redirect("../Pages/pgInicial.aspx");
                }

                if (!IsPostBack)
                {
                    CarregarGV();
                }

            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.Message;
            }

        }
        private void CarregarGV()
        {
            FeriadoBO objFeriadoBO = new FeriadoBO();

            gvFeriados.DataSource = objFeriadoBO.BuscarTodos();
            gvFeriados.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(hfId.Value))
                {
                    Feriado objFeriado = new Feriado();
                    objFeriado.Dia = Convert.ToDateTime(txtData.Text);
                    objFeriado.Nome = txtNome.Text;

                    FeriadoBO objFeriadoBO = new FeriadoBO();
                    objFeriadoBO.Salvar(objFeriado);


                    lblMensagem.CssClass = "alert alert-success col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
                    lblMensagem.Text = "Feriado salvo com sucesso!";

                    CarregarGV();
                    LimparForm();
                }
                else
                {
                    Feriado objFeriado = new Feriado();
                    objFeriado.Id = Convert.ToInt16(hfId.Value);
                    objFeriado.Dia = Convert.ToDateTime(txtData.Text);
                    objFeriado.Nome = txtNome.Text;

                    FeriadoBO objFeriadoBO = new FeriadoBO();
                    objFeriadoBO.Alterar(objFeriado);

                    lblMensagem.Text = "Feriado alterado com sucesso!";
                    lblMensagem.CssClass = "alert alert-success col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
                    CarregarGV();
                    LimparForm();
                }
            }
            catch (Exception erro)
            {
                lblMensagem.CssClass = "alert alert-danger col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
                lblMensagem.Text = erro.Message;
            }

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            FeriadoBO objFeriadoBO = new FeriadoBO();

            string valor = txtFiltrar.Text;
            string atributo = ddlFiltro.SelectedValue;

            gvFeriados.DataSource = objFeriadoBO.Filtrar(atributo, valor);
            gvFeriados.DataBind();

        }
        protected void gvFeriados_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(gvFeriados.SelectedDataKey.Value);

            Feriado objFeriado = new Feriado();

            objFeriado = new FeriadoBO().BuscarId(id);

            txtNome.Text = objFeriado.Nome;
            txtData.Text = objFeriado.Dia.ToShortDateString();
            hfId.Value = objFeriado.Id.ToString();


            lblMensagem.CssClass = "alert alert-warning col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
            lblMensagem.Text = "Você está alterandoo feriado <b>"+ (objFeriado.Nome.ToUpper()) +"</b>";
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparForm();
            lblMensagem.Text = "Preencha os dados corretamente!";
            lblMensagem.CssClass = "alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
        }
        private void LimparForm()
        {
            txtData.Text = String.Empty;
            txtFiltrar.Text = String.Empty;
            txtNome.Text = String.Empty;
            hfId.Value = String.Empty;
        }
    }
}