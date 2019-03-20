using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlBancario.UI.Consultas;
using Microsoft.Reporting.WebForms;

namespace ControlBancario.Reportes
{
    public partial class ReporteDepositos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DepositosReportViewer.ProcessingMode = ProcessingMode.Local;
                DepositosReportViewer.Reset();
                DepositosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ReporteDepositos.rdlc");
                DepositosReportViewer.LocalReport.DataSources.Clear();
                DepositosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Depositos", cDepositos.lista));
                DepositosReportViewer.LocalReport.Refresh();
            }
        }
    }
}