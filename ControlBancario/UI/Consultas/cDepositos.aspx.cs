using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BLL;
using System.Linq.Expressions;
using ControlBancario.App_Code;


namespace ControlBancario.UI.Consultas
{
    public partial class cDepositos : BasePage
    {
        Expression<Func<Depositos, bool>> filter = x => true;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Filtrar()
        {
            int dato = 0;
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filter = x => true;
                    break;

                case 1://DepositoId
                    dato = ToInt(BuscarTextBox.Text);
                    filter = (x => x.DepositosId == dato);
                    break;

                case 2://CuentaId
                    dato = ToInt(BuscarTextBox.Text);
                    filter = (x => x.CuentaId == dato);
                    break;

                case 3://Fecha
                    filter = (x => x.Fecha.Equals(BuscarTextBox.Text));
                    break;

                case 4://Concepto
                    filter = (x => x.Concepto.Contains(BuscarTextBox.Text));
                    break;

                case 5://Monto
                    decimal monto = decimal.Parse(BuscarTextBox.Text);
                    filter = (x => x.Monto == monto);
                    break;
            }
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Repositorio<Depositos> rep = new Repositorio<Depositos>();
            Filtrar();
            DepositoGridView.DataSource = rep.GetList(filter);
            DepositoGridView.DataBind();
        }

        //
        protected void DepositoGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Repositorio<Depositos> rep = new Repositorio<Depositos>();
            DepositoGridView.DataSource = rep.GetList(filter);
            DepositoGridView.PageIndex = e.NewPageIndex;
            DepositoGridView.DataBind();
        }
    }
}