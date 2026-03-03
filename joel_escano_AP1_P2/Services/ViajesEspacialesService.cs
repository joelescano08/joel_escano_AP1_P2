using joel_escano_AP1_P2.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using joel_escano_AP1_P2.Models;

namespace joel_escano_AP1_P2.Services
{
    public class ViajesEspacialesService(IDbContextFactory<Contexto> DbContextFactory)
    {

        public async Task<bool> Existe(int id)
        {
            return true;
        }

        public async Task<bool> Insertar(ViajesEspaciales Viaje)
        {
            return true;
        }

        public async Task<bool> Modificar(ViajesEspaciales Viaje)
        {
            return true;
        }

       

        public async Task<bool> Guardar(ViajesEspaciales Viaje)
        {
            return true;
        }

        public async Task<List<ViajesEspaciales>> Listar(Expression<Func<ViajesEspaciales, bool>> criterio)
        {
            await using var contexto = await DbContextFactory.CreateDbContextAsync();

            return await contexto.ViajesEspaciales.Where(criterio).AsNoTracking().ToListAsync();
        }

        public async Task<bool> Eliminar(int id)
        {
            return true;
        }
    }
}
