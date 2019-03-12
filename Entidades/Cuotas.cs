using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    [Serializable]
    public class Cuotas
    {
        [Key]
        public int Id { get; set; }
        public int NoCuotas { get; set; }        
        public DateTime Fecha { get; set;}
        public decimal Interes { get; set; }
        public decimal Capital { get; set; }
        public decimal MontoPorCuota { get; set;}
        public decimal Balance { get; set; }

        public Cuotas()
        {
            NoCuotas = 0;
            Id = 0;
            Fecha = DateTime.Now;
            Interes = 0;
            Capital = 0;
            MontoPorCuota = 0;
            Balance = 0;
        }

        public Cuotas(int id, int noCuotas, DateTime fecha, decimal interes, decimal capital, decimal montoPorCuota, decimal balance)
        {
            Id = id;
            NoCuotas = noCuotas;           
            Fecha = fecha;
            Interes = interes;
            Capital = capital;
            MontoPorCuota = montoPorCuota;
            Balance = balance;
        }
    }   
}
