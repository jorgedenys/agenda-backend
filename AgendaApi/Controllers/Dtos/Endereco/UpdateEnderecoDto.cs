using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Controllers.Dtos.Endereco;

public class UpdateEnderecoDto
{
    [StringLength(50, ErrorMessage = "O tamanho do Logradouro não pode exceder 50 caracteres")]
    public string Logradouro { get; set; }

    public int Numero { get; set; }
    
}
