using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Proposta.Domain.Entities
{
    public class Proposta
    {
        public Proposta()
        {
            Enderecos = new List<Endereco>();
            Faturamentos = new List<Faturamento>();
            ContasBancos = new List<ContaBanco>();
        }
        
        public string NumeroProposta { get; set; }
        public int IdHtml { get; set; }
        public string? CodGuid { get; set; }
        public string? CodInterno { get; set; }
        public string? ClienteOrigem { get; set; }
        public string? CNPJ { get; set; }
        public string? NomeEmpresarial { get; set; }
        public string? NomeFantasia { get; set; }
        public DateTime DataImportacao { get; set; } = DateTime.UtcNow.AddHours(-3);
        public string? PorteEmpresa { get; set; }
        public decimal? FatBrutoAnual { get; set; }
        public bool Ativo { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public List<Faturamento> Faturamentos { get; set; }
        public List<ContaBanco> ContasBancos { get; set; }
    }
}
