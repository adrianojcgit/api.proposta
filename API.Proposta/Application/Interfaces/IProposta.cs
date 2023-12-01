using API.Proposta.Application.Dto;
using API.Proposta.Domain.Entities;

namespace API.Proposta.Application.Interfaces;

public interface IProposta
{
    Task CreateAsync(PropostaBaseDto cliente);
    Task<bool> AdicionarProposta(PropostaBaseDto proposta);
}
