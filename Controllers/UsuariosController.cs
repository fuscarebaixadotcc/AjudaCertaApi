using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AjudaCerta.Data;
using AjudaCerta.Models;
using Microsoft.EntityFrameworkCore;
using AjudaCerta.Utils;

namespace AjudaCerta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        private async Task<bool> UsuarioExistente(string email)
        {
            if (await _context.Usuarios.AnyAsync(u => u.email == email))
            {
                return true;
            }
            return false;
        }

        private static bool IsEmail(string strEmail)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Usuario u = await _context.Usuarios
                    .FirstOrDefaultAsync(uBusca => uBusca.idUsuario == id);

                return Ok(u);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Add(Usuario novoUsuario)
        {
            try
            {
                /*if (IsEmail(novoUsuario.email))
                {
                    throw new Exception("Endereço de e-mail inválido.");
                }
                else*/ if (await UsuarioExistente(novoUsuario.email))
                {
                    throw new System.Exception("Este e-mail já está cadastrado.");
                }
                else if (novoUsuario.senha.Length < 8)
                {
                    throw new Exception("A senha requer 8 caracteres ou mais.");
                }
                Criptografia.CriarPasswordHash(novoUsuario.senha, out byte[] hash, out byte[] salt);
                novoUsuario.senha = string.Empty;
                novoUsuario.senhaHash = hash;
                novoUsuario.senhaSalt = salt;
                await _context.Usuarios.AddAsync(novoUsuario);
                await _context.SaveChangesAsync();

                return Ok(novoUsuario.idUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.email == credenciais.email);
                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado.");
                }
                else if (!Criptografia
                    .VerificarPasswordHash(credenciais.senha, usuario.senhaHash, usuario.senhaSalt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else
                {
                    Pessoa pessoa = await _context.Pessoas
                        .FirstOrDefaultAsync(p => p.usuario.idUsuario == usuario.idUsuario);
                    return Ok("Usuário: " + pessoa.nome + " foi autenticado com sucesso.");
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}