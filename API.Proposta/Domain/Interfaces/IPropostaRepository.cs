using API.Proposta.Domain.Entities;

namespace API.Proposta.Domain.Interfaces
{
    public interface IPropostaRepository
    {
        Task<bool> AdicionarProposta(PropostaBase proposta);
    }
}
