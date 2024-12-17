using AgendaApi.Controllers.Dtos.Endereco;
using AgendaApi.Models;
using AgendaApi.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{

    private IMapper _mapper;
    private EnderecoService _service;

    public EnderecoController(IMapper mapper, EnderecoService service)
    {
        _mapper = mapper;
        _service = service;
    }

    /// <summary>Lista os endereços</summary>
    /// <returns>ActionResultList</returns>
    /// <response code = "200"> Caso a consulta seja realizada com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<ReadEnderecoDto>> ListarEndereco([FromQuery] int skip = 0,
        [FromQuery] int take = 10)
    {
        List<Endereco> enderecos = _service.ListarEndereco(skip, take);

        List<ReadEnderecoDto> enderecosDto = _mapper.Map<List<ReadEnderecoDto>>(enderecos);

        return Ok(enderecosDto);
    }

    /// <summary>Busca um endereço</summary>
    /// <param name = "id" >Id do endereço que deverá ser buscado</param>
    /// <returns>ActionResult</returns>
    /// <response code = "200"> Caso a consulta seja realizada com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult BuscarEndereco(int id)
    {
        var endereco = _service.BuscarEndereco(id);

        if (endereco == null) return NotFound();

        ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

        return Ok(enderecoDto);
    }

    /// <summary>Adiciona um Endereço no banco de dados</summary>
    /// <param name = "agendaDto" > Objeto com os campos necessários para criação de um Endereço</param>
    /// <returns>ActionResult</returns>
    /// <response code = "201" > Caso inserção seja realizada com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

        _service.AdicionarEndereco(endereco);
        
        return CreatedAtAction(nameof(BuscarEndereco), new { id = endereco.Id }, endereco);
    }

    /// <summary>Atualiza um endereço no banco de dados</summary>
    /// <param name = "agendaDto" > Objeto com os campos necessários para atualização de um Endereço</param>
    /// <returns>ActionResult</returns>
    /// <response code = "204" > Caso a atualização seja realizada com sucesso</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
    {
        var endereco = _service.BuscarEndereco(id);

        if (endereco == null) return NotFound();

        _mapper.Map(enderecoDto, endereco);
        _service.AtualizarEndereco(endereco);
        
        return NoContent();
    }

    /// <summary>Exclui um Endereço do banco de dados</summary>
    /// <param name = "id" >Id do Endereço que deverá ser excluído</param>
    /// <returns>ActionResult</returns>
    /// <response code = "204" > Caso a exclusão seja realizada com sucesso</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult DeletarEndereco(int id)
    {
        var endereco = _service.BuscarEndereco(id);

        if (endereco == null) return NotFound();

        _service.DeletarEndereco(endereco);
        
        return NoContent();
    }

}
