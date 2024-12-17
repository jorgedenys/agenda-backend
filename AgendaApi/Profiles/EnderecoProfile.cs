using AgendaApi.Controllers.Dtos.Endereco;
using AgendaApi.Models;
using AutoMapper;

namespace AgendaApi.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile() 
    {
        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<Endereco, ReadEnderecoDto>();
        CreateMap<UpdateEnderecoDto, Endereco>();
    }

}
