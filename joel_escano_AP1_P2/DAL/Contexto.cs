namespace joel_escano_AP1_P2.DAL;
using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)  : base(options) {}

}
