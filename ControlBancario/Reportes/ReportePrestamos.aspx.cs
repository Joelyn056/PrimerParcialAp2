using ControlBancario.UI.Consultas;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlBancario.Reportes
{
    public partial class ReportePrestamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PrestamosReportViewer.ProcessingMode = ProcessingMode.Local;
                PrestamosReportViewer.Reset();
                PrestamosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ReportePrestamos.rdlc");
                PrestamosReportViewer.LocalReport.DataSources.Clear();
                PrestamosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Prestamos", cPrestamos.lista ));
                PrestamosReportViewer.LocalReport.Refresh();
                
            }
        }
    }
}