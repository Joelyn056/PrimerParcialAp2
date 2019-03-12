using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    [Serializable]
    public class Prestamos
    {
        [Key]
        public int PrestamosId { get; set; }
        public DateTime Fecha { get; set; }
        public int CuentaId { get; set; }       
        public decimal Capital { get; set; }
        public float Interes { get; set; }
        public int Tiempo { get; set; }
        public decimal Total { get; set; }

        public virtual List<Cuotas> Detalle { get; set; }

        public Prestamos()
        {
            PrestamosId = 0;
            CuentaId = 0;
            Fecha = DateTime.Now;
            Capital = 0;
            Interes = 0;
            Tiempo = 0;
            Total = 0;
            Detalle = new List<Cuotas>();
        }

        public Prestamos(int prestamosId, int cuentaId, DateTime fecha, decimal capital, float interes, int tiempo, decimal total, List<Cuotas> detalle)
        {
            PrestamosId = prestamosId;
            CuentaId = cuentaId;
            Fecha = fecha;
            Capital = capital;
            Interes = interes;
            Tiempo = Tiempo;
            Total = total;
            Detalle = detalle;
            
        }

        public Prestamos(int prestamosId, int cuentaId, decimal capital, float interes, int tiempo, decimal total, List<Cuotas> detalle)
        {
            PrestamosId = prestamosId;
            CuentaId = cuentaId;
            Capital = capital;
            Interes = interes;
            Tiempo = tiempo;
            Total = total;
            Detalle = detalle;
        }      
    }
}
