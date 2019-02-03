using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entidades;
using DAL;

namespace BLL
{
    public class RepositorioCuenta: Repositorio<Cuentas>
    {
        public RepositorioCuenta():base()
        {

        }
    }
}
