using AgendaApi.Data;
using AgendaApi.Models;

namespace AgendaApi.Repositories;

public class EnderecoRepository
{

    private AgendaContext _context;

    public EnderecoRepository(AgendaContext context)
    {
        _context = context;
    }

    public List<Endereco> ListarEndereco(int skip, int take)
    {
        return _context.Enderecos.Skip(skip).Take(take).ToList();
    }
    
    public Endereco BuscarEndereco(int id)
    {
        return _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
    }

    public void AdicionarEndereco(Endereco endereco)
    {
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
    }

    public void AtualizarEndereco(Endereco endereco)
    {
        _context.Enderecos.Update(endereco);
        _context.SaveChanges();
    }

    public void DeletarEndereco(Endereco endereco)
    {
        _context.Enderecos.Remove(endereco);
        _context.SaveChanges();
    }

}
