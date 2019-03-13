using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using ControlBancario.App_Code;
using Entidades;
using System.Text.RegularExpressions;


namespace ControlBancario.UI.Registros
{
    public partial class rPrestamos : BasePage
    {
        public bool SeBusco { get; set; }
        List<Cuotas> detalle = new List<Cuotas>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PrestamoReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                PrestamoReportViewer.Reset();

                PrestamoReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ReportePrestamos.rdlc");

                LlenarDropdownList();
                ViewState.Add("Detalle", detalle);
                ViewState.Add("SeBusco", SeBusco);

                //CuotaGridView.DataSource = null;
                //CuotaGridView.DataBind();
                //LlenarDropDownList();
                //FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //PrestamosIdTextBox.Text = "0";
                //TotalTextBox.Text = "0";
            }
            else
            {
                detalle = (List<Cuotas>)ViewState["Detalle"];
                SeBusco = (bool)ViewState["SeBusco"];
            }

            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

        }

        public void LlenarCampos(Prestamos prestamos)
        {
            //LimpiarCampos();
            
            PrestamosIdTextBox.Text = prestamos.PrestamosId.ToString();
            FechaTextBox.Text = prestamos.Fecha.ToString("yyy-MM-dd");
            CuentaDropDownList.SelectedValue = prestamos.CuentaId.ToString();
            //CuentaDropDownList.Text= Convert.ToString(prestamos.CuentaId);
            CapitalTextBox.Text = prestamos.Capital.ToString();
            InteresTextBox.Text = prestamos.Interes.ToString();
            TiempoTextBox.Text = prestamos.Tiempo.ToString();
            TotalTextBox.Text = prestamos.Total.ToString();
            CuotaGridView.DataSource = prestamos.Detalle.ToList();
            CuotaGridView.DataBind();
            ViewState["Detalle"] = prestamos.Detalle;
           
        }

        private Prestamos LlenaClase()
        {

            Prestamos prestamos = new Prestamos();

            //prestamos.PrestamosId = ToInt(PrestamosIdTextBox.Text);
            prestamos.Fecha = DateTime.Parse(FechaTextBox.Text);
            prestamos.CuentaId = ToInt2(CuentaDropDownList.Text);
            prestamos.Capital = ToInt2(CapitalTextBox.Text);
            prestamos.Interes = ToInt2(InteresTextBox.Text);
            prestamos.Tiempo = ToInt2(TiempoTextBox.Text);
            prestamos.Total = ToDecimal(TotalTextBox.Text);
            prestamos.Detalle = detalle;


            return prestamos;

        }

        private void LimpiarCampos()
        {
            PrestamosIdTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            CuentaDropDownList.SelectedIndex = 0;
            CapitalTextBox.Text = string.Empty;
            InteresTextBox.Text = string.Empty;
            TiempoTextBox.Text = string.Empty;
            TotalTextBox.Text = string.Empty;
            CuotaGridView.DataSource = null;
            CuotaGridView.DataBind();
            SeBusco = false;
            ViewState["SeBusco"] = SeBusco;
          

        }

        private void LlenarDropdownList()
        {
            Repositorio<Cuentas> rep = new Repositorio<Cuentas>();
            CuentaDropDownList.DataSource = rep.GetList(x => true);
            CuentaDropDownList.DataValueField = "CuentaId";
            CuentaDropDownList.DataTextField = "Nombre";
            CuentaDropDownList.DataBind();
            CuentaDropDownList.Items.Insert(0, new ListItem("", ""));
        }




        protected void CalcularLinkButton_Click(object sender, EventArgs e)
        {
            detalle.Clear();
            int tiempo = ToInt(TiempoTextBox.Text);
            decimal tasa = (ToDecimal(InteresTextBox.Text) / 100);
            decimal cuota = ToDecimal(CapitalTextBox.Text) * (tasa/ 12) / (decimal)(1 - Math.Pow((double)(1 + (tasa / 12)), -tiempo));
            decimal capital = ToDecimal(CapitalTextBox.Text);
            decimal totalc = 0, totalI = 0, total= 0;
            decimal interes = decimal.Round(capital * (tasa) / tiempo);
            total = (capital + (capital * tasa));
            for (int i = 1; i <= tiempo; ++i)
            {
                Cuotas c = new Cuotas();
                c.Id = ToInt(PrestamosIdTextBox.Text);
                // c.NoCuotas = i;
                //c.Interes = decimal.Round(capital * (tasa / 12), 2);
                c.Interes = interes;
                c.Capital = decimal.Round(cuota - c.Interes, 2);
                c.MontoPorCuota = decimal.Round(cuota, 2);
                c.Balance = decimal.Round(capital - c.Capital, 2);
                capital = c.Balance;
                c.NoCuotas = i;

                //totalc += c.Capital;
                //totalI += c.Interes;
            
                detalle.Add(c);               
            }
            

            CuotaGridView.DataSource = detalle.ToList();
            CuotaGridView.DataBind();
            ViewState["Detalle"] = detalle;
            TotalTextBox.Text = total.ToString();
            
        }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        protected void GuardarLinkButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (IsAmortizacionCalculada())
                {
                    ReporsitorioPrestamos rep = new ReporsitorioPrestamos();

                    Prestamos prestamo = rep.Buscar(ToInt2(PrestamosIdTextBox.Text));

                    if ( prestamo == null )
                    {
                        if(rep.Guardar(LlenaClase()))
                        {
                            CallModal("Prestamo registrado" + LlenaClase().Detalle.Count);
                            LimpiarCampos();
                        }
                    }
                    else
                    {
                        if (rep.Modificar(LlenaClase()))
                        {
                            CallModal("El prestamo a sido modifiado.");
                            LimpiarCampos();
                        }
                    }
                }
                else
                    CallModal("La amortizacion no a sido calculada.");
            }
        }

        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        {
            ReporsitorioPrestamos rep = new ReporsitorioPrestamos();
            Prestamos prestamos = rep.Buscar(ToInt(PrestamosIdTextBox.Text));

            if(prestamos != null)
            {
                if (rep.Eliminar(ToInt(PrestamosIdTextBox.Text)))
                {
                    CallModal("Prestamo eliminado");
                    LimpiarCampos();
                }
                else
                    CallModal("El prestamo no pudo ser eliminado");
            }
            
        }

        private bool IsAmortizacionCalculada()
        {
            return (CuotaGridView.DataSource != null || CuotaGridView.Rows.Count > 0) ? true : false;
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {
            if (SeBusco)
            {
                PrestamoReportViewer.LocalReport.DataSources.Clear();

                int id = ToInt(PrestamosIdTextBox.Text);
                PrestamoReportViewer.LocalReport.DataSources.Add(
                    new Microsoft.Reporting.WebForms.ReportDataSource(
                        "Prestamos",
                        new Repositorio<Prestamos>().GetList(x => x.PrestamosId == id)));

                PrestamoReportViewer.LocalReport.DataSources.Add(
                    new Microsoft.Reporting.WebForms.ReportDataSource(
                        "Cuota",
                        new ReporsitorioPrestamos().Buscar(id).Detalle.ToList()));

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Report",
                    "$(function() { openReportModal(); });", true);
            }
            else
                CallModal("Debe Buscar el prestamo primero");
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            ReporsitorioPrestamos rep = new ReporsitorioPrestamos();
            Prestamos prestamos = rep.Buscar(ToInt(PrestamosIdTextBox.Text));

            if (prestamos != null)
            {
                LlenarCampos(prestamos);
                SeBusco = true;
                ViewState["SeBusco"] = SeBusco;
            }
            else
                CallModal("Este Prestamo no Existe");
        }

        protected void CuotaGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CuotaGridView.DataSource = (List<Cuotas>)ViewState["Detalle"];
            CuotaGridView.PageIndex = e.NewPageIndex;
            CuotaGridView.DataBind();
        }
    }
}