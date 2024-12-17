using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Models;

public class Agenda
{

    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Telefone { get; set; }

    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }

    public Agenda()
    {

    }

    public Agenda(string Nome, string Email, string Telefone)
    {
        this.Nome = Nome;
        this.Email = Email;
        this.Telefone = Telefone;
    }

    public Agenda(string Nome, string Email, string Telefone, int EnderecoId)
    {
        this.Nome = Nome;
        this.Email = Email;
        this.Telefone = Telefone;
        this.EnderecoId = EnderecoId;
    }

}
