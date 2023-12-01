using System.Text;
using System.Net.Http.Headers;
using API.Proposta.Domain.Interfaces;
using API.Proposta.Domain.Entities;
using System.Text.Json;

namespace API.Proposta.Infra.Data.Repositories
{
    public class PropostaRepository: IPropostaRepository
    {
        private readonly HttpClient _http;
        public PropostaRepository()
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5121/")
            };
            _http.DefaultRequestHeaders.Accept.Clear();
            _http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> AdicionarProposta(PropostaBase propostaDto)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(propostaDto);
                var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                contentString.Headers.ContentType = new
                MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await _http.PostAsync("Proposta", contentString);

                if (!response.IsSuccessStatusCode)
                    return false;

                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
