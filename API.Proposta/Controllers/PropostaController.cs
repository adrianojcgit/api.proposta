using API.Proposta.Application.Interfaces;
using API.Proposta.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace API.Proposta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropostaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProposta _proposta;
        public PropostaController(IMapper mapper, IProposta proposta)
        {
            _mapper = mapper;
            _proposta = proposta;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(Application.Dto.PropostaBaseDto propostaDto)
        {
            try
            {
                //var proposta = _mapper.Map<Application.Dto.PropostaBaseDto, PropostaBase>(propostaDto);
                await _proposta.CreateAsync(propostaDto);
                //var propostaRetDto = _mapper.Map<PropostaBase, Application.Dto.PropostaBaseDto>(proposta);
                var ret = await _proposta.AdicionarProposta(propostaDto);
                return CreatedAtAction(nameof(Post), propostaDto);
                //return CreatedAtAction(nameof(Post), new { id = _proposta.Id }, proposta);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

    }
}

