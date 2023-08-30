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
               // else if(!Validacao.VerificaMaioridade(novaPessoa.dtNasc))
               //     throw new Exception("O usuário precisa ser maior de idade.");
                
                novaPessoa.Usuario = await _context.Usuario
                    .FirstOrDefaultAsync(uBusca => uBusca.idUsuario == novaPessoa.idUsuario);


                //TESTAR COM O REGISTRO DO ATRIBUTO USUARIO E ENDERECO INVES DE SÓ O ID, ATUALIZAR PRA INT NO BANCO AS OUTRAS ENUMS DE OUTRAS CLASSES

             //   novaPessoa.Usuario = u;

                novaPessoa.Endereco = await _context.Endereco
                    .FirstOrDefaultAsync(eBusca => eBusca.idEndereco == novaPessoa.idEndereco);
                
           //     novaPessoa.Endereco = e;

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