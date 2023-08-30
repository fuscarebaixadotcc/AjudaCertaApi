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
    public class EnderecosController : ControllerBase
    {
        private readonly DataContext _context;

        public EnderecosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Endereco e = await _context.Endereco
                    .FirstOrDefaultAsync(eBusca => eBusca.idEndereco == id);
                
                return Ok(e);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Post(Endereco novoEndereco)
        {
            try
            {
                await _context.Endereco.AddAsync(novoEndereco);
                await _context.SaveChangesAsync();

                return Ok(novoEndereco.idEndereco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}