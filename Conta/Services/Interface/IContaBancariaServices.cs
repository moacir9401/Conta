using Conta.Models;

namespace Conta.Services.Interface
{
    public interface IContaBancariaServices
    {
        public Task<List<ContaBancaria>> GetAll();

        public Task<ContaBancaria> Get(int? numeroConta);

        public Task<ContaBancaria> Create(ContaBancaria contaBancaria);

        public Task<ContaBancaria> Update(ContaBancaria contaBancaria);

        public void Delete(int numeroConta);
    }
}
