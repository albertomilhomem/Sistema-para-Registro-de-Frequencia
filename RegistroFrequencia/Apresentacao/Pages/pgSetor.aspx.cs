using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.BO;
using Negocio.Model;

namespace Apresentacao.Pages
{
    public partial class pgSetor : System.Web.UI.Page
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
                    CarregarDDLGerente();
                    CarregarGridRegionais();
                }
            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.Message;
            }
        }
        private void CarregarGridRegionais()
        {
            gvRegionais.DataSource = new SetorBO().BuscarTodos();
            gvRegionais.DataBind();
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                if (String.IsNullOrEmpty(hfId.Value))
                {
                    SetorBO objSetorBO = new SetorBO();
                    Setor objSetor = new Setor();

                    objSetor.Telefone = txtTelefone.Text;
                    objSetor.Nome = txtNome.Text;
                    objSetor.Funcionario = new FuncionarioBO().BuscarID(Convert.ToInt16(ddlGerente.SelectedValue));


                    objSetorBO.Salvar(objSetor);

                    lblMensagem.Text = "Setor gravada com sucesso!";
                    lblMensagem.CssClass = "alert alert-success col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
                    LimparForm();
                    CarregarGridRegionais();
                }

                else
                {

                    SetorBO objSetorBO = new SetorBO();
                    Setor objSetor = new Setor();

                    objSetor.Id = Convert.ToInt16(hfId.Value);

                    objSetor.Telefone = txtTelefone.Text;
                    objSetor.Nome = txtNome.Text;
                    objSetor.Funcionario = new FuncionarioBO().BuscarID(Convert.ToInt16(ddlGerente.SelectedValue));

                    objSetorBO.Alterar(objSetor);


                    lblMensagem.Text = "O Setor <b>" + objSetor.Nome + "</b> foi alterada com sucesso!";
                    lblMensagem.CssClass = "alert alert-success col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
                    LimparForm();
                    CarregarGridRegionais();
                }
            }
            catch (Exception erro)
            {

                lblMensagem.Text = erro.Message;
                lblMensagem.CssClass = "alert alert-danger col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
            }
        }
        private void LimparForm()
        {
            hfId.Value = String.Empty;
            txtNome.Text = String.Empty;
            txtTelefone.Text = String.Empty;
        }

        private void CarregarDDLGerente()
        {
            ddlGerente.DataSource = new FuncionarioBO().BuscarTodosGerentes();
            ddlGerente.DataValueField = "Id";
            ddlGerente.DataTextField = "Nome";
            ddlGerente.DataBind();
        }

        protected void gvRegionais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int id = Convert.ToInt16(gvRegionais.SelectedDataKey.Value);

                Setor objSetor = new SetorBO().BuscarID(id);

                hfId.Value = Convert.ToString(objSetor.Id);
                txtNome.Text = objSetor.Nome;
                txtTelefone.Text = objSetor.Telefone;

                if (String.IsNullOrEmpty(Convert.ToString(objSetor.Funcionario.Id)) == false)
                {

                    ddlGerente.SelectedItem.Value = Convert.ToString(objSetor.Funcionario.Id);

                }

                lblMensagem.CssClass = "alert alert-warning col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
                lblMensagem.Text = "Você está editando o Setor: <b>" + objSetor.Nome + "</b>";

            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.Message;
            }
        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {

                SetorBO objSetorBO = new SetorBO();
                string atributo, valor;
                atributo = ddlFiltro.SelectedValue;
                valor = txtFiltrar.Text;

                gvRegionais.DataSource = objSetorBO.Filtrar(atributo, valor);
                gvRegionais.DataBind();

            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.Message;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                LimparForm();
                lblMensagem.Text = "Preencha os dados corretamente!";
                lblMensagem.CssClass = "alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.Message;
            }
        }

    }
}