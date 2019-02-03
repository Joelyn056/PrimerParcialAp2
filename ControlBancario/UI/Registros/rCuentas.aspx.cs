using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using ControlBancario.App_Code;
using Entidades;

namespace ControlBancario.UI.Registros
{
    public partial class rCuentas : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
        }

        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            NombreTextBox.Text = string.Empty;
            BalanceTextBox.Text = string.Empty;
        }

        private Cuentas LlenaClase()
        {
            return new Cuentas(
                ToInt(IdTextBox.Text),
                DateTime.Parse(FechaTextBox.Text),
                NombreTextBox.Text,
                0
                );
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Cuentas> rep = new Repositorio<Cuentas>();
            Cuentas c = rep.Buscar(ToInt(IdTextBox.Text));
            if (c != null)
            {
                FechaTextBox.Text = c.Fecha.ToString("yyyy-MM-dd");
                NombreTextBox.Text = c.Nombre;
                BalanceTextBox.Text = c.Balance.ToString();
            }
            else
                CallModal("Esta cuenta no existe");
        }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioCuenta rep = new RepositorioCuenta();
            Cuentas c = rep.Buscar(ToInt(IdTextBox.Text));

            if( c != null)
            {
                if(rep.Eliminar(ToInt(IdTextBox.Text)))
                {
                    CallModal("Se elimino la cuenta");
                    Limpiar();
                }
                else
                    CallModal("No se elimino la cuenta");
            }
        }

        protected void GuardarLinkButton_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                Repositorio<Cuentas> rep = new Repositorio<Cuentas>();

                if(ToInt(IdTextBox.Text) == 0)
                {
                    if (rep.Guardar(LlenaClase()))
                    {
                        CallModal("Se guardo la cuenta");
                        Limpiar();

                    }
                }
                else
                {
                    if (rep.Modificar(LlenaClase()))
                    {
                        CallModal("Se modifico la cuenta");
                        Limpiar();
                    }
                }
            }
        }
    }
}