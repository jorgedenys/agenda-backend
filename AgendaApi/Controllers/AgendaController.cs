using AgendaApi.Controllers.Dtos.Agenda;
using AgendaApi.Models;
using AgendaApi.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AgendaController : ControllerBase
{

    private IMapper _mapper;
    private AgendaService _service;

    public AgendaController(IMapper mapper, AgendaService service)
    {
        _mapper = mapper;
        _service = service;
    }

    /// <summary>Lista os contatos da Agenda ordenados por Nome</summary>
    /// <returns>ActionResultList</returns>
    /// <response code = "200"> Caso a consulta seja realizada com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<ReadAgendaDto>> ListarAgendaOrdenadaPorNome([FromQuery] int skip = 0,
        [FromQuery] int take = 10)
    {
        List<Agenda> agendas = _service.ListarAgendaOrdenadaPorNome(skip, take);

        List<ReadAgendaDto> agendasDto = _mapper.Map<List<ReadAgendaDto>>(agendas);

        return Ok(agendasDto);
    }

    /// <summary>Busca um contato da Agenda</summary>
    /// <param name = "id" >Id do Contato da Agenda que deverá ser buscado</param>
    /// <returns>ActionResult</returns>
    /// <response code = "200"> Caso a consulta seja realizada com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult BuscarAgenda(int id)
    {
        var agenda = _service.BuscarAgenda(id);

        if (agenda == null) return NotFound();

        ReadAgendaDto agendaDto = _mapper.Map<ReadAgendaDto>(agenda);

        return Ok(agendaDto);
    }

    /// <summary>Adiciona um Contato da Agenda no banco de dados</summary>
    /// <param name = "agendaDto" > Objeto com os campos necessários para criação de um Contato da Agenda</param>
    /// <returns>ActionResult</returns>
    /// <response code = "201" > Caso inserção seja realizada com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult AdicionarAgenda([FromBody] CreateAgendaDto agendaDto)
    {
        Agenda agenda = _mapper.Map<Agenda>(agendaDto);

        _service.AdicionarAgenda(agenda);
        
        return CreatedAtAction(nameof(BuscarAgenda), new { id = agenda.Id }, agenda);
    }

    /// <summary>Atualiza um Contato da Agenda no banco de dados</summary>
    /// <param name = "agendaDto" > Objeto com os campos necessários para atualização de um Contato da Agenda</param>
    /// <returns>ActionResult</returns>
    /// <response code = "204" > Caso a atualização seja realizada com sucesso</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult AtualizarAgenda(int id, [FromBody] UpdateAgendaDto agendaDto)
    {
        var agenda = _service.BuscarAgenda(id);

        if (agenda == null) return NotFound();

        _mapper.Map(agendaDto, agenda);
        _service.AtualizarAgenda(agenda);
        
        return NoContent();
    }

    /// <summary>Exclui um Contato da Agenda do banco de dados</summary>
    /// <param name = "id" >Id do Contato da Agenda que deverá ser excluído</param>
    /// <returns>ActionResult</returns>
    /// <response code = "204" > Caso a exclusão seja realizada com sucesso</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult DeletarAgenda(int id)
    {
        var agenda = _service.BuscarAgenda(id);

        if (agenda == null) return NotFound();

        _service.DeletarAgenda(agenda);
        
        return NoContent();
    }

}
