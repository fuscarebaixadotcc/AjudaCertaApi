using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AjudaCerta.Data;
using AjudaCerta.Models;
using AjudaCertaApi.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AjudaCertaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly DataContext _context;

        public PessoasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Pessoa p = await _context.Pessoa
                    .FirstOrDefaultAsync(pBusca => pBusca.idPessoa == id);
                p.Usuario = await _context.Usuario
                            .FirstOrDefaultAsync(uBusca => uBusca.idUsuario == p.idUsuario);
                p.Endereco = await _context.Endereco
                            .FirstOrDefaultAsync(eBusca => eBusca.idEndereco == p.idEndereco);
                    
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("RegistrarPF")]
        public async Task<IActionResult> Add(Pessoa novaPessoa)
        {
            try
            {
                if(!Validacao.ValidaCPF(novaPessoa.documento))
                    throw new Exception("CPF inválido.");
                else if(!Validacao.VerificaMaioridade(novaPessoa.dtNasc))
                    throw new Exception("O usuário precisa ser maior de idade.");

                await _context.Pessoa.AddAsync(novaPessoa);
                await _context.SaveChangesAsync();

                return Ok(novaPessoa.idPessoa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }     
    }
}