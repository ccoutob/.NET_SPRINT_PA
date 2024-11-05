using Personal.Assist.Cliente.Domain.Entities;
using Personal.Assist.Cliente.Domain.Interfaces;
using RestSharp;

namespace Personal.Assist.Cliente.Service
{
    public class ClienteService : IClienteService
    {
        private readonly RestClient _restClient;

        public ClienteService()
        {
            _restClient = new RestClient("https://viacep.com.br/ws/");
        }

        public async Task<Endereco?> ObterEnderecoPorCepAsync(string cep)
        {
            var request = new RestRequest($"{cep}/json/", Method.Get);
            var response = await _restClient.ExecuteAsync<Endereco>(request);

            if (!response.IsSuccessful || response.Data == null)
                return null;

            return response.Data;
        }
    }
}
