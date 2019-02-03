using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Depositos
    {
        [Key]
        public int DepositosId { get; set; }
        public int CuentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public virtual Cuentas Cuenta { get; set; }

        public Depositos()
        {
            DepositosId = 0;
            CuentaId = 0;
            Fecha = DateTime.Now;
            Concepto = string.Empty;
            Monto = 0;
        }

        public Depositos(int depositosId, int cuentaId, DateTime fecha, string concepto, decimal monto)
        {
            DepositosId = depositosId;
            CuentaId = cuentaId;
            Fecha = fecha;
            Concepto = concepto;
            Monto = monto;
            
        }
    }
}
