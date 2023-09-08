using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AjudaCerta.Models.Enuns;

namespace AjudaCerta.Models
{
    public class Pessoa
    {
        [Key]
        public int idPessoa { get; set; }
        public string nome { get; set; }
        public string documento { get; set; }
        public string telefone { get; set; }
        public string genero { get; set; }
        public DateTime dtNasc { get; set; }
        public TipoPessoaEnum tipo { get; set; }
        public Endereco Endereco{ get; set; }
        public Usuario Usuario{ get; set; }
    }
}