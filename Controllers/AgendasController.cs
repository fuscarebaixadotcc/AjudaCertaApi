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
    public class AgendasController : ControllerBase
    {
        private readonly DataContext _context;

        public AgendasController(DataContext context)
        {
            _context = context;
        }    

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {   
            try
            {
                Agenda a = await _context.Agenda
                            .FirstOrDefaultAsync(aBusca => aBusca.idAgenda == id);
                a.Endereco = await _context.Endereco
                            .FirstOrDefaultAsync(eBusca => eBusca.idEndereco == a.idEndereco);
                a.Pessoa = await _context.Pessoa
                            .FirstOrDefaultAsync(pBusca => pBusca.idPessoa == a.idPessoa);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarAgenda(Agenda novaAgenda)
        {
            try
            {
                await _context.Agenda.AddAsync(novaAgenda);
                await _context.SaveChangesAsync();

                return Ok(novaAgenda.idAgenda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}