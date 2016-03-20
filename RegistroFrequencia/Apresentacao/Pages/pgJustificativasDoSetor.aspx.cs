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
    public partial class pgAutorizarJustificativa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("../Pages/pgLogin.aspx");
                }
                else if (((Funcionario)Session["Usuario"]).Cargo.Nome != "Gerente")
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
            gvJustificativas.DataSource = new JustificativaBO().BuscarTodosPendentes((Funcionario)Session["Usuario"]);
            gvJustificativas.DataBind();

            gvJustificativasRegional.DataSource = new JustificativaBO().BuscarTodosAutorizados((Funcionario)Session["Usuario"]);
            gvJustificativasRegional.DataBind();

        }
        protected void gvJustificativas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(gvJustificativas.SelectedDataKey.Value);
            JustificativaBO objJustificativaBO = new JustificativaBO();

            Justificativa objJustificativa = objJustificativaBO.BuscarID(id);
            objJustificativa.Aprovacao = true;
            objJustificativa.Responsavel = (Funcionario)Session["Usuario"];

            objJustificativaBO.AlterarEstado(objJustificativa);

            CarregarGV();
        }

        protected void gvJustificativas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "comprovantePendente_click")
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

        protected void gvJustificativasRegional_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "comprovanteAutorizado_click")
            {
                int index = Convert.ToInt16(e.CommandArgument);
                int id = Convert.ToInt32(gvJustificativasRegional.DataKeys[index].Value);


                Justificativa objJustificativa = new JustificativaBO().BuscarID(id);


                Response.ClearContent();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + objJustificativa.Id + objJustificativa.Motivo + DateTime.Now + ".pdf;");
                Response.BinaryWrite(objJustificativa.Comprovante);
                Response.End();

            }

        }
    }
}