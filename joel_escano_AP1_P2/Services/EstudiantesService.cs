using joel_escano_AP1_P2.DAL;
using joel_escano_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace joel_escano_AP1_P2.Services;

public class EstudiantesService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<List<Estudiantes>> Listar(Expression<Func<Estudiantes, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes.Where(criterio).AsNoTracking().ToListAsync();
    }
}
