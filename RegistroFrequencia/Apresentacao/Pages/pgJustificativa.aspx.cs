using Negocio.BO;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apresentacao.Pages
{
    public partial class pgJustificativa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("pgLogin.aspx");
                }

                if (!IsPostBack)
                {
                    CarregarDDLMotivo();
                    CarregarGVJustificativas();
                }
            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.Message;
                lblMensagem.CssClass = "alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
            }

        }


        private void CarregarGVJustificativas()
        {
            gvJustificativas.DataSource = new JustificativaBO().BuscarTodosFuncionario((Funcionario)Session["Usuario"]);
            gvJustificativas.DataBind();
        }
        private void CarregarDDLMotivo()
        {
            ddlMotivo.DataSource = Enum.GetNames(typeof(Motivo));
            ddlMotivo.DataBind();
        }
        private void LimparForm()
        {
            hfId.Value = String.Empty;
            txtDataFinal.Text = String.Empty;
            txtDataInicial.Text = String.Empty;
            txtDescricao.Text = String.Empty;
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(hfId.Value))
                {
                    Justificativa objJustificativa = new Justificativa();

                    if (fileComprovante.HasFile)
                    {
                        objJustificativa.Comprovante = fileComprovante.FileBytes;
                    }
                    else
                    {
                        objJustificativa.Comprovante = null;
                    }

                    objJustificativa.InicioPeriodo = Convert.ToDateTime(txtDataInicial.Text);
                    objJustificativa.FimPeriodo = Convert.ToDateTime(txtDataFinal.Text);
                    objJustificativa.Complemento = txtDescricao.Text;
                    objJustificativa.Motivo = (Motivo)Enum.Parse((typeof(Motivo)), ddlMotivo.SelectedValue);
                    objJustificativa.Funcionario = (Funcionario)Session["Usuario"];

                    if (Session["Usuario"] != null)
                    {
                        objJustificativa.Funcionario = (Funcionario)Session["Usuario"];
                    }

                    JustificativaBO objJustificativaBO = new JustificativaBO();
                    objJustificativaBO.Salvar(objJustificativa);

                    lblMensagem.Text = "Justificativa salva com sucesso!";
                    lblMensagem.CssClass = "alert alert-success col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";

                    LimparForm();
                    CarregarGVJustificativas();
                }
                else
                {
                    if (Session["Usuario"] != null)
                    {
                        Justificativa objJustificativa = new Justificativa();

                        if (fileComprovante.HasFile)
                        {
                            objJustificativa.Comprovante = fileComprovante.FileBytes;
                        }
                        else
                        {
                            objJustificativa.Comprovante = null;
                        }

                        objJustificativa.InicioPeriodo = Convert.ToDateTime(txtDataInicial.Text);
                        objJustificativa.Id = Convert.ToInt16(hfId.Value);
                        objJustificativa.FimPeriodo = Convert.ToDateTime(txtDataFinal.Text);
                        objJustificativa.Complemento = txtDescricao.Text;
                        objJustificativa.Motivo = (Motivo)Enum.Parse((typeof(Motivo)), ddlMotivo.SelectedValue);
                        objJustificativa.Funcionario = (Funcionario)Session["Usuario"];

                        objJustificativa.Funcionario = (Funcionario)Session["Usuario"];

                        JustificativaBO objJustificativaBO = new JustificativaBO();
                        objJustificativaBO.Alterar(objJustificativa);

                        lblMensagem.Text = "Justificativa alterada com sucesso!";
                        lblMensagem.CssClass = "alert alert-success col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";


                        LimparForm();
                        CarregarGVJustificativas();
                    }
                }
            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.Message;
                lblMensagem.CssClass = "alert alert-danger col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
            }
        }

        protected void gvJustificativas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(gvJustificativas.SelectedDataKey.Value);
                Justificativa objJustificativa = new JustificativaBO().BuscarID(id);

                if (objJustificativa.Aprovacao == true)
                {
                    throw new Exception("Não é possível alterar uma justificativa que já foi aprovada.");
                }
                else
                {
                    txtDataFinal.Text = objJustificativa.FimPeriodo.ToString();
                    txtDataInicial.Text = objJustificativa.InicioPeriodo.ToString();
                    ddlMotivo.SelectedItem.Text = objJustificativa.Motivo.ToString();
                    txtDescricao.Text = objJustificativa.Complemento;
                    hfId.Value = objJustificativa.Id.ToString();

                    lblMensagem.CssClass = "alert alert-warning col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
                    lblMensagem.Text = "Você está alterando uma justificativa";
                }

            }
            catch (Exception erro)
            {
                lblMensagem.CssClass = "alert alert-danger col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
                lblMensagem.Text = erro.Message;
            }
        }
        protected void gvJustificativas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "comprovante_click")
                {
                    int index = Convert.ToInt16(e.CommandArgument);
                    int id = Convert.ToInt32(gvJustificativas.DataKeys[index].Value);


                    Justificativa objJustificativa = new JustificativaBO().BuscarID(id);


                    Response.ClearContent();
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + objJustificativa.Id + objJustificativa.Motivo + DateTime.Now + ".pdf;");
                    Response.BinaryWrite(objJustificativa.Comprovante);
                    Response.End();
                }

            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.Message;
                lblMensagem.CssClass = "alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparForm();
            lblMensagem.Text = "Preencha os dados corretamente!";
            lblMensagem.CssClass = "alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
        }

    }
}