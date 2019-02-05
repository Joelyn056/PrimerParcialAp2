using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL;
using Entidades;

namespace BLL
{
    public class RepositorioDeposito : Repositorio<Depositos>
    {
        public RepositorioDeposito():base()
        {

        }

        public override bool Guardar(Depositos entity)
        {
            var cuenta = _contexto.Cuenta.Find(entity.CuentaId);
            cuenta.Balance += entity.Monto;
            _contexto.Entry(cuenta).State = System.Data.Entity.EntityState.Modified;
            _contexto.SaveChanges();

            return base.Guardar(entity);
        }

        public override bool Modificar(Depositos entity)
        {
            var antdeposito = _contexto.Deposito.Include(x => x.Cuenta)
                                .Where(z => z.DepositoId == entity.DepositoId)
                                .AsNoTracking()
                                .FirstOrDefault();

            Cuentas cuenta = antdeposito.Cuenta;
            cuenta.Balance -= antdeposito.Monto;

            cuenta.Balance += entity.Monto;
            _contexto.Entry(cuenta).State = EntityState.Modified;
            _contexto.SaveChanges();

            return base.Modificar(entity);
        }

        public override bool Eliminar(int id)
        {
            var deposito = Buscar(id);
            Cuentas cuenta = deposito.Cuenta;

            cuenta.Balance -= deposito.Monto;

            _contexto.Entry(cuenta).State = EntityState.Modified;
            _contexto.SaveChanges();

            return base.Eliminar(id);
        }

        public override Depositos Buscar(int id)
        {
            var d = _contexto.Deposito.Include(x => x.Cuenta)
                    .Where(z => z.DepositoId == id)
                    .FirstOrDefault();
            return base.Buscar(id);
        }
    }
     
}
