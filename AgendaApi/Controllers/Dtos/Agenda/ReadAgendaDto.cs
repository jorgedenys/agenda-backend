using AgendaApi.Controllers.Dtos.Endereco;

namespace AgendaApi.Controllers.Dtos.Agenda;

public class ReadAgendaDto
{

    public int Id { get; set; }

    public string Nome { get; set; }

    public string Email { get; set; }

    public string Telefone { get; set; }

    public int EnderecoId { get; set; }

}
