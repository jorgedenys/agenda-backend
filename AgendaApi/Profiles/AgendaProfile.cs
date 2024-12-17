using AgendaApi.Controllers.Dtos.Agenda;
using AgendaApi.Models;
using AutoMapper;

namespace AgendaApi.Profiles;

public class AgendaProfile : Profile
{
    public AgendaProfile() 
    {
        CreateMap<CreateAgendaDto, Agenda>();

        CreateMap<Agenda, ReadAgendaDto>();

        CreateMap<UpdateAgendaDto, Agenda>();
    }

}
