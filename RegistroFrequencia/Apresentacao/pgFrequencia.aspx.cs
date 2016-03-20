using Negocio.BO;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apresentacao
{
    public partial class pgFrequencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblMensagem.Visible = false;
            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.Message;
            }
        }
        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                int matricula = Convert.ToInt32(txtMatricula.Text);
                Funcionario objFuncionario = new Funcionario(null);
                objFuncionario = new FuncionarioBO().BuscarMatricula(matricula);

                if (objFuncionario != null)
                {
                    Session["Funcionario"] = objFuncionario;

                    panelMatricula.Visible = false;
                    panelVerificar.Visible = true;
                    txtVerificacaoEmail.Text = objFuncionario.Email.ToString();
                    txtVerificacaoNome.Text = objFuncionario.Nome;
                    txtVerificacaoCPF.Text = objFuncionario.Cpf;
                    txtVerificacaoNascimento.Text = objFuncionario.DataNascimento.ToShortDateString();
                    txtVerificacaoMatricula.Text = objFuncionario.Matricula;
                }
                else
                {
                    throw new Exception("Matrícula inválida.");
                }
            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.Message;
                lblMensagem.CssClass = "alert alert-danger col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
                lblMensagem.Visible = true;
            }
        }
        protected void btnRegistrarFrequencia_Click(object sender, EventArgs e)
        {
            try
            {
                Funcionario objFuncionario = (Funcionario)Session["Funcionario"];
                FrequenciaBO objFrequencia = new FrequenciaBO();

                string tipo = objFrequencia.RegistrarFrequencia(objFuncionario);

                lblMensagem.Visible = true;
                lblMensagem.CssClass = "alert alert-success col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
                lblMensagem.Text = "Frequencia registrada como <b>" + tipo + "</b> as <b>" + DateTime.Now.ToString("HH:mm") + "</b>";

                panelConfirmarFrequencia.Visible = false;

                Response.AddHeader("REFRESH", "10;URL=pgFrequencia.aspx");
            }
            catch (Exception erro)
            {
                lblMensagem.Visible = true;
                lblMensagem.CssClass = "alert alert-danger col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
                lblMensagem.Text = erro.Message;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pgFrequencia.aspx");
        }
        protected void btnAutenticar_Click(object sender, EventArgs e)
        {
            try
            {
                Funcionario objFuncionario = (Funcionario)Session["Funcionario"];
                FuncionarioBO objFuncionarioBO = new FuncionarioBO();
                
                string senha = FormsAuthentication.HashPasswordForStoringInConfigFile(txtSenhaConfirmacao.Text, "md5");
                objFuncionarioBO.ConfirmarSenha(objFuncionario, senha);
                
                gvFrequencia.DataSource = new FrequenciaBO().BuscarPeriodo(objFuncionario, DateTime.Now, DateTime.Now);
                gvFrequencia.DataBind();

                panelVerificar.Visible = false;
                panelConfirmarFrequencia.Visible = true;

            }

            catch (Exception erro)
            {
                lblMensagem.Visible = true;
                lblMensagem.CssClass = "alert alert-danger col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
                lblMensagem.Text = erro.Message;
            }

        }
        protected void gvFrequencia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "Dia.DayOfWeek").ToString() == "Saturday")
                {
                    e.Row.BackColor = System.Drawing.Color.Beige;
                }
                else if (DataBinder.Eval(e.Row.DataItem, "Dia.DayOfWeek").ToString() == "Sunday")
                {
                    e.Row.BackColor = System.Drawing.Color.Lavender;
                }
            }
        }
    }
}