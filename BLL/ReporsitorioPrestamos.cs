using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using Entidades;
    

namespace BLL
{
   public class ReporsitorioPrestamos : Repositorio<Prestamos>
    {
        public ReporsitorioPrestamos() : base()
        {

        }

        public override bool Guardar(Prestamos entity)
        {
            Cuentas cuenta = _contexto.Cuenta.Find(entity.CuentaId);
            AcumularBalance(cuenta, entity.Total);

            return base.Guardar(entity);
        }

        private void AcumularBalance (Cuentas cuenta, decimal valor)
        {
            cuenta.Balance += valor;
            _contexto.Entry(cuenta).State = EntityState.Modified;
        }

        private void RestarBalance(Cuentas cuenta, decimal valor)
        {
            cuenta.Balance -= valor;
            _contexto.Entry(cuenta).State = EntityState.Modified;
        }

        public override bool Modificar(Prestamos entity)
        {
            var prestamoAnt = BuscarAsNoTracking(entity.PrestamosId);
            var cuenta = _contexto.Cuenta.Find(entity.CuentaId);
            RestarBalance(cuenta, prestamoAnt.Total);

            foreach (var item in prestamoAnt.Detalle)
                _contexto.Entry(item).State = EntityState.Deleted;

            foreach (var item in entity.Detalle)
                _contexto.Entry(item).State = (item.Id == 0) ? EntityState.Added : EntityState.Modified;

            AcumularBalance(cuenta, entity.Total);

            return base.Modificar(entity);
        }

        public override bool Eliminar(int id)
        {
            Prestamos prestamo = Buscar(id);
            Cuentas cuenta = _contexto.Cuenta.Find(prestamo.CuentaId);
            RestarBalance(cuenta, prestamo.Total);
            return base.Eliminar(id);
        }

        public override Prestamos Buscar(int id)
        {
            Prestamos prestamo = _contexto.Prestamo.
                                 Include(x => x.Detalle)
                                 .Where(z => z.PrestamosId == id)
                                 .FirstOrDefault();
            return prestamo;
        }

        public Prestamos BuscarAsNoTracking(int id)
        {
            Prestamos prestamo = _contexto.Prestamo.
                                 Include(x => x.Detalle)
                                 .Where(z => z.PrestamosId == id)
                                 .AsNoTracking()
                                 .FirstOrDefault();
            return prestamo;
        }

        public override List<Prestamos> GetList(Expression<Func<Prestamos, bool>> expression)
        {
            var lista = _contexto.Prestamo.Include(x => x.Detalle).Where(expression).ToList();
            return lista;
        }
    }
}
