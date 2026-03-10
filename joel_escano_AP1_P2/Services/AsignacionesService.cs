using joel_escano_AP1_P2.Models;
using joel_escano_AP1_P2.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace joel_escano_AP1_P2.Services;

public class AsignacionesService(IDbContextFactory<Contexto> DbContextFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbContextFactory.CreateDbContextAsync();
        return await contexto.AsignacionesPuntos.AnyAsync(a => a.AsignacionId == id);
    }
    public async Task<bool> Insertar(AsignacionesPuntos asignacion)
    {
        await using var contexto = await DbContextFactory.CreateDbContextAsync();

        asignacion.TotalPuntos = asignacion.AsignacionesPuntosDetalle.Sum(d => d.CantidadPuntos);

        contexto.AsignacionesPuntos.Add(asignacion);

        var estudiante = await contexto.Estudiantes.FindAsync(asignacion.EstudianteId);
        if (estudiante != null)
        {
            estudiante.BalancePuntos += asignacion.TotalPuntos;
        }

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(AsignacionesPuntos asignacion)
    {
        await using var contexto = await DbContextFactory.CreateDbContextAsync();

        var asignacionOriginal = await contexto.AsignacionesPuntos.Include(a => a.AsignacionesPuntosDetalle).FirstOrDefaultAsync(a => a.AsignacionId == asignacion.AsignacionId);

        if (asignacionOriginal == null)
            return false;

        var estudianteOriginal = await contexto.Estudiantes.FindAsync(asignacionOriginal.EstudianteId);
        if (estudianteOriginal != null)
        {
            estudianteOriginal.BalancePuntos -= asignacionOriginal.TotalPuntos;
        }

        contexto.AsignacionesPuntosDetalle.RemoveRange(asignacionOriginal.AsignacionesPuntosDetalle);

        asignacion.TotalPuntos = asignacion.AsignacionesPuntosDetalle.Sum(d => d.CantidadPuntos);
        contexto.Entry(asignacionOriginal).CurrentValues.SetValues(asignacion);

        foreach (var detalle in asignacion.AsignacionesPuntosDetalle)
        {
            contexto.AsignacionesPuntosDetalle.Add(new AsignacionesPuntosDetalle
            {
                AsignacionId = asignacion.AsignacionId,
                TipoPuntosId = detalle.TipoPuntosId,
                CantidadPuntos = detalle.CantidadPuntos
            });
        }

        var estudianteNuevo = await contexto.Estudiantes.FindAsync(asignacion.EstudianteId);
        if (estudianteNuevo != null)
        {
            estudianteNuevo.BalancePuntos += asignacion.TotalPuntos;
        }

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(AsignacionesPuntos asignacion)
    {
        if (!await Existe(asignacion.AsignacionId))
        {
            return await Insertar(asignacion);
        }
        else
        {
            return await Modificar(asignacion);
        }
    }

    public async Task<AsignacionesPuntos?> Buscar(int id)
    {
        await using var contexto = await DbContextFactory.CreateDbContextAsync();
        return await contexto.AsignacionesPuntos
            .Include(a => a.AsignacionesPuntosDetalle)
            .FirstOrDefaultAsync(a => a.AsignacionId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbContextFactory.CreateDbContextAsync();

        var asignacion = await contexto.AsignacionesPuntos
            .Include(a => a.AsignacionesPuntosDetalle)
            .FirstOrDefaultAsync(a => a.AsignacionId == id);

        if (asignacion == null)
            return false;

        var estudiante = await contexto.Estudiantes.FindAsync(asignacion.EstudianteId);
        if (estudiante != null)
        {
            estudiante.BalancePuntos -= asignacion.TotalPuntos;
        }

        contexto.AsignacionesPuntos.Remove(asignacion);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<List<AsignacionesPuntos>> Listar(Expression<Func<AsignacionesPuntos, bool>> criterio)
    {
        await using var contexto = await DbContextFactory.CreateDbContextAsync();
        return await contexto.AsignacionesPuntos.Include(a => a.AsignacionesPuntosDetalle).Where(criterio).AsNoTracking().ToListAsync();
    }
}
