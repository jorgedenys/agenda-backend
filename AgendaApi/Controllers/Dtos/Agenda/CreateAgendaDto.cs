using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Controllers.Dtos.Agenda;

public class CreateAgendaDto
{

    [Required(ErrorMessage = "O Nome é obrigatório")]
    [StringLength(50, ErrorMessage = "O tamanho do Nome não pode exceder 50 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O E-mail é obrigatório")]
    [StringLength(30, ErrorMessage = "O tamanho do E-mail não pode exceder 30 caracteres")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório")]
    public string Telefone { get; set; }

    public int EnderecoId { get; set; }

}
