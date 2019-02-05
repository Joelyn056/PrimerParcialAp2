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
        public int CuentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public decimal Balance { get; set; }

        public Cuentas()
        {
            CuentaId = 0;
            Fecha = DateTime.Now;
            Nombre = string.Empty;
            Balance = 0;

        }

        public Cuentas(int id, DateTime fecha, string nombre, decimal balance)
        {
            CuentaId = id;
            Fecha = fecha;
            Nombre = nombre;
            Balance = balance;
        }
    }
}
