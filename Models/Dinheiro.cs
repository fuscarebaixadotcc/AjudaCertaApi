using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AjudaCerta.Models
{
    public class Dinheiro
    {
        [Key]
        public int idDinheiro { get; set; }
        public double valor { get; set; }
    }
}