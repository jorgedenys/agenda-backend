using AgendaApi.Models;
using AgendaApi.Repositories;

namespace AgendaApi.Services;

public class AgendaService
{
    
    private AgendaRepository _agendaRepository;

    public AgendaService(AgendaRepository agendaRepository)
    {
        _agendaRepository = agendaRepository;
    }

    public List<Agenda> ListarAgendaOrdenadaPorNome(int skip, int take)
    {
        return _agendaRepository.ListarAgendaOrdenadaPorNome(skip, take);
    }

    public Agenda BuscarAgenda(int id)
    {
        return _agendaRepository.BuscarAgenda(id);
    }

    public void AdicionarAgenda(Agenda agenda)
    {
        _agendaRepository.AdicionarAgenda(agenda);
    }

    public void AtualizarAgenda(Agenda agenda)
    {
        _agendaRepository.AtualizarAgenda(agenda);
    }

    public void DeletarAgenda(Agenda agenda)
    {
        _agendaRepository.DeletarAgenda(agenda);
    }

}
