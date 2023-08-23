using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AjudaCerta.Models
{
    public class Endereco
    {
        [Key]
        public int idEndereco { get; set; }
        public string rua { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
    }
}