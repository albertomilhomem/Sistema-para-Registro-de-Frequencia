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
    public partial class pgLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"] != null)
            {
                Response.Redirect("pgInicial.aspx");
            }

        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            try
            {
                Funcionario objFuncionario;
                FuncionarioBO objFuncionarioBO = new FuncionarioBO();

                string matricula = txtMatricula.Text;
                string senha = txtSenha.Text;

                objFuncionario = objFuncionarioBO.BuscarMatricula(Convert.ToInt32(matricula));
                if (objFuncionario != null)
                {
                    if (objFuncionario.Senha == FormsAuthentication.HashPasswordForStoringInConfigFile(senha, "md5"))
                    {
                        Session["Usuario"] = objFuncionario;
                        Response.Redirect("~/Pages/pgInicial.aspx");
                    }
                    else
                    {
                        throw new Exception("Senha inválida!");
                    }
                }
                else
                {
                    throw new Exception("Matrícula inválida!");
                }
            }
            catch (Exception erro)
            {
                lblMensagem.Visible = true;
                lblMensagem.Text = erro.Message;
                lblMensagem.CssClass = "alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
            }
        }
    }
}