namespace API.Proposta.Application.Dto
{
    public class PropostaBaseDto
    {
       // public string Id { get; set; }
        public List<PropostaDto> Propostas { get; set; }
        public PropostaBaseDto(List<PropostaDto> propostas)
        {
            Propostas = propostas;
        }
    }
}
