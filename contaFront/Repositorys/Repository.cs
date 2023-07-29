using Conta.Models;
using contaFront.Utils;

namespace contaFront.Repositorys
{
    public class Repository
    {
        private readonly HttpClient _client;

        public Repository(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<ContaBancaria>> GetAll()
        {
            var response = await _client.GetAsync("GetAll");
            return await response.ReadContentAs<List<ContaBancaria>>();
        }

        public async Task<ContaBancaria> Get(int? numeroConta)
        {
            var response = await _client.GetAsync($"Get/{numeroConta}");

            return await response.ReadContentAs<ContaBancaria>();
        }

        public async Task<ContaBancaria> Create(ContaBancaria contaBancaria)
        {
            var response = await _client.PostAsJson("Create", contaBancaria);

            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<ContaBancaria>();
            }
            else
            {
                throw new Exception("Erro ao tentar inserir uma conta bancaria");
            }

        }

        public async Task<ContaBancaria> Update(ContaBancaria contaBancaria)
        {
            var response = await _client.PutAsJson("Create", contaBancaria);

            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<ContaBancaria>();
            }
            else
            {
                throw new Exception("Erro ao tentar alterar uma conta bancaria");
            }
        }

        public async void Delete(int numeroConta)
        {
            var response = await _client.DeleteAsync($"Delete/{numeroConta}");

            if (response.IsSuccessStatusCode)
            {
                await response.ReadContentAs<ContaBancaria>();
            }
            else
            {
                throw new Exception("Erro ao tentar excluir uma conta bancaria");
            }
        }
    }
}
