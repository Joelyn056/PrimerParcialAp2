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
    public partial class cPrestamos : BasePage
    {
        Expression<Func<Prestamos, bool>> filter = x => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FInicialTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FFinalTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

        }

        private void Filtrar()
        {
            var dato = 0;
            string i = DateTime.Parse(FInicialTextBox.Text).Date.ToString("yyyy-MM-dd");
            DateTime fInicial = DateTime.Parse(i);

            string f = DateTime.Parse(FFinalTextBox.Text).Date.ToString("yyyy-MM-dd");
            DateTime fFinal = DateTime.Parse(f);

            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0: //Todo
                    filter = x => true;
                    break;

                case 1://PrestamosId
                    dato = ToInt(BuscarTextBox.Text);
                    filter = (x => x.PrestamosId == dato && ((x.Fecha >= fInicial) && (x.Fecha <= fFinal)));
                    break;

                case 2://Fecha
                    filter = (x => x.Fecha.Equals(BuscarTextBox.Text));
                    break;

                case 3://CuentaId
                    dato = ToInt(BuscarTextBox.Text);
                    filter = (x => x.CuentaId == dato && ((x.Fecha >= fInicial) && (x.Fecha <= fFinal)));
                    break;

                case 4://Capital
                    decimal c = ToDecimal(BuscarTextBox.Text);
                    filter = (x => x.Capital <= c && ((x.Fecha >= fInicial) && (x.Fecha <= fFinal)));
                    break;

                case 5://Interes
                    float interes = ToFloat(BuscarTextBox.Text);
                    filter = (x => x.Interes <= interes && ((x.Fecha >= fInicial) && (x.Fecha <= fFinal)));
                    break;

                case 6://Tiempo
                    dato = ToInt(BuscarTextBox.Text);
                    filter = (x => x.Tiempo <= dato && ((x.Fecha >= fInicial) && (x.Fecha <= fFinal)));
                    break;

                case 7://Total
                    decimal total = ToDecimal(BuscarTextBox.Text);
                    filter = (x => x.Total <= total && ((x.Fecha >= fInicial) && (x.Fecha <= fFinal)));
                    break;
            }
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            ReporsitorioPrestamos rep = new ReporsitorioPrestamos();
            Filtrar();
            PrestamoGridView.DataSource = rep.GetList(filter);
            PrestamoGridView.DataBind();
        }


        protected void PrestamoGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ReporsitorioPrestamos rep = new ReporsitorioPrestamos();
            PrestamoGridView.DataSource = rep.GetList(filter);
            PrestamoGridView.PageIndex = e.NewPageIndex;
            PrestamoGridView.DataBind();
        }

        protected void ButtonImprimir_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Reportes/ListadoDePrestamos.aspx");
        }
      
    }
}