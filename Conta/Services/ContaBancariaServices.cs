using Conta.Models;
using Conta.Models.Context;
using Conta.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Conta.Services
{
    public class ContaBancariaServices: IContaBancariaServices
    {
        private readonly DbContaContext _context;

        public ContaBancariaServices(DbContaContext context)
        {
            _context = context;
        }

        public async Task<List<ContaBancaria>> GetAll()
        {
            var x = await _context.ContaBancaria.ToListAsync();
            return x;
        }

        public async Task<ContaBancaria> Get(int? numeroConta)
        {
            var contaBancaria = await _context.ContaBancaria
                .FirstOrDefaultAsync(m => m.NumeroConta == numeroConta);

            return contaBancaria;
        }

        public async Task<ContaBancaria> Create(ContaBancaria contaBancaria)
        {
            _context.ContaBancaria.Add(contaBancaria);
            await _context.SaveChangesAsync();

            return contaBancaria;
        }

        public async Task<ContaBancaria> Update(ContaBancaria contaBancaria)
        {
            _context.Update(contaBancaria);
            await _context.SaveChangesAsync();
            return contaBancaria;
        }

        public async void Delete(int numeroConta)
        {
            var conta = await Get(numeroConta);
            _context.Remove(conta);
            await _context.SaveChangesAsync();
        }
    }
}