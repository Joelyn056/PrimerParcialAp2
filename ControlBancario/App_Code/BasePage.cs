using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;


namespace ControlBancario.App_Code
{
    public class BasePage : Page
    {
        public int ToInt(string text)
        {
            return (string.IsNullOrWhiteSpace(text)) ? 0 : int.Parse(text);
        }

        public decimal ToDecimal(string text)
        {
            return (string.IsNullOrWhiteSpace(text)) ? 0 : decimal.Parse(text);
        }

        public float ToFloat(string text)
        {
            return (string.IsNullOrWhiteSpace(text)) ? 0 : float.Parse(text);
        }

        protected void CallModal(string mensaje)
        {
            Label label = (Label)Master.FindControl("MessageLabel");
            if (label != null)
                label.Text = mensaje;

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert",
                            "$(function() { openModal(); });", true);
        }
    }
}
