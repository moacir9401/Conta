using Conta.Models;
using Conta.Services;
using Conta.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Conta.Controllers
{
    public class ContaBancariasController : Controller
    {
        private readonly IContaBancariaServices _ContaBancariaServices;

        public ContaBancariasController(IContaBancariaServices ContaBancariaServices)
        {
            _ContaBancariaServices = ContaBancariaServices;
        }

        // GET: ContaBancarias
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ContaBancaria>>> GetAll()
        {
            return Ok(await _ContaBancariaServices.GetAll());
        }

        // GET: ContaBancarias/Details/5
        [HttpGet("Get/{numeroConta:int}")]
        public async Task<ActionResult<ContaBancaria>> Get(int? numeroConta)
        {
            if (numeroConta == null)
            {
                return NotFound();
            }

            var contaBancaria = await _ContaBancariaServices.Get(numeroConta);

            if (contaBancaria == null)
            {
                return NotFound();
            }

            return Ok(contaBancaria);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ContaBancaria>> Create(ContaBancaria contaBancaria)
        {
            try
            {
                await _ContaBancariaServices.Create(contaBancaria);

                return Ok(contaBancaria);
            }
            catch (ArgumentException)
            {
                return UnprocessableEntity("Erro ao inserir uma conta bancaria");
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ContaBancaria>> Update(ContaBancaria contaBancaria)
        {
            try
            {
                await _ContaBancariaServices.Update(contaBancaria);

                return Ok(contaBancaria);
            }
            catch (ArgumentException)
            {
                return UnprocessableEntity("Erro ao Alterar uma conta bancaria");
            }
        }

        // POST: ContaBancarias/Delete/5
        [HttpDelete("Delete/{numeroConta:int}")]
        public async Task<ActionResult> Delete(int numeroConta)
        {
            try
            {
                _ContaBancariaServices.Delete(numeroConta);

                return Ok();
            }
            catch (Exception)
            {
                return UnprocessableEntity("Erro ao Excluir uma conta bancaria");
            }
        }
    }
}