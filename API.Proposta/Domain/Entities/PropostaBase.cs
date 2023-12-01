using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace API.Proposta.Domain.Entities
{
    public class PropostaBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public List<Proposta> Propostas { get; set; }
        public PropostaBase(List<Proposta> propostas)
        {
            Propostas = propostas;
        }
    }
}
