using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlBancario.App_Code;
using Entidades;
using BLL;

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
                

                
            }
            
        }
       
    }
}