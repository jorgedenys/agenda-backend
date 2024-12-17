using AgendaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Data;

public class AgendaContext : DbContext
{

    public DbSet<Agenda> Agendas { get; set; }

    public DbSet<Endereco> Enderecos { get; set; }

    public AgendaContext(DbContextOptions<AgendaContext> opts) : base(opts)
    {

    }

}
