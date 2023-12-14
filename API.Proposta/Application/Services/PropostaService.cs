using API.Proposta.Application.Dto;
using API.Proposta.Application.Interfaces;
using API.Proposta.Domain.Entities;
using API.Proposta.Domain.Interfaces;
using API.Proposta.Infra;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace API.Proposta.Application.Services
{
    public class PropostaService : IProposta
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<PropostaBaseDto> _PropostaDtoCollection;
        private readonly IPropostaRepository _PropostaRepository;

        public PropostaService(IMapper mapper, 
                                IOptions<DatabaseSettings> dabaseSettings
                                , IConfiguration configuration
                                , IPropostaRepository propostaRepository)
        {
            dabaseSettings.Value.ConnectionString = configuration["DatabaseSettings:ConnectionString"];
            dabaseSettings.Value.DatabaseName = configuration["DatabaseSettings:DatabaseName"];
            var mongoClient = new MongoClient(dabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dabaseSettings.Value.DatabaseName);
            _PropostaDtoCollection = mongoDatabase.GetCollection<PropostaBaseDto>("PropostaRover");
            _PropostaRepository = propostaRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(PropostaBaseDto propostaBase)
        {
            await _PropostaDtoCollection.InsertOneAsync(propostaBase);

        }

        public async Task<bool> AdicionarProposta(PropostaBaseDto propostaBase)
        {
            var proposta = _mapper.Map<PropostaBaseDto, PropostaBase>(propostaBase);
            return await _PropostaRepository.AdicionarProposta(proposta);
        }

    }
}
