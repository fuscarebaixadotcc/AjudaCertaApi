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
    [ApiController]
    [Route("[controller]")]
    public class DoacoesController : ControllerBase
    {
        private readonly DataContext _context;
        public DoacoesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Doacao d = await _context.Doacao
                            .FirstOrDefaultAsync(dBusca => dBusca.idDoacao == id);
                
                d.Pessoa = await _context.Pessoa
                            .FirstOrDefaultAsync(pBusca => pBusca.idPessoa == d.idPessoa);

                d.Agenda = await _context.Agenda
                            .FirstOrDefaultAsync(aBusca => aBusca.idAgenda == d.idAgenda);
                
                return Ok(d);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarDoacao(Doacao novaDoacao)
        {
            try
            {
                await _context.Doacao.AddAsync(novaDoacao);
                await _context.SaveChangesAsync();

                return Ok(novaDoacao.idDoacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}