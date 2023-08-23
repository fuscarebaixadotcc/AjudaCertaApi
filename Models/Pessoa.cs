using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public TipoPessoaEnum tipo { get; set; }
        public Endereco endereco{ get; set; }
        public Usuario usuario{ get; set; }
    }
}