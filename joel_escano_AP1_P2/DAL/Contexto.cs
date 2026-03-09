namespace joel_escano_AP1_P2.DAL;
using Microsoft.EntityFrameworkCore;
using joel_escano_AP1_P2.Models;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)  : base(options) {}

    public DbSet<AsignacionesPuntos> ViajesEspaciales{ get; set; }

}
