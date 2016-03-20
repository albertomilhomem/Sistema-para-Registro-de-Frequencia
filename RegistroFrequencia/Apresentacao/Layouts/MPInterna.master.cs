using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apresentacao.Layouts
{
    public partial class MPInterna : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Pages/pgLogin.aspx");
            }
            else
            {
                lblUsuario.Text = ((Funcionario)Session["Usuario"]).Nome.Split(' ')[0];

                if (((Funcionario)Session["Usuario"]).Administrador == true && ((Funcionario)Session["Usuario"]).Cargo.Nome == "Gerente")
                {                    
                    liAdministrador.Visible = false;
                    liGerente.Visible = false;
                    liGerenteAdm.Visible = true;
                    liAdmGerente.Visible = true;
                    liPessoal.Visible = true;
                    liManualDesenvolvedor.Visible = true;
                }
                else if (((Funcionario)Session["Usuario"]).Cargo.Nome == "Gerente")
                {
                    liAdministrador.Visible = false;
                    liGerente.Visible = true;
                    liPessoal.Visible = true;

                    liGerenteAdm.Visible = false;
                    liAdmGerente.Visible = false;
                }
                else if (((Funcionario)Session["Usuario"]).Administrador == true)
                {
                    liAdministrador.Visible = true;
                    liGerente.Visible = false;
                    liPessoal.Visible = true;
                    liGerenteAdm.Visible = false;
                    liAdmGerente.Visible = false;
                    liManualDesenvolvedor.Visible = true;
                }
                else
                {
                    liAdministrador.Visible = false;
                    liGerente.Visible = false;
                    liPessoal.Visible = true;
                    liGerenteAdm.Visible = false;
                    liAdmGerente.Visible = false;
                }
            }



        }
    }
}