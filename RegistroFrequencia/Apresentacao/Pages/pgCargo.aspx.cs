using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Model;
using Negocio.BO;

namespace Apresentacao.Pages
{
    public partial class pgCargo : System.Web.UI.Page
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
                    CarregarGrid();                    
                }
            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.Message;
                lblMensagem.CssClass = "alert alert-danger col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
                lblMensagem.Visible = true;
            }
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(hfId.Value))
                {
                    Cargo objCargo = new Cargo();

                    objCargo.Nome = txtNomeCargo.Text;
                    objCargo.CargaHoraria = TimeSpan.Parse(txtCargaHoraria.Text);

                    CargoBO objCargoBO = new CargoBO();
                    objCargoBO.Salvar(objCargo);


                    lblMensagem.CssClass = "alert alert-success col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
                    lblMensagem.Text = "Cargo gravado com sucesso!";

                    LimparForm();
                    CarregarGrid();
                }
                else
                {

                    Cargo objCargo = new Cargo();

                    objCargo.Id = Convert.ToInt16(hfId.Value);
                    objCargo.Nome = txtNomeCargo.Text;
                    objCargo.CargaHoraria = TimeSpan.Parse(txtCargaHoraria.Text);

                    CargoBO objCargoBO = new CargoBO();
                    objCargoBO.Alterar(objCargo);

                    lblMensagem.CssClass = "alert alert-success col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
                    lblMensagem.Text = "Cargo <b>" + objCargo.Nome + "</b> alterado com sucesso!";


                    LimparForm();
                    CarregarGrid();
                }

            }
            catch (Exception erro)
            {
                lblMensagem.CssClass = "alert alert-danger col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
                lblMensagem.Text = erro.Message;
            }
        }

        private void CarregarGrid()
        {
            if (Session["Usuario"] != null)
            {
                CargoBO objCargoBO = new CargoBO();
                gvCargos.DataSource = objCargoBO.BuscarTodos((Funcionario)Session["Usuario"]);
                gvCargos.DataBind();
            }
        }

        private void LimparForm()
        {
            txtCargaHoraria.Text = String.Empty;
            txtFiltrar.Text = String.Empty;
            txtNomeCargo.Text = String.Empty;
            hfId.Value = String.Empty;
        }
        protected void gvCargos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(gvCargos.SelectedDataKey.Value);
            Cargo objCargo = new CargoBO().BuscarID(id);

            txtCargaHoraria.Text = Convert.ToString(objCargo.CargaHoraria);
            txtNomeCargo.Text = Convert.ToString(objCargo.Nome);
            hfId.Value = Convert.ToString(objCargo.Id);


            lblMensagem.CssClass = "alert alert-warning col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
            lblMensagem.Text = "Você está editando o Cargo: <b>" + objCargo.Nome + "</b>";
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargoBO objCargoBO = new CargoBO();
            string atributo, valor;

            atributo = ddlFiltro.SelectedValue;
            valor = txtFiltrar.Text;

            gvCargos.DataSource = objCargoBO.Filtrar(atributo, valor);
            gvCargos.DataBind();
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparForm();
            lblMensagem.Text = "Preencha os dados corretamente!";
            lblMensagem.CssClass = "alert alert-info col-sm-8 col-md-8 col-xs-8 col-lg-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2 col-xs-offset-2 text-center";
        }
    }
}