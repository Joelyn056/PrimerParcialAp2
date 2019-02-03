using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Cuentas
    {
        [Key]
        public int CuentasId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public decimal Balance { get; set; }

        public Cuentas()
        {
            CuentasId = 0;
            Fecha = DateTime.Now;
            Nombre = string.Empty;
            Balance = 0;

        }

        public Cuentas(int cuentasId, DateTime fecha, string nombre, decimal balance)
        {
            CuentasId = cuentasId;
            Fecha = fecha;
            Nombre = nombre;
            Balance = balance;
        }
    }
}
