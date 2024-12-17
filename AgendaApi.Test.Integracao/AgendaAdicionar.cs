using AgendaApi.Data;
using AgendaApi.Models;
using AgendaApi.Repositories;

namespace AgendaApi.Test.Integracao;

public class AgendaAdicionar
{

    private AgendaContext _context;

    [Fact]
    public void AdicionarAgendaNoBanco()
    {

        // Cenário - Arrange
        string nomeEsperado = "Maria";
        string emailEsperado = "maria@gmail.com";
        string telefoneEsperado = "123456789";
        Agenda agenda = new Agenda(nomeEsperado, emailEsperado, telefoneEsperado);
        AgendaRepository agendaRepository = new AgendaRepository(_context);

        // Ação - Act
        agendaRepository.AdicionarAgenda(agenda);

        // Validação - Assert
        

    }
}