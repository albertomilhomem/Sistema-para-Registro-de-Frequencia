using Negocio.BO;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apresentacao.Pages
{
    public partial class pgAlterarSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Funcionario)Session["Usuario"] != null)
                {
                    if (txtSenhaNova.Text == txtConfirmacaoNovaSenha.Text)
                    {
                        string senhaNova = FormsAuthentication.HashPasswordForStoringInConfigFile(txtSenhaNova.Text, "md5");
                        string senhaAntiga = FormsAuthentication.HashPasswordForStoringInConfigFile(txtSenhaAntiga.Text , "md5");

                        Funcionario objFuncionario = (Funcionario)Session["Usuario"];

                        FuncionarioBO objFuncionarioBO = new FuncionarioBO();
                        objFuncionarioBO.AlterarSenha(objFuncionario, senhaAntiga, senhaNova);

                        lblMensagem.Visible = true;
                        lblMensagem.Text = "Senha alterada com sucesso!";
                        lblMensagem.CssClass = "alert alert-success col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
                    }
                    else
                    {
                        throw new Exception("As senhas digitadas não conferem!");
                    }
                }
            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.Message;
                lblMensagem.CssClass = "alert alert-danger col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/pgInicial.aspx");
        }
    }
}