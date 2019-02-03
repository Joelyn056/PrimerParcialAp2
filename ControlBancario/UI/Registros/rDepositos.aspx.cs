using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;
using ControlBancario.App_Code;

namespace ControlBancario.UI.Registros
{
    public partial class rDepositos : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LlenarDropDown();

            FechaTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
        }

        private void LlenarDropDown()
        {
            Repositorio<Cuentas> rep = new Repositorio<Cuentas>();
            CuentaDropDownList.DataSource = rep.GetList(x => true);
            CuentaDropDownList.DataValueField = "CuentaId";
            CuentaDropDownList.DataTextField = "Nombre";
            CuentaDropDownList.DataBind();
            CuentaDropDownList.Items.Insert(0, new ListItem("", ""));
        }

        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            ConceptoTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
            CuentaDropDownList.SelectedIndex = 0;
        }

        private Depositos LlenaClase()
        {
            return new Depositos(
                ToInt(IdTextBox.Text),
                ToInt(CuentaDropDownList.SelectedValue),
                DateTime.Parse(FechaTextBox.Text),
                ConceptoTextBox.Text,
                decimal.Parse(MontoTextBox.Text)
                );
        }

        private void LlenaCampo(Depositos d)
        {
            FechaTextBox.Text = d.Fecha.ToString("yyyy-MM-dd");
            CuentaDropDownList.SelectedValue = d.CuentaId.ToString();
            ConceptoTextBox.Text = d.Concepto;
            MontoTextBox.Text = d.Monto.ToString();
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Depositos> rep = new Repositorio<Depositos>();
            Depositos d = rep.Buscar(ToInt(IdTextBox.Text));

            if (d != null)
                LlenaCampo(d);
            else
                CallModal("Este deposito no existe");
        }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarLinkButton_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                RepositorioDeposito rep = new RepositorioDeposito();

                if(ToInt(IdTextBox.Text) ==0 )
                {
                    if(rep.Guardar(LlenaClase()))
                    {
                        CallModal("Se a registrado el deposito");
                        Limpiar();
                    }
                }
                else
                {
                    if (rep.Modificar(LlenaClase()))
                    {
                        CallModal("Se no se pudo registrar el deposito");
                        Limpiar();
                    }
                }
            }
        }
    }
}