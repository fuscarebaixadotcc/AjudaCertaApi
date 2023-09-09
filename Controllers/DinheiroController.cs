using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AjudaCerta.Data;
using AjudaCerta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AjudaCertaApi.Controllers
{
    public class DinheiroController : ControllerBase
    {
        private readonly DataContext _context;

        public DinheiroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetValor(int id)
        {
            try
            {
                Dinheiro d = await _context.Dinheiro
                            .FirstOrDefaultAsync(dBusca => dBusca.idDinheiro == id);

                if (d == null)
                    throw new Exception("Não existe nenhuma transação com o id informado.");

                return Ok(d);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarValor(Dinheiro novoValor)
        {
            try
            {
                if (novoValor.valor == 0)
                    throw new Exception("Não é possível realizar uma doação financeira sem algum valor.");

                await _context.Dinheiro.AddAsync(novoValor);
                await _context.SaveChangesAsync();

                return Ok(novoValor.idDinheiro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}