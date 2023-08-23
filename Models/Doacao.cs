using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AjudaCerta.Models.Enuns;

namespace AjudaCerta.Models
{
    public class Doacao
    {
        [Key]
        public int idDoacao { get; set; }
        public DateTime data { get; set; }
        public Pessoa pessoa{ get; set; }
        public StatusDoacaoEnum status { get; set; }
        public TipoDoacaoEnum tipoDoacao { get; set; }
        public StatusDoacaoEnum idDoacaoOrigem { get; set; }
        public Agenda agenda { get; set; }
    }
}