using AgendaApi.Models;
using AgendaApi.Repositories;

namespace AgendaApi.Services;

public class EnderecoService
{
    
    private EnderecoRepository _enderecoRepository;

    public EnderecoService(EnderecoRepository enderecoRepository)
    {
        _enderecoRepository = enderecoRepository;
    }

    public List<Endereco> ListarEndereco(int skip, int take)
    {
        return _enderecoRepository.ListarEndereco(skip, take);
    }

    public Endereco BuscarEndereco(int id)
    {
        return _enderecoRepository.BuscarEndereco(id);
    }

    public void AdicionarEndereco(Endereco endereco)
    {
        _enderecoRepository.AdicionarEndereco(endereco);
    }

    public void AtualizarEndereco(Endereco endereco)
    {
        _enderecoRepository.AtualizarEndereco(endereco);
    }

    public void DeletarEndereco(Endereco endereco)
    {
        _enderecoRepository.DeletarEndereco(endereco);
    }
    
}
