using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Model;
using Negocio.BO;
using System.Web.Security;
namespace Apresentacao.Pages
{
    public partial class pgFuncionario : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("../Pages/pgLogin.aspx");
            }
            else if (((Funcionario)Session["Usuario"]).Administrador == true)
            {
                divAdministrador.Visible = true;
            }
            else if (((Funcionario)Session["Usuario"]).Cargo.Nome != "Gerente")
            {
                Response.Redirect("../Pages/pgInicial.aspx");                               
            }

            if (!IsPostBack)
            {
                CarregarDDLSetor();
                CarregarDDLCargo();
                CarregarGVFuncionarios();
            }
        }

        private void CarregarGVFuncionarios()
        {
            Funcionario objFuncionario = (Funcionario)Session["Usuario"];
            gvFuncionarios.DataSource = new FuncionarioBO().BuscarTodos(objFuncionario);
            gvFuncionarios.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(hfId.Value))
                {
                    if (txtConfimarSenha.Text == txtSenha.Text)
                    {
                        Funcionario objFuncionario = new Funcionario(null);
                        FuncionarioBO objFuncionarioBO = new FuncionarioBO();


                        objFuncionario.Cargo = new CargoBO().BuscarID(Convert.ToInt16(ddlCargo.SelectedValue));
                        objFuncionario.Cpf = txtCpf.Text;
                        objFuncionario.DataAdmissao = Convert.ToDateTime(txtDataAdmissao.Text);
                        objFuncionario.DataNascimento = Convert.ToDateTime(txtDataNascimento.Text);
                        objFuncionario.Email = txtEmail.Text;
                        objFuncionario.Matricula = txtMatricula.Text;
                        objFuncionario.Nome = txtNome.Text;
                        objFuncionario.Setor = new SetorBO().BuscarID(Convert.ToInt16(ddlSetor.SelectedValue));
                        objFuncionario.Senha = FormsAuthentication.HashPasswordForStoringInConfigFile(txtSenha.Text, "md5");
                        objFuncionario.Administrador = Convert.ToBoolean(ddlAdministrador.SelectedValue);


                        objFuncionarioBO.Salvar(objFuncionario);


                        lblMensagem.Text = "Funcionario <b>" + (objFuncionario.Nome) + "</b> salvo com sucesso!";
                        lblMensagem.CssClass = "alert alert-success col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";

                        CarregarGVFuncionarios();
                        LimparForm();
                    }

                    else
                    {
                        throw new Exception("As senhas digitadas não conferem");
                    }
                }

                else
                {
                    Funcionario objFuncionario = new Funcionario(null);
                    FuncionarioBO objFuncionarioBO = new FuncionarioBO();

                    objFuncionario.Cargo = new CargoBO().BuscarID(Convert.ToInt16(ddlCargo.SelectedValue));
                    objFuncionario.Cpf = txtCpf.Text;
                    objFuncionario.DataAdmissao = Convert.ToDateTime(txtDataAdmissao.Text);
                    objFuncionario.DataNascimento = Convert.ToDateTime(txtDataNascimento.Text);
                    objFuncionario.Email = txtEmail.Text;
                    objFuncionario.Matricula = txtMatricula.Text;
                    objFuncionario.Nome = txtNome.Text;
                    objFuncionario.Setor = new SetorBO().BuscarID(Convert.ToInt16(ddlSetor.SelectedValue));
                    objFuncionario.Id = Convert.ToInt16(hfId.Value);
                    objFuncionario.Administrador = Convert.ToBoolean(ddlAdministrador.SelectedValue);

                    objFuncionarioBO.Alterar(objFuncionario);

                    lblMensagem.Text = "Funcionario <b>" + (objFuncionario.Nome) + "</b> alterado com sucesso!";
                    lblMensagem.CssClass = "alert alert-success col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";

                    CarregarGVFuncionarios();
                    LimparForm();
                }
            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.Message;
                lblMensagem.CssClass = "alert alert-danger col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
            }
        }

        private void CarregarDDLSetor()
        {

            if (Session["Usuario"] != null)
            {
                ddlSetor.DataSource = new SetorBO().Buscar((Funcionario)Session["Usuario"]);
                ddlSetor.DataTextField = "Nome";
                ddlSetor.DataValueField = "Id";
                ddlSetor.DataBind();
            }
        }

        private void CarregarDDLCargo()
        {
            if (Session["Usuario"] != null)
            {
                ddlCargo.DataSource = new CargoBO().BuscarTodos((Funcionario)Session["Usuario"]);
                ddlCargo.DataTextField = "Nome";
                ddlCargo.DataValueField = "Id";
                ddlCargo.DataBind();
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            FuncionarioBO objFuncionarioBO = new FuncionarioBO();
            string atributo, valor;

            atributo = ddlFiltro.SelectedValue;
            valor = txtFiltrar.Text;

            gvFuncionarios.DataSource = objFuncionarioBO.Filtrar(atributo, valor);
            gvFuncionarios.DataBind();
        }

        protected void gvFuncionarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(gvFuncionarios.SelectedDataKey.Value);

            Funcionario objFuncionario = new FuncionarioBO().BuscarID(id);

            ddlSetor.SelectedValue = Convert.ToString(objFuncionario.Setor.Id);
            ddlCargo.SelectedValue = Convert.ToString(objFuncionario.Cargo.Id);
            txtCpf.Text = objFuncionario.Cpf;
            txtDataAdmissao.Text = objFuncionario.DataAdmissao.ToShortDateString();
            txtDataNascimento.Text = objFuncionario.DataNascimento.ToShortDateString();
            txtEmail.Text = objFuncionario.Email;
            txtMatricula.Text = objFuncionario.Matricula;
            txtNome.Text = objFuncionario.Nome;
            hfId.Value = objFuncionario.Id.ToString();

            if (objFuncionario.Administrador == true)
            {
                ddlAdministrador.SelectedValue = "true";
            }
            else
            {
                ddlAdministrador.SelectedValue = "false";
            }

            txtSenha.ReadOnly = true;
            txtConfimarSenha.ReadOnly = true;

            lblMensagem.Text = "CUIDADO! Você está editando o funcionario: <b>" + (objFuncionario.Nome) + "</b>";
            lblMensagem.CssClass = "alert alert-warning col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparForm();
            lblMensagem.CssClass = "alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
            lblMensagem.Text = "Preencha os dados corretamente!";
        }
        private void LimparForm()
        {
            hfId.Value = String.Empty;
            txtConfimarSenha.Text = String.Empty;
            txtCpf.Text = String.Empty;
            txtDataAdmissao.Text = String.Empty;
            txtDataNascimento.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtFiltrar.Text = String.Empty;
            txtMatricula.Text = String.Empty;
            txtNome.Text = String.Empty;
            txtSenha.Text = String.Empty;
            txtSenha.ReadOnly = false;
            txtConfimarSenha.ReadOnly = false;
            ddlAdministrador.SelectedValue = "false";
        }

    }
}