using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AjudaCerta.Models.Enuns;

namespace AjudaCerta.Models
{
    public class Agenda
    {
        [Key]
        public int idAgenda { get; set; }
        public DateTime data { get; set; }
        public TipoDoacaoEnum tipo { get; set; }
        public StatusDoacaoEnum statusAgenda { get; set; }
        public Pessoa Pessoa { get; set; }
        public Endereco Endereco { get; set; }
        public Doacao Doacao { get; set; }
        public int idDoacao { get; set; }

    }
}