using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;
using System.Linq.Expressions;
using ControlBancario.App_Code;


namespace ControlBancario.UI.Consultas
{
    public partial class cCuentas : BasePage
    {
        Expression<Func<Cuentas, bool>> filter = x => true;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Filtrar()
        {
            int dato = 0;
            switch(FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filter = x => true;
                    break;

                case 1: ///CuentaId
                    dato = ToInt(BuscarTextBox.Text);
                    filter = (x => x.CuentaId == dato);
                    break;

                case 2: //Fecha
                    filter = (x => x.Fecha.Equals(BuscarTextBox.Text));
                    break;

                case 3://Nombre
                    filter = (x => x.Nombre.Contains(BuscarTextBox.Text));
                    break;

                case 4://Balance
                    decimal balance = decimal.Parse(BuscarTextBox.Text);
                    filter = (x => x.Balance == balance);
                    break;

            }
        }
        //
        protected void CuentaGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Repositorio<Cuentas> rep = new Repositorio<Cuentas>();
            CuentaGridView.DataSource = rep.GetList(filter);
            CuentaGridView.PageIndex = e.NewPageIndex;
            CuentaGridView.DataBind();
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Cuentas> rep = new Repositorio<Cuentas>();
            Filtrar();
            CuentaGridView.DataSource = rep.GetList(filter);
            CuentaGridView.DataBind();
        }
    }
}