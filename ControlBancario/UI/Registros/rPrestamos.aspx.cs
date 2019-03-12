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
        List<Cuotas> Detalle = new List<Cuotas>();
        protected void Page_Load(object sender, EventArgs e)
        {
            CuotaGridView.DataSource = null;
            CuotaGridView.DataBind();
            LlenarDropDownList();
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            PrestamosIdTextBox.Text = "0";
            TotalTextBox.Text = "0";
            ViewState["Prestamos"] = new Prestamos();
        }

        public void LlenarCampos(Prestamos prestamos)
        {
            LimpiarCampos();
            PrestamosIdTextBox.Text = prestamos.PrestamosId.ToString();
            FechaTextBox.Text = prestamos.Fecha.ToString("yyy-MM-dd");
            CuentaDropDownList.Text = Convert.ToString(prestamos.CuentaId);
            CapitalTextBox.Text = prestamos.Capital.ToString();
            InteresTextBox.Text = prestamos.Interes.ToString();
            TiempoTextBox.Text = prestamos.Tiempo.ToString();
            TotalTextBox.Text = prestamos.Total.ToString();
            CuotaGridView.DataSource = prestamos.Detalle.ToList();
            this.BindGrid();
        }

        private Prestamos LlenaClase()
        {
            Prestamos prestamos = new Prestamos();

            prestamos.PrestamosId = ToInt(PrestamosIdTextBox.Text);
            prestamos.Fecha = DateTime.Parse(FechaTextBox.Text);
            prestamos.CuentaId = ToInt(CuentaDropDownList.Text);
            prestamos.Capital = ToInt(CapitalTextBox.Text);
            prestamos.Interes = ToInt(InteresTextBox.Text);
            prestamos.Tiempo = ToInt(TiempoTextBox.Text);
            prestamos.Total = ToInt(TotalTextBox.Text);
            prestamos.Detalle = Detalle;

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
            ViewState["Prestamos"] = new Prestamos();
            this.BindGrid();

        }


        private void LlenarDropDownList()
        {
            Repositorio<Cuentas> rep = new Repositorio<Cuentas>();
            CuentaDropDownList.Items.Clear();
            CuentaDropDownList.DataSource = rep.GetList(x => true);
            CuentaDropDownList.DataValueField = "CuentaId";
            CuentaDropDownList.DataValueField = "Nombres";
            CuentaDropDownList.DataBind();
            CuentaDropDownList.Items.Insert(0, new ListItem("", ""));

            ViewState["Prestamos"] = new Prestamos();
        }

        protected void BindGrid()
        {
            CuotaGridView.DataSource = ((Prestamos)ViewState["Prestamos"]).Detalle;
            CuotaGridView.DataBind();
        }

        protected void CalcularLinkButton_Click(object sender, EventArgs e)
        {
            Detalle.Clear();
            int tiempo = ToInt(TiempoTextBox.Text);
            decimal tasa = (ToDecimal(InteresTextBox.Text) / 100);
            decimal cuota = ToDecimal(CapitalTextBox.Text) * (tasa/ 12) / (decimal)(1 - Math.Pow((double)(1 + (tasa / 12)), -tiempo));
            decimal capital = ToDecimal(CapitalTextBox.Text);
            decimal totalc = 0, totalI = 0;


            for(int i = 1; i <= ToInt(TiempoTextBox.Text); ++i)
            {
                Cuotas c = new Cuotas();
                c.Id = ToInt(PrestamosIdTextBox.Text);
                c.NoCuotas = i;
                c.Interes = decimal.Round(capital * (tasa / 12), 2);
                c.Capital = decimal.Round(cuota - c.Interes, 2);
                c.MontoPorCuota = decimal.Round(cuota, 2);
                c.Balance = decimal.Round(capital - c.Capital, 2);

                totalc += c.Capital;
                totalI += c.Interes;

                Detalle.Add(c);

                CuotaGridView.DataSource = Detalle.ToList();
                CuotaGridView.DataBind();
                ViewState["Detalle"] = Detalle;
                TotalTextBox.Text = totalc.ToString();
                
            }
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

                    if (ToInt(PrestamosIdTextBox.Text) == 0)
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
            
        }
    }
}