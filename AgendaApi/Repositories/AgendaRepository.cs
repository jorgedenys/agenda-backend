using AgendaApi.Data;
using AgendaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Repositories;

public class AgendaRepository
{

    private AgendaContext _context;

    public AgendaRepository(AgendaContext context)
    {
        _context = context;
    }

    public List<Agenda> ListarAgendaOrdenadaPorNome(int skip, int take)
    {
        return _context.Agendas
            .FromSqlRaw("SELECT Id, Nome, Email, Telefone, EnderecoId FROM agendas ORDER BY Nome")
            .Skip(skip).Take(take).ToList();
    }
    
    public Agenda BuscarAgenda(int id)
    {
        return _context.Agendas.FirstOrDefault(agenda => agenda.Id == id);
    }

    public void AdicionarAgenda(Agenda agenda)
    {
        _context.Agendas.Add(agenda);
        _context.SaveChanges();
    }

    public void AtualizarAgenda(Agenda agenda)
    {
        _context.Agendas.Update(agenda);
        _context.SaveChanges();
    }

    public void DeletarAgenda(Agenda agenda)
    {
        _context.Agendas.Remove(agenda);
        _context.SaveChanges();
    }

}
